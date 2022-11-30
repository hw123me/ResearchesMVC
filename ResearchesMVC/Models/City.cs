using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models
{
    public class City
    {
        [Key]
       
        public int CityId { get; set; }

        [Required]
        [Display(Name = "المدينة")]
        public string Name { get; set; }

       [Required, Display(Name ="المنطقة")]
        public int StateId { get; set; }
        [ForeignKey("StateId")]
       
        public State? State { get; set; }
    }
}
