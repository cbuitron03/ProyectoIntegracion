using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    [Serializable]
    public class DTO_Producto
    {
        public int PRD_COD { get; set; }
        public string PRD_DESCRIPCION { get; set; }
        public Nullable<decimal> PRD_PRECIO { get; set; }
        public Nullable<int> PRD_STOCK { get; set; }
        public string PRD_ESTADO { get; set; }
        public string IMG_URL { get; set; }
    }
}
