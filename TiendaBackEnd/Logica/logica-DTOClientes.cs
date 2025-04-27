using AccesoDatos;
using AccesoDatos.DTO;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logica_DTOClientes
    {
        datosDTOCliente op = new datosDTOCliente();

        public List<DTO_Cliente> MostrarClientes()
        {
            return op.seleccionarClientesDTO();
        }

        public DTO_Cliente MostrarClientePorCedula(string cedula)
        {
            return MostrarClientes().Where(cli => cli.CLI_CEDULA == cedula).SingleOrDefault();
        }

    }
}
