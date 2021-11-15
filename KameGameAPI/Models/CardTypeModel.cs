using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Models
{
    public class CardTypeModel
    {
        [Key]
        public int CardTypeId { get; set; }
    }
}
