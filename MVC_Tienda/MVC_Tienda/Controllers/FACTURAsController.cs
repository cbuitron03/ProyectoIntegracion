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
        private db17842Entities db = new db17842Entities();

        // GET: FACTURAs
        public ActionResult Index()
        {
            var fACTURA = db.FACTURA.Include(f => f.CLIENTE).Include(f => f.EMPRESA);
            return View(fACTURA.ToList());
        }

        // GET: FACTURAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
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
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "CLI_CEDULA");
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC");
            return View();
        }

        // POST: FACTURAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FAC_COD,ID_EMP,ID_CLIENTE,FAC_FECHA,FAC_ESTADO,FAC_IVA,FAC_SUBTOTAL,FAC_TOTAL")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.FACTURA.Add(fACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "CLI_CEDULA", fACTURA.ID_CLIENTE);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // GET: FACTURAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACTURA fACTURA = db.FACTURA.Find(id);
            if (fACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "CLI_CEDULA", fACTURA.ID_CLIENTE);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // POST: FACTURAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FAC_COD,ID_EMP,ID_CLIENTE,FAC_FECHA,FAC_ESTADO,FAC_IVA,FAC_SUBTOTAL,FAC_TOTAL")] FACTURA fACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLIENTE = new SelectList(db.CLIENTE, "ID_CLIENTE", "CLI_CEDULA", fACTURA.ID_CLIENTE);
            ViewBag.ID_EMP = new SelectList(db.EMPRESA, "ID_EMP", "EMP_RUC", fACTURA.ID_EMP);
            return View(fACTURA);
        }

        // GET: FACTURAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == 0)
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
        public ActionResult DeleteConfirmed(decimal id)
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
