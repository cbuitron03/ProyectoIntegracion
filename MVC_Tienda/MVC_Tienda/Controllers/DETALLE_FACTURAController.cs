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
        private db17842Entities db = new db17842Entities();

        // GET: DETALLE_FACTURA
        public ActionResult Index()
        {
            var dETALLE_FACTURA = db.DETALLE_FACTURA.Include(d => d.FACTURA).Include(d => d.PRODUCTO);
            return View(dETALLE_FACTURA.ToList());
        }

        // GET: DETALLE_FACTURA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
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
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "FAC_ESTADO");
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION");
            return View();
        }

        // POST: DETALLE_FACTURA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DET_FAC,FAC_COD,PRD_COD,DTF_CANTIDAD,DTF_PRECIO")] DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_FACTURA.Add(dETALLE_FACTURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "FAC_ESTADO", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // GET: DETALLE_FACTURA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_FACTURA dETALLE_FACTURA = db.DETALLE_FACTURA.Find(id);
            if (dETALLE_FACTURA == null)
            {
                return HttpNotFound();
            }
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "FAC_ESTADO", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // POST: DETALLE_FACTURA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DET_FAC,FAC_COD,PRD_COD,DTF_CANTIDAD,DTF_PRECIO")] DETALLE_FACTURA dETALLE_FACTURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_FACTURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FAC_COD = new SelectList(db.FACTURA, "FAC_COD", "FAC_ESTADO", dETALLE_FACTURA.FAC_COD);
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", dETALLE_FACTURA.PRD_COD);
            return View(dETALLE_FACTURA);
        }

        // GET: DETALLE_FACTURA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == 0)
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
        public ActionResult DeleteConfirmed(decimal id)
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
