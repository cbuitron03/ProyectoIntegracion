using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccesoDatos;
using Logica;

namespace APIRest.Controllers
{
    public class DetalleFacturaController : ApiController
    {
        logica_detallefactura op = new logica_detallefactura();
        // GET: api/DetalleFactura
        public List<DETALLE_FACTURA> Get()
        {
            return op.SeleccionarDetalles();
        }

        // GET: api/DetalleFactura/5
        public List<DETALLE_FACTURA> Get(int id)
        {
            return op.seleccionarDetallePorFactura(id);
        }

        // POST: api/DetalleFactura
        public int Post(DETALLE_FACTURA proInsertado)
        {
            return op.insertarDetalle(proInsertado);
        }

        // PUT: api/DetalleFactura/5
        public bool Put(DETALLE_FACTURA proActualizado)
        {
            return op.actualizarDetalleFac(proActualizado);
        }

        // DELETE: api/DetalleFactura/5
        public bool Delete(int prd_cod, int fac_num)
        {
            return op.actualizarEstadoDetalle(prd_cod, fac_num, "Anulado");
        }
    }
}
