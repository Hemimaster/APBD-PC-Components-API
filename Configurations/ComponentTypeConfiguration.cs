using APBD_PC_Components_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_PC_Components_API.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.ToTable("ComponentTypes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Abbreviation)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(150)
            .IsRequired();
        
        builder.HasData(
            new ComponentType
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            }
        );
    }
}