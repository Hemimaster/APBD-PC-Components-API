namespace APBD_PC_Components_API.DTOs.PCs;

public class PCComponentDto
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Amount { get; set; }

    public ComponentTypeDto ComponentType { get; set; } = null!;

    public ComponentManufacturerDto ComponentManufacturer { get; set; } = null!;
}