using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<BasketItem> Basket { get; set; }
    }
}
