using KitapKoleksiyonum.API.Models;

namespace KitapKoleksiyonum.API.DTOs;

public class BookDto
{
    public int Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public string Author {get;set;} = string.Empty;
    public string? ISBN {get;set;}
    public int? PageCount {get;set;}
    public DateTime? PublishDate {get;set;}
    public ReadingStatus Status {get;set;}
    public int? Rating {get;set;}
    public string? Notes {get;set;}
    public int CategoryId {get;set;}
    public string CategoryName {get;set;} = string.Empty;
    public DateTime CreatedAt {get;set;}
}

public class CreateBookDto
{
    public required string Title {get;set;}
    public required string Author {get;set;}
    public string? ISBN {get;set;}
    public int? PageCount {get;set;}
    public DateTime? PublishDate {get;set;}
    public ReadingStatus Status {get;set;} = ReadingStatus.ToRead;
    public int? Rating {get;set;}
    public string? Notes {get;set;}
    public int CategoryId {get;set;}
}

public class UpdateBookDto
{
    public required string Title {get;set;}
    public required string Author {get;set;}
    public string? ISBN {get;set;}
    public int? PageCount {get;set;}  
    public DateTime? PublishDate {get;set;}
    public ReadingStatus Status {get;set;}
    public int? Rating {get;set;}
    public string? Notes {get;set;}
    public int CategoryId {get;set;}
}