using DangAnhTu_241224493.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DangAnhTu_241224493.ViewComponents
{
    [ViewComponent(Name = "NavMenu")]
    public class NavMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext _context;

        public NavMenuViewComponent(QLNhaSachContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.TheLoais
                .OrderBy(t => t.MaTl)
                .ToListAsync();

            return View(categories);
        }
    }
}