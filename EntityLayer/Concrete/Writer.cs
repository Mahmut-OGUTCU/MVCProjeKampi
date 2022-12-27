using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurname { get; set; }

        [StringLength(200)]
        public string WriterImage { get; set; }

        [StringLength(200)]
        [Required]
        public string WriterMail { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }

        public ICollection<Content> Contents { get; set; }

        [StringLength(200)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public int? WriterCreatedID { get; set; }

        public DateTime WriterCreatedDate { get; set; }

        public bool WriterisActive { get; set; }

        public int? WriterUpdatedID { get; set; }

        public DateTime? WriterUpdatedDate { get; set; }
    }
}
