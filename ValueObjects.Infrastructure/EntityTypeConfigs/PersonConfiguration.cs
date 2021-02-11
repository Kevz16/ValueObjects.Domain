using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects.Domain.Aggregates.Person;

namespace ValueObjects.Infrastructure.EntityTypeConfigs
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.PersonId);

            //PostalAddress_StreetNumber
            //PostalAddress_Street
            //PostalAddress_City
            //PostalAddress_PostalCode
            //PostalAddress_Province
            //PostalAddress_Country
            builder.OwnsOne(p => p.PostalAddress);

            builder.OwnsOne(p => p.PhysicalAddress).ToTable("PersonPhyiscalAddress");

            builder.OwnsOne(p => p.EmailAddress).Property(prop => prop.Value).HasColumnName("EmailAddress");
        }
    }
}
