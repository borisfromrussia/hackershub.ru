using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class WebsiteDtInBase
    {
        [Required]
        public string WebsiteName { get; set; }
        [Required]
        public string LockKey { get; set; }
    }
}
