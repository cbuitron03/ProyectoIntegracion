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
    

         public static Usuarios FromServicio(FrontEnd.APIDTOUsuarios.DTO_Usuario user)
            {
                if (user == null) return null;

                return new Usuarios
                {
                    US_COD = user.US_COD,
                    US_USUARIO = user.US_ROL,
                    US_PASS = user.US_PASS,
                    US_ROL = user.US_ROL
                };
         }
    }
}