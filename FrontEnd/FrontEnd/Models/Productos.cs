using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrontEnd.APIDTOImagenes;
using FrontEnd.APIDTOProductos;


namespace FrontEnd.Models
{
    public class ImagenProducto
    {
        public string IMG_TIPO { get; set; }
        public string IMG_URL { get; set; }
    }

    public class Producto
    {
        public int PRD_COD { get; set; }
        public string PRD_DESCRIPCION { get; set; }
        public decimal PRD_PRECIO { get; set; }
        public int PRD_STOCK { get; set; }
        public string PRD_ESTADO { get; set; }

        public List<ImagenProducto> IMAGEN { get; set; } = new List<ImagenProducto>();

        // Método de mapeo estático
        public static Producto FromServicio(FrontEnd.APIDTOProductos.DTO_Producto prodServicio, List<DTO_Imagen> imagenes)
        {
            if (prodServicio == null) return null;

            return new Producto
            {
                PRD_COD = prodServicio.PRD_COD,
                PRD_DESCRIPCION = prodServicio.PRD_DESCRIPCION,
                PRD_PRECIO = (decimal)prodServicio.PRD_PRECIO,
                PRD_STOCK = (int)prodServicio.PRD_STOCK,
                PRD_ESTADO = prodServicio.PRD_ESTADO,
                IMAGEN = imagenes?.Select(img => new ImagenProducto
                {
                    IMG_URL = img.IMG_URL,
                    IMG_TIPO = img.IMG_TIPO
                }).ToList() ?? new List<ImagenProducto>()
            };
        }
    }
}
