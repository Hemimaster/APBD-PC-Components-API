using APBD_PC_Components_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_PC_Components_API.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.ToTable("PCComponents");

        builder.HasKey(e => new { e.PCId, e.ComponentCode });

        builder.Property(e => e.PCId)
            .IsRequired();

        builder.Property(e => e.ComponentCode)
            .HasColumnType("char(10)")
            .IsRequired();

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.HasOne(e => e.PC)
            .WithMany(e => e.PCComponents)
            .HasForeignKey(e => e.PCId);

        builder.HasOne(e => e.Component)
            .WithMany(e => e.PCComponents)
            .HasForeignKey(e => e.ComponentCode);
    }
}