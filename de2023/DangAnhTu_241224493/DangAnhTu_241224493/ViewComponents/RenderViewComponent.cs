using Microsoft.AspNetCore.Mvc;
using DangAnhTu_241224493.Models;

namespace DangAnhTu_241224493.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;
        public RenderViewComponent(QlhangHoaContext context)
        {
            _context = context;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return View("RenderLeftMenu", loaiHangs);
        }
    }
}