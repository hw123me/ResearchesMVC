using Microsoft.AspNetCore.Mvc.Rendering;
using ResearchesMVC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models.ViewModel
{
    public class OrderViewModel
    {
        // public Order? Order { get; set; }
        public int Id { get; set; }
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        [Display(Name = "الجامعة")]
        public string? Uneviersity { get; set; }

        [Required]
        [Display(Name = "المدينة")]
        public string? City_Univ { get; set; }

        [Required]
        [Display(Name = "الكلية")]
        public string? College { get; set; }

        [Required]
        [Display(Name = "القسم")]
        public string? Section { get; set; }

        [Required]
        [Display(Name = "التخصص")]
        public string? Specialize { get; set; }

        [Required]
        [Display(Name = "عنوان الدراسة")]
        public string? StudyTitle { get; set; }

        [Required]
        [Display(Name = "الغرض من الدراسة ")]
        public string? Goal { get; set; }



        [NotMapped]
        [Display(Name = "رفع أدوات الدراسة")]
        public IFormFile? ToolsPdf { get; set; }

        [Display(Name = "المرفقات")]
        public string? ToolsPdfUrl { get; set; }


        [Required, Display(Name = "المرحلة الدراسية")]
        public string? School_Type { get; set; }


        [Required, Display(Name = "العام الدراسي")]
        public string? Term_Year { get; set; }

        [Required, Display(Name = "الفصل الدراسي")]
        public string? Term { get; set; }

        [Required, Display(Name = "حالة الطلب")]
        public int? StatusId { get; set; } = 1;

        [ForeignKey("StatusId")]

        public Status? Status { get; set; }


        public Boolean? Active { get; set; }


        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        [Display(Name = "تاريخ الطلب")]
        public DateTime? CreatedOn { get; set; }

        public IList<SelectListItem> StudyTools { get; set; }
        public IList<SelectListItem> StudySamples { get; set; }

        public List<SelectListItem> ToSide { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "المدير العام", Text = "المدير العام" },
            new SelectListItem { Value = "مساعد/ة المدير العام للشؤون التعليمية", Text = "مساعد/ة المدير العام للشؤون التعليمية" },
            new SelectListItem { Value = "مساعد/ة المدير العام للشؤون المدرسية", Text = "مساعد/ة المدير العام للشؤون المدرسية"  },
            new SelectListItem { Value = "مدير/ة مكتب", Text = "مدير/ة مكتب"  },
            new SelectListItem { Value = "مدير/ة إدارة", Text = "مدير/ة إدارة"  },
            new SelectListItem { Value = "رئيس/ة قسم", Text = "رئيس/ة قسم"  },
            new SelectListItem { Value = "مدير/ة مدرسة", Text = "مدير/ة مدرسة" },


        };
        public string OfficeAdmin { get; set; }
        public string OrgAdmin { get; set; }
        public string SectionAdmin { get; set; }
        public string SchoolAdmin { get; set; }
    }
    
}
