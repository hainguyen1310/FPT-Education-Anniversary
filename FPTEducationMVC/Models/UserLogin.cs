using System.ComponentModel.DataAnnotations;

namespace FPTEducationMVC.Models
{
    public class UserLogin
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; } = null!;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; } = null!;
    }
}
