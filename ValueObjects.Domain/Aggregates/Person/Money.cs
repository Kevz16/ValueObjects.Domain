using System.Collections.Generic;
using ValueObjects.Domain.SeedWork;

namespace ValueObjects.Domain.Aggregates.Person
{
    public class Money : ValueObject
    {
        public double Value { get; private set; }
        public string Type { get; private set; }
        public string Currency { get; private set; }

        public Money(double value, string type, string currency)
        {
            Value = value;
            Type = type;
            Currency = currency;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Currency;
        }

        public double ToDollars()
        {
            return Value / 16.0; 
        }
    }
}
