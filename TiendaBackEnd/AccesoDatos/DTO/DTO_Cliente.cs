using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    public class DTO_Cliente
    {
        public decimal ID_CLIENTE { get; set; }
        public string CLI_CEDULA { get; set; }
        public string CLI_NOMBRE { get; set; }
        public string CLI_TELEFONO { get; set; }
        public string CLI_CORREO { get; set; }
        public string CLI_DIRECCION { get; set; }
    }
}
