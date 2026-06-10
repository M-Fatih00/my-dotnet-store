using my_dotnet_store.Models;
using my_dotnet_store.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IEmailService, SmtpEmailService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

/* <---Configure Identity---> */
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options => 
{
    options.Password.RequiredLength = 7;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;

    options.User.RequireUniqueEmail = true;
    // options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";

    options.Lockout.MaxFailedAccessAttempts = 5; // 5 kere yanlış giirilirse->
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3); // 3 dakika engelle demek.
});
/* <---Configure Identity---> */

// <---Configure Authentication--->
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; //Login path
    options.AccessDeniedPath = "/Account/AccessDenied"; //Kullanıcının yetkisiz bir alana gittiğinde 
    options.ExpireTimeSpan = TimeSpan.FromDays(30); //Cookie bilgisinin ne kadar süre geçerli olacağı
    options.SlidingExpiration = true; //her talep yapıldığında cookie süresi yenilensin mi = true;
});
// <---Configure Authentication--->

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // Authentication aktif olması için
app.UseAuthorization();

// app.MapStaticAssets();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "urunler_by_kategori",
    pattern: "urunler/{url?}",
    defaults: new { controller = "Urun", action = "List"})
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

SeedDatabase.Initialize(app);

app.Run();
