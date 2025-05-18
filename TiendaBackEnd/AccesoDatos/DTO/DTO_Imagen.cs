using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DTO
{
    [Serializable]
    public class DTO_Imagen
    {
        public int IMG_ID { get; set; }
        public int PRD_COD { get; set; }
        public string IMG_URL { get; set; }
        public string IMG_TIPO { get; set; }
    }
}