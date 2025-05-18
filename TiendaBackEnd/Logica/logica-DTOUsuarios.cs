using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using Datos;


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