using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LifeLine.Core;
using LifeLine.Core.Interfaces;
using TrackerEnabledDbContext.Common.Models;
using LifeLine.Core.Models;
using LifeLine.Infrastructure;
using StructureMap;

namespace LifeLine.Web.Controllers
{
    [Authorize]
    public class BloodDonorsController : BaseController
    {
        IBloodDonorRepository db;
        IOnlineUserRepository onlineUserdb;

        //public BloodDonorsController() : this(new BloodDonorRepository(), new OnlineUserRepository())
        //{
        //}

        public BloodDonorsController(IBloodDonorRepository bloodDonordb, IOnlineUserRepository userdb)
        {
            db = bloodDonordb;
            onlineUserdb = userdb;
        }

        // GET: BloodDonors
        public ActionResult Index()
        {
            RecordVisit(User.Identity.Name, "Index", null);
            return View(db.GetBloodDonors().ToList());
        }

        // GET: BloodDonors/Details/5
        public ActionResult Details(int id)
        {
            RecordVisit(User.Identity.Name, "Details", null);

            if (id == null)
            {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);                          
            }
            BloodDonorModel bloodDonor = db.FindById(id);
            if (bloodDonor == null)
            {
                return HttpNotFound();
            }
            
            //bloodDonor.AuditLogs = db.AuditLog().Where(i => i.RecordId == bloodDonor.ID.ToString())
            //                                        .OrderByDescending(x => x.EventDateUTC).ToList();

            return View(bloodDonor);
        }

        // GET: BloodDonors/Create
        public ActionResult Create()
        {
            RecordVisit(User.Identity.Name, "Create", null);
            return View();
        }

        // POST: BloodDonors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BloodGroup,City,Country,PinCode,PhoneNumber,Email")] BloodDonorModel bloodDonor)
        {
            if (ModelState.IsValid)
            {
                db.UserName = User.Identity.Name;
                db.Add(bloodDonor);
                return RedirectToAction("Index");
            }
            
            return View(bloodDonor);
        }

        // GET: BloodDonors/Edit/5
        public ActionResult Edit(int id)
        {
            //get all the online users active on this page
            var editPageOnlineUsers = onlineUserdb.FindOnlineUsersByPageName("Blood/Edit",id);

            //Add a entry for the current user with the page details
            UserModel user = new UserModel();
            user.Name = User.Identity.Name;
            user.PageName = "Blood/Edit";
            user.DonorId = id;
            user.IsActive = true;

            //if current user has already record dont add
            if (editPageOnlineUsers.Count() == 0)
            {
                onlineUserdb.Add(user);
            }
           else if (editPageOnlineUsers != null && editPageOnlineUsers.Count() > 0 && !editPageOnlineUsers.Select(u => u.Name == User.Identity.Name).First())
                onlineUserdb.Add(user);
            
            RecordVisit(User.Identity.Name, "Blood/Edit", editPageOnlineUsers);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDonorModel bloodDonor = db.FindById(id);
            if (bloodDonor == null)
            {
                return HttpNotFound();
            }
            return View(bloodDonor);
        }

        // POST: BloodDonors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BloodGroup,City,Country,PinCode,PhoneNumber,Email")] BloodDonorModel bloodDonor)
        {
            if (ModelState.IsValid)
            {
                db.UserName = User.Identity.Name;
                db.Edit(bloodDonor);
                return RedirectToAction("Index");
            }
            return View(bloodDonor);
        }

        // GET: BloodDonors/Delete/5
        public ActionResult Delete(int id)
        {
            RecordVisit(User.Identity.Name, "Delete", null);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodDonorModel bloodDonor = db.FindById(id);
            if (bloodDonor == null)
            {
                return HttpNotFound();
            }
            return View(bloodDonor);
        }

        // POST: BloodDonors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodDonorModel bloodDonor = db.FindById(id);
            db.Remove(bloodDonor.ID);
            return RedirectToAction("Index");
        }

       
    }
}
