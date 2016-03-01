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
    public class BloodDonorController : Controller
    {
        private BloodDonorContext db = new BloodDonorContext();

        // GET: BloodDonor
        public ActionResult Index()
        {
            var bloodDonors = db.Person.OfType<BloodDonorModel>().Include(b => b.Recipient);
            return View(bloodDonors.ToList());
        }

        // GET: BloodDonor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDonorModel bloodDonorModel = db.Person.OfType<BloodDonorModel>().Find(id);
            if (bloodDonorModel == null)
            {
                return HttpNotFound();
            }
            return View(bloodDonorModel);
        }

        // GET: BloodDonor/Create
        public ActionResult Create()
        {
            ViewBag.RecipientRefId = new SelectList(db.Person.OfType<RecipientModel>(), "ID", "PhoneNumber");
            return View();
        }

        // POST: BloodDonor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IsActive,RecipientRefId,FirstName,LastName,Gender,Email")] BloodDonorModel bloodDonorModel)
        {
            if (ModelState.IsValid)
            {
                OfType<BloodDonorModel>().Add(bloodDonorModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipientRefId = new SelectList(db.Recipient, "ID", "PhoneNumber", bloodDonorModel.RecipientRefId);
            return View(bloodDonorModel);
        }

        // GET: BloodDonor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDonorModel bloodDonorModel = OfType<BloodDonorModel>().Find(id);
            if (bloodDonorModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipientRefId = new SelectList(db.Recipient, "ID", "PhoneNumber", bloodDonorModel.RecipientRefId);
            return View(bloodDonorModel);
        }

        // POST: BloodDonor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IsActive,RecipientRefId,FirstName,LastName,Gender,Email")] BloodDonorModel bloodDonorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodDonorModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipientRefId = new SelectList(db.Recipient, "ID", "PhoneNumber", bloodDonorModel.RecipientRefId);
            return View(bloodDonorModel);
        }

        // GET: BloodDonor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDonorModel bloodDonorModel = OfType<BloodDonorModel>().Find(id);
            if (bloodDonorModel == null)
            {
                return HttpNotFound();
            }
            return View(bloodDonorModel);
        }

        // POST: BloodDonor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodDonorModel bloodDonorModel = OfType<BloodDonorModel>().Find(id);
            OfType<BloodDonorModel>().Remove(bloodDonorModel);
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
