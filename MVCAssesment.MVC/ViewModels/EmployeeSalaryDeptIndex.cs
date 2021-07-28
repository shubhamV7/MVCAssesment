using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAssesment.MVC.ViewModels
{
    public class EmployeeSalaryDeptIndex
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Joining")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }

        public string Mobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Address { get; set; }

        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public decimal SalaryAmount { get; set; }
    }
}