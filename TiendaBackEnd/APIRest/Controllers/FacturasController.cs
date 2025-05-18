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
    public class FacturasController : ApiController
    {
        // GET: api/Facturas
        logica_factura op = new logica_factura();

        // GET: api/Facturas/5
        public List<FACTURA> Get()
        {
            return op.SeleccionarFactura();
        }
        public FACTURA Get(int id)
        {
            return op.seleccionarFacturaPorID(id);
        }
        // POST: api/Facturas
        public int Post(FACTURA proInsertado)
        {
            return op.insertarFactura(proInsertado);
        }

        // PUT: api/Facturas/5
        public bool Put(FACTURA proActualizado)
        {
            return op.actualizarFactura(proActualizado);
        }
        public bool Put(int FAC_COD, string FAC_ESTADO)
        {
            return op.actualizarEstadoFactura(FAC_COD, FAC_ESTADO);
        }
        // DELETE: api/Facturas/5
        public bool Delete(int FAC_COD, string FAC_ESTADO)
        {
            return op.actualizarEstadoFactura(FAC_COD, "Anulado");
        }
       
    }
}
