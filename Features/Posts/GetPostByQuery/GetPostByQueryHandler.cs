using Microsoft.EntityFrameworkCore;

public static class GetPostByQueryHandler
{
    public static async Task<List<PostResponseDto>> HandleAsync (string query, AppDbContext db)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new List<PostResponseDto>();
        }
        var normalizedQuery = query.Trim().ToLower();
        return await db.Posts
            .Where(p => p.Title.ToLower().Contains(normalizedQuery)
                     || p.Content.ToLower().Contains(normalizedQuery)
                     || p.Slug.ToLower().Contains(normalizedQuery))
            .Select(p => new PostResponseDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                Slug = p.Slug,
                ImagePath = p.ImagePath,
                CreatedAt = p.CreatedAt,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty
            })
            .ToListAsync();
    }
}