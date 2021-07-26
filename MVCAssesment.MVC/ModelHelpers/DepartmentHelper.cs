using MVCAssesment.MVC.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCAssesment.MVC.ModelHelpers
{
    public class DepartmentHelper : IDepartmentHelper
    {
        public IEnumerable<Department> GetDepartments()
        {
            IEnumerable<Department> departments = new List<Department>();

            using (DBContext dBContext = new DBContext())
            {
                departments = dBContext.Departments.ToList();
            }

            return departments;
        }

        public Department GetDepartment(int id)
        {
            var department = new Department();

            using (DBContext dBContext = new DBContext())
            {
                department = dBContext.Departments.FirstOrDefault(d => d.DeptID == id);
            }

            return department;
        }

        public void AddDepartment(Department department)
        {
            using (DBContext dBContext = new DBContext())
            {
                dBContext.Departments.Add(department);
                dBContext.SaveChanges();
            }
        }

        public void UpdateDepartment(Department department)
        {
            using (DBContext dBContext = new DBContext())
            {
                dBContext.Entry(department).State = EntityState.Modified;
                dBContext.SaveChanges();
            }
        }

        public bool IfDepartmentExist(int id)
        {
            var isExist = false;

            using (DBContext dBContext = new DBContext())
            {
                isExist = dBContext.Departments.Any(d => d.DeptID == id);
            }

            return isExist;
        }

        public void DeleteDepartment(int id)
        {
            using (DBContext dBContext = new DBContext())
            {
                var dept = new Department() { DeptID = id };
                dBContext.Entry(dept).State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }
    }
}