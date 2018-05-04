using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Paragliding_Management_System.Identity;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Paraglidin_Management_System.Data
{
    public static class DbInitializer
{
    public static async Task InitializeAsync(UsersDbContext context, IServiceProvider serviceProvider)
    {
            try
            {
                context.Database.EnsureCreated();
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Superuser", "Staff", "Client" };
                IdentityResult roleResult;
                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
                var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                var _user = await userManager.FindByNameAsync(config.GetSection("AppSettings")["UserName"]);
                if (_user == null)
                {
                    var poweruser = new AppUser
                    {
                        UserName = config.GetSection("AppSettings")["UserName"]
                    };
                    string UserPassword = config.GetSection("AppSettings")["UserPassword"];
                    var createPowerUser = await userManager.CreateAsync(poweruser, UserPassword);
                    if (createPowerUser.Succeeded)
                    {
                        await userManager.AddToRoleAsync(poweruser, "Superuser");
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
    }
}
}
