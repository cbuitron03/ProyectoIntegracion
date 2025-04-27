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
    /// Descripción breve de APIDTOFacturas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIDTOFacturas : System.Web.Services.WebService
    {

        logica_DTOFactura op = new logica_DTOFactura();

        [WebMethod]
        public List<DTO_Factura> MostrarFacturas()
        {
            return op.MostrarFacturas();
        }

        [WebMethod]
        public DTO_Factura MostrarFacturaPorId(decimal codigo)
        {
            return MostrarFacturas().Where(pro => pro.FAC_COD == codigo).SingleOrDefault();
        }
    }
}
