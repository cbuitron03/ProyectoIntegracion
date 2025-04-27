using AccesoDatos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de APIFacturas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIFacturas : System.Web.Services.WebService
    {

        logica_factura op = new logica_factura();

        [WebMethod]
        public List<FACTURA> SeleccionarFacturas()
        {
            return op.SeleccionarFactura();
        }

        [WebMethod]
        public FACTURA seleccionarFacturaPorID(decimal codigo)
        {
            return SeleccionarFacturas().Where(pro => pro.FAC_COD == codigo).SingleOrDefault();
        }

        #region metodos de accion 

        [WebMethod]
        public decimal insertarFactura(FACTURA proInsertado)
        {
            return op.insertarFactura(proInsertado);
        }

        [WebMethod]
        public bool actualizarFactura(FACTURA proActualizado)
        {
            return op.actualizarFactura(proActualizado);
        }

        [WebMethod]
        public bool eliminarFactura(decimal id)
        {
            return op.eliminarFactura(id);
        }

        #endregion

    }
}
