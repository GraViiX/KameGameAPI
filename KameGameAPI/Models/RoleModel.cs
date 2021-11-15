using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
