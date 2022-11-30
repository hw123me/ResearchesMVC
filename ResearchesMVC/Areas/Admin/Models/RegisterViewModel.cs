using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Areas.Admin.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="البريد الالكتروني مطلوب")]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمة المرور")]
        [Compare("Password",
            ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "الصلاحية")]
        public string? RoleName { get; set; }
    }
}
