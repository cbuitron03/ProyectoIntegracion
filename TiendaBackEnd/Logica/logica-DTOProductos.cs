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

        public DTO_Producto MostrarProductosPorId(int id)
        {
            return MostrarProductos().Where(pro => pro.idProducto == id).SingleOrDefault();
        }
        public bool verificarStock(int idProducto, int cantidadSolicitada)
        {
            return op.verificarStock(idProducto, cantidadSolicitada);
        }
    }
}
