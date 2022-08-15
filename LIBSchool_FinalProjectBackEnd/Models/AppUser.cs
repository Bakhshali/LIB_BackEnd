using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public List<BasketItem> Basket { get; set; }

        public List<WishlistItem> Wishlists { get; set; }

        public bool IsBlock { get; set; }

    }
}
