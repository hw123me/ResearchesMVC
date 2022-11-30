using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Areas.Admin.Models
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "اسم الصلاحية مطلوب")]

        [Display(Name = "اسم الصلاحية")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
