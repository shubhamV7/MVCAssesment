using MVCAssesment.MVC.Models;
using MVCAssesment.MVC.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCAssesment.MVC.ModelHelpers
{
    public class EmployeeHelper : IEmployeeHelper
    {
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using (DBContext dBContext = new DBContext())
            {
                employees = dBContext.Employees.Include(e => e.Department)
                                               .Include(e => e.Salary)
                                               .ToList();
            }


            var ordered = employees.OrderByDescending(e => e.Salary.SalaryAmount)
                                       .ThenBy(e => e.Name).ToList();
            return ordered;
        }

        public IEnumerable<EmployeeSalaryDeptIndex> GetEmployeesOrderBySalaryDesc()
        {
            var employees = new List<EmployeeSalaryDeptIndex>();

            using (DBContext dBContext = new DBContext())
            {
                //Linq query optimized
                employees = dBContext.Employees.Select(e => new EmployeeSalaryDeptIndex()
                                                {
                                                    Employee = e,
                                                    DepartmentName = e.Department.DptName,
                                                    SalaryAmount = e.Salary.SalaryAmount
                                                })
                                               .OrderByDescending(e => e.SalaryAmount)
                                               .ThenBy(e => e.Employee.Name)
                                               .ToList();
            }

            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = new Employee();
            using (DBContext dBContext = new DBContext())
            {
                employee = dBContext.Employees.Include(e => e.Department)
                                                .Include(e => e.Salary)
                                       .Where(e => e.EmployeeId == id)
                                       .FirstOrDefault();
            }

            return employee;
        }

        public bool IfEmployeeExist(int id)
        {
            bool isExist = false;
            using (DBContext dBContext = new DBContext())
            {
                isExist = dBContext.Employees
                                       .Any(e => e.EmployeeId == id);
            }
            return isExist;
        }

        public void DeleteEmployee(int id)
        {
            using (DBContext dBContext = new DBContext())
            {
                var emp = new Employee() { EmployeeId = id };
                dBContext.Entry(emp).State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (DBContext dBContext = new DBContext())
            {
                dBContext.Entry(employee).State = EntityState.Modified;
                dBContext.Entry(employee.Salary).State = EntityState.Modified;
                dBContext.SaveChanges();
            }
        }

        public void AddEmployeeAndSalary(Employee employee)
        {
            using (DBContext dBContext = new DBContext())
            {
                dBContext.Employees.Add(employee);
                dBContext.SaveChanges();
            }
        }
    }
}