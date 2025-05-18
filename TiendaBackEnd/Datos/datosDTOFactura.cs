using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DTO;
using AccesoDatos;

namespace Datos
{
    public class datosDTOFactura
    {
        private datosFactura op;
        public List<DTO_Factura> seleccionarFacturaDTO()
        {
            op = new datosFactura();
            List<FACTURA> proTemp = op.SeleccionarFacturas();
            List<DTO_Factura> res = new List<DTO_Factura>();
            foreach (FACTURA p in proTemp)
            {

                DTO_Factura dto = new DTO_Factura()
                {
                    FAC_COD = p.FAC_COD,
                    FAC_FECHA = p.FAC_FECHA,
                    FAC_ESTADO = p.FAC_ESTADO,
                    FAC_SUBTOTAL = p.FAC_SUBTOTAL ?? 0,
                    FAC_IVA = p.FAC_IVA ?? 0,
                    FAC_TOTAL = p.FAC_TOTAL ?? 0,
                };
                res.Add(dto);

            }
            return res;
        }
    }
}

