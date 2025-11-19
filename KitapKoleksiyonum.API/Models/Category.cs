using System;


namespace KitapKoleksiyonum.API.Models;
public class Category
{	
	public int Id { get; set; }
	public required string Name { get; set; }
	public string? Description { get; set; }
	public ICollection<Book> Books { get; set; } = new List<Book>();
}
