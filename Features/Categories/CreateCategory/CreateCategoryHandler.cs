
using Microsoft.EntityFrameworkCore;

public static class CreateCategoryHandler
{
    public static async Task<(Category? category, string? Error)> HandleAsync(CreateCategoryDto dto, AppDbContext db)
    {
        var isSlug = await db.Categories.AnyAsync(c => c.Slug == dto.Slug);
        if (isSlug)
        {
            return (null, $"Category with slug : {dto.Slug} already existss");
        }

        var category = new Category
        {
            Name = dto.Name,
            Slug = dto.Slug,
            Description = dto.Description,
        };

        db.Categories.Add(category);
        await db.SaveChangesAsync();

        return (category, null);
    }
}