using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChalkIt.Models;

namespace ChalkIt.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        //
        // GET: /Author/

        public ActionResult Index()
        {
            Author userAuthor = new Author();
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
               userAuthor = db.Authors.Find(HttpContext.User.Identity.Name);
               db.Entry(userAuthor).Collection(x => x.Courses).Load();
            }
            return View(userAuthor);
        }

        [HttpPost]
        public ActionResult AddOrEditCourse(string userName, Course course)
        {
            Author userAuthor = new Author();
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
                try
                {
                    userAuthor = db.Authors.Find(userName);
                    Course existingCourse = db.Courses.Find(course.CourseID);
                    if (existingCourse == null)
                    {
                        db.Courses.Add(course);
                        db.Entry(userAuthor).Collection(x => x.Courses).Load();
                        userAuthor.Courses.Add(course);
                    }
                    else
                    {
                        existingCourse.CourseName = course.CourseName;
                        existingCourse.CourseDescription = course.CourseDescription;
                    }
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Author");
        }

        public PartialViewResult EditCourse(int courseID)
        {
            Author userAuthor = new Author();
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
               userAuthor = db.Authors.Find(HttpContext.User.Identity.Name);
               db.Entry(userAuthor).Collection(x => x.Courses).Load();
                foreach(Course tempCourse in userAuthor.Courses)
                {
                    if(tempCourse.CourseID == courseID)
                    {
                        return PartialView("_AuthorCourseUpdateCreate",tempCourse);
                    }
                }
            }
            return PartialView("_AuthorCourseUpdateCreate", new Course());
        }

       
    }
}
