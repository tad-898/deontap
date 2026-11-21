using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DangAnhTu_241224493.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }

    [Display(Name = "Loại tài sản")]
    public int? MaLoai { get; set; }

    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    [Display(Name = "Tên tài sản")]
    public string? TenTs { get; set; }

    [Required(ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    [Display(Name = "Nguyên giá (triệu)")]
    public decimal? NguyenGia { get; set; }

    [Required(ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    [Display(Name = "Tên file ảnh")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; }
}