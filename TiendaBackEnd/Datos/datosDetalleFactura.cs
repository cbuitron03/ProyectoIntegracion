using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosDetalleFactura
    {
        db17842Entities _context;
        public datosDetalleFactura()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<DETALLE_FACTURA> SeleccionarDetalles()
        {
            return _context.DETALLE_FACTURA.ToList();
        }

        #region metodos de accion 

        public int insertarDetalleFac(DETALLE_FACTURA proInsertado)
        {
            _context.DETALLE_FACTURA.Add(proInsertado);
            _context.SaveChanges();
            return proInsertado.ID_DET_FAC;
        }

        public bool actualizarDetalleFac(DETALLE_FACTURA proActualizado)
        {
            DETALLE_FACTURA pro = seleccionarDetallePorId(proActualizado.ID_DET_FAC);
            if (pro != null)
            {
                pro.DTF_CANTIDAD = proActualizado.DTF_CANTIDAD;
                pro.DTF_PRECIO = proActualizado.DTF_PRECIO;
                pro.DTF_ESTADO = proActualizado.DTF_ESTADO;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarDetalleFac(int id)
        {
            DETALLE_FACTURA pro = seleccionarDetallePorId(id);
            if (pro != null)
            {
                _context.DETALLE_FACTURA.Remove(pro);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        private DETALLE_FACTURA seleccionarDetallePorId(int id)
        {
            return _context.DETALLE_FACTURA.Where(pro => pro.ID_DET_FAC == id).SingleOrDefault();
        }
    }
}
