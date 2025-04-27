using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    public class DTO_Detalle_Factura
    {
        public decimal FAC_COD { get; set; }
        public string PRD_DESCRIPCION { get; set; }
        public Nullable<decimal> PRD_PRECIO { get; set; }
        public Nullable<decimal> DTF_CANTIDAD { get; set; }
        public Nullable<decimal> DTF_PRECIO { get; set; }
    }
}
