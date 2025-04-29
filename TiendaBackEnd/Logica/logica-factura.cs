using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_factura
    {
        datosFactura op = new datosFactura();

        public List<FACTURA> SeleccionarFactura()
        {
            return op.SeleccionarFacturas();
        }

        public FACTURA seleccionarFacturaPorID(int codigo)
        {
            return SeleccionarFactura().Where(pro => pro.FAC_COD == codigo).SingleOrDefault();
        }

        #region metodos de accion 

        public int insertarFactura(FACTURA proInsertado)
        {
            return op.insertarFactura(proInsertado);
        }

        public bool actualizarFactura(FACTURA proActualizado)
        {
            return op.actualizarFactura(proActualizado);
        }

        public bool eliminarFactura(int id)
        {
            return op.eliminarFactura(id);
        }

        # endregion
    }
}
