using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.PandaDoc
{
    public static class PandaDocServiceConfigExtension
    {
        /// <summary>
        /// Parameterlized url endpoint. 
        /// The first parameter {0} is the BaseUrl, which is provided by the configuration. 
        /// Some endpoints require a second parameter, such as document id and template id.
        /// </summary>
        private static class PandaDocEndpoints
        {
            public const string Creation = "{0}/documents";
            public const string Sending = "{0}/documents/{1}/send";
            public const string Sharing = "{0}/documents/{1}/session";
            public const string Downloading = "{0}/documents/{1}/download";
            public const string DocumentStatus = "{0}/documents/{1}";
            public const string TemplateDetails = "{0}/templates/{1}/details";
        }

        public static string GetCreationUrl(this PandaDocServiceConfig config)
        {
            return string.Format(PandaDocEndpoints.Creation, config.BaseUrl);
        }

        public static string GetSendingUrl(this PandaDocServiceConfig config, string documentId)
        {
            return string.Format(PandaDocEndpoints.Sending, config.BaseUrl, documentId);
        }

        public static string GetSharingUrl(this PandaDocServiceConfig config, string documentId)
        {
            return string.Format(PandaDocEndpoints.Sharing, config.BaseUrl, documentId);
        }

        public static string GetDownloadingUrl(this PandaDocServiceConfig config, string documentId)
        {
            return string.Format(PandaDocEndpoints.Downloading, config.BaseUrl, documentId);
        }

        public static string GetDocumentStatusUrl(this PandaDocServiceConfig config, string documentId)
        {
            return string.Format(PandaDocEndpoints.DocumentStatus, config.BaseUrl, documentId);
        }

        public static string GetTemplateDetailsUrl(this PandaDocServiceConfig config, string templateId)
        {
            return string.Format(PandaDocEndpoints.TemplateDetails, config.BaseUrl, templateId);
        }
    }
}
