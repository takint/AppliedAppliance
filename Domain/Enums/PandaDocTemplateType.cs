using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    /// <summary>
    /// Types of PandaDoc Document used by CDI College
    /// </summary>
    public enum PandaDocTemplateType
    {
        /// <summary>
        /// Conditional Letter of Acceptance
        /// </summary>
        CLOA = 1,

        /// <summary>
        /// Letter of Acceptance
        /// </summary>
        LOA,

        /// <summary>
        /// Proof of Payment
        /// </summary>
        PP,

        /// <summary>
        /// Enrollment Agreement
        /// </summary>
        EA,

        /// <summary>
        /// Solemn Declaration, which is an alternative to Birth Certificate
        /// </summary>
        SD,

        /// <summary>
        /// Additional Documents for a program
        /// </summary>
        PD
    }
}
