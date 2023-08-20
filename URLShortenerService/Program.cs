using Microsoft.EntityFrameworkCore;
using URLShortenerService;
using URLShortenerService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ModelDBContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<ShortenUrlService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();
app.MapGet("/shorten/{data}", async (ModelDBContext DBcontext, HttpContext httpContext) =>
{
    string shortURLData = httpContext.Request.RouteValues["data"] as string;
    Record? record = await DBcontext.Records.FirstOrDefaultAsync(_ => _.ShortURL.EndsWith(shortURLData));
    if (record != default) 
        httpContext.Response.Redirect(record.LongURL);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html"); 

app.Run();
