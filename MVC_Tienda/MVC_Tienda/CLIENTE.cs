//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Tienda
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENTE()
        {
            this.FACTURA = new HashSet<FACTURA>();
        }
    
        public string CLI_CEDULA { get; set; }
        public int US_COD { get; set; }
        public string CLI_NOMBRE { get; set; }
        public string CLI_TELEFONO { get; set; }
        public string CLI_CORREO { get; set; }
        public string CLI_DIRECCION { get; set; }
        public string CLI_ESTADO { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURA { get; set; }
    }
}
