using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class School : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryID { get; set; }
        public int TOEFLlisten { get; set; }
        public int TOEFLread { get; set; }
        public int TOEFLwrite { get; set; }
        public int TOEFLspeak { get; set; }
        public decimal IELTSlisten { get; set; }
        public decimal IELTSread { get; set; }
        public decimal IELTSwrite { get; set; }
        public decimal IELTSspeak { get; set; }
        public int CAElisten { get; set; }
        public int CAEread { get; set; }
        public int CAEwrite { get; set; }
        public int CAEspeak { get; set; }
        public int TOEFLSum { get; set; }
        public decimal IELTSAvg { get; set; }
        public int CAEAvg { get; set; }
        public int StudyPermit { get; set; }
        public bool TOEFLAccepted { get; set; }
        public bool IELTSAccepted { get; set; }
        public bool CAEAccepted { get; set; }
        public decimal ApplicationFee { get; set; }
        public bool IsUniversity { get; set; }
        public bool IsCollege { get; set; }
        public bool IsEnglishInstitute { get; set; }
        public bool IsHighSchool { get; set; }
        public string Email { get; set; }
        public bool HasLeadIntegration { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
