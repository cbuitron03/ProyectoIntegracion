using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ImagenProducto
    {
        public string IMG_URL { get; set; }
    }

    public class Productos
    {
        public decimal PRD_COD { get; set; }
        public string PRD_DESCRIPCION { get; set; }
        public decimal PRD_PRECIO { get; set; }
        public decimal PRD_STOCK { get; set; }

        public List<ImagenProducto> Imagen { get; set; } = new List<ImagenProducto>();

        // Método de mapeo estático
        public static Productos FromServicio(FrontEnd.APIDTOProductos.PRODUCTO prodServicio)
        {
            if (prodServicio == null) return null;

                PRD_COD = prodServicio.PRD_COD,
                PRD_DESCRIPCION = prodServicio.PRD_DESCRIPCION,
                PRD_PRECIO = (decimal)prodServicio.PRD_PRECIO,
                PRD_STOCK = (decimal)prodServicio.PRD_STOCK
                Imagen = new List<ImagenProducto>
                {
                    new ImagenProducto
                    {
                        IMG_URL = prodServicio.IMAGEN.ToString(),
                    }
                }
        };
        
    }