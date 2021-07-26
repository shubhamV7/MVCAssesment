using System.Web.Mvc;

namespace MVCAssesment.MVC.Controllers
{
    public class CustomErrorsController : Controller
    {
        // for Invalid requests
        public ActionResult BadRequest()
        {
            return View();
        }

        //for Resource not found
        public ActionResult NotFound()
        {
            return View();
        }
    }
}