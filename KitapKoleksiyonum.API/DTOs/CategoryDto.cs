namespace KitapKoleksiyonum.API.DTOs;

public class CategoryDto
{
    public int Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public string? Description {get;set;}
}
public class CreateCategoryDto
{
    public required string Name {get;set;}
    public string? Description {get;set;}
}

public class UpdateCategoryDto
{
    public required string Name {get;set;}
    public string? Description {get;set;}
}