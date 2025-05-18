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

        public PRODUCTO seleccionarProductoPorNombre(string nombre)
        {
            return SeleccionarProductos().Where(pro => pro.PRD_DESCRIPCION.Contains(nombre)).SingleOrDefault();
        }

        public PRODUCTO seleccionarProductoPorID(int id)
        {
            return SeleccionarProductos().Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }

        #region metodos de accion 

        //public int insertarProducto(PRODUCTO proInsertado)
        //{
        //   return op.insertarProducto(proInsertado);
        //}

        public bool actualizarProducto(PRODUCTO proActualizado)
        {
            return op.actualizarProducto(proActualizado);
        }

        public bool eliminarProducto(int id)
        {
            return op.eliminarProducto(id);
        }

        # endregion
        public int insertarProducto(string PRD_NOMBRE, string PRD_DESCRIPCION, decimal PRD_PRECIO, int PRD_STOCK, string PRD_ESTADO)
        {
            PRODUCTO producto = new PRODUCTO();
            producto.PRD_DESCRIPCION = PRD_DESCRIPCION;
            producto.PRD_PRECIO = PRD_PRECIO;
            producto.PRD_STOCK = PRD_STOCK;
            producto.PRD_ESTADO = PRD_ESTADO;
            producto.PRD_CATEGORIA = "Peluche";
            producto.PRD_NOMBRE = PRD_NOMBRE;
            producto.PRD_PROVEEDOR = "Ternura Infinita";
            // Insertar el producto y obtener el ID generado
            int PRD_COD = op.insertarProducto(producto);

            return PRD_COD;
        }
        public bool actualizarEstadoProducto(int PRD_COD, string PRD_ESTADO)
        {
            return op.actualizarEstadoProducto(PRD_COD, PRD_ESTADO);
        }
        public bool verificarStock(int PRD_COD, int cantidad)
        {
            return op.verificarStock(PRD_COD, cantidad);
        }
        public float obtenerPrecioUnitario(int id)
        {
            return op.obtenerPrecioProducto(id);
        }
        public bool disminuirStock(int id, int cantidad)
        {
            return op.disminuirStock(id, cantidad);
        }
    }
}