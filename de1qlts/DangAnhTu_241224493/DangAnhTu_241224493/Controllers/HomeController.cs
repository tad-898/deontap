using DangAnhTu_241224493.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DangAnhTu_241224493.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _context;

        public HomeController(QltaiSanContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var taiSans = await _context.TaiSans
                .FromSqlRaw(@"
                    SELECT MaTs,
                           ISNULL(MaLoai, 0) AS MaLoai,
                           ISNULL(CAST(TenTs AS NVARCHAR(MAX)), N'') AS TenTs,
                           ISNULL(CAST(NguyenGia AS DECIMAL(18,2)), 0) AS NguyenGia,
                           ISNULL(CAST(Anh AS NVARCHAR(MAX)), N'') AS Anh
                    FROM TaiSan
                    WHERE NguyenGia IS NOT NULL AND NguyenGia >= 20")
                .AsNoTracking()
                .ToListAsync();
            return View(taiSans);
        }

        public async Task<IActionResult> LocTaiSanTheoLoai(int maLoai)
        {
            var taiSans = await _context.TaiSans
                .FromSqlRaw(@"
                    SELECT MaTs,
                           ISNULL(MaLoai, 0) AS MaLoai,
                           ISNULL(CAST(TenTs AS NVARCHAR(MAX)), N'') AS TenTs,
                           ISNULL(CAST(NguyenGia AS DECIMAL(18,2)), 0) AS NguyenGia,
                           ISNULL(CAST(Anh AS NVARCHAR(MAX)), N'') AS Anh
                    FROM TaiSan
                    WHERE MaLoai = {0}", maLoai)
                .AsNoTracking()
                .ToListAsync();
            return PartialView("_DanhSachTaiSan", taiSans);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaiSan taiSan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiSan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiTaiSans, "MaLoai", "TenLoai", taiSan.MaLoai);
            return View(taiSan);
        }
    }
}