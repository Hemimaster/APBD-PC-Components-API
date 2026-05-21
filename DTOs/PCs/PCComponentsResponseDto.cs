namespace APBD_PC_Components_API.DTOs.PCs;

public class PCComponentsResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<PCComponentDto> Components { get; set; } = new List<PCComponentDto>();
}