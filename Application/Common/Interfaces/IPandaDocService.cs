using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IPandaDocService
    {
        /// <summary>
        /// Issue a complete document, which is created, sent, shared and saved to disk according the the template type (CLOA, PP, LOA are required to be saved once created).
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<PandaDocDocument> IssuePandaDocDocument(int applicationId, PandaDocTemplateType type);
        //Task<PandaDocDocument> Create();

        /// <summary>
        /// Sending a document effectively set the <see cref="PandaDocDocument"/> status to <c>document.sent</c> and optionally sending an email to all recipients.
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        Task<bool> Send(PandaDocDocument document, bool sendEmail = true);

        Task<bool> ShareWithAllRecipients(PandaDocDocument document, Dictionary<string, string> recipients);

        /// <summary>
        /// Share a PandaDoc document with an existing recipient.
        /// </summary>
        /// <param name="documentId">The document id return from PandaDoc API after it was created.</param>
        /// <param name="recipientEmail">Email of the recipient. The email should be included in the recipient list while creating the document.</param>
        /// <param name="lifetime">The duration in seconds that the share session will be valid.</param>
        /// <returns></returns>
        Task<PandaDocShareInfo> ShareWith(string documentId, string recipientEmail, int lifetime);

        Task<byte[]> Download(string documentId);

        Task<bool> SaveToDisk(PandaDocDocument document);

        Task<string> GetStatus(string documentId);
    }
}
