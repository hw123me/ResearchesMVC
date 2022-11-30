using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Display(Name = "مدير التعليم")]
        public string? AdminName { get; set; }

        [NotMapped]
        public IFormFile? SignImage { get; set; }

        [Display(Name = "التوقيع")]
        public string? SignImageUrl { get; set; }
    }
}
