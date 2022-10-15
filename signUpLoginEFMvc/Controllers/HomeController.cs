using signUpLoginEFMvc.Models;
using System.Linq;
using System.Web.Mvc;

namespace signUpLoginEFMvc.Controllers
{
    public class HomeController : Controller
    {
        signupContext db = new signupContext();

        public ActionResult Index()
        {
            var list = db.signUps.ToList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SignUp sign)
        {
            db.Entry(sign).State = System.Data.Entity.EntityState.Added;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["Inserted"] = "<script>alert('Data Inserted')</script>";
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(SignUp s)
        {
            var check = db.signUps.Where(m => m.Name == s.Name && m.Password == s.Password).FirstOrDefault();
            if (check != null)
            {
                Session["userid"] = s.Id.ToString();
                Session["Name"] = s.Name.ToString();
                
               ViewBag.alert = "Login sucessfull";
               ViewData["Alert"] = "Login sucessfull";


                ModelState.Clear();
                return RedirectToAction("Index","user");
             


            }
            else
            {
                return RedirectToAction("Contact", "Home");
            }
          
          
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["Userid"] = null;
            return RedirectToAction("Login","Home");
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            SignUp ss = new SignUp();
            var Edtt = db.signUps.Where(m => m.Id == id).FirstOrDefault();

            Edtt.Password = ss.Password;
            Edtt.ConfirmPassword = ss.ConfirmPassword;

            return View(Edtt);
        }
        [HttpPost]
        public ActionResult Edit(int id,SignUp sp)
        {
            db.Entry(sp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var ddtt = db.signUps.Where(m => m.Id == id).FirstOrDefault();

            return View(ddtt);
        }

        [HttpPost]
        public ActionResult Delete(int id,SignUp sp)
        {
            db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChangesAsync();
            return View();
        }



    }
}