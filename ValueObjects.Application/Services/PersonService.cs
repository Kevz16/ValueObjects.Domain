using System;
using ValueObjects.Domain.Aggregates.Person;

namespace ValueObjects.Application.Services
{
    public interface IPersonService
    {
        Person CreatePerson();
    }

    public class PersonService : IPersonService
    {
        public Person CreatePerson()
        {
            var fullName = Fullname.Create("Billy", "The", "Goat");
            var idNo = RSAIdentityNumber.Create("21021112341134");
            var cellNo = CellphoneNumber.Create("27743389201");
            var emailAddress = EmailAddress.Create("btg@mountain.com");
            var physicalAddress = new Address("4", "Table Mountain", "Cape Town", "7441", "Western Cape", "South Africa");
            var postalAddress = new Address("4", "Table Mountain", "Cape Town", "7441", "Western Cape", "South Africa");
            var workAddress = new Address("4", "Table Mountain", "Cape Town", "7441", "Western Cape", "South Africa");
            var money = new Money(900000, "Coins", "ZAR");

            var person = new Person(fullName, idNo, cellNo, emailAddress, physicalAddress, postalAddress, workAddress, money, false, "Some Stuff About Me", MaritalStatus.Married, Gender.Goat, DateTime.Today);
            return person;
        }
    }
}
