using Application.DTOs;
using Application.Features.Contracts;
using Application.Interfaces;
using Application.Mappings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterAdria_Task.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductHandlers _productHandlers;

    public ProductsController(IProductHandlers productHandlers)
    {
        _productHandlers = productHandlers;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
    {
        var result = await _productHandlers.GetHandler.Get(query);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productHandlers.GetByIdHandler.GetById(id);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProductDto request)
    {
        var toCommand = request.ToCommand();

        var result = await _productHandlers.AddHandler.Add(toCommand);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductDto update)
    {
        var toUpdate = update.ToUpdateCommand();

        var result = await _productHandlers.UpdateHandler.Update(toUpdate);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productHandlers.DeleteHandler.Delete(id);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }
}
