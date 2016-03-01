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
    public class DonationsController : Controller
    {
        private BloodDonorContext db = new BloodDonorContext();

        // GET: Donations
        public ActionResult Index()
        {
            var donations = db.Donations.Include(d => d.Recipient);
            return View(donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Persons.OfType<Donor>(), "Id", "FirstName");
            ViewBag.RecpientId = new SelectList(db.Persons.OfType<Recipient>(), "Id", "FirstName");
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorId = new SelectList(db.Persons, "Id", "FirstName", donation.DonorId);
            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Persons.OfType<Donor>(), "Id", "FirstName");
            ViewBag.RecpientId = new SelectList(db.Persons.OfType<Recipient>(), "Id", "FirstName");
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorId = new SelectList(db.Persons, "Id", "FirstName", donation.DonorId);
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int id)
        {
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
