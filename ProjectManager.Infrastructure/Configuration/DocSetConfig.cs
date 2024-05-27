using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Infrastructure.Configuration;

public class DocSetConfig : IEntityTypeConfiguration<DocSetEntity>
{
    public void Configure(EntityTypeBuilder<DocSetEntity> builder)
    {
        builder.Property(a => a.Mark);

        builder.Property(a => a.Number);
    }
}