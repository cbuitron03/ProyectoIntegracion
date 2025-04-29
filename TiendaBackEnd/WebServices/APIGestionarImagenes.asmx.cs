using AccesoDatos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de APIGestionarImagenes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIGestionarImagenes : System.Web.Services.WebService
    {
        logica_imagenes op = new logica_imagenes();

        [WebMethod]
        public List<IMAGEN> SeleccionarImagenes()
        {
            return op.SeleccionarImagenes();
        }

        [WebMethod]

        public List<IMAGEN> seleccionarImagenPorIdProducto(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.PRD_COD == id).ToList();
        }

        [WebMethod]
        public IMAGEN seleccionarProductoPorID(int id)
        {
            return SeleccionarImagenes().Where(pro => pro.IMG_ID == id).SingleOrDefault();
        }

        #region metodos de accion 

        [WebMethod]
        public int insertarProducto(IMAGEN proInsertado)
        {
            return op.insertarImagen(proInsertado);
        }

        [WebMethod]
        public bool actualizarImagen(IMAGEN proActualizado)
        {
            return op.actualizarImagen(proActualizado);
        }

        [WebMethod]
        public bool actualizarImagenPorIdProducto(IMAGEN proActualizado)
        {
            return op.actualizarImagenPorIdProducto(proActualizado);
        }

        [WebMethod]
        public bool eliminarImagen(int id)
        {
            return op.eliminarImagen(id);
        }

        #endregion

    }
}
