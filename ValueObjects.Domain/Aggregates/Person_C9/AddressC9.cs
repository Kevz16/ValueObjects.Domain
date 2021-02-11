namespace ValueObjects.Domain.Aggregates.Person_C9
{
    public record AddressC9(string StreetNumber, string Street, string City, string PostalCode, string Province, string Country)
    {

        public void Post()
        {
            // Some Post Logic
        }
    }
}
