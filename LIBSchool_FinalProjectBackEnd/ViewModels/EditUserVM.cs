using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.ViewModels
{
    public class EditUserVM
    {
        [Required, StringLength(maximumLength: 15)]
        public string Name { get; set; }

        [Required, StringLength(maximumLength: 15)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
