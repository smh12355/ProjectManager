using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Configuration;

public class DocSetConfig : IEntityTypeConfiguration<DocSetEntity>
{
    public void Configure(EntityTypeBuilder<DocSetEntity> builder)
    {
        builder.Property(a => a.Mark)
            .HasConversion(a => a.ToString(), a => Enum.Parse<Mark>(a));

        builder.Property(a => a.Number);
    }
}