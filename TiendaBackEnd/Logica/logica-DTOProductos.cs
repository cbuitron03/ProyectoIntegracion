using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_DTOProductos
    {
        datosDTOProducto op = new datosDTOProducto();

        public List<DTO_Producto> MostrarProductos()
        { 
            return op.seleccionarProductosDTO();
        }

        public DTO_Producto MostrarProductoPorId(decimal id)
        {
            return MostrarProductos().Where(pro=>pro.PRD_COD==id).SingleOrDefault();    
        }

    }
}
