using System;

namespace Domain.Enums
{
    /// <summary>
    /// The process of an application comprises several steps, and any of them could fail which should fail the corresponding phase, such as submission, enrollment.
    /// This enum is intended to keep track of the process to avoid repeating the completed steps and recover from where it failded last time.
    /// </summary>
    [Flags]
    public enum ApplicationProcesses
    {
        /// <summary>
        /// This indicates a error happened
        /// </summary>
        None = 0,
        /// <summary>
        /// User clicked submission button and tried to submit
        /// </summary>
        Started = 0x_0000_0001,
        /// <summary>
        /// Files has been uploaded to lead center successfully
        /// </summary>
        UploadedToLeadCenter = 0x_0000_0010,
        /// <summary>
        /// The <see cref="ApplicationEvents.StatusChangedToApplicationSubmitted"/> record has been created, 
        /// and the record will be holding the references to genereated PandaDoc documents as well as uploaded files.
        /// </summary>
        SubmittedRecordCreated = 0x_0000_0100,
        /// <summary>
        /// Application submitted
        /// </summary>
        Submitted = 0x_0000_1000
    }
}
