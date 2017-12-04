using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EspirituSantoApp.Models;

namespace EspirituSantoApp.Controllers
{
    public class GradoController : Controller
    {
        private EspirituSantoAppContext db = new EspirituSantoAppContext();

        // GET: /Grado/
        public ActionResult Index()
        {
            return View(db.Gradoes.ToList());
        }

        // GET: /Grado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: /Grado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Grado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Grado_ID,Grado_Nombre,Grado_Anio")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Gradoes.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grado);
        }

        // GET: /Grado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: /Grado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Grado_ID,Grado_Nombre,Grado_Anio")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grado);
        }

        // GET: /Grado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Gradoes.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: /Grado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = db.Gradoes.Find(id);
            db.Gradoes.Remove(grado);
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
