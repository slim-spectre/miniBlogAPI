using Microsoft.EntityFrameworkCore;

public static class DeletePostHandler {
    public static async Task<bool> HandleAsync (int id, AppDbContext db)
    {
        var deletedRows = await db.Posts.Where(p => p.Id == id).ExecuteDeleteAsync();

        return deletedRows > 0;
    }
}