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
public class CategoryController : ControllerBase
{
    private readonly ICategoryHandlers _categoryHandlers;

    public CategoryController(ICategoryHandlers categoryHandlers)
    {
        _categoryHandlers = categoryHandlers;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetCategoryQuery query, CancellationToken cancellationToken)
    {
        var result = await _categoryHandlers.GetHandler.Get(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _categoryHandlers.GetByIdHandler.GetById(id);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddCategoryDto request)
    {
        var toCommand = request.ToCommand();

        var result = await _categoryHandlers.AddHandler.Add(toCommand);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto update)
    {
        var toUpdate = update.ToUpdateCommand();

        var result = await _categoryHandlers.UpdateHandler.Update(toUpdate);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _categoryHandlers.DeleteHandler.Delete(id);

        return result.IsSuccessful ? Ok(result.Data) : BadRequest(result.Error);
    }
}
