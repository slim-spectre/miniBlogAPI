
public static class GetPostsEndpoint
{
    public static void MapGetPostsEndpoint (this  IEndpointRouteBuilder app)
    {
        app.MapGet("/posts", async (AppDbContext db) =>
        {
            var posts = await GetPostsHandler.HandleAsync(db);
            if(posts.Count == 0)
            {
                return Results.NotFound(new {Message = "Posts were not found"});
            }
            return Results.Ok(posts);
        });
    }
}