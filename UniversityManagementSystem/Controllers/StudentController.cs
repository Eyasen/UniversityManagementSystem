using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        UniversityEntities1 db = new UniversityEntities1();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    ViewBag.Message = "Student has been created!";
                }
                return View(student);
            }


            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Student student = new Student();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Student has been Updated!";

                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Details(int? id,Student student)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Student student = db.Students.Find(id);
            if (student == null)
                return HttpNotFound();
            return View(student);
        }



        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Student student)
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

                    if (student == null)
                        return HttpNotFound();

                    student = db.Students.Find(id);
                    db.Students.Remove(student);
                    db.SaveChanges();
                    ViewBag.Message = "Student has been deleted! ";

                }
                return View(student);
            }
            catch
            {
                return View();
            }
        }


    }
}