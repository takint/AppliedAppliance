using Domain.Enums;
using Domain.ValueObjects;
using System;

namespace Domain.Entities
{
    /// <summary>
    /// Class <c>PandaDocDocument</c> represent a document created from a template via <c>PandaDoc</c>. The document can be shared with different roles and viewed/modified online.
    /// </summary>
    public partial class PandaDocDocument : BaseEntity<string>
    {
        public PandaDocDocument(string id, string name)
        {
            this.Id = id;
            this.Name = name;
            Process |= PandaDocProcess.Uploaded;
        }

        // parameterless constructor for entity framework
        protected PandaDocDocument() { }

        /// <summary>
        /// A convinient name given to the document while creation
        /// </summary>
        public string Name { get; protected set; }
        /// <summary>
        /// The current PandaDoc Status
        /// </summary>
        public string Status { get; protected set; }
        /// <summary>
        /// Actions have been taken on this document
        /// </summary>
        public PandaDocProcess Process { get; protected set; } = PandaDocProcess.Init;
        /// <summary>
        /// After this document is shared with a student with the student's email, the student will be able to view/modify/download the document depending on settings of the document.
        /// </summary>
        public PandaDocShareInfo StudentShareInfo { get; set; }
        public PandaDocShareInfo ADOAShareInfo { get; set; }
       
        /// The document itself will be expired after a certain amount of time specified after being sent.
        /// <remark>This field is not used now.</remark>
        /// </summary>
        public DateTime ExpiresAt { get; protected set; }
        /// <summary>
        /// When the document is download/saved to the disk, a file id should be assigned referencing the stored pdf file
        /// </summary>
        public long? FileId { get; protected set; }
        public File File { get; protected set; }
        public int ApplicationDocumentId { get; protected set; }
        public ApplicationDocument ApplicationDocument { get; protected set; }
    }
}
