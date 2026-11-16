public static class UpdatePostEndpoint
{
    public static void MapUpdatePostEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapPut("/posts/{id:int}", async (int id, UpdatePostDto dto, AppDbContext db) =>
        {
            var (post, error, statusCode) = await UpdatePostHandler.HandleAsync(id, dto, db);
            if (error is not null)
            {
                return statusCode switch
                {
                    404 => Results.NotFound(new { Message = error }),
                    409 => Results.Conflict(new { Message = error }),
                    _ => Results.BadRequest(new { Message = error })
                };
            }
            return Results.Ok(post);
        });
    }
}