using Microsoft.EntityFrameworkCore;

public static class GetPostByIdHandler
{
    public static async Task<Post?> HandleAsync (AppDbContext db, int id)
    {
        return await db.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }
}