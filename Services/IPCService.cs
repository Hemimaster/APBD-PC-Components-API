using APBD_PC_Components_API.DTOs.PCs;

namespace APBD_PC_Components_API.Services;

public interface IPCService
{
    Task<ICollection<PCResponseDto>> GetAllPCsAsync();

    Task<PCComponentsResponseDto> GetPCComponentsAsync(int id);

    Task<PCResponseDto> CreatePCAsync(CreatePCRequestDto request);

    Task<PCResponseDto> UpdatePCAsync(int id, UpdatePCRequestDto request);

    Task DeletePCAsync(int id);
}