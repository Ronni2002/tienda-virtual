using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Features.Products.Dto;
using OnlineStore.Application.Interfaces.Products;

namespace OnlineStore.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IProductHandler _handler;

    public ProductsController(IProductHandler handler)
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

    [HttpGet("{id:guid}", Name = "GetProductAsync")]
    [Authorize(Roles = "Admin, Seller, User")]
    public async Task<IActionResult> GetProductAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var product = await _handler.GetProductAsync(id, cancellationToken);

            if (product is null)
                return NotFound();
            
            return Ok(product);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin, Seller")]
    public async Task<IActionResult> AddAsync([FromBody] ProductDto dto, CancellationToken cancellationToken = default)
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
    public async Task<IActionResult> UpdateAsync([FromBody] ProductDto dto,
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
    public async Task<IActionResult> DeleteAsync([FromBody] ProductDto dto,
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