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

        public int realizarCompra(carritoDTO carrito, string idEmpresa, string direccion, string metodoPago, CLIENTE cliente)
        {
            if (verificarStock(carrito))
            {
                if (disminuirStock(carrito))
                {
                    return crearFactura(carrito, idEmpresa, direccion, metodoPago, cliente);
                }
            }
            return -1;
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

        public int crearFactura(carritoDTO carrito, string idEmpresa, string direccion, string metodoPago, CLIENTE clientecarrito)
        {
            var datosFac = new datosFactura();
            var datosDet = new datosDetalleFactura();
            var datosCli = new datosCliente();

            // Buscar o crear cliente
            CLIENTE cliente = datosCli.seleccionarClientePorId(clientecarrito.CLI_CEDULA);
            if (cliente == null)
            {
                cliente = new CLIENTE
                {
                    CLI_CEDULA = clientecarrito.CLI_CEDULA,
                    CLI_NOMBRE = clientecarrito.CLI_NOMBRE,
                    CLI_TELEFONO = clientecarrito.CLI_TELEFONO,
                    CLI_DIRECCION = clientecarrito.CLI_DIRECCION,
                    CLI_CORREO = clientecarrito.CLI_CORREO,
                    CLI_ESTADO = "Activo",
                    US_COD = 2
                };
                cliente.CLI_CEDULA = datosCli.insertarCliente(cliente);
                Console.WriteLine("Cedula del Insertado: " + cliente.CLI_CEDULA);
            }

            // Crear factura
            FACTURA factura = new FACTURA
            {
                CLI_CEDULA = cliente.CLI_CEDULA,
                ID_EMP = idEmpresa.ToString(),
                FAC_FECHA = System.DateTime.Now,
                FAC_ESTADO = "Pendiente"
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
            Console.WriteLine("Id Factura ingresada: " + idFactura);

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
                    DTF_ESTADO = "Pendiente"
                };
                int idDetalle = datosDet.insertarDetalleFac(detalle);
                Console.WriteLine("Id Detalle Insertado" + idDetalle); 
            }

            return idFactura;
        }
    }

}
