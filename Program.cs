using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=products.db"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseStaticFiles();

app.MapGetPostsByCategoryEndpoint();
app.MapUpdatePostEndpoint();
app.MapGetPostsEndpoint();
app.MapGetPostBySlugEndpoint();
app.MapGetPostByQueryEndpoint();
app.MapGetPostByIdEndpoint();
app.MapDeletePostEndpoint();
app.MapCreatePostEndpoint();

app.MapGetCategoriesEndpoint();
app.MapUpdateCategoryEndpoint();
app.MapDeleteCategoryEndpoint();
app.MapCreateCategoryEndpoint();

app.MapGetAboutEndpoint();

app.Run();
