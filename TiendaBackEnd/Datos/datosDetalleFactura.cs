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
        db17842Entities2 _context;
        public datosDetalleFactura()
        {
            _context = new db17842Entities2();
        }

        public List<DETALLE_FACTURA> SeleccionarDetalles()
        {
            return _context.DETALLE_FACTURA.ToList();
        }

        #region metodos de accion 

        public decimal insertarDetalleFac(DETALLE_FACTURA proInsertado)
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
                pro.DTF_CANTIDAD = proActualizado.DTF_CANTIDAD;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarDetalleFac(decimal id)
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
        private DETALLE_FACTURA seleccionarDetallePorId(decimal id)
        {
            return _context.DETALLE_FACTURA.Where(pro => pro.ID_DET_FAC == id).SingleOrDefault();
        }
    }
}
