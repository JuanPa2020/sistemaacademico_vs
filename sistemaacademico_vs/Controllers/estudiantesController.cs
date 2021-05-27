using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sistemaacademico_vs.Models;

namespace sistemaacademico_vs.Controllers
{
    public class estudiantesController : Controller
    {
        private sistemaacademicoEntities db = new sistemaacademicoEntities();

        // GET: estudiantes
        public ActionResult Index()
        {
            return View(db.estudiante.ToList());
        }

        // GET: estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiante estudiante = db.estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,nombre,carrera,semestre,telefono")] estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.estudiante.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiante estudiante = db.estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estudiante,nombre,carrera,semestre,telefono")] estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estudiante estudiante = db.estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estudiante estudiante = db.estudiante.Find(id);
            db.estudiante.Remove(estudiante);
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
