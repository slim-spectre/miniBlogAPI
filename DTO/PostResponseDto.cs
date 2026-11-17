public record PostResponseDto
{
    public int Id {get;set;}
    public string Title {get;set;} = string.Empty;
    public string Content {get;set;} = string.Empty;
    public string Slug {get;set;} = string.Empty;
    public string ImagePath {get;set;} = string.Empty;
    public DateTime CreatedAt {get;set;}
    public int CategoryId {get;set;}
    public string? CategoryName { get; set; } = string.Empty;
}