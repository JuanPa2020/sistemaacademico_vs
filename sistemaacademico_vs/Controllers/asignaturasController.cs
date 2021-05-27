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
    public class asignaturasController : Controller
    {
        private sistemaacademicoEntities db = new sistemaacademicoEntities();

        // GET: asignaturas
        public ActionResult Index()
        {
            var asignatura = db.asignatura.Include(a => a.notas);
            return View(asignatura.ToList());
        }

        // GET: asignaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: asignaturas/Create
        public ActionResult Create()
        {
            ViewBag.id_notas = new SelectList(db.notas, "id_nota", "id_nota");
            return View();
        }

        // POST: asignaturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_asignatura,nombre,profesor,creditos,duracion,id_notas")] asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.asignatura.Add(asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_notas = new SelectList(db.notas, "id_nota", "id_nota", asignatura.id_notas);
            return View(asignatura);
        }

        // GET: asignaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_notas = new SelectList(db.notas, "id_nota", "id_nota", asignatura.id_notas);
            return View(asignatura);
        }

        // POST: asignaturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_asignatura,nombre,profesor,creditos,duracion,id_notas")] asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_notas = new SelectList(db.notas, "id_nota", "id_nota", asignatura.id_notas);
            return View(asignatura);
        }

        // GET: asignaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: asignaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asignatura asignatura = db.asignatura.Find(id);
            db.asignatura.Remove(asignatura);
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
