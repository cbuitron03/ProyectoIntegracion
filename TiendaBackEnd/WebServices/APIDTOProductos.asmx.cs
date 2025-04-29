using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using Logica;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de APIDTOProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIDTOProductos : System.Web.Services.WebService
    {

        
        logica_DTOProductos op = new logica_DTOProductos();

        [WebMethod]
        public List<DTO_Producto> MostrarProductos()
        {
            return op.MostrarProductos();
        }

        [WebMethod]
        public DTO_Producto MostrarProductoPorId(int id)
        {
            return op.MostrarProductoPorId(id);
        }
    }
}
