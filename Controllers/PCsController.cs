using APBD_PC_Components_API.DTOs.PCs;
using APBD_PC_Components_API.Exceptions;
using APBD_PC_Components_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PC_Components_API.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCsController : ControllerBase
{
    private readonly IPCService _pcService;

    public PCsController(IPCService pcService)
    {
        _pcService = pcService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPCsAsync()
    {
        var pcs = await _pcService.GetAllPCsAsync();

        return Ok(pcs);
    }

    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCComponentsAsync(int id)
    {
        try
        {
            var pc = await _pcService.GetPCComponentsAsync(id);

            return Ok(pc);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePCAsync(CreatePCRequestDto request)
    {
        var pc = await _pcService.CreatePCAsync(request);

        return CreatedAtAction(nameof(GetPCComponentsAsync), new { id = pc.Id }, pc);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePCAsync(int id, UpdatePCRequestDto request)
    {
        try
        {
            var pc = await _pcService.UpdatePCAsync(id, request);

            return Ok(pc);
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePCAsync(int id)
    {
        try
        {
            await _pcService.DeletePCAsync(id);

            return NoContent();
        }
        catch (NotFoundException exception)
        {
            return NotFound(exception.Message);
        }
    }
}