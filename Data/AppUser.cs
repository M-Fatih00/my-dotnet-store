using Microsoft.AspNetCore.Identity;

namespace my_dotnet_store.Models;

public class AppUser : IdentityUser<int>
{
    public string AdSoyad { get; set; } = null!;
}