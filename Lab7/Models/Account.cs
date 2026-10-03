
using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreMVC_LAB05.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ Email")]
        [Required(ErrorMessage = "Địa chỉ Email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ Email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Ảnh đại diện")]
        [Required(ErrorMessage = "Ảnh đại diện không được để trống")]
        public string Avatar { get; set; } = string.Empty;

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Link Facebook phải đúng định dạng URL")]
        public string Facebook { get; set; } = string.Empty;
    }
}