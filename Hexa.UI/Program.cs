using Hexa.BL.Repositories;
using Hexa.DAL.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;

class Program
{
    static void Main(string[] args)
    { 
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<SQLContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CS1")));
        builder.Services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
        {
            opt.ExpireTimeSpan = TimeSpan.FromMinutes(15);
            opt.LoginPath = "/admin/login"; 
            opt.LogoutPath = "/admin/logout"; 
        });


        var app = builder.Build();
        if (!app.Environment.IsDevelopment()) app.UseStatusCodePagesWithRedirects("hata/{0}");
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication(); 
        app.UseAuthorization(); 
        app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

        app.Run();

    }
}