using APBD_PC_Components_API.Data;
using APBD_PC_Components_API.DTOs.PCs;
using APBD_PC_Components_API.Entities;
using APBD_PC_Components_API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace APBD_PC_Components_API.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _context;

    public PCService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<PCResponseDto>> GetAllPCsAsync()
    {
        return await _context.PCs
            .Select(pc => new PCResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<PCComponentsResponseDto> GetPCComponentsAsync(int id)
    {
        var pc = await _context.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new PCComponentsResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Components = pc.PCComponents
                    .Select(pcComponent => new PCComponentDto
                    {
                        Code = pcComponent.Component.Code,
                        Name = pcComponent.Component.Name,
                        Description = pcComponent.Component.Description,
                        Amount = pcComponent.Amount,
                        ComponentType = new ComponentTypeDto
                        {
                            Id = pcComponent.Component.ComponentType.Id,
                            Abbreviation = pcComponent.Component.ComponentType.Abbreviation,
                            Name = pcComponent.Component.ComponentType.Name
                        },
                        ComponentManufacturer = new ComponentManufacturerDto
                        {
                            Id = pcComponent.Component.ComponentManufacturer.Id,
                            Abbreviation = pcComponent.Component.ComponentManufacturer.Abbreviation,
                            FullName = pcComponent.Component.ComponentManufacturer.FullName,
                            FoundationDate = pcComponent.Component.ComponentManufacturer.FoundationDate
                        }
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        return pc;
    }

    public async Task<PCResponseDto> CreatePCAsync(CreatePCRequestDto request)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        await _context.PCs.AddAsync(pc);
        await _context.SaveChangesAsync();

        return new PCResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<PCResponseDto> UpdatePCAsync(int id, UpdatePCRequestDto request)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;

        await _context.SaveChangesAsync();

        return new PCResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task DeletePCAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);

        if (pc is null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        _context.PCs.Remove(pc);

        await _context.SaveChangesAsync();
    }
}