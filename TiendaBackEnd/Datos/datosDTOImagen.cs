using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using AccesoDatos;

namespace Datos
{
    public class datosDTOImagen
    {
        private datosImagen op;
        public List<DTO_Imagen> seleccionarImagenDTO()
        {
            op = new datosImagen();
            List<IMAGEN> proTemp = op.SeleccionarImagenes();
            List<DTO_Imagen> res = new List<DTO_Imagen>();
            foreach (IMAGEN p in proTemp)
            {

                DTO_Imagen dto = new DTO_Imagen()
                {
                    IMG_ID = p.IMG_ID,
                    PRD_COD = p.PRD_COD,
                    IMG_TIPO = p.IMG_TIPO,
                    IMG_URL = p.IMG_URL,
                };
                res.Add(dto);

            }
            return res;
        }
    }
}