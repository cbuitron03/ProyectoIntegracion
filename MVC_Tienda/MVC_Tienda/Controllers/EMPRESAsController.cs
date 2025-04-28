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
    public class EMPRESAsController : Controller
    {
        private db17842Entities db = new db17842Entities();

        // GET: EMPRESAs
        public ActionResult Index()
        {
            return View(db.EMPRESA.ToList());
        }

        // GET: EMPRESAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPRESAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EMP,EMP_RUC,EMP_NOMBRE,EMP_MISION,EMP_VISION,EMP_TELF")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(eMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPRESA);
        }

        // GET: EMPRESAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EMP,EMP_RUC,EMP_NOMBRE,EMP_MISION,EMP_VISION,EMP_TELF")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            db.EMPRESA.Remove(eMPRESA);
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
