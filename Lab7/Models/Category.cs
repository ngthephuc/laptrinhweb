
using System.ComponentModel.DataAnnotations;

namespace NetCoreMVC_LAB05.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Tên danh mục phải từ 3 đến 50 ký tự")]
        public string CategoryName { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string Description { get; set; } = string.Empty;
    }
}