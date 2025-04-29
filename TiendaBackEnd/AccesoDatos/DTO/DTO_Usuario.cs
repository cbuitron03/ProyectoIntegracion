using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    [Serializable]
    public class DTO_Usuario
    {
        public int US_COD { get; set; }
        public string US_USUARIO { get; set; }
        public string US_PASS { get; set; }
        public string US_ROL { get; set; }
    }
}
