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
    /// Descripción breve de APIDTOClientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIDTOClientes : System.Web.Services.WebService
    {
        logica_DTOClientes op = new logica_DTOClientes();

        [WebMethod]
        public List<DTO_Cliente> MostrarClientes()
        {
            return op.MostrarClientes();
        }

        [WebMethod]
        public DTO_Cliente MostrarClientePorCedula(string cedula)
        {
            return op.MostrarClientePorCedula(cedula);
        }
    }
}
