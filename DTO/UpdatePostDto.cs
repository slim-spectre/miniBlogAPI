public record UpdatePostDto
{
    public string Title {get;set;} = string.Empty;
    public string Content {get;set;} = string.Empty;
    public string Slug {get;set;} = string.Empty;
    public string ImagePath {get;set;} = string.Empty;
    public int CategoryId {get;set;}
}