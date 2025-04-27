using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DTO_Producto
    {
        public decimal PRD_COD { get; set; }
        public string PRD_DESCRIPCION { get; set; }
        public decimal PRD_PRECIO { get; set; }
        public decimal PRD_STOCK { get; set; }
        public string IMG_URL { get; set; }
    }
}
