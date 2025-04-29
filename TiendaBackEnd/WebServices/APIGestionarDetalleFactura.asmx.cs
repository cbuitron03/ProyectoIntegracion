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
    /// Descripción breve de APIGestionarDetalleFactura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIGestionarDetalleFactura : System.Web.Services.WebService
    {

        logica_detallefactura op = new logica_detallefactura();

        [WebMethod]
        public List<DETALLE_FACTURA> SeleccionarDetalles()
        {
            return op.SeleccionarDetalles();
        }


        [WebMethod]
        public DETALLE_FACTURA seleccionarDetallesPorID(int id)
        {
            return SeleccionarDetalles().Where(pro => pro.FAC_COD == id).SingleOrDefault();
        }

        #region metodos de accion 

        [WebMethod]
        public int insertarDetalleFac(DETALLE_FACTURA proInsertado)
        {
            return op.insertarDetalle(proInsertado);
        }

        [WebMethod]
        public bool actualizarDetalleFac(DETALLE_FACTURA proActualizado)
        {
            return op.actualizarDetalleFac(proActualizado);
        }

        [WebMethod]
        public bool eliminarDetalleFac(int id)
        {
            return op.eliminarDetalleFac(id);
        }

        #endregion

    }
}
