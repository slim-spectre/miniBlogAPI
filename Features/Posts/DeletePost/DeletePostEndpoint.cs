public static class DeletePostEndpoint
{
    public static void MapDeletePostEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapDelete("/posts/{id:int}", async (int id, AppDbContext db) =>
        {
            var isDeleted = await DeletePostHandler.HandleAsync(id, db);
            return isDeleted ?
                Results.NoContent()
                : Results.NotFound(new { Message = $"Post with Id: {id} does not exist" });
        });
    }
}