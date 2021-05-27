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
    public class horariosController : Controller
    {
        private sistemaacademicoEntities db = new sistemaacademicoEntities();

        // GET: horarios
        public ActionResult Index()
        {
            return View(db.horario.ToList());
        }

        // GET: horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: horarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: horarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_horario,id_estudiante,asignatura,hora,aula")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(horario);
        }

        // GET: horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: horarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_horario,id_estudiante,asignatura,hora,aula")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(horario);
        }

        // GET: horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            horario horario = db.horario.Find(id);
            db.horario.Remove(horario);
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
