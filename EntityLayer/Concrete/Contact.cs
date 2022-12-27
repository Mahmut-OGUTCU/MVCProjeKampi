using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserMail { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        public string Message { get; set; }

        public bool ContactisRead { get; set; }

        public int? ContactCreatedID { get; set; }

        public DateTime ContactCreatedDate { get; set; }

        public bool ContactisActive { get; set; }

        public int? ContactUpdatedID { get; set; }

        public DateTime? ContactUpdatedDate { get; set; }
    }
}
