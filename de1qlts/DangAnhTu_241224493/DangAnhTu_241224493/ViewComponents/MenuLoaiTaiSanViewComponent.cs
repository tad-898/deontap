using DangAnhTu_241224493.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DangAnhTu_241224493.ViewComponents
{
    public class MenuLoaiTaiSanViewComponent : ViewComponent
    {
        private readonly QltaiSanContext _context;

        public MenuLoaiTaiSanViewComponent(QltaiSanContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loaiTaiSans = await _context.LoaiTaiSans.ToListAsync();
            return View(loaiTaiSans);
        }
    }
}