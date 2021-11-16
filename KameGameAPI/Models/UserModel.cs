using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UPassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int UTLF { get; set; }

        [ForeignKey("CardModel.CardId")]
        public int CardId { get; set; }
        public CardModel card { get; set; }

        [ForeignKey("RoleModel.RoleId")]
        public int RoleId { get; set; }
        public RoleModel role { get; set; }

        [ForeignKey("AddressModel.AddressId")]
        public int AddressId { get; set; }
        public AddressModel address { get; set; }
    }
}
