using FrontEnd.APIGestionarImagenes;
using FrontEnd.APIDTOProductos;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductosController : Controller
    {
        public ActionResult Index()
        {
            var client = new APIDTOProductosSoapClient();
            var clientImg = new APIGestionarImagenesSoapClient();


            //Llamar al servicio
            var respuesta = client.MostrarProductos();
            var productos = new List<Producto>();

            //Mapear la respuesta del WS a tu modelo
            foreach (var prodServicio in respuesta)
            {
                // Obtener las imágenes desde el servicio de imágenes
                var imagenes = clientImg.seleccionarImagenPorIdProducto(prodServicio.PRD_COD);

                var imagenesMapeadas = imagenes?.Where(img => img != null && !string.IsNullOrWhiteSpace(img.IMG_URL))
                    .Select(img => new ImagenProducto
                    {
                        IMG_URL = img.IMG_URL,
                        IMG_TIPO = img.IMG_TIPO
                    }).ToList() ?? new List<ImagenProducto>();

                productos.Add(new Producto
                {
                    PRD_COD = prodServicio.PRD_COD,
                    PRD_DESCRIPCION = prodServicio.PRD_DESCRIPCION,
                    PRD_PRECIO = (decimal)prodServicio.PRD_PRECIO,
                    PRD_STOCK = (int)prodServicio.PRD_STOCK,
                    PRD_ESTADO = prodServicio.PRD_ESTADO,
                    IMAGEN = imagenesMapeadas
                });

            }

            return View(productos);
        }

    }
}
