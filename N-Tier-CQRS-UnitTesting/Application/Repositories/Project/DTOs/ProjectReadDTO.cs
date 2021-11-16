using System.ComponentModel.DataAnnotations;

namespace Application.Repositories.Project.DTOs
{
    public class ProjectReadDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(5)]
        public string Code { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int CompanyID { get; set; }
    }
}
