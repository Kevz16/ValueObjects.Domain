using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class RSAIdentityNumber : ValueObject
    {
        private static readonly Regex _regex = new Regex(@"^(This Regex Wont Work :)$");

        public string Value { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public bool IsCitizen { get; private set; }

        public static RSAIdentityNumber Create(string rsaIdNumber)
        {
            if (!IsValid(rsaIdNumber))
                throw new Exception("Invalid RSA ID Number");
            return new RSAIdentityNumber(rsaIdNumber);
        }

        private RSAIdentityNumber(string rsaIdNumber)
        {
            Value = rsaIdNumber ?? throw new ArgumentNullException(nameof(rsaIdNumber));

            // DateOfBirth = Some string manipulations YYMMDD
            // Gender = More string manipulations SSSS
            IsCitizen = Value.Substring(10, 1) == "0";
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
