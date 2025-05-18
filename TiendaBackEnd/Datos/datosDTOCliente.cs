using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using AccesoDatos;

namespace Datos
{
    public class datosDTOCliente
    {
        private datosCliente op;
        public List<DTO_Cliente> seleccionarClientesDTO()
        {
            op = new datosCliente();
            List<CLIENTE> cliTemp = op.SeleccionarClientes();
            List<DTO_Cliente> res = new List<DTO_Cliente>();
            foreach (CLIENTE c in cliTemp)
            {

                DTO_Cliente dto = new DTO_Cliente()
                {
                    CLI_CEDULA = c.CLI_CEDULA,
                    CLI_NOMBRE = c.CLI_NOMBRE,
                    CLI_TELEFONO = c.CLI_TELEFONO,
                    CLI_CORREO = c.CLI_CORREO,
                    CLI_DIRECCION = c.CLI_DIRECCION,
                    CLI_ESTADO = c.CLI_ESTADO
                };
                res.Add(dto);

            }
            return res;
        }
    }
}
