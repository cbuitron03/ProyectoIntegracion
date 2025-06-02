using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaRecargar
    {
        public static class recargar
        {
            public static async Task Todo()
            {
                using (var httpClient = new HttpClient())
                {
                    var contenido = new StringContent("{}", Encoding.UTF8, "application/json");
                    await httpClient.PostAsync("https://busdatos.runasp.net/api/integracion/proveedores/recargar/Ternura%20Infinita", contenido);
                }

            }

        }
    }
}