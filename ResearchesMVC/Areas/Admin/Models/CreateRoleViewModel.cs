using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Areas.Admin.Models
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "اسم الصلاحية مطلوب")]
        [Display(Name ="اسم الصلاحية")]
        public string RoleName { get; set; }
    }
}
