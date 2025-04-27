using AccesoDatos;
using AccesoDatos.DTO;
using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class logica_DTOUsuarios
    {
        datosDTOUsuario op = new datosDTOUsuario();

        public List<DTO_Usuario> MostrarUsuarios()
        {
            return op.seleccionarUsuariosDTO();
        }
    }
}
