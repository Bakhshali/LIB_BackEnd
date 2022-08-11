using LIBSchool_FinalProjectBackEnd.Models;
using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.ViewModels
{
    public class ForgotVM
    {
        public AppUser AppUser { get; set; }

        public string Token { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
