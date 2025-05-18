using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosProductos
    {
        db17842Entities _context;
        public datosProductos()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<PRODUCTO> SeleccionarProductos()
        {
            return _context.PRODUCTO.ToList();
        }

        #region metodos de accion 

        public int insertarProducto(PRODUCTO proInsertado)
        {
            _context.PRODUCTO.Add(proInsertado);
            _context.SaveChanges();
            return proInsertado.PRD_COD;
        }

        public bool actualizarProducto(PRODUCTO proActualizado)
        {
            PRODUCTO pro = seleccionarProductoPorId(proActualizado.PRD_COD);
            if (pro != null)
            {
                pro.PRD_DESCRIPCION = proActualizado.PRD_DESCRIPCION;
                pro.PRD_PRECIO = proActualizado.PRD_PRECIO;
                pro.PRD_STOCK = proActualizado.PRD_STOCK;
                pro.PRD_ESTADO = proActualizado.PRD_ESTADO;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarProducto(int id)
        {
            PRODUCTO pro = seleccionarProductoPorId(id);
            if (pro != null)
            {
                _context.PRODUCTO.Remove(pro);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        public PRODUCTO seleccionarProductoPorId(int id)
        {
            return _context.PRODUCTO.Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }
        public bool actualizarEstadoProducto(int PRD_COD, string PRD_ESTADO)
        {
            PRODUCTO producto = _context.PRODUCTO
                .Where(p => p.PRD_COD == PRD_COD)
                .SingleOrDefault();

            if (producto != null)
            {
                producto.PRD_ESTADO = PRD_ESTADO;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verificarStock(int id, int cantidad)
        {
            PRODUCTO pro = seleccionarProductoPorId(id);
            if (pro != null)
            {
                if (pro.PRD_STOCK >= cantidad)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool disminuirStock(int id, int cantidad)
        {
            PRODUCTO pro = seleccionarProductoPorId(id);
            if (pro != null && pro.PRD_STOCK >= cantidad)
            {
                pro.PRD_STOCK -= cantidad;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false; // No existe el producto o no hay suficiente stock
            }
        }
        public float obtenerPrecioProducto(int idProducto)
        {
            return (float)_context.PRODUCTO.Where(p => p.PRD_COD == idProducto).Select(p => p.PRD_PRECIO).FirstOrDefault();
        }
    }
}
