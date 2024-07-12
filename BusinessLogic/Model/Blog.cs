using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class Blog
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập chủ đề")]
        [StringLength(100)]
        [Display(Name = "Chủ đề")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập nội dung")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [Display(Name = "Người đăng bài")]
        public int UserPostId { get; set; }

        public virtual User? UserPost { get; set; }

        public ICollection<FeedBacks>? FeedBack { get; set; }
    }
}
