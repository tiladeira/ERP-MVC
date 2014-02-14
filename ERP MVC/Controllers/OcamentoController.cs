using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class OcamentoController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Ocamento/

        public ActionResult Index()
        {
            var orcamento = db.Orcamento.Include(o => o.Agendamento).Include(o => o.FormaPagamento).Include(o => o.Pedido).Include(o => o.Produto);
            return View(orcamento.ToList());
        }

        //
        // GET: /Ocamento/Details/5

        public ActionResult Details(int id = 0)
        {
            Orcamento orcamento = db.Orcamento.Find(id);
            if (orcamento == null)
            {
                return HttpNotFound();
            }
            return View(orcamento);
        }

        //
        // GET: /Ocamento/Create

        public ActionResult Create()
        {
            ViewBag.IdAgendamento = new SelectList(db.Agendamento, "IdAgendamento", "HoraAgendada");
            ViewBag.IdFormaPagamento = new SelectList(db.FormaPagamento, "IdFormaPagamento", "FormaPagamento1");
            ViewBag.IdPedido = new SelectList(db.Pedido, "IdPedido", "IdPedido");
            ViewBag.IdProduto = new SelectList(db.Produto, "IdProduto", "NomeProduto");
            return View();
        }

        //
        // POST: /Ocamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                db.Orcamento.Add(orcamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgendamento = new SelectList(db.Agendamento, "IdAgendamento", "HoraAgendada", orcamento.IdAgendamento);
            ViewBag.IdFormaPagamento = new SelectList(db.FormaPagamento, "IdFormaPagamento", "FormaPagamento1", orcamento.IdFormaPagamento);
            ViewBag.IdPedido = new SelectList(db.Pedido, "IdPedido", "IdPedido", orcamento.IdPedido);
            ViewBag.IdProduto = new SelectList(db.Produto, "IdProduto", "NomeProduto", orcamento.IdProduto);
            return View(orcamento);
        }

        //
        // GET: /Ocamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Orcamento orcamento = db.Orcamento.Find(id);
            if (orcamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgendamento = new SelectList(db.Agendamento, "IdAgendamento", "HoraAgendada", orcamento.IdAgendamento);
            ViewBag.IdFormaPagamento = new SelectList(db.FormaPagamento, "IdFormaPagamento", "FormaPagamento1", orcamento.IdFormaPagamento);
            ViewBag.IdPedido = new SelectList(db.Pedido, "IdPedido", "IdPedido", orcamento.IdPedido);
            ViewBag.IdProduto = new SelectList(db.Produto, "IdProduto", "NomeProduto", orcamento.IdProduto);
            return View(orcamento);
        }

        //
        // POST: /Ocamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Orcamento orcamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orcamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgendamento = new SelectList(db.Agendamento, "IdAgendamento", "HoraAgendada", orcamento.IdAgendamento);
            ViewBag.IdFormaPagamento = new SelectList(db.FormaPagamento, "IdFormaPagamento", "FormaPagamento1", orcamento.IdFormaPagamento);
            ViewBag.IdPedido = new SelectList(db.Pedido, "IdPedido", "IdPedido", orcamento.IdPedido);
            ViewBag.IdProduto = new SelectList(db.Produto, "IdProduto", "NomeProduto", orcamento.IdProduto);
            return View(orcamento);
        }

        //
        // GET: /Ocamento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Orcamento orcamento = db.Orcamento.Find(id);
            if (orcamento == null)
            {
                return HttpNotFound();
            }
            return View(orcamento);
        }

        //
        // POST: /Ocamento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orcamento orcamento = db.Orcamento.Find(id);
            db.Orcamento.Remove(orcamento);
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