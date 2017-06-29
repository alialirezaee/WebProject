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
    public class booksController : Controller
    {
        private Web_ProjectEntities db = new Web_ProjectEntities();

        // GET: books
        public ActionResult Index()
        {
            var book = db.book.Include(b => b.bookType);
            return View(book.ToList());
        }

        // GET: books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: books/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.bookType, "bookTypeID", "bookTypeName");
            return View();
        }

        // POST: books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookID,bookName,bookPublisher,bookPublishYear,bookCategory,bookPrice,quantityAvailable,arrivalDate")] book book)
        {
            if (ModelState.IsValid)
            {
                db.book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.bookType, "bookTypeID", "bookTypeName", book.bookID);
            return View(book);
        }

        // GET: books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.bookType, "bookTypeID", "bookTypeName", book.bookID);
            return View(book);
        }

        // POST: books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookID,bookName,bookPublisher,bookPublishYear,bookCategory,bookPrice,quantityAvailable,arrivalDate")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.bookType, "bookTypeID", "bookTypeName", book.bookID);
            return View(book);
        }

        // GET: books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.book.Find(id);
            db.book.Remove(book);
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
