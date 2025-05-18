using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    [Serializable]
    public class productoCantidadDTO
    {
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    }
}
