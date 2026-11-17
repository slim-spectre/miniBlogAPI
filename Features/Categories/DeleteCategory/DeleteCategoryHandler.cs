using Microsoft.EntityFrameworkCore;

public static class DeleteCategoryHandler {
    public static async Task<bool> HandleAsync (int id, AppDbContext db)
    {
        var deletedRows = await db.Categories.Where(p => p.Id == id).ExecuteDeleteAsync();

        return deletedRows > 0;
    }
}