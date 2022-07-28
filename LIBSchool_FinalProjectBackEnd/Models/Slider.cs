using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        public string Subtitle { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
