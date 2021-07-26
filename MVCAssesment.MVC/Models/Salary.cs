using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAssesment.MVC.Models
{
    public class Salary
    {
        [Key]
        [ForeignKey("Employee")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Salary Amount")]
        public decimal SalaryAmount { get; set; }

        public Employee Employee { get; set; }
    }
}