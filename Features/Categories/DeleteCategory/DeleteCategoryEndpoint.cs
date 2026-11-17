public static class DeleteCategoryEndpoint {
    public static void MapDeleteCategoryEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapDelete("/categories/{id:int}", async (int id, AppDbContext db) =>
        {
            var isDeleted = await DeleteCategoryHandler.HandleAsync(id, db);
            return isDeleted ?
                Results.NoContent() :
                Results.NotFound(new { Message = $"Category with id : {id} was not found" });
        });
    }
}