using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DisasterAlleviation.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Configure DbContext with Azure SQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Build app
var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Optional: Fix double slashes in URL
app.Use(async (context, next) =>
{
    if (context.Request.Path.Value.Contains("//"))
    {
        context.Response.Redirect(context.Request.Path.Value.Replace("//", "/"));
        return;
    }
    await next();
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Default route: HomeController / Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Volunteer Tasks route
app.MapControllerRoute(
    name: "volunteerTasks",
    pattern: "VolunteerTasks/{action=Manage}/{id?}",
    defaults: new { controller = "Volunteer" });

app.Run();
