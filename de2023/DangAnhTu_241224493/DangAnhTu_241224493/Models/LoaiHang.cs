namespace DangAnhTu_241224493.Models
{
    public partial class LoaiHang
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; } = string.Empty;

        public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
    }
}