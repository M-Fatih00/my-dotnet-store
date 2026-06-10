using Microsoft.AspNetCore.Mvc;
using my_dotnet_store.Models;

namespace my_dotnet_store.ViewComponents;

public class Navbar : ViewComponent
{
    private readonly DataContext _context;
    public Navbar(DataContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(_context.Kategoriler.ToList());
    }
}