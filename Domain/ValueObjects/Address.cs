using Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    /// <summary>
    /// This is a Owned Entity
    /// </summary>
    public class Address : ValueObject
    {
        public string Address1 { get; private set; }
        public string StreetNumber { get; private set; }
        public string StreetName { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        public Address() { }

        public Address(string address1, string streetNumber, string streetName, string city, string province, string country, string postalCode)
        {
            Address1 = address1;
            StreetNumber = streetNumber;
            StreetName = streetName;
            City = city;
            Province = province;
            Country = country;
            PostalCode = postalCode;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Address1;
            yield return StreetNumber;
            yield return StreetName;
            yield return City;
            yield return Province;
            yield return Country;
            yield return PostalCode;
        }
    }
}
