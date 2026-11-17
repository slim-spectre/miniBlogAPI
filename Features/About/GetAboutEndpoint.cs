public static class GetAboutEndpoint
{
    public static void MapGetAboutEndpoint (this IEndpointRouteBuilder app)
    {
        app.MapGet("/about", () => Results.File("files/about.html", "text/html; charset=utf-8"));
    }
}