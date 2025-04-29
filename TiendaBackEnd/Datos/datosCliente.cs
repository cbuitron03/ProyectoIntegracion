using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class datosCliente
    {
        db17842Entities _context;
        public datosCliente()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<CLIENTE> SeleccionarClientes()
        {
            return _context.CLIENTE.ToList();
        }

        #region metodos de accion 

        public string insertarCliente(CLIENTE cliInsertado)
        {
            _context.CLIENTE.Add(cliInsertado);
            _context.SaveChanges();
            return cliInsertado.CLI_CEDULA;
        }

        public bool actualizarCliente(CLIENTE cliActualizado)
        {
            CLIENTE cli = seleccionarClientePorId(cliActualizado.CLI_CEDULA);
            if (cli != null)
            {
                cli.CLI_CEDULA = cliActualizado.CLI_CEDULA;
                cli.CLI_NOMBRE = cliActualizado.CLI_NOMBRE;
                cli.CLI_TELEFONO= cliActualizado.CLI_TELEFONO;
                cli.CLI_CORREO = cliActualizado.CLI_CORREO;
                cli.CLI_DIRECCION = cliActualizado.CLI_DIRECCION;
                cli.CLI_ESTADO = cliActualizado.CLI_ESTADO;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarCliente(string cedula)
        {
            CLIENTE cli = _context.CLIENTE.Where(a => a.CLI_CEDULA == cedula).SingleOrDefault();
            if (cli != null)
            {
                _context.CLIENTE.Remove(cli);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        private CLIENTE seleccionarClientePorId(string cedula)
        {
            return _context.CLIENTE.Where(cli => cli.CLI_CEDULA == cedula).SingleOrDefault();
        }
    }
}
