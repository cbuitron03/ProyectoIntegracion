using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Tienda;

namespace MVC_Tienda.Controllers
{
    public class FACTURAsController : Controller
    {
        private db17842Entities1 db = new db17842Entities1();

        // GET: FACTURAs
        public ActionResult Index()
        {
            var fACTURA = db.FACTURA.Include(f => f.CLIENTE).Include(f => f.EMPRESA);
            return View(fACTURA.ToList());
        }

        // GET: FACTURAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // GET: FACTURAs/Create
        public ActionResult Create()
        {
            ViewBag.CLI_CEDULA = new SelectList(db.CLIENTE, "CLI_CEDULA", "CLI_NOMBRE");
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC");
            return View();
        }

        // POST: FACTURAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FAC_COD,ID_EMP,CLI_CEDULA,FAC_FECHA,FAC_ESTADO,FAC_SUBTOTAL,FAC_IVA,FAC_TOTAL")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURA.Add(fACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLI_CEDULA = new SelectList(db.CLIENTE, "CLI_CEDULA", "CLI_NOMBRE", fACTURA.CLI_CEDULA);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // GET: FACTURAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLI_CEDULA = new SelectList(db.CLIENTE, "CLI_CEDULA", "CLI_NOMBRE", fACTURA.CLI_CEDULA);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // POST: FACTURAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FAC_COD,ID_EMP,CLI_CEDULA,FAC_FECHA,FAC_ESTADO,FAC_SUBTOTAL,FAC_IVA,FAC_TOTAL")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLI_CEDULA = new SelectList(db.CLIENTE, "CLI_CEDULA", "CLI_NOMBRE", fACTURA.CLI_CEDULA);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // GET: FACTURAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            return View(fACTURA);
        }

        // POST: FACTURAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACTURA fACTURA = db.FACTURA.Find(id);
            db.FACTURA.Remove(fACTURA);
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
