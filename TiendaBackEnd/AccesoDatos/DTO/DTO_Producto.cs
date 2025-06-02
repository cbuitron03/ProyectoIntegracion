using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DTO_Producto
    {
        public int idProducto { get; set; }
        public string prodCategoria { get; set; }
        public string prodNombre { get; set; }
        public string prodDescripcion { get; set; }
        public Nullable<decimal> prodPrecio { get; set; }
        public Nullable<int> prodStock { get; set; }
        public string prodProveedor { get; set; }
        public List<string> prodImg { get; set; }
    }
}
