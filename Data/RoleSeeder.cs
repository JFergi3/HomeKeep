using Microsoft.AspNetCore.Identity;
using HomeKeep.Models;

namespace HomeKeep.Data;

// Creates the Manager role and assigns it to the configured administrator.
public static class RoleSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<HomeKeepUser>>();
        var config = services.GetRequiredService<IConfiguration>();

        if (!await roleManager.RoleExistsAsync("Manager"))
        {
            await roleManager.CreateAsync(new IdentityRole("Manager"));
        }

        var email = config["Admin:Email"];

        if (string.IsNullOrEmpty(email))
        {
            return;
        }

        var member = await userManager.FindByEmailAsync(email);

        if (member != null && !await userManager.IsInRoleAsync(member, "Manager"))
        {
            await userManager.AddToRoleAsync(member, "Manager");
        }
    }
}