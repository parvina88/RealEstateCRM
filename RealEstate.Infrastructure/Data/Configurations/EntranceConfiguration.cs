using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.Infrastructure.Data.Configurations;

public class EntranceConfiguration : IEntityTypeConfiguration<Entrance>
{
    public void Configure(EntityTypeBuilder<Entrance> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.NumberOfFloors)
            .IsRequired();

        builder.Property(x => x.NumberOfApartmentsPerFloor)
            .IsRequired();

        builder.Property(x => x.NumberOfFloors)
            .IsRequired();

        builder.HasOne(e => e.Building)
            .WithMany(b => b.Entrances)
            .HasForeignKey(e => e.BuildingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
