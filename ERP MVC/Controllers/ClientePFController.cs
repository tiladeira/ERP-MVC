using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class ClientePFController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /ClientePF/

        public ActionResult Index()
        {
            return View(db.ClientePF.ToList());
        }

        //
        // GET: /ClientePF/Details/5

        public ActionResult Details(int id = 0)
        {
            ClientePF clientepf = db.ClientePF.Find(id);
            if (clientepf == null)
            {
                return HttpNotFound();
            }
            return View(clientepf);
        }

        //
        // GET: /ClientePF/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClientePF/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientePF clientepf)
        {
            if (ModelState.IsValid)
            {
                db.ClientePF.Add(clientepf);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientepf);
        }

        //
        // GET: /ClientePF/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClientePF clientepf = db.ClientePF.Find(id);
            if (clientepf == null)
            {
                return HttpNotFound();
            }
            return View(clientepf);
        }

        //
        // POST: /ClientePF/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientePF clientepf)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientepf).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientepf);
        }

        //
        // GET: /ClientePF/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClientePF clientepf = db.ClientePF.Find(id);
            if (clientepf == null)
            {
                return HttpNotFound();
            }
            return View(clientepf);
        }

        //
        // POST: /ClientePF/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientePF clientepf = db.ClientePF.Find(id);
            db.ClientePF.Remove(clientepf);
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