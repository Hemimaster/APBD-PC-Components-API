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
        
        builder.HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "AMD Ryzen 7 7800X3D",
                Description = "High performance desktop processor",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "NVIDIA GeForce RTX 4070",
                Description = "Graphics card for gaming and creative workloads",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance 32GB DDR5",
                Description = "DDR5 memory kit for desktop computers",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        );
    }
    
    
}