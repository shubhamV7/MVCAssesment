using MVCAssesment.MVC.ModelHelpers;
using System.Linq;
using System.Web.Mvc;

namespace MVCAssesment.MVC.Controllers
{
    [HandleError]
    public class EmployeesController : Controller
    {
        private IEmployeeHelper _employeeHelper;
        private IDepartmentHelper _departmentHelper;

        public EmployeesController()
        {
            _employeeHelper = HelperFactory.GetEmployeeHelper();
            _departmentHelper = HelperFactory.GetDepartmentHelper();
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _employeeHelper.GetEmployees();
            var orderedList = employees.OrderByDescending(e => e.Salary.SalaryAmount)
                                       .ThenBy(e => e.Name).ToList();
            return View(orderedList);
        }

        //show list with rank
        public ActionResult Index2()
        {
            var employees = _employeeHelper.GetEmployeesOrderBySalaryDesc();

            return View(employees);
        }

        public ActionResult Create()
        {
            ViewBag.Departments = _departmentHelper.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeHelper.AddEmployeeAndSalary(employee);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _departmentHelper.GetDepartments();
            return View(employee);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "CustomErrors");
            }

            var employee = _employeeHelper.GetEmployee(id.Value);

            if (employee == null)
            {
                return RedirectToAction("NotFound", "CustomErrors");
            }

            ViewBag.Departments = _departmentHelper.GetDepartments();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                //if salary id is not included in form data
                if (employee.Salary.Id == 0)
                {
                    return RedirectToAction("BadRequest", "CustomErrors");
                }
                else
                {
                    if (_employeeHelper.IfEmployeeExist(employee.EmployeeId))
                    {
                        _employeeHelper.UpdateEmployee(employee);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("NotFound", "CustomErrors");
                    }
                }
            }

            ViewBag.Departments = _departmentHelper.GetDepartments();
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "CustomErrors");
            }

            if (_employeeHelper.IfEmployeeExist(id.Value))
            {
                _employeeHelper.DeleteEmployee(id.Value);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound", "CustomErrors");
            }
        }
    }
}