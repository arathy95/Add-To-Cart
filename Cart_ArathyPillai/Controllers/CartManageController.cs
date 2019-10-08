using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Controllers
{
    public class CartManageController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: CartManage
        public ActionResult Index()
        {
            int uid = (Int32)Session["userid"];
            var tbl_Cart = db.tbl_Cart.Include(t => t.tbl_Product).Include(t => t.tbl_User);
            return View(tbl_Cart.ToList().Where(a=>a.FKuserid== uid /*1 && a.orderplaces==false*/));
        }

        public ActionResult ShowOrder()
        {
            var tbl_Cart = db.tbl_Cart.Include(t => t.tbl_Product).Include(t => t.tbl_User);
            return View(tbl_Cart.ToList().Where(a => a.FKuserid == 1 && a.orderplaces == true));
        }
        // GET: CartManage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cart tbl_Cart = db.tbl_Cart.Find(id);
            if (tbl_Cart == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cart);
        }

        // GET: CartManage/Create
        public ActionResult Create()
        {
            ViewBag.FKproductid = new SelectList(db.tbl_Product, "productid", "productname");
            ViewBag.FKuserid = new SelectList(db.tbl_User, "userid", "username");
            return View();
        }

        // POST: CartManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cartid,quantity,date,FKproductid,FKuserid")] tbl_Cart tbl_Cart)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Cart.Add(tbl_Cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKproductid = new SelectList(db.tbl_Product, "productid", "productname", tbl_Cart.FKproductid);
            ViewBag.FKuserid = new SelectList(db.tbl_User, "userid", "username", tbl_Cart.FKuserid);
            return View(tbl_Cart);
        }

        // GET: CartManage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cart tbl_Cart = db.tbl_Cart.Find(id);
            if (tbl_Cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKproductid = new SelectList(db.tbl_Product, "productid", "productname", tbl_Cart.FKproductid);
            ViewBag.FKuserid = new SelectList(db.tbl_User, "userid", "username", tbl_Cart.FKuserid);
            return View(tbl_Cart);
        }

        // POST: CartManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cartid,quantity,date,FKproductid,FKuserid")] tbl_Cart tbl_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKproductid = new SelectList(db.tbl_Product, "productid", "productname", tbl_Cart.FKproductid);
            ViewBag.FKuserid = new SelectList(db.tbl_User, "userid", "username", tbl_Cart.FKuserid);
            return View(tbl_Cart);
        }

        // GET: CartManage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Cart tbl_Cart = db.tbl_Cart.Find(id);
            if (tbl_Cart == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Cart);
        }

        // POST: CartManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Cart tbl_Cart = db.tbl_Cart.Find(id);
            db.tbl_Cart.Remove(tbl_Cart);
            db.SaveChanges();
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
