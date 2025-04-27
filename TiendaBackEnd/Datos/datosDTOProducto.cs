using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosDTOProducto
    {
        private datosProductos op;  
        public List<DTO_Producto> seleccionarProductosDTO()
        {
            op = new datosProductos();
            List<PRODUCTO> proTemp = op.SeleccionarProductos();
            List<DTO_Producto> res = new List<DTO_Producto>();
            foreach (PRODUCTO p in proTemp)
            {

                DTO_Producto dto = new DTO_Producto()
                {
                    PRD_COD = p.PRD_COD,
                    PRD_DESCRIPCION = p.PRD_DESCRIPCION,
                    PRD_PRECIO = (decimal)p.PRD_PRECIO,
                    PRD_STOCK = (decimal)p.PRD_STOCK
                };
                res.Add(dto);

            }
            return res;
        }


    }
}
