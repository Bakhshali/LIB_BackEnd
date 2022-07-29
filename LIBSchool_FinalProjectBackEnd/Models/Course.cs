using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBSchool_FinalProjectBackEnd.Models
{
    public class Course
    {
        public int Id { get; set; }

        
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        public string SubName { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal GroupPrice { get; set; }

        
        [Column(TypeName = "decimal(5,2)")]
        public decimal? İndividualPrice { get; set; }
        
        public string İnformation { get; set; }
        
        public string BelongTitle { get; set; }

        public string BelongText { get; set; }

        public string Condition { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
