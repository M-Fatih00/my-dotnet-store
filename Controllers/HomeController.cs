using Microsoft.AspNetCore.Mvc;
using my_dotnet_store.Models;

namespace my_dotnet_store.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        var urunler = _context.Urunler.Where(urun => urun.Aktif && urun.Anasayfa).ToList();
        ViewData["Kategoriler"] = _context.Kategoriler.ToList();
        return View(urunler);
    }
}
