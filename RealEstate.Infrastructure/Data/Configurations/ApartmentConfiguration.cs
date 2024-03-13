using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.Infrastructure.Data.Configurations;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Number)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(a => a.Floor)
            .IsRequired();

        builder.Property(a => a.NumberOfRooms)
            .IsRequired();

        builder.Property(a => a.TotalArea)
            .IsRequired();
        
        builder.Property(a => a.PricePerSquare)
            .HasPrecision(18, 2);

        builder.Property(a => a.Type)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired();

        builder.HasOne(a => a.Entrance)
            .WithMany(e => e.Apartments)
            .HasForeignKey(a => a.EntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
