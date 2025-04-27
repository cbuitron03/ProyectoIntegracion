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
        db17842Entities2 _context;
        public datosEmpresa()
        {
            _context = new db17842Entities2();
        }

        public List<EMPRESA> SeleccionarEmpresa()
        {
            return _context.EMPRESA.ToList();
        }

    }
}
