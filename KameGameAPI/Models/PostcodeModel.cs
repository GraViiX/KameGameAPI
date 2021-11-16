using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class PostcodeModel
    {
        [Key]
        public int PostcodeId { get; set; }

        [Required]
        public int Postcode { get; set; }

        [Required]
        public string City { get; set; }
    }
}
