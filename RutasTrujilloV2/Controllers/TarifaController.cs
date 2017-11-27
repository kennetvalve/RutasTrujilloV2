using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RutasTrujilloV2.Models;
using RutasTrujilloV2.Repository;

namespace RutasTrujilloV2.Controllers
{
    public class TarifaController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Tarifa
        public ActionResult Index()
        {
            var tarifa = db.Tarifa.Include(t => t.Empresa);
            return View(tarifa.ToList());
        }

        // GET: Tarifa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifa.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // GET: Tarifa/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial");
            return View();
        }

        // POST: Tarifa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTarifa,Tipo,Precio,IdEmpresa")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Tarifa.Add(tarifa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", tarifa.IdEmpresa);
            return View(tarifa);
        }

        // GET: Tarifa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifa.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", tarifa.IdEmpresa);
            return View(tarifa);
        }

        // POST: Tarifa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTarifa,Tipo,Precio,IdEmpresa")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarifa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", tarifa.IdEmpresa);
            return View(tarifa);
        }

        // GET: Tarifa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarifa tarifa = db.Tarifa.Find(id);
            if (tarifa == null)
            {
                return HttpNotFound();
            }
            return View(tarifa);
        }

        // POST: Tarifa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarifa tarifa = db.Tarifa.Find(id);
            db.Tarifa.Remove(tarifa);
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
