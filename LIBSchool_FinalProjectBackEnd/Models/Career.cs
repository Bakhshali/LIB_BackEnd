using DataAnnotationsExtensions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Career
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."), StringLength(maximumLength: 50)]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."),MaxLength(10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon nömrəsi düzgün deyil(nömrə 0 ilə başlamalıdır).")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır.")]
        public string VacancyName { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır.")]
        public int? Experience { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır.")]
        public string Subject { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Image { get; set; }
    }
}
