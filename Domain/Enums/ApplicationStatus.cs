using System;
using System.ComponentModel;

namespace Domain.Enums
{
    [Flags]
    public enum ApplicationStatus
    {
        [Description("Incomplete")]
        Incomplete = 0,

        [Description("Application Submitted")]
        ApplicationSubmitted = 1,

        [Description("Transaction Expired")]
        TransactionExpired = 2,

        [Description("Tuition Fees Sent")]
        TuitionFeesPaid = 3,

        [Description("Payment Approved")]
        Enrolled = 4,

        [Description("Started")]
        Started = 5,

        [Description("Request For Cancellation")]
        RequestForCancellation = 6,

        [Description("Cancelled")]
        Cancelled = 7
    }
}
