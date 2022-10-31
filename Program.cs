using bugTracker.Data;
using Microsoft.EntityFrameworkCore;
using bugTracker.Repositories;
using Microsoft.AspNetCore.Identity;
using bugTracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<BancoContext>();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();


var app = builder.Build();

var scope = app.Services.CreateScope();

var ctx = scope.ServiceProvider.GetRequiredService<BancoContext>();
var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

ctx.Database.EnsureCreated();

var adminRole = new IdentityRole("Admin");

if(!ctx.Roles.Any())
{
    roleMgr.CreateAsync(adminRole).GetAwaiter().GetResult();
}

if(!ctx.Users.Any(u => u.UserName == "admin"))
{
    var adminUser = new ApplicationUser 
    {
       UserName = "admin",
       Email = "admin@test.com",
       Nome = "Admin",
       Cargo = "Admin"
    };
    userMgr.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
    userMgr.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
}

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//}

app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
