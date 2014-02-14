using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class FormaPagamentoController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /FormaPagamento/

        public ActionResult Index()
        {
            return View(db.FormaPagamento.ToList());
        }

        //
        // GET: /FormaPagamento/Details/5

        public ActionResult Details(int id = 0)
        {
            FormaPagamento formapagamento = db.FormaPagamento.Find(id);
            if (formapagamento == null)
            {
                return HttpNotFound();
            }
            return View(formapagamento);
        }

        //
        // GET: /FormaPagamento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FormaPagamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormaPagamento formapagamento)
        {
            if (ModelState.IsValid)
            {
                db.FormaPagamento.Add(formapagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formapagamento);
        }

        //
        // GET: /FormaPagamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FormaPagamento formapagamento = db.FormaPagamento.Find(id);
            if (formapagamento == null)
            {
                return HttpNotFound();
            }
            return View(formapagamento);
        }

        //
        // POST: /FormaPagamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormaPagamento formapagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formapagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formapagamento);
        }

        //
        // GET: /FormaPagamento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FormaPagamento formapagamento = db.FormaPagamento.Find(id);
            if (formapagamento == null)
            {
                return HttpNotFound();
            }
            return View(formapagamento);
        }

        //
        // POST: /FormaPagamento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaPagamento formapagamento = db.FormaPagamento.Find(id);
            db.FormaPagamento.Remove(formapagamento);
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