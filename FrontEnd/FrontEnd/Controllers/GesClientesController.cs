using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class GesClientesController : Controller
    {
        // GET: GesClientes
        public ActionResult Index()
        {
            return View();
        }

        // GET: GesClientes/Details/5
        public ActionResult Details(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = cedula;
            return View();
        }

        // GET: GesClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GesClientes/Create
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

        // GET: GesClientes/Edit/5
        public ActionResult Edit(string cedula)
        {
            if (string.IsNullOrEmpty(cedula))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Cedula = cedula;
            return View();
        }



        // GET: GesClientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
