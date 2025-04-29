using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using AccesoDatos;
using AccesoDatos.DTO;

namespace Logica
{
    public class logica_DTODetalleFactura
    {
        datosDTODetalleFactura op = new datosDTODetalleFactura();

        public List<DTO_Detalle_Factura> MostrarDetalles()
        {
            return op.seleccionarDetalleFacDTO();
        }

        public DTO_Detalle_Factura MostrarDetallesPorId(int id)
        {
            return MostrarDetalles().Where(pro => pro.ID_DET_FAC == id).SingleOrDefault();
        }
    }
}
