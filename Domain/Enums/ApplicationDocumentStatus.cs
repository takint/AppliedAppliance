using System;
using System.ComponentModel;

namespace Domain.Enums
{
    /// <summary>
    /// The lifecycle of application document
    /// </summary>
    [Flags]
    public enum ApplicationDocumentStatus
    {
        [Description("Rejected")]
        Rejected = -1,

        [Description("Missing")]
        Missing = 0,

        [Description("Reviewing")]
        Reviewing = 1,

        [Description("Verified")]
        Verified = 2,

        [Description("Approved")]
        Complete = 3
    }
}
