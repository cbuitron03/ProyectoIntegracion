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
    public class UsuariosController : ApiController
    {
        logica_usuarios op = new logica_usuarios();

        // GET: api/Usuarios
        public List<USUARIO> Get()
        {
            return op.SeleccionarUsuarios();
        }
        public USUARIO autenticarUsuario(string US_USUARIO, string US_PASS)
        {
            return op.autenticarUsuario(US_USUARIO, US_PASS);
        }
        // GET: api/Usuarios/5
        public USUARIO Get(string usuario)
        {
            return op.seleccionarUsuarioPorUsuario(usuario);
        }

        // POST: api/Usuarios
        public int Post(USUARIO usuInsertado)
        {
            return op.insertarUsuario(usuInsertado);
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
