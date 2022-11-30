using System.ComponentModel.DataAnnotations;

namespace ResearchesMVC.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        //[Required]
        //[Display(Name ="اسم المستخدم")]
        //public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }

        [Display(Name = "رقم الجوال ")]
        public string? PhoneNumber { get; set; }

        public List<string> Claims { get; set; }

        [Display(Name = " الصلاحيات")]
        public IList<string> Roles { get; set; }
    }
}
