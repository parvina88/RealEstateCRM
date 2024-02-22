using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data.Configurations;

public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Date)
            .IsRequired();

        builder.Property(d => d.Comment)
            .HasMaxLength(500);

        builder.Property(d => d.Status)
            .IsRequired();

        builder.HasOne(d => d.Apartment)
            .WithMany()
            .HasForeignKey(d => d.ApartmentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Customer)
            .WithMany()
            .HasForeignKey(d => d.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Employee)
            .WithMany()
            .HasForeignKey(d => d.EmployeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
