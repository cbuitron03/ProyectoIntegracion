using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logica_imagenes
    {
        datosImagen op = new datosImagen();

        public List<IMAGEN> SeleccionarImagenes()
        {
            return op.SeleccionarImagenes();
        }

        public List<IMAGEN> seleccionarImagenPorIdProducto(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.PRD_COD == id ).ToList();
        }

        public IMAGEN seleccionarImagenPorID(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.IMG_ID == id).SingleOrDefault();
        }

        #region metodos de accion 

        public int insertarImagen(IMAGEN proInsertado)
        {
            return op.insertarImagen(proInsertado);
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
