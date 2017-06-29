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
    public class ordersController : Controller
    {
        private Web_ProjectEntities db = new Web_ProjectEntities();

        // GET: orders
        public ActionResult Index()
        {
            var order = db.order.Include(o => o.users);
            return View(order.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.users, "userID", "Fname");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderID,customerID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.users, "userID", "Fname", order.customerID);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.users, "userID", "Fname", order.customerID);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderID,customerID")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.users, "userID", "Fname", order.customerID);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.order.Find(id);
            db.order.Remove(order);
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
