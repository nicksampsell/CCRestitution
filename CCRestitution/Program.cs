using CCRestitution;
using CCRestitution.Data;
using CCRestitution.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options => {
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).AddRazorOptions(options => {
    options.ViewLocationFormats.Add("/{0}.cshtml");
    options.ViewLocationFormats.Add("/Views/Shared/LayoutPartials/{0}.cshtml");
});

builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataContext") ?? throw new InvalidOperationException("Connection string not found")));

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllUsers", policy => policy.RequireClaim("UserRole"));
    options.AddPolicy("Supervisor", policy => policy.RequireClaim("UserRole", UserRole.Supervisor.ToString(), UserRole.Administrator.ToString(), UserRole.Developer.ToString()));
    options.AddPolicy("Administrator", policy => policy.RequireClaim("UserRole", UserRole.Administrator.ToString(), UserRole.Developer.ToString()));
    options.AddPolicy("Developer", policy => policy.RequireClaim("UserRole", UserRole.Developer.ToString()));
    options.FallbackPolicy = options.DefaultPolicy;
});




builder.Services.AddTransient<IClaimsTransformation, CCClaimsTransformation>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
