using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.Infrastructure.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(c => c.DateOfBirth)
            .HasColumnType("date");
    }
}
