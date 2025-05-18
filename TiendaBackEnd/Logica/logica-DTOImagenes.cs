using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using Datos;


namespace Logica
{
    public class logica_DTOImagenes
    {
        datosDTOImagen op = new datosDTOImagen();

        public List<DTO_Imagen> MostrarImagenes()
        {
            return op.seleccionarImagenDTO();
        }

        public DTO_Imagen MostrarImagenPorId(int id)
        {
            return MostrarImagenes().Where(pro => pro.IMG_ID == id).SingleOrDefault();
        }

    }
}