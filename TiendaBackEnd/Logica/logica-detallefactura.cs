﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_detallefactura
    {
        datosDetalleFactura op = new datosDetalleFactura();

        public List<DETALLE_FACTURA> SeleccionarDetalles()
        {
            return op.SeleccionarDetalles();
        }

        public DETALLE_FACTURA seleccionarDetallePorId(int id)
        {
            return SeleccionarDetalles().Where(pro => pro.ID_DET_FAC == id).SingleOrDefault();
        }
        public List<DETALLE_FACTURA> seleccionarDetallePorFactura(int id)
        {
            return SeleccionarDetalles().Where(pro => pro.FAC_COD == id).ToList();
        }

        #region metodos de accion 

        public int insertarDetalle(DETALLE_FACTURA proInsertado)
        {
            return op.insertarDetalleFac(proInsertado);
        }

        public bool actualizarDetalleFac(DETALLE_FACTURA proActualizado)
        {
            return op.actualizarDetalleFac(proActualizado);
        }

        public bool eliminarDetalleFac(int id)
        {
            return op.eliminarDetalleFac(id);
        }

        # endregion
        public bool actualizarEstadoDetalle(int PRD_COD, int FAC_NUM, string Det_Estado)
        {
            return op.actualizarEstadoDetalle(PRD_COD, FAC_NUM, Det_Estado);
        }
    }
}
