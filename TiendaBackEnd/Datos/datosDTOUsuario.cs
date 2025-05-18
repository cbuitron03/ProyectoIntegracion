using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using AccesoDatos;

namespace Datos
{
    public class datosDTOUsuario
    {
        private datosUsuario op;
        public List<DTO_Usuario> seleccionarUsuariosDTO()
        {
            op = new datosUsuario();
            List<USUARIO> usuTemp = op.SeleccionarUsuarios();
            List<DTO_Usuario> res = new List<DTO_Usuario>();
            foreach (USUARIO u in usuTemp)
            {

                DTO_Usuario dto = new DTO_Usuario()
                {
                    US_COD = u.US_COD,
                    US_USUARIO = u.US_USUARIO,
                    US_PASS = u.US_PASS,
                    US_ROL = u.US_ROL
                };
                res.Add(dto);

            }
            return res;
        }
    }
}

