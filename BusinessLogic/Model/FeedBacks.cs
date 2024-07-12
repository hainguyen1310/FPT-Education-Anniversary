using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Model
{
    [PrimaryKey(nameof(BlogId), nameof(UserId))]
    public class FeedBacks
    {
        [Display(Name = "Chọn danh mục blog")]
        public int BlogId { get; set; }
        [Display(Name = "Người tương tác")]
        public int UserId { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        public bool? Like {  get; set; }

        public virtual User? User { get; set; }

        public virtual Blog? Blog { get; set; }
    }
}
