using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using User_and_groups.Models;

namespace User_and_groups.Controllers
{
    public class HomeController : Controller
    {
        private AllDbContext db = new AllDbContext();

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Users users = db.Users.Include(s => s.Groups).FirstOrDefault(s=> s.IdUsers == id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        
        public ActionResult Edit(int id = 0)
        {
            Users users = db.Users.Include(s => s.Groups).FirstOrDefault(s => s.IdUsers == id);
            if (users == null)
            {
                return HttpNotFound();
            }
                ViewBag.Groups = db.Groups.ToList();
                return View(users);
        }

        [HttpPost]
        public ActionResult Edit(Users users, int[] selectedCourses, int id = 0)
        {
            Users newStudent = db.Users.Include(s => s.Groups).FirstOrDefault(s => s.IdUsers == id);
            newStudent.NameUsers = users.NameUsers;


            newStudent.Groups.Clear();
            if (selectedCourses != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Groups.Where(co => selectedCourses.Contains(co.IdGroups)))
                {
                    newStudent.Groups.Add(c);
                }
            }

            db.Entry(newStudent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
