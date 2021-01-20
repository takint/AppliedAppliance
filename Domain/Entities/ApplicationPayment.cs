using System;

namespace Domain.Entities
{
    public class ApplicationPayment : BaseEntity<int>
    {
        public int ApplicationId { get; set; }
        public int StudentId { get; set; }
        public string ReferenceId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }

        public Student Student { get; set; }
        public StudentApplication StudentApplication { get; set; }
    }
}
