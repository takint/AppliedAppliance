using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class StudentApplication : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public int SchoolID { get; set; }
        public int ProgramId { get; set; }
        public int CampusId { get; set; }
        public int GradingSchemeId { get; set; }
        public decimal ApplicationFee { get; set; }
        public ApplicationStatus Status { get; protected set; } = ApplicationStatus.Incomplete;
        public DateTime StartDate { get; set; }
        public decimal? TuitionFee { get; set; }
        public byte? DashboardStep { get; set; }
        /// <summary>
        /// keep track of the current 'ApplicationProcess' 
        /// </summary>
        public ApplicationProcesses Process { get; set; }

        /// <summary>
        /// Details realted to student
        /// </summary>
        public string StudentCode { get; set; }
        public string IELTSTRFNumber { get; set; }
        public bool IsProfileCompleted { get; set; }
        public bool IsGraduated { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthCountry { get; set; }
        public string Phone { get; set; }
        public string ApartmentNumber { get; set; }
        public string StreetNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string FirstLanguage { get; set; }
        public string PassportNumber { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string GradeAverage { get; set; }
        public int EducationLevel { get; set; }
        public string EducationCountry { get; set; }
        public string ConvertedGrade { get; set; }
        public string UserNoticeMessage { get; set; }
        public string SchoolAttended { get; set; }

        //Linked objects
        public School School { get; set; }
        public Student Student { get; set; }
        public Program Program { get; set; }
        public Campus Campus { get; set; }

    }
}
