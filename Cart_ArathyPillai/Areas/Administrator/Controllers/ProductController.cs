using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Areas.Administrator.Controllers
{
    public class ProductController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Administrator/Product
        public ActionResult Index()
        {
            var tbl_Product = db.tbl_Product.Include(t => t.tbl_SubCategory);
            return View(tbl_Product.ToList());
        }

        // GET: Administrator/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // GET: Administrator/Product/Create
        public ActionResult Create()
        {

            ViewBag.categoryid = new SelectList(db.tbl_Category.ToList(), "categoryid", "categoryname");
            ViewBag.FKsubcatid = new List<SelectListItem>(){
                new SelectListItem(){ Text = "", Value="Select Sub Category"}
            };


            //ViewBag.FKsubcatid = new SelectList(db.tbl_SubCategory, "subcategoryid", "subcategoryname");
            return View();
        }

        // POST: Administrator/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productid,productname,productquantity,productprice,productdescription,productimg,FKsubcatid")] tbl_Product tbl_Product, HttpPostedFileBase productimg)
        {
            try
            {
                string dirpath = Server.MapPath("~/Content/Administrator/Images/");
                if (!Directory.Exists(dirpath))
                {
                    Directory.CreateDirectory(dirpath);
                }

                string filename = "Product_" + Guid.NewGuid().ToString().Replace('-', '_') + "." + productimg.FileName.Split('.')[1];
                string filepath = dirpath + "\\" + filename;
                productimg.SaveAs(filepath);

                ViewBag.message = "Image Uploaded";
                tbl_Product.productimg = filename;

                if (ModelState.IsValid)
                {
                    db.tbl_Product.Add(tbl_Product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["err"] = ex.Message;
            }


            
            ViewBag.categoryid = new SelectList(db.tbl_Category.ToList(), "categoryid", "categoryname");
            ViewBag.FKsubcatid = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "", Value="Select Sub Category"}
            };


            ViewBag.FKsubcatid = new SelectList(db.tbl_SubCategory, "subcategoryid", "subcategoryname", tbl_Product.FKsubcatid);
            return View(tbl_Product);
        }


        public JsonResult GetSubCatbyCat(int id)
        {
            return Json(db.tbl_SubCategory.Where(a => a.FKcategoryid == id).Select(b => new { b.subcategoryname, b.subcategoryid }).ToList(), JsonRequestBehavior.AllowGet);
        }



        // GET: Administrator/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKsubcatid = new SelectList(db.tbl_SubCategory, "subcategoryid", "subcategoryname", tbl_Product.FKsubcatid);
            return View(tbl_Product);
        }

        // POST: Administrator/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productid,productname,productquantity,productprice,productdescription,productimg,FKsubcatid")] tbl_Product tbl_Product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_Product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["err"] = ex.Message;

                }
            }
            ViewBag.FKsubcatid = new SelectList(db.tbl_SubCategory, "subcategoryid", "subcategoryname", tbl_Product.FKsubcatid);
            return View(tbl_Product);
        }

        // GET: Administrator/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Product tbl_Product = db.tbl_Product.Find(id);
            if (tbl_Product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Product);
        }

        // POST: Administrator/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Product tbl_Product = db.tbl_Product.Find(id);
                db.tbl_Product.Remove(tbl_Product);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                TempData["err"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
