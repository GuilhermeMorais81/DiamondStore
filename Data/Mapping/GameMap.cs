using DiamondStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiamondStore.Data.Mapping;

public class GameMap : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Game");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.ReleaseDate)
            .IsRequired()
            .HasColumnType("DATETIME");
    }
}