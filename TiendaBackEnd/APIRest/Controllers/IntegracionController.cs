using AccesoDatos;
using AccesoDatos.DTO;
using Logica;
using Logica.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Logica.LogicaRecargar;

namespace APIRest.Controllers
{
    [System.Web.Http.RoutePrefix("api/integracion")]
    public class IntegracionController : ApiController
    {
        logica_productos prod = new logica_productos();
        logica_DTOProductos prodDTO = new logica_DTOProductos();
        private readonly realizarCompraDTO opCompra = new realizarCompraDTO();
        logica_factura factura = new logica_factura();

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("productos")]
        public List<DTO_Producto> GetProductos()
        {
            return prodDTO.MostrarProductos();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("productos/{id:int}")]
        public DTO_Producto GetProductoPorId(int id)
        {
            return prodDTO.MostrarProductosPorId(id);
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("stock")]
        public bool GetVerificarStock(int id, int cantidad)
        {
            return prod.verificarStock(id, cantidad);
        }
        //Compra
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("compra")]
        public int PostRealizarCompra()
        {
            try
            {
                // Leer el JSON del cuerpo de la solicitud
                string jsonContent = Request.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JObject.Parse(jsonContent);

                // Crear el objeto clienteDTO
                CLIENTE cliente = new CLIENTE
                {
                    CLI_CEDULA = (string)jsonObject["cliente"]["cliCedula"],
                    CLI_NOMBRE = (string)jsonObject["cliente"]["cliNombre"] + " "+ jsonObject["cliente"]["cliApellido"],
                    CLI_DIRECCION = (string)jsonObject["direccion"],
                    CLI_TELEFONO = (string)jsonObject["cliente"]["cliTelefono"],
                    CLI_CORREO = "",
                    CLI_ESTADO = "Activo",
                    US_COD = 2
                };

                // Crear la lista de productos para el carritoDTO
                List<productoCantidadDTO> productos = jsonObject["carrito"]["productos"].ToObject<List<productoCantidadDTO>>();

                // Crear el objeto carritoDTO
                carritoDTO carrito = new carritoDTO
                {
                    productos = productos
                };

                // Obtener los otros parámetros
                string idEmpresa = "T009";
                string direccion = (string)jsonObject["direccion"];
                string metodoPago = (string)jsonObject["metodoPago"];

                // Llamar a la lógica de negocio
                int res = opCompra.realizarCompra(carrito, idEmpresa, direccion, metodoPago, cliente);
                _ = recargar.Todo();
                return res;
            }
            catch (Exception ex)
            {
                // Loguea el error para depuración
                return -1; // Indica que hubo un error al procesar la solicitud
            }
        }
        //Confirmarcompra
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("confirmarCompra")]
        public bool PostconfirmarCompra()
        {
            try
            {
                // Leer el JSON del cuerpo de la solicitud
                string jsonContent = Request.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JObject.Parse(jsonContent);
                int idFactura = (int)jsonObject["idFactura"];
                bool res = factura.actualizarEstadoFactura(idFactura, "Pagada");
                _ = recargar.Todo();
                return res;
            }
            catch (Exception ex)
            {
                // Loguea el error para depuración
                return false; // Indica que hubo un error al procesar la solicitud
            }
        }
    }
}