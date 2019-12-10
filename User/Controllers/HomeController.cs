using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User.Models;
using User.Data;
using System.Web.Helpers;


namespace User.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _context;

        public HomeController()
        {
            _context = new UserContext();
        }
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Register()
        {
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Person person)
        {
            if(_context.People.Any(p=>p.Email == person.Email))
            {
                
               
                return RedirectToAction("index", "home");
            }

            if (ModelState.IsValid)
            {
                person.Password = Crypto.HashPassword(person.Password);
                person.Token = Guid.NewGuid().ToString();
                _context.People.Add(person);
                _context.SaveChanges();

                HttpCookie cookie = new HttpCookie("token",person.Token);
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                Response.SetCookie(cookie);


                return RedirectToAction("index", "dashboard");
            }


            return RedirectToAction("index", "home");
        }

    }
}