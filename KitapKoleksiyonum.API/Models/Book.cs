using System;


namespace KitapKoleksiyonum.API.Models;

public class Book
{	
	public int Id { get; set; }
	public required string Title { get; set; }
	public required string Author { get; set; }
	public string? ISBN { get; set; }
	public int? PageCount { get; set; }
	public DateTime? PublishDate { get; set; }
	public ReadingStatus Status { get; set; }
	public int? Rating { get; set; }
	public string? Notes { get;set; }
	public int CategoryId { get; set; }
	public Category? Category { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum ReadingStatus
{
	ToRead = 0,
	Reading = 1,
	Completed = 2
}
