using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;

namespace UniversityManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}