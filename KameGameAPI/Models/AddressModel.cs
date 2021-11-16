using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class AddressModel
    {
        [Key]
        public int AddressId { get; set; }

        [ForeignKey("PostcodeModel.PostCodeId")]
        public int PostCodeId { get; set; }
        public PostcodeModel postCode { get; set; }

        [Required]
        public string StreetNames { get; set; }
    }
}
