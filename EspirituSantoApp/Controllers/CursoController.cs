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
    public class CursoController : Controller
    {
        private EspirituSantoAppContext db = new EspirituSantoAppContext();

        // GET: /Curso/
        [Authorize(Roles = "Editor")]
        public ActionResult Index()
        {
            var cursoes = db.Cursoes.Include(c => c.Aula).Include(c => c.Grado);
            return View(cursoes.ToList());
        }

        // GET: /Curso/Details/5
        [Authorize(Roles = "Editor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: /Curso/Create
        [Authorize(Roles = "Editor")]
        public ActionResult Create()
        {
            ViewBag.Aula_ID = new SelectList(db.Aulas, "Aula_ID", "Aula_ID");
            ViewBag.Grado_ID = new SelectList(db.Gradoes, "Grado_ID", "Grado_Nombre");
            return View();
        }

        // POST: /Curso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CursoID,Cur_Nombre,Cur_CuposDisp,Cur_Paralelo,Aula_ID,Grado_ID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Aula_ID = new SelectList(db.Aulas, "Aula_ID", "Aula_ID", curso.Aula_ID);
            ViewBag.Grado_ID = new SelectList(db.Gradoes, "Grado_ID", "Grado_Nombre", curso.Grado_ID);
            return View(curso);
        }

        // GET: /Curso/Edit/5
        [Authorize(Roles = "Editor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aula_ID = new SelectList(db.Aulas, "Aula_ID", "Aula_ID", curso.Aula_ID);
            ViewBag.Grado_ID = new SelectList(db.Gradoes, "Grado_ID", "Grado_Nombre", curso.Grado_ID);
            return View(curso);
        }

        // POST: /Curso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CursoID,Cur_Nombre,Cur_CuposDisp,Cur_Paralelo,Aula_ID,Grado_ID")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Aula_ID = new SelectList(db.Aulas, "Aula_ID", "Aula_ID", curso.Aula_ID);
            ViewBag.Grado_ID = new SelectList(db.Gradoes, "Grado_ID", "Grado_Nombre", curso.Grado_ID);
            return View(curso);
        }

        // GET: /Curso/Delete/5
        [Authorize(Roles = "Editor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: /Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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
