using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class PragaController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Praga/

        public ActionResult Index()
        {
            var praga = db.Praga.Include(p => p.TipoPraga);
            return View(praga.ToList());
        }

        //
        // GET: /Praga/Details/5

        public ActionResult Details(int id = 0)
        {
            Praga praga = db.Praga.Find(id);
            if (praga == null)
            {
                return HttpNotFound();
            }
            return View(praga);
        }

        //
        // GET: /Praga/Create

        public ActionResult Create()
        {
            ViewBag.IdTipoPraga = new SelectList(db.TipoPraga, "IdTipoPraga", "TipoPraga1");
            return View();
        }

        //
        // POST: /Praga/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Praga praga)
        {
            if (ModelState.IsValid)
            {
                db.Praga.Add(praga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPraga = new SelectList(db.TipoPraga, "IdTipoPraga", "TipoPraga1", praga.IdTipoPraga);
            return View(praga);
        }

        //
        // GET: /Praga/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Praga praga = db.Praga.Find(id);
            if (praga == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPraga = new SelectList(db.TipoPraga, "IdTipoPraga", "TipoPraga1", praga.IdTipoPraga);
            return View(praga);
        }

        //
        // POST: /Praga/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Praga praga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(praga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPraga = new SelectList(db.TipoPraga, "IdTipoPraga", "TipoPraga1", praga.IdTipoPraga);
            return View(praga);
        }

        //
        // GET: /Praga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Praga praga = db.Praga.Find(id);
            if (praga == null)
            {
                return HttpNotFound();
            }
            return View(praga);
        }

        //
        // POST: /Praga/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Praga praga = db.Praga.Find(id);
            db.Praga.Remove(praga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(Praga praga)
        {
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[fileName];
                postedFile.SaveAs(Server.MapPath("~/Images/Praga/") + Path.GetFileName(postedFile.FileName));
            }

            return View();
        }
    }
}