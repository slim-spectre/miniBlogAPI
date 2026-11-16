using Microsoft.EntityFrameworkCore;

public static class CreatePostHandler
{
    public static async Task<(Post? post, string? Error, int statusCode)> HandleAsync(CreatePostDto dto, AppDbContext db)
    {
        var isSlug = await db.Posts.AnyAsync(x => x.Slug == dto.Slug);
        if (isSlug)
        {
            return (null, $"Post with this slug : {dto.Slug} already exist", 409);
        }

        var isCategory = await db.Categories.AnyAsync(x => x.Id == dto.CategoryId);
        if (!isCategory)
        {
            return (null, $"Category with this id : {dto.CategoryId} doesnt  exist", 400);
        }

        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            Slug = dto.Slug,
            ImagePath = dto.ImagePath,
            CreatedAt = DateTime.UtcNow,
            CategoryId = dto.CategoryId,
        };

        db.Posts.Add(post);
        await db.SaveChangesAsync();

        return (post, null, 201);
    }
}