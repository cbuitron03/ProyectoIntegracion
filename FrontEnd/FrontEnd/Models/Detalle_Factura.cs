using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Detalle_Factura
    {
        public int ID_DET_FAC { get; set; }
        public int FAC_COD { get; set; }
        public int PRD_COD { get; set; }
        public Nullable<int> DTF_CANTIDAD { get; set; }
        public Nullable<decimal> DTF_PRECIO { get; set; }
        public string DTF_ESTADO { get; set; }
    }
}