using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set;}
        public string Description { get; set;}
        public string? NewsTime { get; set;}
    }
}
