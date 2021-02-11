using ValueObjects.Domain.Aggregates.Person_C9;

namespace ValueObjects.Application.Services
{
    public class Person_C9Service
    {
        public void CreatePerson()
        {
            var address = new AddressC9("4", "Table Mountain", "Cape Town", "7441", "Western Cape", "South Africa");
            var otherAddress = address with { City = "Other City" };
        }
    }
}
