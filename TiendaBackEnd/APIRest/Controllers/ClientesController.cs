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
    public class ClientesController : ApiController
    {
        logica_clientes op = new logica_clientes();
        // GET api/<controller>
        public List<CLIENTE> Get()
        {
            return op.SeleccionarClientes();
        }

        // GET api/<controller>/5
        /*public CLIENTE Get(string nombre)
        {
            return op.seleccionarClientePorNombre(nombre);
        }*/

        public CLIENTE Get(string cedula)
        {
            return op.seleccionarClientePorCedula(cedula);
        }

        // POST api/<controller>
        /*public void Post([FromBody] string value)
        {
        */

        // PUT api/<controller>/5
        public bool Put(string CLI_CEDULA, string CLI_ESTADO)
        {
            return op.actualizarEstadoCliente(CLI_CEDULA, CLI_ESTADO);
        }
        public bool Put(CLIENTE cliActualizado)
        {
            return op.actualizarCliente(cliActualizado);
        }
        // DELETE api/<controller>/5
        public bool Delete(string cedula)
        {
            return op.actualizarEstadoCliente(cedula, "Inactivo");
        }

    }
}