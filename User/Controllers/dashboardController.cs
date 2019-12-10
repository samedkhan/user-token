using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User.Data;

namespace User.Controllers
{
    public class dashboardController : Controller
    {
        private readonly UserContext _context;

        public dashboardController()
        {
            _context = new UserContext();
        }
        // GET: dashboard
        public ActionResult Index()
        {
            if (Request.Cookies.Get("token") != null)
            {
                return View();
            }

            return RedirectToAction("index", "home");
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Response.Cookies.Get("token");

            if (cookie == null)
            {
                return RedirectToAction("index", "home");
            }

            Person person = _context.People.FirstOrDefault(p => p.Token == cookie.Value);




            person.Token = string.Empty;
            _context.SaveChanges();

            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("index", "home");
        }
    }
}