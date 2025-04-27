using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Datos;

namespace Logica
{
    public class logica_empresa
    {
        datosEmpresa op = new datosEmpresa();

        public List<EMPRESA> SeleccionarEmpresa()
        {
            return op.SeleccionarEmpresa();
        }

    }
}
