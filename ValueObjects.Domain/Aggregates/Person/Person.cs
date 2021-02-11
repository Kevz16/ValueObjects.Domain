using System;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class Person : IAggregateRoot
    {
        public int PersonId { get; set; }

        public Fullname Fullname { get; private set; }
        public RSAIdentityNumber RSAIdentityNumber { get; private set; }
        public CellphoneNumber CellphoneNumber { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Address PhysicalAddress { get; private set; }
        public Address PostalAddress { get; private set; }
        public Address WorkAddress { get; private set; }
        public Money Money { get; private set; }
        public bool IsEmployed { get; private set; }
        public string About { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }


        public Person(Fullname fullname,
                      RSAIdentityNumber rSAIdentityNumber,
                      CellphoneNumber cellphoneNumber,
                      EmailAddress emailAddress,
                      Address physicalAddress,
                      Address postalAddress,
                      Address workAddress,
                      Money money,
                      bool isEmployed,
                      string about,
                      MaritalStatus maritalStatus,
                      Gender gender,
                      DateTime dateOfBirth)
        {
            Fullname = fullname ?? throw new ArgumentNullException(nameof(fullname));
            RSAIdentityNumber = rSAIdentityNumber ?? throw new ArgumentNullException(nameof(rSAIdentityNumber));
            CellphoneNumber = cellphoneNumber ?? throw new ArgumentNullException(nameof(cellphoneNumber));
            EmailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            PhysicalAddress = physicalAddress ?? throw new ArgumentNullException(nameof(physicalAddress));
            PostalAddress = postalAddress ?? throw new ArgumentNullException(nameof(postalAddress));
            WorkAddress = workAddress ?? throw new ArgumentNullException(nameof(workAddress));
            Money = money ?? throw new ArgumentNullException(nameof(money));
            IsEmployed = isEmployed;
            About = about ?? throw new ArgumentNullException(nameof(about));
            MaritalStatus = maritalStatus;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public void ChangeEmailAddress(string emailAddress)
        {
            EmailAddress = EmailAddress.Create(emailAddress);
        }

        public bool PhysicalAddressSameAsPostalAddress()
        {
            return PhysicalAddress.Equals(PostalAddress);
        }

        public bool WorksFromHome()
        {
            return PhysicalAddress.Equals(WorkAddress);
        }
    }
}
