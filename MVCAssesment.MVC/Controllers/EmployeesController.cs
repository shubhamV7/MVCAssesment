using MVCAssesment.MVC.ModelHelpers;
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
        public ActionResult Update(int employeeId, Models.Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employeeId == employee.EmployeeId)
                {
                    if (_employeeHelper.IfEmployeeExist(employeeId))
                    {
                        _employeeHelper.UpdateEmployee(employee);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("NotFound", "CustomErrors");
                    }
                }
                else
                {
                    return RedirectToAction("BadRequest", "CustomErrors");
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