
using ResearchesMVC.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models
{

    //public enum GoalType
    //{
    //    [Display(Name = "ماجستير")]
    //    Master,

    //    [Display(Name = "دكتوراه")]
    //    Doctor,

    //    [Display(Name = "بحث تخرج")]
    //    GProject,

    //    [Display(Name = "متطلبات مادة دراسية")]
    //    StudySubReq,

    //    [Display(Name = "دراسية ميدانية")]
    //    EmpStudy,

    //    [Display(Name = "تكليف من جهة")]
    //    CommissionByOne,

    //    [Display(Name = " ترقية ")]
    //    Promotion,

    //    [Display(Name = "غرض آخر")]
    //    Other,

    //}
    //public enum Term
    //{
    //    [Display(Name = "الفصل الاول")]
    //    First,

    //    [Display(Name = "الفصل الثاني")]
    //    Second,

    //    [Display(Name = "الفصل الثالث")]
    //    Third,

    //}
    //public enum Marhala
    //{
    //    [Display(Name = "ابتدائي")]
    //    Primary,

    //    [Display(Name = "متوسط")]
    //    Middle,

    //    [Display(Name = " ثانوي")]
    //    Secondary,

    //    [Display(Name = " تعليم الكبار/الكبيرات")]
    //    AdultEdu,

    //    [Display(Name = "تعليم خاص/التربية الخاصة")]
    //    PrivateEdu,

    //    [Display(Name = " التعليم الأهلي")]
    //    PEducation,

    //    [Display(Name = " قطاع الإدارة")]
    //    ManageSector,

    //    [Display(Name = " غير ذلك")]
    //    Other,

    //}

    public class Order
    {
        [Key]
        [Display(Name = "رقم الطلب")]
        public int Id { get; set; }

        [Display(Name = " اسم الباحث")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = " اسم الباحث")]
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
        public string? Section{ get; set; }

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


        [Required, Display(Name ="المرحلة الدراسية")]
        public string? School_Type { get; set; }


        [Required, Display(Name = "العام الدراسي")]
        public string? Term_Year  { get; set; }

        [Required, Display(Name ="الفصل الدراسي")]
        public string? Term { get; set; }

        [Required, Display(Name = "حالة الطلب")]
        public int? StatusId { get; set; } = 1;

        [ForeignKey("StatusId")]
        [Display(Name = "حالة الطلب")]
        public Status? Status { get; set; } 

        
        public Boolean? Active { get; set; } 
       

        [Display(Name ="ملاحظات")]
        public string? Notes { get; set; }

        [Display(Name = "تاريخ الطلب")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? CreatedOn { get; set; }

        public ICollection<OrderTool>? Tools { get; set; } = new HashSet<OrderTool>();
        public ICollection<OrderSample>? Samples { get; set; } = new HashSet<OrderSample>();

    }
   
}
