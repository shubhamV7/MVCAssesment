using MVCAssesment.MVC.Models;
using System.Collections.Generic;

namespace MVCAssesment.MVC.ModelHelpers
{
    public interface IDepartmentHelper
    {
        IEnumerable<Department> GetDepartments();

        Department GetDepartment(int id);

        void AddDepartment(Department department);

        void UpdateDepartment(Department department);

        bool IfDepartmentExist(int id);

        void DeleteDepartment(int id);
    }
}