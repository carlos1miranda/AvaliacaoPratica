using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvaliacaoPratica.Models;

namespace AvaliacaoPratica.Controllers
{
    public class PratosController : Controller
    {
        private PraticaDBEntities db = new PraticaDBEntities();

        // GET: Pratos
        public ActionResult Index()
        {
            var pratos = db.Pratos.Include(p => p.Restaurantes);
            return View(pratos.ToList());
        }

        // GET: Pratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pratos pratos = db.Pratos.Find(id);
            if (pratos == null)
            {
                return HttpNotFound();
            }
            return View(pratos);
        }

        // GET: Pratos/Create
        public ActionResult Create()
        {
            ViewBag.FK_RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "RestauranteNome");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PratoId,PratoNome,PratoDescricao,Preco,FK_RestauranteId")] Pratos pratos)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(pratos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "RestauranteNome", pratos.FK_RestauranteId);
            return View(pratos);
        }

        // GET: Pratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pratos pratos = db.Pratos.Find(id);
            if (pratos == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "RestauranteNome", pratos.FK_RestauranteId);
            return View(pratos);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoId,PratoNome,PratoDescricao,Preco,FK_RestauranteId")] Pratos pratos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pratos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_RestauranteId = new SelectList(db.Restaurantes, "RestauranteId", "RestauranteNome", pratos.FK_RestauranteId);
            return View(pratos);
        }

        // GET: Pratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pratos pratos = db.Pratos.Find(id);
            if (pratos == null)
            {
                return HttpNotFound();
            }
            return View(pratos);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pratos pratos = db.Pratos.Find(id);
            db.Pratos.Remove(pratos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
