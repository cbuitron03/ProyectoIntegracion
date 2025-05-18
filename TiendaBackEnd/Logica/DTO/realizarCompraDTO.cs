using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.DTO;
using Datos;

namespace Logica.DTO
{
    public class realizarCompraDTO
    {
        logica_DTOProductos logicaProducto = new logica_DTOProductos();
        logica_productos opProducto = new logica_productos();

        public bool realizarCompra(carritoDTO carrito, string idEmpresa, string direccion, string metodoPago, DTO_Cliente cliente)
        {
            if (verificarStock(carrito))
            {
                if (disminuirStock(carrito))
                {
                    return crearFactura(carrito, idEmpresa, direccion, metodoPago, cliente);
                }
            }
            return false;
        }

        public bool verificarStock(carritoDTO carrito)
        {
            foreach (productoCantidadDTO p in carrito.productos)
            {
                if (!logicaProducto.verificarStock(p.idProducto, p.cantidad))
                {
                    return false;
                }
            }
            return true;
        }

        public bool disminuirStock(carritoDTO carrito)
        {
            foreach (productoCantidadDTO p in carrito.productos)
            {
                if (!opProducto.disminuirStock(p.idProducto, p.cantidad))
                {
                    return false;
                }
            }
            return true;
        }

        public bool crearFactura(carritoDTO carrito, string idEmpresa, string direccion, string metodoPago, DTO_Cliente clienteDTO)
        {
            var datosFac = new datosFactura();
            var datosDet = new datosDetalleFactura();
            var datosCli = new datosCliente();

            // Buscar o crear cliente
            CLIENTE cliente = datosCli.seleccionarClientePorId(clienteDTO.CLI_CEDULA);
            if (cliente == null)
            {
                cliente = new CLIENTE
                {
                    CLI_CEDULA = clienteDTO.CLI_CEDULA,
                    CLI_NOMBRE = clienteDTO.CLI_NOMBRE,
                    CLI_TELEFONO = clienteDTO.CLI_TELEFONO,
                    CLI_DIRECCION = clienteDTO.CLI_DIRECCION,
                    CLI_CORREO = clienteDTO.CLI_CORREO,
                    CLI_ESTADO = "ACTIVO"
                };
                cliente.CLI_CEDULA = datosCli.insertarCliente(cliente);
            }

            // Crear factura
            FACTURA factura = new FACTURA
            {
                CLI_CEDULA = cliente.CLI_CEDULA,
                ID_EMP = idEmpresa.ToString(),
                FAC_FECHA = System.DateTime.Now,
                FAC_ESTADO = "PAGADA"
            };

            // Calcular totales
            float subtotal = 0f, iva = 0f, total = 0f;
            foreach (var item in carrito.productos)
            {
                float precioUnitario = opProducto.obtenerPrecioUnitario(item.idProducto);
                subtotal += item.cantidad * precioUnitario;
            }

            iva = subtotal * 0.15f;
            total = subtotal + iva;

            // Asignar a factura (suponiendo que los campos son float en la entidad)
            factura.FAC_SUBTOTAL = (decimal)subtotal;
            factura.FAC_IVA = (decimal)iva;
            factura.FAC_TOTAL = (decimal)total;

            // Guardar factura
            int idFactura = datosFac.insertarFactura(factura);

            // Crear detalle por cada producto
            foreach (var item in carrito.productos)
            {
                float precioUnitario = opProducto.obtenerPrecioUnitario(item.idProducto);
                DETALLE_FACTURA detalle = new DETALLE_FACTURA
                {
                    FAC_COD = idFactura,
                    PRD_COD = item.idProducto,
                    DTF_CANTIDAD = item.cantidad,
                    DTF_PRECIO = (decimal)precioUnitario,
                    DTF_ESTADO = "PAGADO"
                };
                datosDet.insertarDetalleFac(detalle);
            }

            return true;
        }
    }

}
