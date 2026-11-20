using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DangAnhTu_241224493.ViewModels
{
    public class BookCreateViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        [Display(Name = "MaTL")]
        public int MaTl { get; set; }

        [Required(ErrorMessage = "TenSach không được để trống")]
        [StringLength(100, ErrorMessage = "TenSach tối đa 100 ký tự")]
        [Display(Name = "TenSach")]
        public string TenSach { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gia không được để trống")]
        [Range(50, 1000, ErrorMessage = "Gia phải là số từ 50 đến 1000")]
        [Display(Name = "Gia")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Anh không được để trống")]
        [RegularExpression(@"^.*\.(jpg|jpeg|png|webp|JPG|JPEG|PNG|WEBP)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .jpeg | .png | webp")]
        [Display(Name = "Anh")]
        public string Anh { get; set; } = string.Empty;

        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}