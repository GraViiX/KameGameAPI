using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.DTOs
{
    public class CardResp
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public int CardTypeId { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
