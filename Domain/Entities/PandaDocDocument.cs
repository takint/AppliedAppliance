using Domain.Enums;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// Class <c>PandaDocDocument</c> represent a document created from a template via <c>PandaDoc</c>. The document can be shared with different roles and viewed/modified online.
    /// </summary>
    public class PandaDocDocument : BaseEntity<string>
    {
        /// <summary>
        /// A convinient name given to the document while creation
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The current PandaDoc Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Actions have been taken on this document
        /// </summary>
        public PandaDocProcess Process { get; set; } = PandaDocProcess.Init;
        /// <summary>
        /// After this document is shared with a student with the student's email, the student will be able to view/modify/download the document depending on settings of the document.
        /// </summary>
        public string StudentShareLink { get; set; }
        /// <summary>
        /// A share link will be expired after a certain amout of time specified while sharing.
        /// </summary>
        public DateTime StudentShareLinkExpiresAt { get; set; }
        /// <summary>
        /// After this document is shared with a ADOA with the corresponding email, the ADOA will be able to view/modify/download the document depending on settings of the document.
        /// </summary>
        public string ADOAShareLink { get; set; }
        /// <summary>
        /// A share link will be expired after a certain amout of time specified while sharing.
        /// </summary>
        public DateTime ADOAShareLinkExpiresAt { get; set; }
        /// <summary>
        /// The document itself will be expired after a certain amount of time specified after being sent.
        /// <remark>This field is not used now.</remark>
        /// </summary>
        public DateTime ExpiresAt { get; set; }
        /// <summary>
        /// When the document is download/saved to the disk, a file id should be assigned referencing the stored pdf file
        /// </summary>
        public long? FileId { get; set; }
        public File File { get; set; }
    }
}
