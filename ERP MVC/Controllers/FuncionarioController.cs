using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_MVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private EPISistemaEntities db = new EPISistemaEntities();

        //
        // GET: /Funcionario/

        public ActionResult Index()
        {
            var funcionario = db.Funcionario.Include(f => f.Beneficio).Include(f => f.Departamento).Include(f => f.Nivel).Include(f => f.Profissao).Include(f => f.RegimeContratacao);
            return View(funcionario.ToList());
        }

        //
        // GET: /Funcionario/Details/5

        public ActionResult Details(int id = 0)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Create

        public ActionResult Create()
        {
            ViewBag.IdBeneficio = new SelectList(db.Beneficio, "IdBeneficio", "IdBeneficio");
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Departamento1");
            ViewBag.IdNivel = new SelectList(db.Nivel, "IdNivel", "Nivel1");
            ViewBag.IdProfissao = new SelectList(db.Profissao, "IdProfissao", "Profissao1");
            ViewBag.IdRegimeContratacao = new SelectList(db.RegimeContratacao, "IdRegimeContratacao", "RegimeContratacao1");
            return View();
        }

        //
        // POST: /Funcionario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBeneficio = new SelectList(db.Beneficio, "IdBeneficio", "IdBeneficio", funcionario.IdBeneficio);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Departamento1", funcionario.IdDepartamento);
            ViewBag.IdNivel = new SelectList(db.Nivel, "IdNivel", "Nivel1", funcionario.IdNivel);
            ViewBag.IdProfissao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", funcionario.IdProfissao);
            ViewBag.IdRegimeContratacao = new SelectList(db.RegimeContratacao, "IdRegimeContratacao", "RegimeContratacao1", funcionario.IdRegimeContratacao);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBeneficio = new SelectList(db.Beneficio, "IdBeneficio", "IdBeneficio", funcionario.IdBeneficio);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Departamento1", funcionario.IdDepartamento);
            ViewBag.IdNivel = new SelectList(db.Nivel, "IdNivel", "Nivel1", funcionario.IdNivel);
            ViewBag.IdProfissao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", funcionario.IdProfissao);
            ViewBag.IdRegimeContratacao = new SelectList(db.RegimeContratacao, "IdRegimeContratacao", "RegimeContratacao1", funcionario.IdRegimeContratacao);
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBeneficio = new SelectList(db.Beneficio, "IdBeneficio", "IdBeneficio", funcionario.IdBeneficio);
            ViewBag.IdDepartamento = new SelectList(db.Departamento, "IdDepartamento", "Departamento1", funcionario.IdDepartamento);
            ViewBag.IdNivel = new SelectList(db.Nivel, "IdNivel", "Nivel1", funcionario.IdNivel);
            ViewBag.IdProfissao = new SelectList(db.Profissao, "IdProfissao", "Profissao1", funcionario.IdProfissao);
            ViewBag.IdRegimeContratacao = new SelectList(db.RegimeContratacao, "IdRegimeContratacao", "RegimeContratacao1", funcionario.IdRegimeContratacao);
            return View(funcionario);
        }

        //
        // GET: /Funcionario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        //
        // POST: /Funcionario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            db.Funcionario.Remove(funcionario);
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