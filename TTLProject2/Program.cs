using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TTLProject2.Bussiness;
using TTLProject2.Areas.Identity.Data;
using TTLProject2.Data;
using TlSchoolProject.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IReadataRepository, ReadataRepository>();
builder.Services.AddSingleton<IWriteDataRepository, WriteDataRepository>();
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();
//builder.Services.AddDefaultIdentity<ApplicationUser>()
//    .AddRoles<IdentityRole>()
//        .AddEntityFrameworkStores<AuthDbContext>()
//        .AddDefaultTokenProviders();
var config = builder.Configuration;
builder.Services.ConfigureAll<AppSetting>(options =>
{
	options.ConnectionString = config.GetConnectionString("DefaultConnection");

});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddMvc();
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
