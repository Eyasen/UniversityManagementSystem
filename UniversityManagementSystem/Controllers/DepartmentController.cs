using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        UniversityEntities1 db = new UniversityEntities1();
        // GET: Department
        public ActionResult Index()
        {
          
            return View(db.Departments.ToList());
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Message = "";
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Departments.Add(department);
                    db.SaveChanges();
                    ViewBag.Message = "Department has been Created!";   
                }
                return View(department);
            }


            catch
            {
                return View();
            }
        }

     

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Department department = new Department();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

       
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Entry(department).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Department has been Updated!";
                    
                }
                return View(department);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int? id, Department department)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            department = db.Departments.Find(id);
            if (department == null)
                return HttpNotFound();
            return View(department);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Department department = db.Departments.Find(id);
            if (department == null)
                return HttpNotFound();
            return View(department);
        }



        // POST: Department/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,Department department)
        {
            try
            {
                ViewBag.Message = null;

                if (ModelState.IsValid)
                {

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    if (department == null)
                        return HttpNotFound();

                    department = db.Departments.Find(id);
                    db.Departments.Remove(department);
                    db.SaveChanges();
                    ViewBag.Message = "department has been deleted! ";

                }
                return View(department);
            }
            catch
            {
                return View();
            }
        }



    }
}

