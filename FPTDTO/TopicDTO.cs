using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPTDTO
{
	public class TopicDTO
	{
		public int TopicId { get; set; }
		public string TopicTitle { get; set; }
		public string? TopicSubtitle { get; set; }
		public string Content { get; set; }

		public string? ImageUrl { get; set; }
		[NotMapped]
		public IFormFile? ImageFile { get; set; } = null;
		public int TopicCategoryId { get; set; }

		public string TopicCategoryName { get; set; }

	}
}
