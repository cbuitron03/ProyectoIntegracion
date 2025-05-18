using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using AccesoDatos;

namespace Datos
{
    public class datosDTOEmpresa
    {
        private datosEmpresa op;
        public List<DTO_Empresa> seleccionarEmpresaDTO()
        {
            op = new datosEmpresa();
            List<EMPRESA> proTemp = op.SeleccionarEmpresa();
            List<DTO_Empresa> res = new List<DTO_Empresa>();
            foreach (EMPRESA p in proTemp)
            {

                DTO_Empresa dto = new DTO_Empresa()
                {
                    ID_EMP = p.ID_EMP,
                    EMP_NOMBRE = p.EMP_NOMBRE,
                    EMP_RUC = p.EMP_RUC,
                    EMP_MISION = p.EMP_MISION,
                    EMP_VISION = p.EMP_VISION,
                    EMP_TELF = p.EMP_TELF,
                };
                res.Add(dto);

            }
            return res;
        }
    }
}
