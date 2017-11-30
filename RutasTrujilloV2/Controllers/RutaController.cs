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
    public class RutaController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Ruta
        public ActionResult Index()
        {
            var ruta = db.Ruta.Include(r => r.Empresa);
            return View(ruta.ToList());
        }

        // GET: Ruta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // GET: Ruta/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial");
            return View();
        }

        // POST: Ruta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuta,Letra,Origen,Destino,IdEmpresa")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Ruta.Add(ruta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", ruta.IdEmpresa);
            return View(ruta);
        }

        // GET: Ruta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", ruta.IdEmpresa);
            return View(ruta);
        }

        // POST: Ruta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuta,Letra,Origen,Destino,IdEmpresa")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpresa = new SelectList(db.Empresa, "IdEmpresa", "RazonSocial", ruta.IdEmpresa);
            return View(ruta);
        }

        // GET: Ruta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // POST: Ruta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Ruta ruta = db.Ruta.Find(id);
            db.Ruta.Remove(ruta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult VerHorario(int? id)
        {
            var Horario = db.Horario.Where(i => i.IdRuta == id);
            return View(Horario.ToList());
        }

        public ActionResult VerPunto(int? id)
        {
            var Punto = db.Punto.Where(i => i.IdRuta == id);
            return View(Punto.ToList());
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
