
using Microsoft.EntityFrameworkCore;

public static class GetPostsByCategoryHandler
{
    public static async Task<List<Post>> HandleAsync (AppDbContext db, string categoryName)
    {
        return await db.Posts.Include(p => p.Category).Where(p => p.Category.Name == categoryName).ToListAsync();
    }
}