using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Factura
    {
        public int FAC_COD { get; set; }
        public string ID_EMP { get; set; }
        public string CLI_CEDULA { get; set; }
        public string CLI_NOMBRE { get; set; }
        public string CLI_CORREO { get; set; }
        public string CLI_DIRECCION { get; set; }
        public Nullable<System.DateTime> FAC_FECHA { get; set; }
        public string FAC_ESTADO { get; set; }
        public Nullable<decimal> FAC_SUBTOTAL { get; set; }
        public Nullable<decimal> FAC_IVA { get; set; }
        public Nullable<decimal> FAC_TOTAL { get; set; }
    }
}