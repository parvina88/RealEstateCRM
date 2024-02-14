using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Entities;

namespace RealEstate.Infrastructure.Data.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Title)
            .IsRequired();

        builder.Property(d => d.FilePath)
            .IsRequired();

        builder.Property(d => d.OriginalFileName)
            .IsRequired();

        builder.HasOne(d => d.Apartment)
            .WithMany(a => a.AttachedDocuments)
            .HasForeignKey(d => d.ApartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Entrance)
            .WithMany(e => e.AttachedDocuments)
            .HasForeignKey(d => d.EntranceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
