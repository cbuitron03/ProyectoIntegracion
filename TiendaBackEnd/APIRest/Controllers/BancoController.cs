using AccesoDatos;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class BancoController : ApiController
    {
        
        Logica_Banco op = new Logica_Banco();
        logica_factura factura = new logica_factura();
        // POST: api/Banco
        [HttpPost]
        [Route("api/banco/transaccion")]
        public async Task<bool> PostTransaccion(string cliCedula, int facCod)
        {
            try
            {
                bool res = await op.RealizarTransaccion(cliCedula, facCod, 0);
                if (res)
                {
                    return factura.actualizarEstadoFactura(facCod, "Pagada");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Error en la transacción: {ex.Message}");
                return false;
            }
        }
    }
}
