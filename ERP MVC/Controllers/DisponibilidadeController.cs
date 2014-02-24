using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class DisponibilidadeController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Disponibilidade/

        public ActionResult Index()
        {
            return View(db.Disponibilidade.ToList());
        }

        //
        // GET: /Disponibilidade/Details/5

        public ActionResult Details(int id = 0)
        {
            Disponibilidade disponibilidade = db.Disponibilidade.Find(id);
            if (disponibilidade == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidade);
        }

        //
        // GET: /Disponibilidade/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Disponibilidade/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                db.Disponibilidade.Add(disponibilidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disponibilidade);
        }

        //
        // GET: /Disponibilidade/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Disponibilidade disponibilidade = db.Disponibilidade.Find(id);
            if (disponibilidade == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidade);
        }

        //
        // POST: /Disponibilidade/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Disponibilidade disponibilidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disponibilidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disponibilidade);
        }

        //
        // GET: /Disponibilidade/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Disponibilidade disponibilidade = db.Disponibilidade.Find(id);
            if (disponibilidade == null)
            {
                return HttpNotFound();
            }
            return View(disponibilidade);
        }

        //
        // POST: /Disponibilidade/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disponibilidade disponibilidade = db.Disponibilidade.Find(id);
            db.Disponibilidade.Remove(disponibilidade);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}