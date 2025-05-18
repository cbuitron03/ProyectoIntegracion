using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosUsuario
    {
        db17842Entities _context;
        public datosUsuario()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<USUARIO> SeleccionarUsuarios()
        {
            return _context.USUARIO.ToList();
        }

        #region metodos de accion 

        public int insertarUsuario(USUARIO usuInsertado)
        {
            try
            {
                _context.USUARIO.Add(usuInsertado);
                _context.SaveChanges();
                return usuInsertado.US_COD;
            }
            catch (Exception ex)
            {
                return -1;
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
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

        public bool eliminarUsuario(int id)
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
        private USUARIO seleccionarUsuarioPorId(int id)
        {
            return _context.USUARIO.Where(usu => usu.US_COD == id).SingleOrDefault();
        }
        public USUARIO autenticarUsuario(string US_USUARIO, string US_PASS)
        {
            return _context.USUARIO.FirstOrDefault(u => u.US_USUARIO == US_USUARIO && u.US_PASS == US_PASS);
        }
    }
}
