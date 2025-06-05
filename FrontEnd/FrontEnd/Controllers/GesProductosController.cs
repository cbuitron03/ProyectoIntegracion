using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class GesProductosController : Controller
    {
        // GET: GesProductos
        public ActionResult Index()
        {
            return View();
        }

        // GET: GesProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                // Redirige o muestra un error porque no llegó un id válido
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = id.Value;
            return View();
        }



        // GET: GesProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GesProductos/Create
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

        // GET: GesProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = id.Value;
            return View();
        }


        // POST: GesProductos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GesProductos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GesProductos/Delete/5
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
