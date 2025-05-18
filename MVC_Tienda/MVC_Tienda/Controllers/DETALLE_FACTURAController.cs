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
    public class DETALLE_FACTURAController : Controller
    {
        private db17842Entities1 db = new db17842Entities1();

        // GET: DETALLE_FACTURA
        public ActionResult Index()
        {
            var dETALLE_FACTURA = db.DETALLE_FACTURA.Include(d => d.FACTURA).Include(d => d.PRODUCTO);
            return View(dETALLE_FACTURA.ToList());
        }

        // GET: DETALLE_FACTURA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA);
        }

        // GET: DETALLE_FACTURA/Create
        public ActionResult Create()
        {
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "CLI_CEDULA");
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION");
            return View();
        }

        // POST: DETALLE_FACTURA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DET_FAC,FAC_COD,PRD_COD,DTF_CANTIDAD,DTF_PRECIO,DTF_ESTADO")] DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_FACTURA.Add(dETALLE_FACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "CLI_CEDULA", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // GET: DETALLE_FACTURA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "CLI_CEDULA", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // POST: DETALLE_FACTURA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DET_FAC,FAC_COD,PRD_COD,DTF_CANTIDAD,DTF_PRECIO,DTF_ESTADO")] DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_FACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "CLI_CEDULA", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // GET: DETALLE_FACTURA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_FACTURA);
        }

        // POST: DETALLE_FACTURA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            db.DETALLE_FACTURA.Remove(dETALLE_FACTURA);
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
