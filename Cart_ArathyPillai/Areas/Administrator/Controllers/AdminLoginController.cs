using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Areas.Administrator.Controllers
{
    public class AdminLoginController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: Administrator/AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginForAdmin()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginForAdmin(tbl_AdminLogin ad)
        {
            var LoginData = db.tbl_AdminLogin.SingleOrDefault(a => ad.emailid == a.emailid && ad.password == a.password);
            if(LoginData!=null)
            {
                Session["adminid"] = LoginData.id;
                TempData["msg"] = "Login Successfull";
                return RedirectToAction("Index","Dashboard");
            }
            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("LoginForAdmin", "AdminLogin");
        }
    }
}