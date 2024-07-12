using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class Message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        public string Query { get; set; }

        public string Response { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateTime { get; set; }

        public int UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
