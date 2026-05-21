using System.ComponentModel.DataAnnotations;

namespace APBD_PC_Components_API.DTOs.PCs;

public class CreatePCRequestDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    [Range(0.01, double.MaxValue)]
    public double Weight { get; set; }

    [Range(0, int.MaxValue)]
    public int Warranty { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}