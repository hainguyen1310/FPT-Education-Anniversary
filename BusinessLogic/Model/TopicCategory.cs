using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class TopicCategory
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TopicCategoryId { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên chủ đề")]
        [StringLength(100)]
        [Display(Name = "Chủ đề")]
        public string TopicName { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mô tả")]
        [StringLength(100)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Topic>? Topics { get; set; }
    }
}
