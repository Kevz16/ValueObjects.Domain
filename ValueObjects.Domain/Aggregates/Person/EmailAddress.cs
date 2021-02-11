using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class EmailAddress : ValueObject
    {
        private static readonly Regex _regex = new Regex(@"^(This Regex Wont Work :)$");

        public string Value { get; private set; }

        public static EmailAddress Create(string emailAddress)
        {
            if (!IsValid(emailAddress))
                throw new Exception("Invalid email address");
            return new EmailAddress(emailAddress);
        }

        private EmailAddress(string emailAddress)
        {
            Value = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
        }

        private static bool IsValid(string value)
        {
            return _regex.IsMatch(value);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
