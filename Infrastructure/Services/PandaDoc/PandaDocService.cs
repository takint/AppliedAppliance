
using Application.Common.Extensions;
using Application.Common.Interfaces;
using Domain.Constants;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.PandaDoc
{
    public partial class PandaDocService : IPandaDocService
    {
        private readonly HttpClient pandaDocClient;
        private readonly PandaDocServiceConfig config;
        private readonly ILogger<PandaDocService> logger;
        private readonly IApplicationDbContext context;
        private readonly string baseUrl;
        private readonly int shareLifetimeInSeconds;
        /// <summary>
        /// Create a PandaDocService object.
        /// </summary>
        /// <param name="client">Required headers should be pre-configured, such as Authorization.</param>
        /// <param name="config">A valid <see cref="PandaDocServiceConfig"/> should have a valid ApiKey as well as BaseUrl for API.</param>
        public PandaDocService(HttpClient client, IOptions<PandaDocServiceConfig> config, ILogger<PandaDocService> logger, IApplicationDbContext context)
        {

            pandaDocClient = client;
            this.config = config.Value;
            this.logger = logger;
            this.context = context;

            baseUrl = config.Value.BaseUrl;
            shareLifetimeInSeconds = config.Value.ShareLifetimeInSeconds;
        }

        private Task<PandaDocDocument> Create()
        {
            throw new NotImplementedException();
        }

        private async Task<string> GetTemplateId(int applicationId, PandaDocTemplateType type)
        {
            switch (type)
            {
                case PandaDocTemplateType.EA:
                    return await GetEATemplateId(applicationId);
                case PandaDocTemplateType.PD:
                    return await GetPDTemplateId(applicationId);
                default:
                    return GetSchoolTemplateId(applicationId, type);
            }
        }

        private async Task<string> GetEATemplateId(int applicationId)
        {
            return await context.StudentApplications
                                .AsNoTracking()
                                .Include(x => x.Program)
                                .Include(x => x.Program.EATemplate)
                                .Where(x => x.Id == applicationId)
                                .Select(x => x.Program.EATemplate.TemplateId)
                                .SingleOrDefaultAsync();
        }

        private async Task<string> GetPDTemplateId(int applicationId)
        {
            return await context.StudentApplications
                                .AsNoTracking()
                                .Include(x => x.Program)
                                .Include(x => x.Program.AdditionalDocument)
                                .Where(x => x.Id == applicationId)
                                .Select(x => x.Program.AdditionalDocument.TemplateId)
                                .SingleOrDefaultAsync();
        }

        private string GetSchoolTemplateId(int applicationId, PandaDocTemplateType type)
        {
            return string.Empty;
        }

        private async Task<TemplateDetails> GetTemplateDetails(string templateId)
        {
            var response = await pandaDocClient.GetAsync(config.GetTemplateDetailsUrl(templateId));
            var responseData = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Failed to get template: {0}", templateId);
                return null;
            }

            return responseData.ToType<TemplateDetails>();
        }

        public async Task<byte[]> Download(string documentId)
        {
            if (string.IsNullOrEmpty(documentId))
            {
                return null;
            }

            var response = await pandaDocClient.GetAsync(config.GetDownloadingUrl(documentId));
            if (!response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                logger.LogError("Failed to download pandadoc: {0} with errors: {1}", documentId, responseData);
                return null;
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetStatus(string documentId)
        {
            var response = await pandaDocClient.GetAsync(config.GetDocumentStatusUrl(documentId));
            var responseData = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Failed to get pandadoc status with id: {0}, errors: {1}", documentId, responseData);
                return null;
            }

            var documentStatusResult = responseData.ToType<DocumentStatus>();
            return documentStatusResult.Status;
        }

        public Task<bool> SaveToDisk(PandaDocDocument document)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Send(PandaDocDocument document, bool sendEmail = true)
        {
            string dateFormat = string.Format("ddd, dd MMM yyy HH':'mm':'ss UTC");
            var docSendLink = config.GetSendingUrl(document.Id);

            var documentSendingOptions = new DocumentSendingOptions
            {
                Subject = document.Name,
                Message = string.Format("Hello! This document was sent from AppliedAppliance. Please help to fill in your registration information. This document will be expired at {0}",
                    DateTime.UtcNow.AddSeconds(PandaDocResources.DEFAULT_DOC_EXPIRED_SECONDS).ToString(dateFormat)),
                Silent = !sendEmail // send email if 'Slient' set to false
            };

            var payload = documentSendingOptions.ToJsonStringContent();

            var response = await pandaDocClient.PostAsync(docSendLink, payload);

            var responseData = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Failed to send pandadoc: {0}", responseData);
                return false;
            }

            var documentSendingResult = responseData.ToType<DocumentSendingResult>();

            DateTime.TryParse(documentSendingResult.ExpirationDate, out var docExpiresAt);

            document.Send(docExpiresAt);
            return true;
        }

        public async Task<PandaDocShareInfo> ShareWith(string documentId, string recipientEmail, int lifetime)
        {
            var docShareLink = config.GetSharingUrl(documentId);
            var documentShareOptions = new DocumentShareOptions
            {
                Recipient = recipientEmail,
                Lifetime = lifetime
            };

            var requestPayload = new StringContent(documentShareOptions.Serialize(), Encoding.UTF8, "application/json");
            var response = await pandaDocClient.PostAsync(docShareLink, requestPayload);

            var responseData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                logger.LogError("Failed to share pandadoc: {0}", responseData);
                return null;
            }

            var documentShareResult = responseData.ToType<DocumentShareResult>();
            DateTime.TryParse(documentShareResult.ExpiresAt, out DateTime shareDocumentExpiresAt);
            return new PandaDocShareInfo(recipientEmail, documentShareResult.Id, shareDocumentExpiresAt);
        }

        public async Task<bool> ShareWithAllRecipients(PandaDocDocument document, Dictionary<string, string> recipients)
        {
            int failcount = 0;
            foreach (var recipient in recipients)
            {
                var shareInfo = await ShareWith(document.Id, recipient.Value, shareLifetimeInSeconds);

                if (shareInfo == null)
                {
                    // currently continue trying to share with remaining recipients even if one of them failed.
                    failcount++;
                    continue;
                }

                // The possible recipients should be 'Student' or 'ADOA'
                if (recipient.Key == PandaDocRoles.STUDENT)
                {
                    document.StudentShareInfo = shareInfo;
                }

                if (recipient.Key == PandaDocRoles.ADOA)
                {
                    document.ADOAShareInfo = shareInfo;
                }
                document.Share();
            }

            return failcount == recipients.Count;
        }

        public async Task<PandaDocDocument> IssuePandaDocDocument(int applicationId, PandaDocTemplateType type)
        {
            var res = await GetTemplateDetails("dndArNHUD3vG2bLhkTVRWN");
            return null;
        }
    }
}
