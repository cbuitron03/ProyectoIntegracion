using AccesoDatos;
using AccesoDatos.DTO;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de APIDTODetalleFactura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIDTODetalleFactura : System.Web.Services.WebService
    {

        logica_DTODetalleFactura op = new logica_DTODetalleFactura();

        [WebMethod]
        public List<DTO_Detalle_Factura> MostrarDetalles()
        {
            return op.MostrarDetalles();
        }

        [WebMethod]
        public DTO_Detalle_Factura MostrarDetallesPorId(int id)
        {
            return op.MostrarDetallesPorId(id);
        }
    }
}
