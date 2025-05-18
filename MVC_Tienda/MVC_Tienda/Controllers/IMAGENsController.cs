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
    public class IMAGENsController : Controller
    {
        private db17842Entities1 db = new db17842Entities1();

        // GET: IMAGENs
        public ActionResult Index()
        {
            var iMAGEN = db.IMAGEN.Include(i => i.PRODUCTO);
            return View(iMAGEN.ToList());
        }

        // GET: IMAGENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            return View(iMAGEN);
        }

        // GET: IMAGENs/Create
        public ActionResult Create()
        {
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION");
            return View();
        }

        // POST: IMAGENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IMG_ID,PRD_COD,IMG_URL,IMG_TIPO")] IMAGEN iMAGEN)
        {
            if (ModelState.IsValid)
            {
                db.IMAGEN.Add(iMAGEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", iMAGEN.PRD_COD);
            return View(iMAGEN);
        }

        // GET: IMAGENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", iMAGEN.PRD_COD);
            return View(iMAGEN);
        }

        // POST: IMAGENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IMG_ID,PRD_COD,IMG_URL,IMG_TIPO")] IMAGEN iMAGEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iMAGEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRD_COD = new SelectList(db.PRODUCTO, "PRD_COD", "PRD_DESCRIPCION", iMAGEN.PRD_COD);
            return View(iMAGEN);
        }

        // GET: IMAGENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            if (iMAGEN == null)
            {
                return HttpNotFound();
            }
            return View(iMAGEN);
        }

        // POST: IMAGENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IMAGEN iMAGEN = db.IMAGEN.Find(id);
            db.IMAGEN.Remove(iMAGEN);
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
