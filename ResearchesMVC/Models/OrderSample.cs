using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchesMVC.Models
{
    public class OrderSample
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "رقم الطلب ")]
        public int OrderId { get; set; } = 1;

        [ForeignKey("OrderId")]

        public Order Order { get; set; }

        [Display(Name = "عينة الدراسة")]
        public int StudySampleId { get; set; } = 1;

        [ForeignKey("StudySampleId")]

        public StudySample StudySample { get; set; }

       
    }
}
