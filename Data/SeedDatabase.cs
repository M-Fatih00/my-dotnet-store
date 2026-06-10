using Microsoft.AspNetCore.Identity;

namespace my_dotnet_store.Models;

public static class SeedDatabase
{
    public static async Task Initialize(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;

        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

        if (!roleManager.Roles.Any()) 
        {
            var admin = new AppRole { Name = "Admin" };
            await roleManager.CreateAsync(admin);
        }

        if (!userManager.Users.Any())
        {
            var admin = new AppUser
            {
                AdSoyad = "Fatih Mehmet",
                UserName = "fatihmehmet",
                Email = "admin@gmail.com"
            };

            await userManager.CreateAsync(admin, "1234567");
            await userManager.AddToRoleAsync(admin, "Admin");

            var customer = new AppUser
            {
                AdSoyad = "Mehmet Fatih",
                UserName = "mehmetfatih",
                Email = "customer@gmail.com"
            };

            await userManager.CreateAsync(customer, "1234567");
        }
    }
}