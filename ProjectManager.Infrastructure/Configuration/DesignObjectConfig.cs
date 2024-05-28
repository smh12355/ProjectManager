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
        builder.Property(a => a.ParentDesignObjectId).IsRequired(false);

        builder.HasMany(a => a.ChildrenDesignObjects)
            .WithOne(a => a.ParentDesignObject)
            .HasForeignKey(a => a.ParentDesignObjectId)
            .OnDelete(DeleteBehavior.Cascade);
        // лучше Restrict

        builder.HasMany(a => a.DocSets)
            .WithOne(a => a.DesignObject)
            .HasForeignKey(a => a.DesignObjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
