using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class CardModel
    {
        [Key]
        public int CardId { get; set; }
        [ForeignKey("CardTypeModel.CardTypeId")]
        public int CardTypeId { get; set; }
        public CardTypeModel cardType { get; set; }
        [Required]
        public int CardNumber { get; set; }
        [Required]
        public string CardDate { get; set; }
        [Required]
        public int SecurityNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
