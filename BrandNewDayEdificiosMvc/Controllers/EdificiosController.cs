using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrandNewDayEdificiosMvc.Models;

namespace BrandNewDayEdificiosMvc.Controllers
{
    public class EdificiosController : Controller
    {
        private BrandNewDayDbContext db = new BrandNewDayDbContext();

        // GET: Edificios
        public ActionResult Index()
        {
            var edificios = db.Edificios.Include(e => e.Barrio);
            return View(edificios.ToList());
        }

        // GET: Edificios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edificio edificio = db.Edificios.Find(id);
            if (edificio == null)
            {
                return HttpNotFound();
            }
            return View(edificio);
        }

        // GET: Edificios/Create
        public ActionResult Create()
        {
            ViewBag.BarrioId = new SelectList(db.Barrios, "BarrioId", "Nombre");
            return View();
        }

        // POST: Edificios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EdificioId,Nombre,Peligro,Vigilante,BarrioId")] Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                db.Edificios.Add(edificio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarrioId = new SelectList(db.Barrios, "BarrioId", "Nombre", edificio.BarrioId);
            return View(edificio);
        }

        // GET: Edificios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edificio edificio = db.Edificios.Find(id);
            if (edificio == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarrioId = new SelectList(db.Barrios, "BarrioId", "Nombre", edificio.BarrioId);
            return View(edificio);
        }

        // POST: Edificios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EdificioId,Nombre,Peligro,Vigilante,BarrioId")] Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edificio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarrioId = new SelectList(db.Barrios, "BarrioId", "Nombre", edificio.BarrioId);
            return View(edificio);
        }

        // GET: Edificios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Edificio edificio = db.Edificios.Find(id);
            if (edificio == null)
            {
                return HttpNotFound();
            }
            return View(edificio);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Edificio edificio = db.Edificios.Find(id);
            db.Edificios.Remove(edificio);
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
