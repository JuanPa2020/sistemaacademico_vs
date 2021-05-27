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
    public class matriculasController : Controller
    {
        private sistemaacademicoEntities db = new sistemaacademicoEntities();

        // GET: matriculas
        public ActionResult Index()
        {
            var matricula = db.matricula.Include(m => m.asignatura).Include(m => m.estudiante).Include(m => m.horario);
            return View(matricula.ToList());
        }

        // GET: matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = db.matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: matriculas/Create
        public ActionResult Create()
        {
            ViewBag.id_asignatura = new SelectList(db.asignatura, "id_asignatura", "nombre");
            ViewBag.id_estudiante = new SelectList(db.estudiante, "id_estudiante", "nombre");
            ViewBag.id_horario = new SelectList(db.horario, "id_horario", "asignatura");
            return View();
        }

        // POST: matriculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_matricula,id_estudiante,id_asignatura,id_horario")] matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.matricula.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_asignatura = new SelectList(db.asignatura, "id_asignatura", "nombre", matricula.id_asignatura);
            ViewBag.id_estudiante = new SelectList(db.estudiante, "id_estudiante", "nombre", matricula.id_estudiante);
            ViewBag.id_horario = new SelectList(db.horario, "id_horario", "asignatura", matricula.id_horario);
            return View(matricula);
        }

        // GET: matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = db.matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_asignatura = new SelectList(db.asignatura, "id_asignatura", "nombre", matricula.id_asignatura);
            ViewBag.id_estudiante = new SelectList(db.estudiante, "id_estudiante", "nombre", matricula.id_estudiante);
            ViewBag.id_horario = new SelectList(db.horario, "id_horario", "asignatura", matricula.id_horario);
            return View(matricula);
        }

        // POST: matriculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_matricula,id_estudiante,id_asignatura,id_horario")] matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_asignatura = new SelectList(db.asignatura, "id_asignatura", "nombre", matricula.id_asignatura);
            ViewBag.id_estudiante = new SelectList(db.estudiante, "id_estudiante", "nombre", matricula.id_estudiante);
            ViewBag.id_horario = new SelectList(db.horario, "id_horario", "asignatura", matricula.id_horario);
            return View(matricula);
        }

        // GET: matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            matricula matricula = db.matricula.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            matricula matricula = db.matricula.Find(id);
            db.matricula.Remove(matricula);
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
