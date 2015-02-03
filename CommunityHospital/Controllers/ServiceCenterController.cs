using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityHospital.Models;

namespace CommunityHospital.Controllers
{
    public class ServiceCenterController : Controller
    {
        private ServiceCenterGateway db = new ServiceCenterGateway();

        // GET: /ServiceCenter/
        public ActionResult Index()
        {
            var servicecenters = db.ServiceCenters.Include(s => s.ADistrict).Include(s => s.AThana);
            return View(servicecenters.ToList());
        }

        // GET: /ServiceCenter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter servicecenter = db.ServiceCenters.Find(id);
            if (servicecenter == null)
            {
                return HttpNotFound();
            }
            return View(servicecenter);
        }

        // GET: /ServiceCenter/Create
        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name");
            ViewBag.ThanaId = new SelectList(db.Thanas, "ThanaId", "Name");
            return View();
        }

        // POST: /ServiceCenter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ServiceCenterId,Name,Code,Password,DistrictId,ThanaId")] ServiceCenter servicecenter)
        {
            if (ModelState.IsValid)
            {
                db.ServiceCenters.Add(servicecenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", servicecenter.DistrictId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "ThanaId", "Name", servicecenter.ThanaId);
            return View(servicecenter);
        }

        // GET: /ServiceCenter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter servicecenter = db.ServiceCenters.Find(id);
            if (servicecenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", servicecenter.DistrictId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "ThanaId", "Name", servicecenter.ThanaId);
            return View(servicecenter);
        }

        // POST: /ServiceCenter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ServiceCenterId,Name,Code,Password,DistrictId,ThanaId")] ServiceCenter servicecenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicecenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", servicecenter.DistrictId);
            ViewBag.ThanaId = new SelectList(db.Thanas, "ThanaId", "Name", servicecenter.ThanaId);
            return View(servicecenter);
        }

        // GET: /ServiceCenter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCenter servicecenter = db.ServiceCenters.Find(id);
            if (servicecenter == null)
            {
                return HttpNotFound();
            }
            return View(servicecenter);
        }

        // POST: /ServiceCenter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCenter servicecenter = db.ServiceCenters.Find(id);
            db.ServiceCenters.Remove(servicecenter);
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
