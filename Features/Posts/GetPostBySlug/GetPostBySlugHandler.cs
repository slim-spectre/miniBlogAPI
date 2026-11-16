
using Microsoft.EntityFrameworkCore;

public static class GetPostBySlugHandler
{
    public static async Task<Post?> HandleAsync (AppDbContext db, string slug)
    {
        return await db.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Slug == slug);
    }
}