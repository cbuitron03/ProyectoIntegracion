using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using Logica;

namespace WebServices
{
    /// <summary>
    /// Descripción breve de APIGestionarProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class APIGestionarProductos : System.Web.Services.WebService
    {
        logica_productos op = new logica_productos();

        [WebMethod]
        public List<PRODUCTO> SeleccionarProductos()
        {
            return op.SeleccionarProductos();
        }

        [WebMethod]

        public List<PRODUCTO> seleccionarProductoPorNombre(string nombre)
        {
            return SeleccionarProductos().Where(pro => pro.PRD_DESCRIPCION.Contains(nombre)).ToList();
        }

        [WebMethod]
        public PRODUCTO seleccionarProductoPorID(int id)
        {
            return SeleccionarProductos().Where(pro => pro.PRD_COD == id).SingleOrDefault();
        }

        //#region metodos de accion 

        //[WebMethod]
        //public int insertarProducto(PRODUCTO proInsertado)
        //{
        //    return op.insertarProducto(proInsertado);
        //}

        //[WebMethod]
        //public bool actualizarProducto(PRODUCTO proActualizado)
        //{
        //    return op.actualizarProducto(proActualizado);
        //}

        //[WebMethod]
        //public bool eliminarProducto(int id)
        //{
        //    return op.eliminarProducto(id);
        //}

        //#endregion
        //Crear Producto
        /*[WebMethod]
        public int insertarProducto(string PRD_DESCRIPCION, decimal PRD_PRECIO, int PRD_STOCK, string PRD_ESTADO)
        {
            return op.insertarProducto(PRD_DESCRIPCION, PRD_PRECIO, PRD_STOCK, PRD_ESTADO);
        }*/
        //Actualizar Producto
        [WebMethod]
        public bool actualizarProducto(PRODUCTO proActualizado)
        {
            return op.actualizarProducto(proActualizado);
        }
        //Actualizar Estado Producto
        [WebMethod]
        public bool actualizarEstadoProducto(int PRD_COD, string PRD_ESTADO)
        {
            return op.actualizarEstadoProducto(PRD_COD, PRD_ESTADO);
        }
    }
}
