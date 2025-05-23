﻿using System;
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
    public class CLIENTEsController : Controller
    {
        private db17842Entities1 db = new db17842Entities1();

        // GET: CLIENTEs
        public ActionResult Index()
        {
            var cLIENTE = db.CLIENTE.Include(c => c.USUARIO);
            return View(cLIENTE.ToList());
        }

        // GET: CLIENTEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Create
        public ActionResult Create()
        {
            ViewBag.US_COD = new SelectList(db.USUARIO, "US_COD", "US_USUARIO");
            return View();
        }

        // POST: CLIENTEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLI_CEDULA,US_COD,CLI_NOMBRE,CLI_TELEFONO,CLI_CORREO,CLI_DIRECCION,CLI_ESTADO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTE.Add(cLIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.US_COD = new SelectList(db.USUARIO, "US_COD", "US_USUARIO", cLIENTE.US_COD);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.US_COD = new SelectList(db.USUARIO, "US_COD", "US_USUARIO", cLIENTE.US_COD);
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLI_CEDULA,US_COD,CLI_NOMBRE,CLI_TELEFONO,CLI_CORREO,CLI_DIRECCION,CLI_ESTADO")] CLIENTE cLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.US_COD = new SelectList(db.USUARIO, "US_COD", "US_USUARIO", cLIENTE.US_COD);
            return View(cLIENTE);
        }

        // GET: CLIENTEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTE);
        }

        // POST: CLIENTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            db.CLIENTE.Remove(cLIENTE);
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
