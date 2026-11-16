using Microsoft.EntityFrameworkCore;

public static class UpdateCategoryHandler
{
    public static async Task<(Category? category, string? Error, int statusCode)> HandleAsync (int id, UpdateCategoryDto dto, AppDbContext db)
    {
        var category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (category == null)
        {
            return (null, $"Category with this Id: {id} does not exist", 404);
        }
        var isSlug = await db.Categories.AnyAsync(c => c.Slug == dto.Slug && c.Id != id);
        if (isSlug)
        {
            return (null, $"Category with suuhh slug : {dto.Slug} already exists", 409);
        }

        category.Name = dto.Name;
        category.Description = dto.Description;
        category.Slug = dto.Slug;

        await db.SaveChangesAsync();

        return (category, null, 200);
    }
}