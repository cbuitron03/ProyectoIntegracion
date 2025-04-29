using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    [Serializable]
    public class DTO_Empresa
    {
        public int ID_EMP { get; set; }
        public string EMP_RUC { get; set; }
        public string EMP_NOMBRE { get; set; }
        public string EMP_MISION { get; set; }
        public string EMP_VISION { get; set; }
        public string EMP_TELF { get; set; }

    }
}
