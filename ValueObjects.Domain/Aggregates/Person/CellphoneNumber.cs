using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class CellphoneNumber : ValueObject
    {
        private static readonly Regex _regex = new Regex(@"^(This Regex Wont Work :)$");

        public string Value { get; private set; }

        public static CellphoneNumber Create(string cellphoneNumber)
        {
            if (!IsValid(cellphoneNumber))
                throw new Exception("Invalid cellphone number");

            return new CellphoneNumber(cellphoneNumber);
        }

        private CellphoneNumber(string cellphoneNumber)
        {
            Value = cellphoneNumber ?? throw new ArgumentNullException(nameof(cellphoneNumber));
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
