﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.PandaDoc
{
    public static class PandaDocFields
    {
        // fields could be auto filled
        // student info
        public const string STUDENT_FIRSTNAME = "Student.FirstName";
        public const string STUDENT_LASTNAME = "Student.LastName";
        public const string STUDENT_MIDDLENAME = "Student.MiddleName";
        public const string STUDENT_EMAIL = "Student.Email";
        public const string STUDENT_STUDENTCODE = "Student.StudentCode";
        public const string STUDENT_PHONE = "Student.Phone";
        public const string STUDENT_POSTAL = "Student.Postal";
        public const string STUDENT_BIRTHDATE = "Student.BirthDate";
        public const string STUDENT_CITY = "Student.City";
        public const string STUDENT_COUNTRY = "Student.Country";
        public const string STUDENT_PROVINCE = "Student.ProvinceState";
        public const string STUDENT_ADDRESS = "Student.Address";
        public const string STUDENT_FULLNAME = "Student.FullName";
        public const string STUDENT_STREETNAME = "Student.StreetName";
        public const string STUDENT_POBOX = "Student.POBox";
        public const string STUDENT_APARTMENT_NUMBER = "Student.ApartmentNumber";
        public const string STUDENT_STREET_NUMBER = "Student.StreetNumber";
        public const string STUDENT_FULL_ADDRESS = "Student.FullAddress";
        public const string STUDENT_POBOX_APARTMENT = "Student.StudentPOBoxApartmentNumber";
        public const string STUDENT_STREET_CITY_STATE_COUNTRY_POSTAL = "Student.StudentStreetCityStateCountryPostal";

        // program info
        public const string PROGRAM_TITLE = "Program.Title";
        public const string PROGRAM_TUITION = "Program.Tuition";

        // campus info
        public const string CAMPUS_NAME = "Campus.Name";
        public const string CAMPUS_CITY = "Campus.City";
        public const string CAMPUS_PROVINCE = "Campus.Province";
        public const string CAMPUS_COUNTRY = "Campus.Country";
        public const string CAMPUS_PHONE = "Campus.Phone";
        public const string CAMPUS_FAX = "Campus.Fax";
        public const string CAMPUS_ADDRESS = "Campus.Address";
        public const string CAMPUS_POSTAL = "Campus.Postal";
        public const string CAMPUS_INSTITUITION_NAME = "Campus.InstitutionName";

        // school info
        public const string SCHOOL_NAME = "School.Name";
        public const string SCHOOL_TYPE = "Campus.SchoolType";

        // application info
        // a program could have multiple intakes, thus the startDate and endDate varies from application to application
        public const string PROGRAM_STARTDATE = "Program.StartDate";
        public const string PROGRAM_ENDDATE = "Program.EndDate";
        public const string APPLICATION_TUITION = "Tuition";
        public const string OFFER_OF_ADMISSION_VALID_DATE = "Date.OfferofAdmission";
        public const string FIRST_DEPOSIT = "Program.FirstDeposit";
        public const string REGISTRATION_FEE = "Program.RegistrationFee";
        public const string PROCESSING_FEE = "Program.ProcessingFee";
        public const string PAYMENT_SWIFT_CODE = "Payment.SwiftCode";
        public const string PAYMENT_WIRE_DATE = "Payment.WireDate";
        public const string PROGRAM_CATEGORY = "Program.ProgramType";
        public const string PROGRAM_HAS_FINANCIAL_AID_YES = "Program.HasFinancialAid.Yes";
        public const string PROGRAM_HAS_FINANCIAL_AID_NO = "Program.HasFinancialAid.No";
        public const string PROGRAM_IS_EXCHANGE_YES = "Program.IsExchange.Yes";
        public const string PROGRAM_IS_EXCHANGE_NO = "Program.IsExchange.No";
        public const string PROGRAM_LEVEL = "Program.LevelOfStudy";
        public const string PROGRAM_YEARLY_TUITION = "Program.YearlyTuition";
        public const string APPLICATION_STARTDATE = "Student.AplicationStartDate";
        public const string EMPLOYMENT_ASSISTANCE_END_DATE = "Program.6MonthsAfterEndDate";
        public const string PAYMENT_WESTERN_UNION_LINK = "Student.WesternUnionLink";
        public const string PROGRAM_ADMISSION_VALID_DATE = "Program.OfferOfValidAdmission";

        // other
        public const string CURRENT_DATE = "CurrentDate";
        public const string MODE = "Mode";
        public const string AMOUNT_PAID = "AmountPaid";
        public const string REMAINING_BALANCE = "RemainingBalance";
        public const string TOTAL_AMOUNT = "TotalAmount";
        public const string CLOA_REGISTRATION_FEE = "CLOA.RegistrationFee";
        public const string LOA_VALID_DATE = "Campus.ExpirationDateOfLOA";
    }
}
