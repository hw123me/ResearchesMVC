using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Models
{
    public class State
    {
        [Key]
       
        public int StateId { get; set; }

        [Required]
        [Display(Name = "المنطقة")]
        public string Name { get; set; }
    }
}
