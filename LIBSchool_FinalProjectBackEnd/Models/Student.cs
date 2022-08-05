using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ResultImage { get; set; }

        public int ResultId { get; set; }
        public Result Result { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
