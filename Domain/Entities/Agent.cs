using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Agent : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Guid { get; set; }
        public string Phone { get; set; }
        public bool Notify { get; set; }
        public bool Approved { get; set; }

        public int? ManagerId { get; set; }
        public Agent AgentManager { get; set; }

        public string CompanyName { get; set; }
        public string Website { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramAt { get; set; }
        public string TwitterAt { get; set; }
        public string SkypeId { get; set; }
        public string WhatsAppId { get; set; }
        public string LinkedinUrl { get; set; }
        public string MainSourceStudent { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public int? ReferralStaffID { get; set; }
        public DateTime? RecruitStartTime { get; set; }
        public string ProvidedService { get; set; }
        public bool CanadianRepresented { get; set; }
        public bool AmericanRepresented { get; set; }
        public bool OthersRepresented { get; set; }
        public string InstitutionRepresenting { get; set; }
        public string OrganizationBelong { get; set; }
        public int? MinimumStudentSend { get; set; } = 1;
        public int? MinimumStudentRefer { get; set; } = 1;
        public string Comments { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceInstitution { get; set; }
        public string ReferenceEmail { get; set; }
        public string ReferencePhone { get; set; }
        public string ReferenceWebsite { get; set; }
        public string UserNoticeMessage { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string InstitutionNumber { get; set; }
        public string TransitNumber { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftCode { get; set; }
        public string AccountName { get; set; }
    }
}
