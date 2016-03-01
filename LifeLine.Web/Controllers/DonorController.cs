using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LifeLine.Core.Models;
using LifeLine.Infrastructure.Service;
using LifeLine.Core.Interfaces;
using LifeLine.Infrastructure;
using TrackerEnabledDbContext.Common.Models;
using LifeLine.Web.ViewModel;
using StructureMap;
using LifeLine.Web.Utilities;

namespace LifeLine.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Donors")]
    public class DonorController : BaseController
    {
        private readonly IDonationService _db;
        private readonly ICampService _campdb;

        public DonorController(IDonationService donationdb, ICampService campdb)
        {
            _db = donationdb;
            _campdb = campdb;
        }

        //Specifies that this is the default action for this route prefix. Route
        [HttpGet,Route("")]
        public ActionResult Index()
        {
            var donorList = _db.GetAll();

            //do the model to Vm ampping
            if (donorList != null)
            {
                //var donorViewModels = donorList.Select(i => Helper.MapModelToViewModel(i)).ToList();
                var donorViewModels = donorList.Select(i => Automap.MapModelToViewModel<Donor, DonorVM>(i)).ToList();

                return View(donorViewModels);
            }
            return View(new List<DonorVM>());
        }

        //specify a constraint for the Id to a Guid
        [HttpGet, Route("Config/Details")]
        public ActionResult Details(Guid id)
        {
            var donor = _db.FindById(id);
            if (donor == null)
            {
                throw new DonorNotFoundException($"Cannot find Donor with id {id.ToString()}");
            }
            donor.AuditLogs = _db.AuditLog().Where(i => i.RecordId == donor.Id.ToString())
                                                    .OrderByDescending(x => x.EventDateUTC).ToList();
            //Map the model to VM
            //var donorVM = Helper.MapModelToViewModel(donor);
            //donorVM.Camp = _campdb.FindById(donor.CampId);
             var donorVM = Automap.MapModelToViewModel<Donor, DonorVM>(donor);
            donorVM.Camp = _campdb.FindById(donor.CampId);

            return View(donorVM);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DonorVM donorVM = new DonorVM();
            donorVM.CampsList = _campdb.GetCampsList();
            return View(donorVM);
        }

        /// <summary>
        /// Creates a donor
        /// </summary>
        /// <param name="donorVM">donor values as got from the donor view model binded to the view</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DonorVM donorVM)
        {
            //Map the VM to model
            var donor = Helper.MapViewModelToModel(donorVM);

            //var donor = Helper.MapViewModelToModel<DonorVM, Donor>(donorVM);

            _db.Add(donor);
            return RedirectToAction("Index");

           // return View(donorVM);
        }

        //specify a constraint for the Id to a Guid
        [HttpGet, Route("Config/Update")]
        public ActionResult Edit(Guid id)
        {
            Donor donor = _db.FindById(id);
            if (donor == null)
            {
                return HttpNotFound();
            }

            //Map the model to VM
            var donorVM = Helper.MapModelToViewModel(donor);
            donorVM.CampsList = _campdb.GetCampsList();
            
            return View(donorVM);
        }

        /// <summary>
        /// Updates a donor detail
        /// </summary>
        /// <param name="donorVM">donor values as got from the donor view model binded to the view</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DonorVM donorVM)
        {
            //Map the VM to model
            var donor = Helper.MapViewModelToModel(donorVM);

            _db.Edit(donor);
            return RedirectToAction("Index");
            return View(donorVM);
        }

        [HttpGet, Route("Config/Remove")]
        public ActionResult Delete(Guid id)
        {
            Donor donor = _db.FindById(id) as Donor;
            if (donor == null)
            {
                return HttpNotFound();
            }

            //Map the model to VM
            var donorVM = Helper.MapModelToViewModel(donor);

            return View(donorVM);
        }

        /// <summary>
        /// Deletes a donor
        /// </summary>
        /// <param name="id">Id of the donor</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Donor donor = _db.FindById(id) as Donor;
            _db.Remove(donor);
            return RedirectToAction("Index");
        }

        public ActionResult Eligibility()
        {
            return View();
        }

    }
}
