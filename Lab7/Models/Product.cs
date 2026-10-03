
using System.ComponentModel.DataAnnotations;

namespace NetCoreMVC_LAB05.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Tên sản phẩm phải từ 3 đến 100 ký tự")]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "Giá sản phẩm")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(1, 1000000000,
            ErrorMessage = "Giá sản phẩm phải từ 1 đến 1 tỷ")]
        public decimal Price { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Mã danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }
    }
}