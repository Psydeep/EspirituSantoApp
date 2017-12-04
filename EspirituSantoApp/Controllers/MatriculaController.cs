using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EspirituSantoApp.Models
{
    public class MatriculaController : Controller
    {
        private EspirituSantoAppContext db = new EspirituSantoAppContext();

        // GET: /Matricula/
        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Cronograma).Include(m => m.Estudiante);
            return View(matriculas.ToList());
        }

        // GET: /Matricula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: /Matricula/Create
        public ActionResult Create()
        {
            ViewBag.Cron_ID = new SelectList(db.Cronogramas, "Cron_ID", "Cron_ID");
            ViewBag.Est_ID = new SelectList(db.Estudiantes, "Est_ID", "Est_Apellidos");
            return View();
        }

        // POST: /Matricula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Mat_ID,Mat_fecha,Est_ID,Cron_ID,Cur_ID")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cron_ID = new SelectList(db.Cronogramas, "Cron_ID", "Cron_ID", matricula.Cron_ID);
            ViewBag.Est_ID = new SelectList(db.Estudiantes, "Est_ID", "Est_Apellidos", matricula.Est_ID);
            return View(matricula);
        }

        // GET: /Matricula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cron_ID = new SelectList(db.Cronogramas, "Cron_ID", "Cron_ID", matricula.Cron_ID);
            ViewBag.Est_ID = new SelectList(db.Estudiantes, "Est_ID", "Est_Apellidos", matricula.Est_ID);
            return View(matricula);
        }

        // POST: /Matricula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Mat_ID,Mat_fecha,Est_ID,Cron_ID,Cur_ID")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cron_ID = new SelectList(db.Cronogramas, "Cron_ID", "Cron_ID", matricula.Cron_ID);
            ViewBag.Est_ID = new SelectList(db.Estudiantes, "Est_ID", "Est_Apellidos", matricula.Est_ID);
            return View(matricula);
        }

        // GET: /Matricula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: /Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
