
using System.ComponentModel.DataAnnotations;
public record UpdatePostDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be from 3 to 100 symbols")]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Content is required")]
    [MinLength(10, ErrorMessage = "Content min length is 10 symbols")]
    public string Content { get; set; } = string.Empty;
    [Required(ErrorMessage = "Slug is required")]
    public string Slug { get; set; } = string.Empty;
    [Required(ErrorMessage = "Path to photo is required")]
    public string ImagePath { get; set; } = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be > 0")]
    public int CategoryId { get; set; }
}