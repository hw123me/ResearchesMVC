using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Areas.Admin.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }
    }
}
