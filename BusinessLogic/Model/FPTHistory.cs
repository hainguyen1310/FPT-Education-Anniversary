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
    public class FPTHistory
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FPTHistoryId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Year { get; set; }
        [Display(Name = "Chủ đề")]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } = null;
    }
}
