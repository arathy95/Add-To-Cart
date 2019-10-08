using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Controllers
{
    public class UserAuthenticationController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: UserAuthentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            try
            {
                var LoginData = db.tbl_User.SingleOrDefault(a => a.useremailid == user.useremailid && a.userpassword == user.userpassword);

                if(LoginData!=null)
                {
                    Session["userid"] = LoginData.userid;
                    Session["useremailid"] = LoginData.useremailid;

                    return RedirectToAction("Index", "SearchProduct");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return View();
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "UserAuthentication");
        }
    }
}