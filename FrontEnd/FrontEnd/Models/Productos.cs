using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Productos
    {
        public int idProducto { get; set; } = 0;
        public string prodDescripcion { get; set; } = "";
        public double prodPrecio { get; set; } = 0;
        public int prodStock { get; set; } = 0;
        public string prodCategoria { get; set; } = "";
        public string prodNombre { get; set; } = "";
        public string prodProveedor { get; set; } = "";
        public int prodEstado { get; set;} = 0;

    }
}