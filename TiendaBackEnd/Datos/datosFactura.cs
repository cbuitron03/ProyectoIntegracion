using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosFactura
    {
        db17842Entities _context;
        public datosFactura()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<FACTURA> SeleccionarFacturas()
        {
            return _context.FACTURA.ToList();
        }

        #region metodos de accion 

        public int insertarFactura(FACTURA proInsertado)
        {
            _context.FACTURA.Add(proInsertado);
            _context.SaveChanges();
            return proInsertado.FAC_COD;
        }

        public bool actualizarFactura(FACTURA proActualizado)
        {
            FACTURA pro = seleccionarFacturaPorId(proActualizado.FAC_COD);
            if (pro != null)
            {
                pro.FAC_FECHA = proActualizado.FAC_FECHA;
                pro.FAC_ESTADO = proActualizado.FAC_ESTADO;
                pro.FAC_IVA = proActualizado.FAC_IVA;
                pro.FAC_SUBTOTAL = proActualizado.FAC_SUBTOTAL;
                pro.FAC_TOTAL = proActualizado.FAC_TOTAL;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarFactura(int codigo)
        {
            FACTURA pro = seleccionarFacturaPorId(codigo);
            if (pro != null)
            {
                _context.FACTURA.Remove(pro);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        private FACTURA seleccionarFacturaPorId(int codigo)
        {
            return _context.FACTURA.Where(pro => pro.FAC_COD == codigo).SingleOrDefault();
        }
    }
}
