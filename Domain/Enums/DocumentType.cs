using System.ComponentModel;

namespace Domain.Enums
{
    
    public enum DocumentGroup
    {
        [Description("Application Document")]
        ApplicationDoc = 0,

        [Description("Student Document")]
        StudentDoc = 1,
        /**
         * school related documents, and should be managed by school users
         * eg. document templates, images
         */
        [Description("School Document")]
        SchoolDoc = 2,
        /**
         * agent related documents, such as company log, business certificates
         */
        [Description("Agent Document")]
        AgentDoc = 3,

        [Description("Others Document")]
        Other = int.MaxValue
    }

    public class DocumentType
    {
        public static DocumentGroup GetGroup(int documentId)
        {
            //DocumentDto document;
            //if (Documents.TryGetValue(documentId, out document))
            //{
            //    switch (document.DocumentGroup)
            //    {
            //        case "ApplicationDoc":
            //            return DocumentGroup.ApplicationDoc;
            //        case "StudentDoc":
            //            return DocumentGroup.StudentDoc;
            //        case "SchoolDoc":
            //            return DocumentGroup.SchoolDoc;
            //    }
            //}
            return DocumentGroup.Other;
        }
    }

}
