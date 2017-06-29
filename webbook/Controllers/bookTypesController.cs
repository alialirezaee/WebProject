using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webbook.Models;

namespace webbook.Controllers
{
    public class bookTypesController : Controller
    {
        private Web_ProjectEntities db = new Web_ProjectEntities();

        // GET: bookTypes
        public ActionResult Index()
        {
            var bookType = db.bookType.Include(b => b.book);
            return View(bookType.ToList());
        }

        // GET: bookTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookType bookType = db.bookType.Find(id);
            if (bookType == null)
            {
                return HttpNotFound();
            }
            return View(bookType);
        }

        // GET: bookTypes/Create
        public ActionResult Create()
        {
            ViewBag.bookTypeID = new SelectList(db.book, "bookID", "bookName");
            return View();
        }

        // POST: bookTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookTypeID,bookTypeName")] bookType bookType)
        {
            if (ModelState.IsValid)
            {
                db.bookType.Add(bookType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookTypeID = new SelectList(db.book, "bookID", "bookName", bookType.bookTypeID);
            return View(bookType);
        }

        // GET: bookTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookType bookType = db.bookType.Find(id);
            if (bookType == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookTypeID = new SelectList(db.book, "bookID", "bookName", bookType.bookTypeID);
            return View(bookType);
        }

        // POST: bookTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookTypeID,bookTypeName")] bookType bookType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookTypeID = new SelectList(db.book, "bookID", "bookName", bookType.bookTypeID);
            return View(bookType);
        }

        // GET: bookTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookType bookType = db.bookType.Find(id);
            if (bookType == null)
            {
                return HttpNotFound();
            }
            return View(bookType);
        }

        // POST: bookTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookType bookType = db.bookType.Find(id);
            db.bookType.Remove(bookType);
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
