using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LifeLine.Infrastructure;
using LifeLine.Web.ViewModel;
using LifeLine.Infrastructure.Service;
using LifeLine.Core.Models;
using StructureMap;
using LifeLine.Web.Utilities;
using LifeLine.Infrastructure.Implementation;

namespace LifeLine.Web.Controllers
{
    public class CampController : Controller
    {
        private readonly ICampService _db;

        public CampController(ICampService campService)
        {
            _db = campService;
        }

        // GET: Camp
        public ActionResult Index()
        {
            var campList = _db.GetAll();
            var campViewModels = campList.Select(i => Automap.MapModelToViewModel<Camp,CampVM>(i)).ToList();

            return View(campViewModels);
        }

        // GET: Camp/Details/5
        public ActionResult Details(Guid id)
        {
            Camp camp = _db.FindById(id);
            if (camp == null)
            {
                return HttpNotFound();
            }

            //Map the model to VM
            var campVM = Automap.MapModelToViewModel<Camp, CampVM>(camp);

            return View(campVM);
        }

        // GET: Camp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camp/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CampVM campVM)
        {
            if (ModelState.IsValid)
            {
                //Map the model to VM
                var camp = Automap.MapViewModelToModel<CampVM,Camp>(campVM);

                campVM.Id = Guid.NewGuid();
                _db.Add(camp);
                return RedirectToAction("Index");
            }

            return View(campVM);
        }

        // GET: Camp/Edit/5
        public ActionResult Edit(Guid id)
        {
            Camp camp = _db.FindById(id);
            if (camp == null)
            {
                return HttpNotFound();
            }

            //Map the model to VM
            var campVM = Automap.MapModelToViewModel<Camp, CampVM>(camp);

            return View(campVM);
        }

        // POST: Camp/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CampVM campVM)
        {
            if (ModelState.IsValid)
            {
                //Map the model to VM
                var camp = Automap.MapViewModelToModel<CampVM, Camp>(campVM);

                _db.Edit(camp);

                return RedirectToAction("Index");
            }
            return View(campVM);
        }

        // GET: Camp/Delete/5
        public ActionResult Delete(Guid id)
        {
            Camp camp = _db.FindById(id);
            if (camp == null)
            {
                return HttpNotFound();
            }
            //Map the model to VM
            var campVM = Automap.MapModelToViewModel<Camp, CampVM>(camp);

            return View(campVM);
        }

        // POST: Camp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Camp camp = _db.FindById(id);
            _db.Remove(camp);
            return RedirectToAction("Index");
        }

        public ActionResult GetMessages()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            return PartialView("_MessagesList", _messageRepository.GetAllMessages());
        }

    }
}
