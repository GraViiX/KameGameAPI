using KameGameAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.DTOs
{
    public class UserResp
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int UTLF { get; set; }
        public int CardId { get; set; }
        public CardModel card { get; set; }
        public int RoleId { get; set; }
        public RoleModel role { get; set; }
        public int AddressId { get; set; }
        public AddressModel address { get; set; }
    }
}
