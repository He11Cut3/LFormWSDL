using System.Diagnostics;
using System.Web.Mvc;
using WebApplication1.Models;

namespace LForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}
