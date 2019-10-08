using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Controllers
{
    public class SearchProductController : Controller
    {
        Database1Entities db = new Database1Entities();

        // GET: SearchProduct
        public ActionResult Index(string productname="")
        {
            if(productname=="")
            {
                return View(db.tbl_Product);
            }

            var data = db.tbl_Product.Where(a => a.productname.Contains(productname));
            return View(data);
        }

        //[HttpGet]
        //public ActionResult AddToCart(int id)
        //{
        //    //tbl_Product product = new tbl_Product();
        //    //var productdata = db.tbl_Cart.Where(a => a.FKproductid == id);

        //    return View();
        //}


        //[HttpPost]
        //public ActionResult AddToCart(int quantity, int id)
        //{
        //    //tbl_Product product = new tbl_Product();
        //    //var productdata = db.tbl_Cart.Where(a => a.FKproductid == id);

            

        //    tbl_Cart ct = new tbl_Cart();

        //    ct.date = DateTime.Now;
        //    ct.FKproductid = id;
        //    ct.quantity = quantity;
        //    ct.FKuserid = 1;

        //    db.tbl_Cart.Add(ct);
        //    db.SaveChanges();

        //    return View(ct);
        //}
    }
}