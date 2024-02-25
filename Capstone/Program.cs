using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Capstone.Models;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        public static async Task Main(string[] args)
        {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        
        builder.Services.AddDbContext<CapstoneContext>(
                                dbContextOptions => dbContextOptions
                                .UseMySql(
                                    builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                                )
                                )
                            );

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CapstoneContext>()
                .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 0;
        });

        WebApplication app = builder.Build();

        app.UseDeveloperExceptionPage();
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // using (var scope = app.Services.CreateScope())
        // {
        //     var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        //     string email = "admin@admin.com";
        //     string password = "admin123";

        //     if (await userManager.FindByEmailAsync(email) == null)
        //     {
        //         var user = new IdentityUser();
        //         user.UserName = email;
        //         user.Email = email;

        //         await userManager.CreateAsync(user, password);

        //         await userManager.AddToRoleAsync(user, "Admin");
        //     }

        // }



        app.Run();
        }
    }
}