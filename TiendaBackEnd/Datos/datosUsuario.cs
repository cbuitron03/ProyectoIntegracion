using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class datosUsuario
    {
        db17842Entities2 _context;
        public datosUsuario()
        {
            _context = new db17842Entities2();
        }

        public List<USUARIO> SeleccionarUsuarios()
        {
            return _context.USUARIO.ToList();
        }

        #region metodos de accion 

        public decimal insertarUsuario(USUARIO usuInsertado)
        {
            _context.USUARIO.Add(usuInsertado);
            _context.SaveChanges();
            return usuInsertado.US_COD;
        }

        public bool actualizarUsuario(USUARIO usuActualizado)
        {
            USUARIO usu = seleccionarUsuarioPorId(usuActualizado.US_COD);
            if (usu != null)
            {
                usu.US_USUARIO = usuActualizado.US_USUARIO;
                usu.US_PASS = usuActualizado.US_PASS;
                usu.US_ROL = usuActualizado.US_ROL;
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        public bool eliminarUsuario(decimal id)
        {
            USUARIO usu = seleccionarUsuarioPorId(id);
            if (usu != null)
            {
                _context.USUARIO.Remove(usu);
                _context.SaveChanges();
                return true;

            }
            else
                return false;
        }

        # endregion
        private USUARIO seleccionarUsuarioPorId(decimal id)
        {
            return _context.USUARIO.Where(usu => usu.US_COD == id).SingleOrDefault();
        }
    }
}
