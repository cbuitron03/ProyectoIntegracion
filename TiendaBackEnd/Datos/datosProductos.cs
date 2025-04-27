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
        db17842Entities2 _context;
        public datosProductos()
        {
            _context = new db17842Entities2();
        }

        public List<PRODUCTO> SeleccionarProductos()
        {
            return _context.PRODUCTO.ToList();
        }

        #region metodos de accion 

        public decimal insertarProducto(PRODUCTO proInsertado)
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
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarProducto(decimal id)
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
        private PRODUCTO seleccionarProductoPorId(decimal id)
        {
            return _context.PRODUCTO.Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }
    }
}
