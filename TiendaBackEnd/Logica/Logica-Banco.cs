using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using IntegracionBanco;

namespace Logica
{
    public class Logica_Banco
    {
        public async Task<bool> RealizarTransaccion(string cliCedula, int facCod, decimal monto)
        {
            logica_factura op = new logica_factura();
            IntegracionBanco.bancoDto.clienteDto cliente = new IntegracionBanco.bancoDto.clienteDto()
            {
                cliente_id = cliCedula
            };
            FACTURA factura = op.seleccionarFacturaPorID(facCod);
            monto = (decimal)factura.FAC_TOTAL;
            string res = await bancoConsumer.transaccionValida(cliente, monto, 122);
            if(res == "OK")
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Error en la transacción: {res}");
                return false;
            }
        }
    }
}