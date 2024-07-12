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
    public class Achievement
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AchievementId { get; set; }
        [StringLength(100)]
        [Display(Name = "Chủ đề")]
        public string? AchievementTitle { get; set; }
        [StringLength(100)]
        [Display(Name = "Chủ đề con")]
        public string? AchievementSubtitle { get; set; }
		[StringLength(100)]
		[Display(Name = "Mô tả")]
		public string? AchievementDescription { get; set; }

        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; } = null;
    }
}
