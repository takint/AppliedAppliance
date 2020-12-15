using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Schools.Queries.GetSchools
{
    public class CampusDto : IMapFrom<Campus>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int SchoolId { get; set; }
        public string Description { get; set; }
        public int? BrandId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longtitude { get; set; }
        public string PostalCode { get; set; }
        public int? SubmissionCode { get; set; }
        public int? LeadCampusId { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public string Fax { get; set; }
        public decimal ProcessingFee { get; set; }

        public void Mapping(Profile profile)
        {
           // Special map
        }
    }
}
