using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class GesFacturasController : Controller
    {
        // GET: GesFacturas
        public ActionResult Index()
        {
            return View();
        }

        // GET: GesFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // Redirige o muestra un error porque no llegó un id válido
                return RedirectToAction("Index");
            }

            ViewBag.FacturaId = id.Value;
            return View();
        }

        // GET: GesFacturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GesFacturas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GesFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                // Redirige o muestra un error porque no llegó un id válido
                return RedirectToAction("Index");
            }

            ViewBag.FacturaId = id.Value;
            return View();
        }


        // GET: GesFacturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GesFacturas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
