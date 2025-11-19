using Microsoft.AspNetCore.Mvc;
using KitapKoleksiyonum.API.Models;
using KitapKoleksiyonum.API.DTOs;
using KitapKoleksiyonum.API.Data;
using Microsoft.EntityFrameworkCore;

namespace KitapKoleksiyonum.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController:ControllerBase
{
    private readonly AppDbContext _context;

    public BooksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        var books = await _context.Books
        .Include(b => b.Category)
        .Select(b => new BookDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            ISBN = b.ISBN,
            PageCount = b.PageCount,
            PublishDate = b.PublishDate,
            Status = b.Status,
            Rating = b.Rating,
            Notes = b.Notes,
            CategoryId = b.CategoryId,
            CategoryName = b.Category!.Name,
            CreatedAt = b.CreatedAt
        })
        .ToListAsync();

        return Ok (books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook (int id)
    {
        var book = await _context.Books
        .Include(b => b.Category)
        .FirstOrDefaultAsync(b => b.Id == id);
    
        if (book == null)
    {
        return NotFound();
    }

    var booksDto = new BookDto
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author,
        ISBN = book.ISBN,
        PageCount = book.PageCount,
        PublishDate = book.PublishDate,
        Status = book.Status,
        Rating = book.Rating,
        Notes = book.Notes,
        CategoryId = book.CategoryId,
        CategoryName = book.Category!.Name,
        CreatedAt = book.CreatedAt
    };
    return Ok(booksDto);
    }


    [HttpPost]
    public async Task<ActionResult<BookDto>>CreateBook(CreateBookDto dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            ISBN = dto.ISBN,
            PageCount = dto.PageCount,
            PublishDate = dto.PublishDate,
            Status = dto.Status,
            Rating = dto.Rating,
            Notes = dto.Notes,
            CategoryId = dto.CategoryId
        };

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        var bookDto  = new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            PageCount = book.PageCount,
            PublishDate = book.PublishDate,
            Status = book.Status,
            Rating = book.Rating,
            Notes = book.Notes,
            CategoryId = book.CategoryId,
            CategoryName = (await _context.Categories.FindAsync(book.CategoryId))!.Name,
            CreatedAt = book.CreatedAt
        };

        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, bookDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto dto)
        {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.ISBN = dto.ISBN;
        book.PageCount = dto.PageCount;
        book.PublishDate = dto.PublishDate;
        book.Status = dto.Status;
        book.Rating = dto.Rating;
        book.Notes = dto.Notes;
        book.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult>DeleteBook (int id)
    {
        var book = await _context.Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();

    }
    }