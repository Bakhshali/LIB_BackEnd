using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public string YoutubeImage { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
