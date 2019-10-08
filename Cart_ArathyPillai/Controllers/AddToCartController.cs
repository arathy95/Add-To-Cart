using Cart_ArathyPillai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cart_ArathyPillai.Controllers
{
    public class AddToCartController : Controller
    {
        Database1Entities db = new Database1Entities();


        // GET: AddToCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart(int id)
        {
            tbl_Cart ct = new tbl_Cart();

            int userid = (Int32)Session["userid"];

            ct.date = DateTime.Now;
            ct.FKproductid = id;
            ct.quantity = 1;
            ct.FKuserid = userid;

           
            db.tbl_Cart.Add(ct);
            db.SaveChanges();


            //tbl_Product product = new tbl_Product();
            //var productdata = db.tbl_Cart.Where(a => a.FKproductid == id);
            return RedirectToAction("Index", "CartManage");
        }

        [HttpPost]
        public ActionResult Cart(int quantity, int id)
        {
            //tbl_Product product = new tbl_Product();
            //var productdata = db.tbl_Cart.Where(a => a.FKproductid == id);



            tbl_Cart ct = new tbl_Cart();

            //ct.date = DateTime.Now;
            ct.FKproductid = id;
            //ct.quantity = quantity;
            //ct.FKuserid = 1;

            db.tbl_Cart.Add(ct);
            db.SaveChanges();

            return View(ct);
        }
    }
}