using Microsoft.EntityFrameworkCore;

public static class UpdatePostHandler
{
    public static async Task<(Post? post, string? Error, int statusCode)> HandleAsync (int id, UpdatePostDto dto, AppDbContext db)
    {
        var post = await db.Posts.FirstOrDefaultAsync(c => c.Id == id);
        if (post == null)
        {
            return (null, $"Post with this Id: {id} does not exist", 404);
        }
        var isSlug = await db.Posts.AnyAsync(c => c.Slug == dto.Slug && c.Id != id);
        if (isSlug)
        {
            return (null, $"Post with suuhh slug : {dto.Slug} already exists", 409);
        }
        var isCategory = await db.Categories.AnyAsync(c => c.Id == dto.CategoryId);
        if (!isCategory)
        {
            return (null, $"Category with such Id: {dto.CategoryId} doesnt exists", 400);
        }

        post.Title = dto.Title;
        post.Content = dto.Content;
        post.Slug = dto.Slug;
        post.ImagePath = dto.ImagePath;
        post.CategoryId = dto.CategoryId;

        await db.SaveChangesAsync();

        return (post, null, 200);
    }
}