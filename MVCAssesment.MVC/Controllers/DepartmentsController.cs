using MVCAssesment.MVC.ModelHelpers;
using System.Web.Mvc;

namespace MVCAssesment.MVC.Controllers
{
    //[HandleError]
    public class DepartmentsController : Controller
    {
        private IDepartmentHelper _departmentHelper;

        public DepartmentsController()
        {
            _departmentHelper = HelperFactory.GetDepartmentHelper();
        }

        // GET: Department
        public ActionResult Index()
        {
            var departments = _departmentHelper.GetDepartments();

            return View(departments);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Add Department";
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentHelper.AddDepartment(department);

                return RedirectToAction("Index");
            }

            ViewBag.Title = "Add Department";
            return View(department);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "CustomErrors");
            }

            var department = _departmentHelper.GetDepartment(id.Value);

            if (department == null)
            {
                return RedirectToAction("NotFound", "CustomErrors");
            }

            return View(department);
        }

        [HttpPost]
        public ActionResult Update(int deptId, Models.Department department)
        {
            if (ModelState.IsValid)
            {
                if (deptId == department.DeptID)
                {
                    if (_departmentHelper.IfDepartmentExist(deptId))
                    {
                        _departmentHelper.UpdateDepartment(department);
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

            //ViewBag.Title = "Update Department";
            return View(department);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("BadRequest", "CustomErrors");
            }

            if (_departmentHelper.IfDepartmentExist(id.Value))
            {
                _departmentHelper.DeleteDepartment(id.Value);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound", "CustomErrors");
            }
        }
    }
}