using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccesoDatos;
using Logica;
using Microsoft.Ajax.Utilities;

namespace APIRest.Controllers
{
    public class UsuariosController : ApiController
    {
        logica_usuarios op = new logica_usuarios();

        // GET: api/Usuarios
        public List<USUARIO> Get()
        {
            return op.SeleccionarUsuarios();
        }
        // GET: api/Usuarios/5
        public USUARIO Get(string usuario)
        {
            return op.seleccionarUsuarioPorUsuario(usuario);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/autenticarUsuario")]
        public bool autenticarUsuario(string US_USUARIO, string US_PASS)
        {
            if (op.autenticarUsuario(US_USUARIO, US_PASS) != null)
                return true;
            else
                return false;
        }
        // POST: api/Usuarios
        public bool Post(
            string CLI_CEDULA,
            int US_COD,
            string CLI_NOMBRE,
            string CLI_TELEFONO,
            string CLI_CORREO,
            string CLI_DIRECCION,
            string CLI_ESTADO,
            string US_USUARIO,
            string US_PASS,
            string US_ROL)
        {
            return op.registrarUsuarioCliente(CLI_CEDULA,
            US_COD,
            CLI_NOMBRE,
            CLI_TELEFONO,
            CLI_CORREO,
            CLI_DIRECCION,
            CLI_ESTADO,
            US_USUARIO,
            US_PASS,
            US_ROL);
        }

        // PUT: api/Usuarios/5
        public bool Put(USUARIO usuActualizado)
        {
            return op.actualizarUsuario(usuActualizado);
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
