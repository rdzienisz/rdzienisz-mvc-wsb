using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rdzienisz.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<rdzieniszContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("rdzieniszContext") ?? throw new InvalidOperationException("Connection string 'rdzieniszContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<rdzieniszContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapRazorPages();

app.Run();
