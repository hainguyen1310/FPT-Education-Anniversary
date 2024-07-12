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
    public class Topic
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập đề tài")]
        [StringLength(100)]
        [Display(Name = "Đề tài")]
        public string TopicTitle { get; set; }
        [StringLength(100)]
        [Display(Name = "Chủ đề con")]
        public string? TopicSubtitle { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập nội dung")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } = null;
        [Display(Name = "Chọn danh mục chủ đề")]
        public int TopicCategoryId { get; set; }

        public virtual TopicCategory? TopicCategory { get; set; }

    }
}
