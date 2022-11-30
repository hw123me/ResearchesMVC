using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="الحالة")]
        public string? Name { get; set; }

    }
}
