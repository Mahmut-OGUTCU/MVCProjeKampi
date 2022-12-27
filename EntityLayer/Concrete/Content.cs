using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public int? WriterID { get; set; }
        public virtual Writer Writer { get; set; }

        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        public int ContentCreatedID { get; set; }

        public DateTime ContentCreatedDate { get; set; }

        public bool ContentisActive { get; set; }

        public int? ContentUpdatedID { get; set; }

        public DateTime? ContentUpdatedDate { get; set; }
    }
}
