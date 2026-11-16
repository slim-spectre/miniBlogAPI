
using Microsoft.EntityFrameworkCore;

public static class GetCategoriesHandler
{
    public static async Task<List<CategoryDto>> HandleAsync (AppDbContext db)
    {
        return await db.Categories.Select(c => 
        new CategoryDto {Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug,
                        Description = c.Description,
                        Posts = c.Posts, PostsUrl = $"/posts/category/{c.Name}"}
        ).ToListAsync();
    }
}