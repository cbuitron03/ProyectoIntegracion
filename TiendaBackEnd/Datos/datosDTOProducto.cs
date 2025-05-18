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
        private datosImagen img;
        public List<DTO_Producto> seleccionarProductosDTO()
        {
            op = new datosProductos();
            img = new datosImagen();

            List<PRODUCTO> proTemp = op.SeleccionarProductos();
            List<DTO_Producto> res = new List<DTO_Producto>();
            foreach (PRODUCTO p in proTemp)
            {
                List<String> tempimg = img.urlporIdProducto(p.PRD_COD);
                DTO_Producto dto = new DTO_Producto()
                {
                    PRD_COD = p.PRD_COD,
                    PRD_CATEGORIA = p.PRD_CATEGORIA,
                    PRD_NOMBRE = p.PRD_NOMBRE,
                    PRD_DESCRIPCION = p.PRD_DESCRIPCION,
                    PRD_PRECIO = (decimal)p.PRD_PRECIO,
                    PRD_STOCK = (int)p.PRD_STOCK,
                    PRD_PROVEEDOR = p.PRD_PROVEEDOR,
                    IMG_URL = tempimg
                };
                res.Add(dto);

            }
            return res;
        }
        public bool verificarStock(int idProducto, int cantidadSolicitada)
        {
            PRODUCTO p = op.seleccionarProductoPorId(idProducto);
            if (p == null)
                return false;

            return p.PRD_STOCK >= cantidadSolicitada;
        }
    }
}
