using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCAssesment.MVC.Models
{
    public class Department
    {
        [Key]
        public int DeptID { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Department Name")]
        public string DptName { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}