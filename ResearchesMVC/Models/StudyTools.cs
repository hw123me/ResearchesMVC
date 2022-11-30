using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Models
{
    public class StudyTool
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "الأداة")]
        [StringLength(100)]
        public string? ToolName { get; set; }

    }
}
