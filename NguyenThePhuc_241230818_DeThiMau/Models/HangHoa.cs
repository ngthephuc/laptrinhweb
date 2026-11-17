
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NguyenThePhuc_241230818_DeThiMau.Models;

[Table("HangHoa")]
public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    [StringLength(50)]
    public string TenHang { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    [Range(typeof(decimal), "100", "5000",
        ErrorMessage = "Giá phải là số và nằm trong khoảng 100 đến 5000")]
    public decimal? Gia { get; set; }

    [StringLength(100)]
    [RegularExpression(@"^.+\.(jpg|png|gif|tiff)$",
        ErrorMessage = "Tên file ảnh phải có đuôi .jpg, .png, .gif hoặc .tiff")]
    public string? Anh { get; set; }

    [ForeignKey("MaLoai")]
    [InverseProperty("HangHoas")]
    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
