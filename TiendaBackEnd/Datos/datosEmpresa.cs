using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Datos
{
    public class datosEmpresa
    {
        db17842Entities _context;
        public datosEmpresa()
        {
            _context = new db17842Entities();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public List<EMPRESA> SeleccionarEmpresa()
        {
            return _context.EMPRESA.ToList();
        }

    }
}
