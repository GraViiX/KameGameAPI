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

        [ForeignKey("UserModel.UserId")]
        public int UserId { get; set; }
        public UserModel user { get; set; }

        //[ForeignKey("CardModel.CardId")]
        //public int CardId { get; set; }
        //public CardModel card { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public string Bought { get; set; }
    }
}
