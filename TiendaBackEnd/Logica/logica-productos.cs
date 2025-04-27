using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos; 


namespace Logica
{
    public class logica_productos
    {
        datosProductos op = new datosProductos();

        public List<PRODUCTO> SeleccionarProductos()
        {
            return op.SeleccionarProductos();
        }

        public List<PRODUCTO> seleccionarProductoPorNombre(string nombre)
        {
            return SeleccionarProductos().Where(pro=>pro.PRD_DESCRIPCION.Contains(nombre)).ToList();
        }

        public PRODUCTO seleccionarProductoPorID(decimal id)
        {
            return SeleccionarProductos().Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }

        #region metodos de accion 

        public decimal insertarProducto(PRODUCTO proInsertado)
        {
           return op.insertarProducto(proInsertado);
        }

        public bool actualizarProducto(PRODUCTO proActualizado)
        {
            return op.actualizarProducto(proActualizado);
        }

        public bool eliminarProducto(decimal id)
        {
            return op.eliminarProducto(id);
        }

        # endregion
    }
}
