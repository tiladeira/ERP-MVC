using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class ClientePJController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /ClientePJ/

        public ActionResult Index()
        {
            var clientepj = db.ClientePJ.Include(c => c.TipoCliente).Include(c => c.TipoEndereco).Include(c => c.TipoSegmento);
            return View(clientepj.ToList());
        }

        //
        // GET: /ClientePJ/Details/5

        public ActionResult Details(int id = 0)
        {
            ClientePJ clientepj = db.ClientePJ.Find(id);
            if (clientepj == null)
            {
                return HttpNotFound();
            }
            return View(clientepj);
        }

        //
        // GET: /ClientePJ/Create

        public ActionResult Create()
        {
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1");
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1");
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1");
            return View();
        }

        //
        // POST: /ClientePJ/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientePJ clientepj)
        {
            if (ModelState.IsValid)
            {
                db.ClientePJ.Add(clientepj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", clientepj.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", clientepj.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", clientepj.IdTipoSegmento);
            return View(clientepj);
        }

        //
        // GET: /ClientePJ/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClientePJ clientepj = db.ClientePJ.Find(id);
            if (clientepj == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", clientepj.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", clientepj.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", clientepj.IdTipoSegmento);
            return View(clientepj);
        }

        //
        // POST: /ClientePJ/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientePJ clientepj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientepj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", clientepj.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", clientepj.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", clientepj.IdTipoSegmento);
            return View(clientepj);
        }

        //
        // GET: /ClientePJ/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClientePJ clientepj = db.ClientePJ.Find(id);
            if (clientepj == null)
            {
                return HttpNotFound();
            }
            return View(clientepj);
        }

        //
        // POST: /ClientePJ/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientePJ clientepj = db.ClientePJ.Find(id);
            db.ClientePJ.Remove(clientepj);
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