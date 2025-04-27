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
    /// Descripción breve de APIDTOUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIDTOUsuarios : System.Web.Services.WebService
    {
        logica_DTOUsuarios op = new logica_DTOUsuarios();

        [WebMethod]
        public List<DTO_Usuario> MostrarUsuarios()
        {
            return op.MostrarUsuarios();
        }
    }
}