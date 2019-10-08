using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cart_ArathyPillai.Models;

namespace Cart_ArathyPillai.Areas.Administrator.Controllers
{
    public class CategoryController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Administrator/Category
        public ActionResult Index()
        {
            return View(db.tbl_Category.ToList());
        }

        // GET: Administrator/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Category tbl_Category = db.tbl_Category.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // GET: Administrator/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryid,categoryname")] tbl_Category tbl_Category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbl_Category.Add(tbl_Category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["err"]= ex.Message;
                }
            }

            return View(tbl_Category);
        }

        // GET: Administrator/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Category tbl_Category = db.tbl_Category.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // POST: Administrator/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryid,categoryname")] tbl_Category tbl_Category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_Category).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["err"]= ex.Message;
                }
            }
            return View(tbl_Category);
        }

        // GET: Administrator/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Category tbl_Category = db.tbl_Category.Find(id);
            if (tbl_Category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Category);
        }

        // POST: Administrator/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Category tbl_Category = db.tbl_Category.Find(id);
                db.tbl_Category.Remove(tbl_Category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                TempData["err"]= ex.Message;
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
