using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    public class DTO_Factura
    {
        public decimal FAC_COD { get; set; }
        public string EMP_RUC { get; set; }
        public string EMP_NOMBRE { get; set; }
        public string CLI_CEDULA { get; set; }
        public string CLI_NOMBRE { get; set; }
        public string CLI_CORREO { get; set; }
        public string CLI_DIRECCION { get; set; }
        public Nullable<decimal> FAC_SUBTOTAL { get; set; }
        public Nullable<decimal> FAC_IVA { get; set; }
        public Nullable<decimal> FAC_TOTAL { get; set; }
    }
}
