using Microsoft.EntityFrameworkCore;


public static class PostPostEndpoint
{
    public static void MapCreatePostEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/posts", async (CreatePostDto dto, AppDbContext db) =>
        {
            var (post, error, statusCode) = await CreatePostHandler.HandleAsync(dto, db);
            if (error is not null)
            {
                return statusCode == 409 ?
                    Results.Conflict(new { Message = error }) :
                    Results.BadRequest(new { Message = error });
            }
            return Results.Created($"/posts/{post!.Id}", post);

        }).AddEndpointFilter<ValidationFilter<CreatePostDto>>();
    }
}