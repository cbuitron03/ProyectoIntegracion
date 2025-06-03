using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class GesUsuariosController : Controller
    {
        // GET: GesUsuarios
        public ActionResult Index()
        {
            return View();
        }

        // GET: GesUsuarios/Details/5
        public ActionResult Details(string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Index");
            }

            ViewBag.Usuario = usuario;
            return View();
        }



        // GET: GesUsuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GesUsuarios/Create
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

        // GET: GesUsuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GesUsuarios/Edit/5
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

        // GET: GesUsuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GesUsuarios/Delete/5
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
