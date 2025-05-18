using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_clientes
    {
        datosCliente op = new datosCliente();

        public List<CLIENTE> SeleccionarClientes()
        {
            return op.SeleccionarClientes();
        }

        public CLIENTE seleccionarClientePorNombre(string nombre)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_NOMBRE.Contains(nombre)).SingleOrDefault();
        }

        public CLIENTE seleccionarClientePorCedula(string cedula)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_CEDULA.Contains(cedula)).SingleOrDefault();
        }

        #region metodos de accion 

        public string insertarCliente(CLIENTE cliInsertado)
        {
            return op.insertarCliente(cliInsertado);
        }

        public bool actualizarCliente(CLIENTE cliActualizado)
        {
            return op.actualizarCliente(cliActualizado);
        }

        public bool eliminarCliente(string cedula)
        {
            return op.eliminarCliente(cedula);
        }

        # endregion
        public bool actualizarEstadoCliente(string CLI_CEDULA, string CLI_ESTADO)
        {
            return op.actualizarEstadoCliente(CLI_CEDULA, CLI_ESTADO);
        }
    }
}
