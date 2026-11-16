
public static class GetPostBySlugEndpoint
{
    public static void MapGetPostBySlugEndpoint (this IEndpointRouteBuilder app) {
        app.MapGet("/posts/slug/{slug}", async (AppDbContext db, string slug) =>
        {
            var post = await GetPostBySlugHandler.HandleAsync(db,slug);
            if(post == null)
            {
                return Results.NotFound(new {Message = "Post with this slug was not found"});
            }
            return Results.Ok(post);
        });
    }
}