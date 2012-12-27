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
            ViewBag.AuthorName = userAuthor.AuthorUserName;
            return View(userAuthor);
        }

        [HttpPost]
        public ActionResult CreateOrModifyCourse(string userName, Course course)
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
                        course.Exercises = new List<Exercise>();
                        db.Courses.Add(course);
                        db.Entry(userAuthor).Collection(x => x.Courses).Load();
                        userAuthor.Courses.Add(course);
                    }
                    else
                    {
                        db.Entry(existingCourse).Collection(x => x.Exercises).Load();
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
               ViewBag.AuthorName = userAuthor.AuthorUserName;
                foreach(Course tempCourse in userAuthor.Courses)
                {
                    if(tempCourse.CourseID == courseID)
                    {
                        db.Entry(tempCourse).Collection(y => y.Exercises).Load();
                        return PartialView("_AuthorCourseUpdateCreate",tempCourse);
                    }
                }
            }
            return PartialView("_AuthorCourseUpdateCreate", new Course());
        }

        public PartialViewResult DeleteCourse(int courseID, string userName)
        {
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
                try
                {
                    Course existingCourse = db.Courses.Find(courseID);
                    if (existingCourse != null)
                    {
                        db.Courses.Remove(existingCourse);
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
            ViewBag.AuthorName = userName;
            return PartialView("_AuthorCourseUpdateCreate", new Course());
        }


        public PartialViewResult CourseList(string userName)
        {
            Author userAuthor = new Author();
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
                userAuthor = db.Authors.Find(userName);
                db.Entry(userAuthor).Collection(x => x.Courses).Load();
            }
            ViewBag.AuthorName = userAuthor.AuthorUserName;
            return PartialView("_AuthorCoursesList", userAuthor.Courses);
        }

        public PartialViewResult AddCourse()
        {
            return PartialView("_AuthorCourseUpdateCreate", new Course());
        }

       
    }
}
