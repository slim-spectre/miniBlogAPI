public static class GetCategoriesEndpoint
{
    public static void MapGetCategoriesEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", async (AppDbContext db) =>
        {
            var categories = await GetCategoriesHandler.HandleAsync(db);
            if(categories.Count == 0)
            {
                return Results.NotFound(new {Message = "Categories were not found"});
            }

            return Results.Ok(categories);
        });
    }
}