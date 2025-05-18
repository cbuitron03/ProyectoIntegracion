using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosImagen
    {
        db17842Entities _context;
        public datosImagen()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<IMAGEN> SeleccionarImagenes()
        {
            return _context.IMAGEN.ToList();
        }

        #region metodos de accion 

        public int insertarImagen(IMAGEN proInsertado)
        {
            _context.IMAGEN.Add(proInsertado);
            _context.SaveChanges();
            return proInsertado.PRD_COD;
        }

        public bool actualizarImagen(IMAGEN proActualizado)
        {
            IMAGEN pro = seleccionarImagenPorId(proActualizado.IMG_ID);
            if (pro != null)
            {
                pro.IMG_URL = proActualizado.IMG_URL;
                pro.IMG_TIPO = proActualizado.IMG_TIPO;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool actualizarImagenPorIdProducto(IMAGEN proActualizado)
        {
            IMAGEN pro = seleccionarImagenPorIdProducto(proActualizado.IMG_ID);
            if (pro != null)
            {
                pro.IMG_URL = proActualizado.IMG_URL;
                pro.IMG_TIPO = proActualizado.IMG_TIPO;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarImagen(int id)
        {
            IMAGEN pro = seleccionarImagenPorId(id);
            if (pro != null)
            {
                _context.IMAGEN.Remove(pro);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        public IMAGEN seleccionarImagenPorId(int id)
        {
            return _context.IMAGEN.Where(pro => pro.IMG_ID == id).SingleOrDefault();
        }

        public IMAGEN seleccionarImagenPorIdProducto(int id)
        {
            return _context.IMAGEN.Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }
        public List<string> urlporIdProducto(int id)
        {
            List<string> urls = new List<string>();
            var imagenes = _context.IMAGEN.Where(i => i.PRD_COD == id).ToList();
            foreach (var img in imagenes)
            {
                urls.Add(img.IMG_URL);
            }
            return urls;
        }
    }
}