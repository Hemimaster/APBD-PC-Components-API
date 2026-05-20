using APBD_PC_Components_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_PC_Components_API.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("Components");

        builder.HasKey(e => e.Code);

        builder.Property(e => e.Code)
            .HasColumnType("char(10)")
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.Description)
            .IsRequired();

        builder.Property(e => e.ComponentManufacturersId)
            .IsRequired();

        builder.Property(e => e.ComponentTypesId)
            .IsRequired();

        builder.HasOne(e => e.ComponentManufacturer)
            .WithMany(e => e.Components)
            .HasForeignKey(e => e.ComponentManufacturersId);

        builder.HasOne(e => e.ComponentType)
            .WithMany(e => e.Components)
            .HasForeignKey(e => e.ComponentTypesId);
    }
}