using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    [Serializable]
    public class carritoDTO
    {
        public List<productoCantidadDTO> productos { get; set; }
    }
}
