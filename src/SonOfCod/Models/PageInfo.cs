using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonOfCod.Models
{
    [Table("PageInfo")]
    public class PageInfo
    {
        [Key]
        public int Id { get; set; }
        public string NewsletterBody { get; set; }
        public string LandingTitle { get; set; }
        public string LandingBody { get; set; }
    }
}
