using System.ComponentModel.DataAnnotations;


public record UpdateCategoryDto
{
    [Required(ErrorMessage = "Name is required")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 symbols")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Slug is required")]
    public string Slug { get; set; } = string.Empty;
    [Required(ErrorMessage = "Descripiton is required")]
    [MinLength(10, ErrorMessage = "Description min length is 10 symbols")]
    public string Description { get; set; } = string.Empty;
}