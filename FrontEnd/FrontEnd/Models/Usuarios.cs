using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class Usuarios
    {
        public int US_COD { get; set; }
        public string US_USUARIO { get; set; }
        public string US_PASS { get; set; }
        public string US_ROL { get; set; }
        public string US_ESTADO { get; set; }
        public List<Clientes> CLIENTE { get; set; }
    }
}