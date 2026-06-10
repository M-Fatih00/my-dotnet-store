using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using my_dotnet_store.Models;

namespace my_dotnet_store.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly DataContext _context;
    public AdminController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var model = new AdminDashboardModel
        {
            ToplamSatis = _context.Orders.Sum(o => (double?)o.ToplamFiyat) ?? 0,
            SiparisSayisi = _context.Orders.Count(),
            UrunSayisi = _context.Urunler.Count(),
            UyeSayisi = _context.Users.Count(),
            SonSiparisler = _context.Orders
                .OrderByDescending(o => o.SiparisTarihi)
                .Take(5)
                .ToList()
        };

        return View(model);
    }
}