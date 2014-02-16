using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class TipoClienteController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /TipoCliente/

        public ActionResult Index()
        {
            return View(db.TipoCliente.ToList());
        }

        //
        // GET: /TipoCliente/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoCliente tipocliente = db.TipoCliente.Find(id);
            if (tipocliente == null)
            {
                return HttpNotFound();
            }
            return View(tipocliente);
        }

        //
        // GET: /TipoCliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoCliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoCliente tipocliente)
        {
            if (ModelState.IsValid)
            {
                db.TipoCliente.Add(tipocliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipocliente);
        }

        //
        // GET: /TipoCliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoCliente tipocliente = db.TipoCliente.Find(id);
            if (tipocliente == null)
            {
                return HttpNotFound();
            }
            return View(tipocliente);
        }

        //
        // POST: /TipoCliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoCliente tipocliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipocliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipocliente);
        }

        //
        // GET: /TipoCliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoCliente tipocliente = db.TipoCliente.Find(id);
            if (tipocliente == null)
            {
                return HttpNotFound();
            }
            return View(tipocliente);
        }

        //
        // POST: /TipoCliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCliente tipocliente = db.TipoCliente.Find(id);
            db.TipoCliente.Remove(tipocliente);
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