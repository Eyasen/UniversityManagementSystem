using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        UniversityEntities1 db = new UniversityEntities1();
        // GET: Course
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Courses.Add(course);
                    db.SaveChanges();
                    ViewBag.Message = "Course has been Added!";
                }
                return View(course);
            }


            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Course course = new Course();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }


        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                ViewBag.Message = null;
                if (ModelState.IsValid)
                {
                    db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Message = "Course has been Updated!";

                }
                return View(course);
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Details(int? id, Course course)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            course = db.Courses.Find(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }




        [HttpGet]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Course course = db.Courses.Find(id);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }



        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Course course)
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
                    
                    if (course == null)
                        return HttpNotFound();

                    course = db.Courses.Find(id);
                    db.Courses.Remove(course);
                    db.SaveChanges();
                    ViewBag.Message = "Course has been deleted! ";

                }
                return View(course);
            }
            catch
            {
                return View();
            }
        }



    }
}