using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DangAnhTu_241224493.Models
{
    [Table("HangHoa")]
    public partial class HangHoa
    {
        [Key]
        public int MaHang { get; set; }

        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống")]
        [StringLength(50)]
        public string TenHang { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(100, 5000, ErrorMessage = "Giá phải là số và nằm trong khoảng 100 đến 5000")]
        [Column(TypeName = "numeric(18, 0)")]
        public decimal? Gia { get; set; }

        [Required(ErrorMessage = "Ảnh không được để trống")]
        [StringLength(100)]
        [RegularExpression(@"^.*\.(jpg|JPG|png|PNG|gif|GIF|tiff|TIFF)$", ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
        public string? Anh { get; set; }

        [ForeignKey(nameof(MaLoai))]
        public virtual LoaiHang? MaLoaiNavigation { get; set; }
    }
}