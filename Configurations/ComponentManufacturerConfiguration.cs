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
        
        builder.HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateOnly(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateOnly(1994, 1, 1)
            }
        );
    }
    
    
}