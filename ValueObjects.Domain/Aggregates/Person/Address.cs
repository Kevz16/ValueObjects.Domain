using System.Collections.Generic;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class Address : ValueObject
    {
        public string StreetNumber { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }

        public Address(string streetNumber, string street, string city, string postalCode, string province, string country)
        {
            // Validation 
            // PostalCode is 4 chars long and between 0001 and 9999
            // Province is 1 of the 9
            // Etc

            StreetNumber = streetNumber;
            Street = street;
            City = city;
            PostalCode = postalCode;
            Province = province;
            Country = country;
        }

        public override string ToString()
        {
            return $"{StreetNumber} {Street}, {City}, {Province}, {Country}";
        }

        /// <summary>
        /// The yield operator allows the creation of items as it is demanded.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return StreetNumber;
            yield return Street;
            yield return City;
            yield return PostalCode;
            yield return Province;
            yield return Country;
        }
    }
}
