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
    public class CronogramaController : Controller
    {
        private EspirituSantoAppContext db = new EspirituSantoAppContext();

        // GET: /Cronograma/
        public ActionResult Index()
        {
            return View(db.Cronogramas.ToList());
        }

        // GET: /Cronograma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cronograma cronograma = db.Cronogramas.Find(id);
            if (cronograma == null)
            {
                return HttpNotFound();
            }
            return View(cronograma);
        }

        // GET: /Cronograma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cronograma/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Cron_ID,Cron_FechaInicio,Cron_FechaFin")] Cronograma cronograma)
        {
            if (ModelState.IsValid)
            {
                db.Cronogramas.Add(cronograma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cronograma);
        }

        // GET: /Cronograma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cronograma cronograma = db.Cronogramas.Find(id);
            if (cronograma == null)
            {
                return HttpNotFound();
            }
            return View(cronograma);
        }

        // POST: /Cronograma/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Cron_ID,Cron_FechaInicio,Cron_FechaFin")] Cronograma cronograma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cronograma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cronograma);
        }

        // GET: /Cronograma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cronograma cronograma = db.Cronogramas.Find(id);
            if (cronograma == null)
            {
                return HttpNotFound();
            }
            return View(cronograma);
        }

        // POST: /Cronograma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cronograma cronograma = db.Cronogramas.Find(id);
            db.Cronogramas.Remove(cronograma);
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
