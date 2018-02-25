using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        UniversityEntities1 db = new UniversityEntities1();
        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            ViewBag.Message = null;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    ViewBag.Message = "Teacher has been added";
                }
                return View(teacher);
            }


            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Teacher teacher = new Teacher();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }


        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Teacher has been Updated!";

                }
                return View(teacher);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int? id, Teacher teacher)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            teacher = db.Teachers.Find(id);
            if (teacher == null)
                return HttpNotFound();
            return View(teacher);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
                return HttpNotFound();
            return View(teacher);
        }



        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id,Teacher teacher)
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

                    if (teacher == null)
                        return HttpNotFound();

                    teacher = db.Teachers.Find(id);
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                    ViewBag.Message = "Teacher has been deleted! ";

                }
                return View(teacher);
            }
            catch
            {
                return View();
            }
        }





    }
}