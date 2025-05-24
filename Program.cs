using Microsoft.EntityFrameworkCore; // Necesario para EF Core
using practica3.Data; // Importa tu DbContext
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Agrega el DbContext para guardar feedback usando SQLite
builder.Services.AddDbContext<FeedbackDbContext>(options =>
    options.UseSqlite("Data Source=feedback.db"));

// Agrega PostService que usa HttpClient para consumir JSONPlaceholder
builder.Services.AddHttpClient<practica3.Services.PostService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
