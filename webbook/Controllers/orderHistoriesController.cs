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
    public class orderHistoriesController : Controller
    {
        private Web_ProjectEntities db = new Web_ProjectEntities();

        // GET: orderHistories
        public ActionResult Index()
        {
            var orderHistory = db.orderHistory.Include(o => o.book).Include(o => o.order);
            return View(orderHistory.ToList());
        }

        // GET: orderHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderHistory orderHistory = db.orderHistory.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            return View(orderHistory);
        }

        // GET: orderHistories/Create
        public ActionResult Create()
        {
            ViewBag.bookID = new SelectList(db.book, "bookID", "bookName");
            ViewBag.orderID = new SelectList(db.order, "orderID", "orderID");
            return View();
        }

        // POST: orderHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,orderID,bookID,quantity,date")] orderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                db.orderHistory.Add(orderHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookID = new SelectList(db.book, "bookID", "bookName", orderHistory.bookID);
            ViewBag.orderID = new SelectList(db.order, "orderID", "orderID", orderHistory.orderID);
            return View(orderHistory);
        }

        // GET: orderHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderHistory orderHistory = db.orderHistory.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookID = new SelectList(db.book, "bookID", "bookName", orderHistory.bookID);
            ViewBag.orderID = new SelectList(db.order, "orderID", "orderID", orderHistory.orderID);
            return View(orderHistory);
        }

        // POST: orderHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,orderID,bookID,quantity,date")] orderHistory orderHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookID = new SelectList(db.book, "bookID", "bookName", orderHistory.bookID);
            ViewBag.orderID = new SelectList(db.order, "orderID", "orderID", orderHistory.orderID);
            return View(orderHistory);
        }

        // GET: orderHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderHistory orderHistory = db.orderHistory.Find(id);
            if (orderHistory == null)
            {
                return HttpNotFound();
            }
            return View(orderHistory);
        }

        // POST: orderHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderHistory orderHistory = db.orderHistory.Find(id);
            db.orderHistory.Remove(orderHistory);
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
