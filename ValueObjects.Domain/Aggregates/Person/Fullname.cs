using System;
using System.Collections.Generic;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class Fullname : ValueObject
    {
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }

        public static Fullname Create(string firstName, string middleName, string lastName)
        {
            return new Fullname(firstName, middleName, lastName);
        }

        public static Fullname Create(string firstName, string middleName, string lastName, string nickName)
        {
            return new Fullname(firstName, middleName, lastName, nickName);
        }

        private Fullname(string firstName, string middleName, string lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        private Fullname(string firstName, string middleName, string lastName, string nickName) : this (firstName, middleName, lastName)
        {
            NickName = nickName ?? throw new ArgumentNullException(nameof(nickName));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return MiddleName;
            yield return LastName;
        }
    }
}
