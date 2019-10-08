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
    public class SubCategoryController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Administrator/SubCategory
        public ActionResult Index()
        {
            var tbl_SubCategory = db.tbl_SubCategory.Include(t => t.tbl_Category);
            return View(tbl_SubCategory.ToList());
        }

        // GET: Administrator/SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubCategory tbl_SubCategory = db.tbl_SubCategory.Find(id);
            if (tbl_SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SubCategory);
        }

        // GET: Administrator/SubCategory/Create
        public ActionResult Create()
        {
            ViewBag.FKcategoryid = new SelectList(db.tbl_Category, "categoryid", "categoryname");
            return View();
        }

        // POST: Administrator/SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subcategoryid,subcategoryname,FKcategoryid")] tbl_SubCategory tbl_SubCategory)
        {
            if (ModelState.IsValid)
            {
                db.tbl_SubCategory.Add(tbl_SubCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKcategoryid = new SelectList(db.tbl_Category, "categoryid", "categoryname", tbl_SubCategory.FKcategoryid);
            return View(tbl_SubCategory);
        }

        // GET: Administrator/SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubCategory tbl_SubCategory = db.tbl_SubCategory.Find(id);
            if (tbl_SubCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKcategoryid = new SelectList(db.tbl_Category, "categoryid", "categoryname", tbl_SubCategory.FKcategoryid);
            return View(tbl_SubCategory);
        }

        // POST: Administrator/SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subcategoryid,subcategoryname,FKcategoryid")] tbl_SubCategory tbl_SubCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SubCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKcategoryid = new SelectList(db.tbl_Category, "categoryid", "categoryname", tbl_SubCategory.FKcategoryid);
            return View(tbl_SubCategory);
        }

        // GET: Administrator/SubCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SubCategory tbl_SubCategory = db.tbl_SubCategory.Find(id);
            if (tbl_SubCategory == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SubCategory);
        }

        // POST: Administrator/SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_SubCategory tbl_SubCategory = db.tbl_SubCategory.Find(id);
            db.tbl_SubCategory.Remove(tbl_SubCategory);
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
