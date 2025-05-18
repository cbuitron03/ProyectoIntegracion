using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using Datos;

namespace Logica
{
    public class logica_DTOFactura
    {
        datosDTOFactura op = new datosDTOFactura();

        public List<DTO_Factura> MostrarFacturas()
        {
            return op.seleccionarFacturaDTO();
        }

        public DTO_Factura MostrarFacturaPorId(int codigo)
        {
            return MostrarFacturas().Where(pro => pro.FAC_COD == codigo).SingleOrDefault();
        }
    }
}
