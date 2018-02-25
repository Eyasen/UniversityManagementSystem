using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Controllers
{
    public class RegistrationController : Controller
    {
        UniversityEntities1 db = new UniversityEntities1();
        // GET: Registration

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]    
        public ActionResult Login(Registration registration)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "invalid username and password!");
            }
            else
            {
                var details = (from userlist in db.Registrations
                    where userlist.UserName == registration.UserName && userlist.Password == registration.Password
                    select new
                    {
                        userlist.Password,
                        userlist.UserName
                    }).ToList();

                if (details.FirstOrDefault() != null)
                {
                    Session["Password"] = details.FirstOrDefault().Password;
                    Session["UserName"] = details.FirstOrDefault().UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.message = "Invalid username and Password";
                }
                return View();
            }

            return View(registration);
        }

        public ActionResult Welcome()
        {
            return View();
        }

    }
}