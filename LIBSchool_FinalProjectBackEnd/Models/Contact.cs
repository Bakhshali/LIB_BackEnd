using System.ComponentModel.DataAnnotations;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."), StringLength(maximumLength: 15)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."), DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefon nömrəsi düzgün deyil(nömrə 0 ilə başlamalıdır).")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır."), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tələb olunan hissələr doldurulmalıdır.")]
        public string Subject { get; set; }
    }
}
