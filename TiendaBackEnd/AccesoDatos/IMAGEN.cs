//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class IMAGEN
    {
        public int IMG_ID { get; set; }
        public int PRD_COD { get; set; }
        public string IMG_URL { get; set; }
        public string IMG_TIPO { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
