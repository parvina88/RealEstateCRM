using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RealEstate.Infrastructure.Data.Configurations;

public class DealDocumentConfiguaration : IEntityTypeConfiguration<DealDocument>
{
    public void Configure(EntityTypeBuilder<DealDocument> builder)
    {
        builder.HasKey(dd => new { dd.DealId, dd.DocumentId});

        builder.HasOne(dd => dd.Deal)
            .WithMany(d => d.DealDocuments)
            .HasForeignKey(dd => dd.DealId);

        builder.HasOne(dd => dd.Document)
            .WithMany()
            .HasForeignKey(dd => dd.DocumentId);
    }
}
