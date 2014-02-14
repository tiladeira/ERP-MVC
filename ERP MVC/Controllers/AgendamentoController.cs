using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class AgendamentoController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Agendamento/

        public ActionResult Index()
        {
            var agendamento = db.Agendamento.Include(a => a.Disponibilidade).Include(a => a.Periodo).Include(a => a.StatusAgendamento);
            return View(agendamento.ToList());
        }

        //
        // GET: /Agendamento/Details/5

        public ActionResult Details(int id = 0)
        {
            Agendamento agendamento = db.Agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Create

        public ActionResult Create()
        {
            ViewBag.IdDisponibilidade = new SelectList(db.Disponibilidade, "IdDisponibilidade", "Disponibilidade1");
            ViewBag.IdPeriodo = new SelectList(db.Periodo, "IdPeriodo", "Periodo1");
            ViewBag.IdStatus = new SelectList(db.StatusAgendamento, "IdStatusAgendamento", "Status");
            return View();
        }

        //
        // POST: /Agendamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Agendamento.Add(agendamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDisponibilidade = new SelectList(db.Disponibilidade, "IdDisponibilidade", "Disponibilidade1", agendamento.IdDisponibilidade);
            ViewBag.IdPeriodo = new SelectList(db.Periodo, "IdPeriodo", "Periodo1", agendamento.IdPeriodo);
            ViewBag.IdStatus = new SelectList(db.StatusAgendamento, "IdStatusAgendamento", "Status", agendamento.IdStatus);
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Agendamento agendamento = db.Agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDisponibilidade = new SelectList(db.Disponibilidade, "IdDisponibilidade", "Disponibilidade1", agendamento.IdDisponibilidade);
            ViewBag.IdPeriodo = new SelectList(db.Periodo, "IdPeriodo", "Periodo1", agendamento.IdPeriodo);
            ViewBag.IdStatus = new SelectList(db.StatusAgendamento, "IdStatusAgendamento", "Status", agendamento.IdStatus);
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDisponibilidade = new SelectList(db.Disponibilidade, "IdDisponibilidade", "Disponibilidade1", agendamento.IdDisponibilidade);
            ViewBag.IdPeriodo = new SelectList(db.Periodo, "IdPeriodo", "Periodo1", agendamento.IdPeriodo);
            ViewBag.IdStatus = new SelectList(db.StatusAgendamento, "IdStatusAgendamento", "Status", agendamento.IdStatus);
            return View(agendamento);
        }

        //
        // GET: /Agendamento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Agendamento agendamento = db.Agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

        //
        // POST: /Agendamento/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.Agendamento.Find(id);
            db.Agendamento.Remove(agendamento);
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