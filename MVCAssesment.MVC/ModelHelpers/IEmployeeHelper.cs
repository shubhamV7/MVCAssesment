using MVCAssesment.MVC.Models;
using MVCAssesment.MVC.ViewModels;
using System.Collections.Generic;

namespace MVCAssesment.MVC.ModelHelpers
{
    public interface IEmployeeHelper
    {
        IEnumerable<Employee> GetEmployees();

        IEnumerable<EmployeeSalaryDeptIndex> GetEmployeesOrderBySalaryDesc();

        Employee GetEmployee(int id);

        bool IfEmployeeExist(int id);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employee employee);

        void AddEmployeeAndSalary(Employee employee);
    }
}