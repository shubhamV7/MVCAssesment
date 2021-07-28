using MVCAssesment.MVC.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCAssesment.MVC.ViewModels
{
    public class EmployeeSalaryDeptIndex
    {
        public Employee Employee { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Salary Amount")]
        public decimal SalaryAmount { get; set; }
    }
}