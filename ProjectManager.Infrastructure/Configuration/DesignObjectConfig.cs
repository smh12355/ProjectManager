using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Infrastructure.Configuration;

public class DesignObjectConfig : IEntityTypeConfiguration<DesignObjectEntity>
{
    public void Configure(EntityTypeBuilder<DesignObjectEntity> builder)
    {
        builder.Property(a => a.Code);

        builder.Property(a => a.Name);

        builder.HasMany(a => a.DocSets)
            .WithOne(a => a.DesignObject)
            .HasForeignKey(a => a.DesignObjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
