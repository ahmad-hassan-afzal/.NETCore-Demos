using System.ComponentModel.DataAnnotations;

namespace Application.Repositories.Company.DTOs
{
    public class CompanyReadDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Website { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
    }
}