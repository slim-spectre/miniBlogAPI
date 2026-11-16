using Microsoft.EntityFrameworkCore;

public static class GetPostsHandler
{
    public static async Task<List<Post>> HandleAsync (AppDbContext db)
    {
        return await db.Posts.Include(p => p.Category).ToListAsync();
    }
}