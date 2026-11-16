public record CategoryDto
{
    public int Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public string Slug {get;set;} = string.Empty;
    public string Description {get;set;} = string.Empty;
    public List<Post>? Posts {get;set;}
    public string PostsUrl {get;set;} = string.Empty;
}