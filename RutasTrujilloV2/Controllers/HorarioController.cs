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
    public class HorarioController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: Horario
        public ActionResult Index()
        {
            var horario = db.Horario.Include(h => h.Ruta);
            return View(horario.ToList());
        }

        // GET: Horario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: Horario/Create
        public ActionResult Create()
        {
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra");
            return View();
        }

        // POST: Horario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHorario,HoraSalida,HoraLlegada,IdRuta")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", horario.IdRuta);
            return View(horario);
        }

        // GET: Horario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", horario.IdRuta);
            return View(horario);
        }

        // POST: Horario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHorario,HoraSalida,HoraLlegada,IdRuta")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuta = new SelectList(db.Ruta, "IdRuta", "Letra", horario.IdRuta);
            return View(horario);
        }

        // GET: Horario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            db.Horario.Remove(horario);
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
