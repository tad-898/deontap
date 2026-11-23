using DangAnhTu_241224493.Models;

namespace DangAnhTu_241224493.ViewModels
{
    public class BookSectionViewModel
    {
        public string SectionTitle { get; set; } = "ĐẶNG ANH TÚ";
        public List<Sach> Books { get; set; } = new();
    }
}