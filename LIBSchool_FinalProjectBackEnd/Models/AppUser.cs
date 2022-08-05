using Microsoft.AspNetCore.Identity;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
