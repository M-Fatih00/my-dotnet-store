using Microsoft.AspNetCore.Mvc;
using my_dotnet_store.Models;

namespace my_dotnet_store.ViewComponents;

public class Slider : ViewComponent
{
    private readonly DataContext _context;

    public Slider(DataContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(_context.Sliderlar.Where(i => i.Aktif).OrderBy(i => i.Index).ToList());
    }
}