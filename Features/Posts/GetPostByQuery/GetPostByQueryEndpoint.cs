public static class GetPostByQueryEndpoint
{
    public static void MapGetPostByQueryEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapGet("/posts/q", async (AppDbContext db, string? search) =>
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return Results.BadRequest(new { Message = "Search query cannot be empty." });
            }
            
            var posts = await GetPostByQueryHandler.HandleAsync(search, db);

            if (posts.Count == 0)
            {
                return Results.NotFound(new { Message = $"Posts with query '{search}' were not found." });
            }

            return Results.Ok(posts);
        });
    }
}