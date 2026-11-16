public static class UpdateCategoryEndpoint
{
    public static void MapUpdateCategoryEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapPut("/categories/{id:int}", async (int id, UpdateCategoryDto dto, AppDbContext db) =>
        {
            var (category, error, statusCode) = await UpdateCategoryHandler.HandleAsync(id, dto, db);
            if (error is not null)
            {
                return statusCode == 404 ?
                    Results.NotFound(new { Message = error }) :
                    Results.Conflict(new { Message = error });
            }
            return Results.Ok(category);
        });
    }
}