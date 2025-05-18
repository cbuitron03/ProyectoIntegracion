using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccesoDatos;
using Logica;

namespace APIRest.Controllers
{
    public class ImagenController : ApiController
    {
        logica_imagenes op = new logica_imagenes();
       
        // GET: api/Imagen
        public List<IMAGEN> Get()
        {
            return op.SeleccionarImagenes();    
        }
        public List<IMAGEN> Get(int id)
        {
            return op.seleccionarImagenPorIdProducto(id);
        }
        
        // POST: api/Imagen
        public int Post(int PRD_COD, string IMG_URL, string IMG_TIPO)
        {
            return op.insertarImagen(PRD_COD, IMG_URL, IMG_TIPO);
        }

        // PUT: api/Imagen/5
        public bool Put(IMAGEN proActualizado)
        {
            return op.actualizarImagen(proActualizado);
        }

        // DELETE: api/Imagen/5
        public bool Delete(int id)
        {
            return op.eliminarImagen(id);
        }
    }
}
