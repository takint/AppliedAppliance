using Domain.Common;
using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PandaDocShareInfo : ValueObject
    {
        public PandaDocShareInfo(string recipient, string sessionId, DateTime expiresAt)
        {
            Recipient = recipient;
            SessionId = sessionId;
            // if passed in expires time is not valid, making the share session to expire 1 year from now.
            ExpiresAt = expiresAt == DateTime.MinValue ? DateTime.UtcNow.AddYears(1) : expiresAt;
        }

        protected PandaDocShareInfo() { }

        /// <summary>
        /// The role of the person to share the document with
        /// </summary>
        public string Recipient { get; private set; }
        /// <summary>
        /// After a document is shared, a session id will be returned from the API.
        /// </summary>
        public string SessionId { get; private set; }
        public DateTime ExpiresAt { get; private set; }

        /// <summary>
        /// A share link comprise the base link and <see cref="SessionId"/>
        /// </summary>
        public string Link
        {
            get
            {
                if (string.IsNullOrEmpty(SessionId)) return null;
                return string.Format(PandaDocResources.VIEW_SHARE_DOC_LINK, SessionId);
            }
            set { }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Recipient;
            yield return SessionId;
            yield return ExpiresAt;
        }
    }
}
