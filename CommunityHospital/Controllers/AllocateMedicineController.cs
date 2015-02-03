using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunityHospital.Models;
using WebGrease.Css.Extensions;

namespace CommunityHospital.Controllers
{
    public class AllocateMedicineController : Controller
    {
        private ServiceCenterGateway db = new ServiceCenterGateway();

        // GET: /AllocateMedicine/
        public ActionResult Index()
        {
            var allocatemedicines = db.AllocateMedicines.Include(a => a.AMedicine).Include(a => a.AServiceCenter);
            return View(allocatemedicines.ToList());
        }

        // GET: /AllocateMedicine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateMedicine allocatemedicine = db.AllocateMedicines.Find(id);
            if (allocatemedicine == null)
            {
                return HttpNotFound();
            }
            return View(allocatemedicine);
        }

        // GET: /AllocateMedicine/Create
        public ActionResult Create()
        {
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name");
            ViewBag.ServiceCenterId = new SelectList(db.ServiceCenters, "ServiceCenterId", "Name");
            return View();
        }

        // POST: /AllocateMedicine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AllocateMedicineId,DistrictThanaRelationshipId,ServiceCenterId,MedicineId")] AllocateMedicine allocatemedicine)
        {
          
            if (ModelState.IsValid)
            {
                db.AllocateMedicines.Add(allocatemedicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", allocatemedicine.MedicineId);
            ViewBag.ServiceCenterId = new SelectList(db.ServiceCenters, "ServiceCenterId", "Name", allocatemedicine.ServiceCenterId);
            return View(allocatemedicine);
        }

        // GET: /AllocateMedicine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateMedicine allocatemedicine = db.AllocateMedicines.Find(id);
            if (allocatemedicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", allocatemedicine.MedicineId);
            ViewBag.ServiceCenterId = new SelectList(db.ServiceCenters, "ServiceCenterId", "Name", allocatemedicine.ServiceCenterId);
            return View(allocatemedicine);
        }

        // POST: /AllocateMedicine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AllocateMedicineId,DistrictThanaRelationshipId,ServiceCenterId,MedicineId")] AllocateMedicine allocatemedicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocatemedicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicineId = new SelectList(db.Medicines, "MedicineId", "Name", allocatemedicine.MedicineId);
            ViewBag.ServiceCenterId = new SelectList(db.ServiceCenters, "ServiceCenterId", "Name", allocatemedicine.ServiceCenterId);
            return View(allocatemedicine);
        }

        // GET: /AllocateMedicine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateMedicine allocatemedicine = db.AllocateMedicines.Find(id);
            if (allocatemedicine == null)
            {
                return HttpNotFound();
            }
            return View(allocatemedicine);
        }

        // POST: /AllocateMedicine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllocateMedicine allocatemedicine = db.AllocateMedicines.Find(id);
            db.AllocateMedicines.Remove(allocatemedicine);
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

        public ActionResult AllDistrict()
        {
            var districts = db.Districts.Select(i =>
            new 
            {
                DistrictId = i.DistrictId,
                Name =i.Name,
                
            });

            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}
