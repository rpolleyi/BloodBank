using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LifeLine.Core.Models;
using LifeLine.Infrastructure;

namespace LifeLine.Web.Controllers
{
    public class RecipientController : Controller
    {
        private BloodDonorContext db = new BloodDonorContext();

        // GET: Recipient
        public ActionResult Index()
        {
            return View(db.Persons.OfType<Recipient>().ToList());
        }

        // GET: Recipient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Persons.Find(id) as Recipient;
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // GET: Recipient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PhoneNumber,Email,ReceivedDate")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(recipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipient);
        }

        // GET: Recipient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Persons.Find(id) as Recipient; ;
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // POST: Recipient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNumber,Email,ReceivedDate")] Recipient recipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipient);
        }

        // GET: Recipient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipient recipient = db.Persons.Find(id) as Recipient; ;
            if (recipient == null)
            {
                return HttpNotFound();
            }
            return View(recipient);
        }

        // POST: Recipient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipient recipient = db.Persons.Find(id) as Recipient; ;
            db.Persons.Remove(recipient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
