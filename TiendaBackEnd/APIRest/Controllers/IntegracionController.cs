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

namespace APIRest.Controllers
{
    [System.Web.Http.RoutePrefix("api/integracion")]
    public class IntegracionController : ApiController
    {
        logica_productos prod = new logica_productos();
        logica_DTOProductos prodDTO = new logica_DTOProductos();
        private readonly realizarCompraDTO opCompra = new realizarCompraDTO();

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
        public bool PostRealizarCompra()
        {
            try
            {
                // Leer el JSON del cuerpo de la solicitud
                string jsonContent = Request.Content.ReadAsStringAsync().Result;
                JObject jsonObject = JObject.Parse(jsonContent);

                // Crear el objeto clienteDTO
                DTO_Cliente cliente = new DTO_Cliente
                {
                    CLI_CEDULA = (string)jsonObject["cliente"]["cliCedula"],
                    CLI_NOMBRE = (string)jsonObject["cliente"]["cliNombre"] + jsonObject["cliente"]["cliApellido"],
                    CLI_DIRECCION = (string)jsonObject["direccion"],
                    CLI_TELEFONO = (string)jsonObject["cliente"]["cliTelefono"],
                    CLI_CORREO = ""
                };

                // Crear la lista de productos para el carritoDTO
                List<productoCantidadDTO> productos = jsonObject["carrito"]["productos"].ToObject<List<productoCantidadDTO>>();

                // Crear el objeto carritoDTO
                carritoDTO carrito = new carritoDTO
                {
                    productos = productos
                };

                // Obtener los otros parámetros
                int idEmpresa = 1;
                string direccion = (string)jsonObject["direccion"];
                string metodoPago = (string)jsonObject["metodoPago"];

                // Llamar a la lógica de negocio
                return opCompra.realizarCompra(carrito, idEmpresa.ToString(), direccion, metodoPago, cliente);
            }
            catch (Exception ex)
            {
                // Loguea el error para depuración
                return false; // Indica que hubo un error al procesar la solicitud
            }
        }
    }
}