using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Features.ProductPrices.Dto;
using OnlineStore.Application.Interfaces.ProductPrices;
using OnlineStore.Domain.Common;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductPricesController : ControllerBase
{
    private readonly IProductPriceHandler _handler;

    public ProductPricesController(IProductPriceHandler handler)
    {
        _handler = handler;
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin, Seller, User")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return Ok(await _handler.GetAllAsync(cancellationToken));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:guid}", Name = "GetProductPriceAsync")]
    [Authorize(Roles = "Admin, Seller, User")]
    public async Task<IActionResult> GetProductPriceAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var productPrice = await _handler.GetProductPriceAsync(id, cancellationToken);

            if (productPrice is null)
                return NotFound();

            return Ok(productPrice);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Seller")]
    public async Task<IActionResult> AddAsync([FromBody] ProductPriceDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            dto.Id = Guid.NewGuid();
            await _handler.AddAsync(dto, cancellationToken);
            return CreatedAtRoute("GetProductAsync", new {id = dto.Id}, dto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin, Seller")]
    public async Task<IActionResult> UpdateAsync([FromBody] ProductPriceDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _handler.UpdateAsync(dto, cancellationToken);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync([FromBody] ProductPriceDto dto,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _handler.DeleteAsync(dto, cancellationToken);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}