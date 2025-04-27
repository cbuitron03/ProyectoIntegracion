using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logica_clientes
    {
        datosCliente op = new datosCliente();

        public List<CLIENTE> SeleccionarClientes()
        {
            return op.SeleccionarClientes();
        }

        public List<CLIENTE> seleccionarClientePorNombre(string nombre)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_NOMBRE.Contains(nombre)).ToList();
        }

        public List<CLIENTE> seleccionarClientePorCedula(string cedula)
        {
            return SeleccionarClientes().Where(cli => cli.CLI_CEDULA.Contains(cedula)).ToList();
        }

        #region metodos de accion 

        public decimal insertarCliente(CLIENTE cliInsertado)
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
    }
}
