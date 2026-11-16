public static class CreateCategoryEndpoint
{
    public static void MapCreateCategoryEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapPost("/categories", async (CreateCategoryDto dto, AppDbContext db) =>
        {
            var (category, error) = await CreateCategoryHandler.HandleAsync(dto, db);

            if (error is not null) return Results.Conflict(new { Message = error });

            return Results.Created($"/categories/{category!.Id}", category);
        });
    }
}