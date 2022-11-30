using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models
{
    public class OrderTool
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "رقم الطلب ")]
        public int OrderId { get; set; } = 1;

        [ForeignKey("OrderId")]

        public Order Order { get; set; }

        [Display(Name = "أدوات الدراسة")]
        public int StudyToolId { get; set; } = 1;

        [ForeignKey("StudyToolId")]

        public StudyTool StudyTool { get; set; }

    }
}
