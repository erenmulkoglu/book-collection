using KitapKoleksiyonum.API.Data;
using KitapKoleksiyonum.API.DTOs;
using KitapKoleksiyonum.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KitapKoleksiyonum.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var categories = await _context.Categories
        .Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
        })
        .ToListAsync();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>>GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if(category == null)
        {
            return NotFound();
        }

        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
        return Ok (categoryDto);
    }

    [HttpPost]
        public async Task <ActionResult<CategoryDto>>CreateCategory(CreateCategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        var categoryDto = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };

        return CreatedAtAction(nameof(GetCategory), new {id = category.Id}, categoryDto);
    }

    [HttpPut]
    public async Task<IActionResult>UpdateCategory(int id, UpdateCategoryDto dto)
    {
        var category = await _context.Categories.FindAsync(id);

        if(category == null)
        {
            return NotFound();
        }

        category.Name = dto.Name;
        category.Description = dto.Description;

        await _context.SaveChangesAsync();
        return NoContent();        

        }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory (int id)
    {
        var category = await _context.Categories.FindAsync();

        if(category == null)
        {
            return NotFound();
        }
        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();
        return NoContent();
        }
}