using Microsoft.AspNetCore.Identity;

namespace my_dotnet_store.Models;

public static class SeedDatabase
{
    public static async void Initialize(IApplicationBuilder app)
    {
        var userManager = app.ApplicationServices
                                .CreateScope()
                                .ServiceProvider
                                .GetRequiredService<UserManager<AppUser>>();

        var roleManager = app.ApplicationServices
                                .CreateScope()
                                .ServiceProvider
                                .GetRequiredService<RoleManager<AppRole>>();

        if(!roleManager.Roles.Any()) // Herhangi bir rol yoksa demek
        {
            var admin = new AppRole {Name = "Admin"};
            await roleManager.CreateAsync(admin);
        }
        
        if(!userManager.Users.Any())
        {
            var admin = new AppUser
            {
                AdSoyad = "Fatih Canıbek",
                UserName = "fatihcanibek",
                Email = "admin@gmail.com"
            };

            await userManager.CreateAsync(admin, "1234567");
            await userManager.AddToRoleAsync(admin, "Admin");

            var customer = new AppUser
            {
                AdSoyad = "Sadık Turan",
                UserName = "sadikturan",
                Email = "customer@gmail.com"
            };

            await userManager.CreateAsync(customer, "1234567");
        }
    }
}