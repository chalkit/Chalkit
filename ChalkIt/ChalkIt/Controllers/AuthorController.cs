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
        public ActionResult Index(Author user, Course course)
        {
            using (ChalkitDbContext db = new ChalkitDbContext())
            {
                try
                {
                    db.Authors.Attach(user);
                    db.Courses.Add(course);
                    db.Entry(user).Collection(x => x.Courses).Load();
                    user.Courses.Add(course);
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
            return RedirectToAction("Index", "Author",user);
        }

    }
}
