using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class Carrito1Controller : Controller
    {
        // GET: Carrito1
        public ActionResult Index()
        {
            return View();
        }

        // GET: Carrito1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrito1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito1/Create
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

        // GET: Carrito1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito1/Edit/5
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

        // GET: Carrito1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito1/Delete/5
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
