
public static class GetPostByIdEndpoint
{
    public static void MapGetPostByIdEndpoint (this  IEndpointRouteBuilder app)
    {
        app.MapGet("/posts/{id:int}", async (AppDbContext db, int id) =>
        {
            var post = await GetPostByIdHandler.HandleAsync(db, id);
            if(post == null)
            {
                return Results.NotFound(new {Message = "Post with this id was not found"});
            }
            return Results.Ok(post);
        });
    }
}