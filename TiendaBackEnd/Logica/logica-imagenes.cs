using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_imagenes
    {
        datosImagen op = new datosImagen();

        public List<IMAGEN> SeleccionarImagenes()
        {
            return op.SeleccionarImagenes();
        }

        public IMAGEN seleccionarImagenPorID(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.IMG_ID == id).SingleOrDefault();
        }
        public List<IMAGEN> seleccionarImagenPorIdProducto(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.PRD_COD == id).ToList();
        }


        #region metodos de accion 

        public int insertarImagen(int PRD_COD, string IMG_URL, string IMG_TIPO)
        {
            IMAGEN imagen = new IMAGEN();
            imagen.PRD_COD = PRD_COD;
            imagen.IMG_URL = IMG_URL;
            imagen.IMG_TIPO = IMG_TIPO;

            int IMG_ID = op.insertarImagen(imagen);

            return IMG_ID;
        }

        public bool actualizarImagen(IMAGEN proActualizado)
        {
            return op.actualizarImagen(proActualizado);
        }

        public bool actualizarImagenPorIdProducto(IMAGEN proActualizado)
        {
            return op.actualizarImagenPorIdProducto(proActualizado);
        }

        public bool eliminarImagen(int id)
        {
            return op.eliminarImagen(id);
        }

        # endregion
    }
}
