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
    /// Descripción breve de APIGestionarClientes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIGestionarClientes : System.Web.Services.WebService
    {
        logica_clientes op = new logica_clientes();

        [WebMethod]
        public List<CLIENTE> SeleccionarClientes()
        {
            return op.SeleccionarClientes();
        }

        [WebMethod]

        public List<CLIENTE> seleccionarClientesPorNombre(string nombre)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_NOMBRE.Contains(nombre)).ToList();
        }

        [WebMethod]
        public List<CLIENTE> seleccionarClientePorCedula(string cedula)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_CEDULA.Contains(cedula)).ToList();
        }

        #region metodos de accion 

        [WebMethod]
        public string insertarCliente(CLIENTE cliInsertado)
        {
            return op.insertarCliente(cliInsertado);
        }

        [WebMethod]
        public bool actualizarCliente(CLIENTE cliActualizado)
        {
            return op.actualizarCliente(cliActualizado);
        }

        [WebMethod]
        public bool eliminarCliente(string cliente)
        {
            return op.eliminarCliente(cliente);
        }

        #endregion

    }
}