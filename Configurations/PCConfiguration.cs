using APBD_PC_Components_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_PC_Components_API.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.ToTable("PCs");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.Weight)
            .HasColumnType("float(5)")
            .IsRequired();

        builder.Property(e => e.Warranty)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.Stock)
            .IsRequired();
    }
}