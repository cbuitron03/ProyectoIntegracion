using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.DTO;

namespace Datos
{
    public class datosDTODetalleFactura
    {
        private datosDetalleFactura op;
        public List<DTO_Detalle_Factura> seleccionarDetalleFacDTO()
        {
            op = new datosDetalleFactura();
            List<DETALLE_FACTURA> proTemp = op.SeleccionarDetalles();
            List<DTO_Detalle_Factura> res = new List<DTO_Detalle_Factura>();
            foreach (DETALLE_FACTURA p in proTemp)
            {

                DTO_Detalle_Factura dto = new DTO_Detalle_Factura()
                {
                    ID_DET_FAC = p.ID_DET_FAC,
                    DTF_CANTIDAD = (decimal)p.DTF_CANTIDAD,
                    DTF_PRECIO = (decimal)p.DTF_PRECIO,
                };
                res.Add(dto);

            }
            return res;
        }
    }
}
