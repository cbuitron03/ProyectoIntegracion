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
    /// Descripción breve de APIGestionarUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIGestionarUsuarios : System.Web.Services.WebService
    {
        logica_usuarios op = new logica_usuarios();
        [WebMethod]
        public List<USUARIO> SeleccionarUsuarios()
        {
            return op.SeleccionarUsuarios();
        }
       
        [WebMethod]
        public decimal insertarUsuario(USUARIO usuarioInsertado)
        {
            return op.insertarUsuario(usuarioInsertado);
        }
        [WebMethod]
        public bool actualizarUsuario(USUARIO usuarioActualizado)
        {
            return op.actualizarUsuario(usuarioActualizado);
        }
        [WebMethod]
        public bool eliminarUsuario(decimal id)
        {
            return op.eliminarUsuario(id);
        }
    }
}