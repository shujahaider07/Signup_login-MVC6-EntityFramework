using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace signUpLoginEFMvc.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login","Home");
            }
            return View();
        }
    }
}