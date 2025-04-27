using AccesoDatos;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logica_usuarios
    {
        datosUsuario op = new datosUsuario();

        public List<USUARIO> SeleccionarUsuarios()
        {
            return op.SeleccionarUsuarios();
        }

        public List<USUARIO> seleccionarUsuarioPorUsuario(string usuario)
        {
            return SeleccionarUsuarios().Where(usu => usu.US_USUARIO.Contains(usuario)).ToList();
        }

        #region metodos de accion 

        public decimal insertarUsuario(USUARIO usuInsertado)
        {
            return op.insertarUsuario(usuInsertado);
        }

        public bool actualizarUsuario(USUARIO usuActualizado)
        {
            return op.actualizarUsuario(usuActualizado);
        }

        public bool eliminarUsuario(decimal id)
        {
            return op.eliminarUsuario(id);
        }

        # endregion
    }
}
