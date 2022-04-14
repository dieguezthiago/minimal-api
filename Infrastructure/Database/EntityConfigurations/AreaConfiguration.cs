using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.EntityConfigurations;

public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .OwnsOne(x => x.X);

        builder
            .OwnsOne(x => x.Y);

        builder
            .HasMany(x => x.Robots)
            .WithOne(x => x.Area)
            .HasForeignKey(x => x.AreaId)
            .IsRequired(false);
    }
}