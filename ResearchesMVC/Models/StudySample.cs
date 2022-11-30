using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Models
{
    public class StudySample
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "العينة")]
        [StringLength(100)]
        public string? SampleName { get; set; }
    }
}
