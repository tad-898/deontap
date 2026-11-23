<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using DangAnhTu_241224493.Models;
using DangAnhTu_241224493.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DangAnhTu_241224493.Models;
>>>>>>> 3ab655a (De 2023)

namespace DangAnhTu_241224493.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
        private readonly QLNhaSachContext _context;

        public HomeController(QLNhaSachContext context)
=======
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext context)
>>>>>>> 3ab655a (De 2023)
        {
            _context = context;
        }

<<<<<<< HEAD

        public async Task<IActionResult> Index(int? id, string? categoryName)
        {
            IQueryable<Sach> query = _context.Saches
                .Include(s => s.MaTlNavigation)
                .Where(s => s.Gia != null);

            string title = "ĐẶNG ANH TÚ";

            if (id.HasValue && id.Value > 0)
            {
                query = query.Where(s => s.MaTl == id.Value);
                var category = await _context.TheLoais.FindAsync(id.Value);
                title = !string.IsNullOrWhiteSpace(categoryName)
                    ? categoryName
                    : (category?.TenTl ?? "THỂ LOẠI");
            }
            else
            {
                query = query.Where(s => s.Gia >= 100);
                title = string.IsNullOrWhiteSpace(categoryName) ? "ĐẶNG ANH TÚ" : categoryName;
            }

            var books = await query.OrderBy(s => s.MaSach).ToListAsync();

            var vm = new BookSectionViewModel
            {
                SectionTitle = title,
                Books = books
            };

            return View(vm);
        }

        public async Task<IActionResult> FilterByCategory(int? id, string? categoryName)
        {
            IQueryable<Sach> query = _context.Saches
                .Include(s => s.MaTlNavigation)
                .Where(s => s.Gia != null);

            string title = "ĐẶNG ANH TÚ";

            if (id.HasValue && id.Value > 0)
            {
                query = query.Where(s => s.MaTl == id.Value);
                var category = await _context.TheLoais.FindAsync(id.Value);
                title = !string.IsNullOrWhiteSpace(categoryName)
                    ? categoryName
                    : (category?.TenTl ?? "THỂ LOẠI");
            }
            else
            {
                query = query.Where(s => s.Gia >= 100);
                title = string.IsNullOrWhiteSpace(categoryName) ? "ĐẶNG ANH TÚ" : categoryName;
            }

            var books = await query.OrderBy(s => s.MaSach).ToListAsync();

            var vm = new BookSectionViewModel
            {
                SectionTitle = title,
                Books = books
            };

            return PartialView("_DangAnhTu_MainContent", vm);

        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new BookCreateViewModel
            {
                Categories = await _context.TheLoais
                    .OrderBy(t => t.MaTl)
                    .Select(t => new SelectListItem
                    {
                        Value = t.MaTl.ToString(),
                        Text = t.TenTl
                    })
                    .ToListAsync()
            };

            return View(vm);
=======
        public IActionResult Index()
        {
            var hangHoas = _context.HangHoas
                                   .Where(h => h.Gia != null && h.Gia >= 100)
                                   .ToList();
            return View(hangHoas);
        }

        public IActionResult FilterByLoai(int maLoai)
        {
            var hangHoas = _context.HangHoas
                                   .Where(h => h.MaLoai == maLoai && h.Gia != null && h.Gia >= 100)
                                   .ToList();
            return PartialView("_ProductListPartial", hangHoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
>>>>>>> 3ab655a (De 2023)
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _context.TheLoais
                    .OrderBy(t => t.MaTl)
                    .Select(t => new SelectListItem
                    {
                        Value = t.MaTl.ToString(),
                        Text = t.TenTl
                    })
                    .ToListAsync();

                return View(model);
            }

            var newBook = new Sach
            {
                MaTl = model.MaTl,
                TenSach = model.TenSach.Trim(),
                Gia = model.Gia,
                Anh = model.Anh.Trim()
            };

            _context.Saches.Add(newBook);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
=======
        public IActionResult Create(HangHoa hangHoa)
        {
            ModelState.Remove("MaLoaiNavigation");

            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hangHoa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
>>>>>>> 3ab655a (De 2023)
        }
    }
}