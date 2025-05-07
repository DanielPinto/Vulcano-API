using Microsoft.AspNetCore.Mvc;
using Vulcano.Application.DTOs;
using Vulcano.Application.UseCases.EquipmentUseCase;
using Vulcano.Domain.Interfaces;
using Vulcano.Domain.Utils;
using Vulcano.WebApi.Filters;

namespace Vulcano.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[ServiceFilter(typeof(ValidateModelAttribute))]

public class EquipmentController(EquipmentHandler handler, IApiResponseFormatter responseFormatter) : ControllerBase
{
    private readonly EquipmentHandler _handler = handler;
    private readonly IApiResponseFormatter _responseFormatter = responseFormatter;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEquipmentDto dto)
    {
        var result = await _handler.CreateAsync(dto);
        return _responseFormatter.FormatCreated(result, Request, Response, dto.Id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateEquipmentDto dto)
    {
        dto.Id = id;
        await _handler.UpdateAsync(dto);
        return NoContent();
    }

}
