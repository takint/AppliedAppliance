using System;

namespace Domain.Enums
{
    /// <summary>
    /// The life cyle of a PandaDoc document
    /// </summary>
    [Flags]
    public enum PandaDocProcess
    {
        /// <summary>
        /// Initial state, nothing has been done
        /// </summary>
        Init = 0b_0000_0001,
        /// <summary>
        /// A creation request has been sent to PandaDoc
        /// </summary>
        Uploaded = 0b_0000_0010,
        /// <summary>
        /// the Pandadoc document has been created successfully and sealed to prevent further modification
        /// </summary>
        Sent = 0b_0000_0100,
        /// <summary>
        /// the PandaDoc document has been shared with corresponding recipients
        /// </summary>
        Shared = 0b_0000_1000,
        /// <summary>
        /// the Pandadoc document has been successfully saved to disk. A valid file id should be set when this flag is on.
        /// </summary>
        Saved = 0b_0001_0000
    }
}
