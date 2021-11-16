using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class ShopModel
    {
        [Key]
        public int ShopId { get; set; }

        [ForeignKey("UserModel.UserID")]
        public int UserId { get; set; }
        public UserModel userModel { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public DateTime Bought { get; set; }

    }
}
