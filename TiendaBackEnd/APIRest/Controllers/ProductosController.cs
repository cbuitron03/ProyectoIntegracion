using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccesoDatos;
using Logica;

namespace APIRest.Controllers
{
    public class ProductosController : ApiController
    {
        logica_productos op = new logica_productos();

        // GET: api/Productos
        public List<PRODUCTO> Get()
        {
            return op.SeleccionarProductos();
        }

        // GET: api/Productos/5
        public PRODUCTO Get(int id)
        {
            return op.seleccionarProductoPorID(id);
        }
        // GET: api/Productos/5
        public PRODUCTO Get(string nombre)
        {
            return op.seleccionarProductoPorNombre(nombre);
        }
        // POST: api/Productos
        public int Post(string PRD_NOMBRE,string PRD_DESCRIPCION, decimal PRD_PRECIO, int PRD_STOCK, string PRD_ESTADO)
        {
            return op.insertarProducto(PRD_NOMBRE, PRD_DESCRIPCION, PRD_PRECIO,PRD_STOCK,PRD_ESTADO);
        }

        // PUT: api/Productos/5
        public bool Put(PRODUCTO producto)
        {
            return op.actualizarProducto(producto);
        }
        public bool Put(int PRD_COD, string PRD_ESTADO)
        {
            return op.actualizarEstadoProducto(PRD_COD, PRD_ESTADO);
        }

        // DELETE: api/Productos/5
        public bool Delete(int id)
        {
            return op.actualizarEstadoProducto(id, "Inactivo");
        }
    }
}
