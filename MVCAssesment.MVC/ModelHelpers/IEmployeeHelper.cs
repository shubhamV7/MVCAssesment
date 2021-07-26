using MVCAssesment.MVC.Models;
using System.Collections.Generic;

namespace MVCAssesment.MVC.ModelHelpers
{
    public interface IEmployeeHelper
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(int id);

        bool IfEmployeeExist(int id);

        void DeleteEmployee(int id);

        void UpdateEmployee(Employee employee);

        void AddEmployeeAndSalary(Employee employee);
    }
}