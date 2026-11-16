

public static class GetPostsByCategoryEndpoint
{
    public static void MapGetPostsByCategoryEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapGet("/posts/category/{categoryname}", async (AppDbContext db, string categoryName) =>
        {
            var posts = await GetPostsByCategoryHandler.HandleAsync(db,categoryName);
            if(posts.Count == 0)
            {
                return Results.NotFound(new {Message = "Posts with such category were not found"});
            }
            return Results.Ok(posts);
        });
    }
}