using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(50)]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        [StringLength(100)]
        [Display(Name = "Họ tên")]
        public string? FullName { get; set; }
        [Display(Name = "Địa chỉ email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Yêu cầu nhập thư điện tử")]
        public string Email { get; set; }
        public string? Phone { get; set; }

        public string? Avatar { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } = null;
        public string? Address { get; set; }

        public virtual ICollection<Message>? Message { get; set; }

        public virtual ICollection<Blog>? Blog { get; set; }

        public virtual ICollection<FeedBacks>? FeedBack { get; set; }
    }
}
