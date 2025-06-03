using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Carrito1
    {
        public int id { get; set; }       // Coincide con JSON y uso en Detalles
        public string nombre { get; set; }
        public string imagen { get; set; }
        public decimal precio { get; set; }   // Coincide con JSON y uso en Cálculos/Detalles
        public int cantidad { get; set; } // Coincide con JSON y uso en Cálculos/Detalles
    }
}