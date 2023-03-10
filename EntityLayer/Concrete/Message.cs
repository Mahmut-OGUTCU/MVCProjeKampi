using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string ReceiverMail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public bool MessageisRead { get; set; }

        public int MessageCreatedID { get; set; }

        public DateTime MessageCreatedDate { get; set; }

        public bool MessageisActive { get; set; }

        public int? MessageUpdatedID { get; set; }

        public DateTime? MessageUpdatedDate { get; set; }
    }
}
