using APBD_PC_Components_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_PC_Components_API.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.ToTable("ComponentManufacturers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.FullName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.FoundationDate)
            .HasColumnType("date")
            .IsRequired();
    }
}