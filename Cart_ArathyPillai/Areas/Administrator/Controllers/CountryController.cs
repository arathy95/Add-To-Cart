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
    public class CountryController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Administrator/Country
        public ActionResult Index()
        {
            return View(db.tbl_Country.ToList());
        }

        // GET: Administrator/Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Country tbl_Country = db.tbl_Country.Find(id);
            if (tbl_Country == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Country);
        }

        // GET: Administrator/Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "countryid,countryname")] tbl_Country tbl_Country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbl_Country.Add(tbl_Country);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["err"] = ex.Message;
                }
            }

            return View(tbl_Country);
        }

        // GET: Administrator/Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Country tbl_Country = db.tbl_Country.Find(id);
            if (tbl_Country == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Country);
        }

        // POST: Administrator/Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "countryid,countryname")] tbl_Country tbl_Country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_Country).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    TempData["err"] = ex.Message;
                }
            }
            return View(tbl_Country);
        }

        // GET: Administrator/Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Country tbl_Country = db.tbl_Country.Find(id);
            if (tbl_Country == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Country);
        }

        // POST: Administrator/Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Country tbl_Country = db.tbl_Country.Find(id);
                db.tbl_Country.Remove(tbl_Country);
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
