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
    public class PuntoController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Punto
        public ActionResult Index()
        {
            var punto = db.Punto.Include(p => p.Ruta);
            return View(punto.ToList());
        }

        // GET: Punto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            return View(punto);
        }

        // GET: Punto/Create
        public ActionResult Create()
        {
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra");
            return View();
        }

        // POST: Punto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPunto,Latitud,Longitud,IdRuta")] Punto punto)
        {
            if (ModelState.IsValid)
            {
                db.Punto.Add(punto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", punto.IdRuta);
            return View(punto);
        }

        // GET: Punto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", punto.IdRuta);
            return View(punto);
        }

        // POST: Punto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPunto,Latitud,Longitud,IdRuta")] Punto punto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", punto.IdRuta);
            return View(punto);
        }

        // GET: Punto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punto punto = db.Punto.Find(id);
            if (punto == null)
            {
                return HttpNotFound();
            }
            return View(punto);
        }

        // POST: Punto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Punto punto = db.Punto.Find(id);
            db.Punto.Remove(punto);
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
