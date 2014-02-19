using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class ClienteController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Cidade).Include(c => c.Profissao).Include(c => c.TipoCliente).Include(c => c.TipoEndereco).Include(c => c.TipoSegmento);
            return View(cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Cidade1");
            ViewBag.IdProfisao = new SelectList(db.Profissao, "IdProfissao", "Profissao1");
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1");
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1");
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1");
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                //var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", cliente.IdCidade);
            ViewBag.IdProfisao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", cliente.IdProfisao);
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", cliente.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", cliente.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", cliente.IdTipoSegmento);
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", cliente.IdCidade);
            ViewBag.IdProfisao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", cliente.IdProfisao);
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", cliente.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", cliente.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", cliente.IdTipoSegmento);
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCidade = new SelectList(db.Cidade, "IdCidade", "Cidade1", cliente.IdCidade);
            ViewBag.IdProfisao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", cliente.IdProfisao);
            ViewBag.IdTipoCliente = new SelectList(db.TipoCliente, "IdTipoCliente", "TipoCliente1", cliente.IdTipoCliente);
            ViewBag.IdTipoEndereco = new SelectList(db.TipoEndereco, "IdTipoEndereco", "TipoEndereco1", cliente.IdTipoEndereco);
            ViewBag.IdTipoSegmento = new SelectList(db.TipoSegmento, "IdTipoSegmento", "TipoSegmento1", cliente.IdTipoSegmento);
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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