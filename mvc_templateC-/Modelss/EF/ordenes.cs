//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelss.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ordenes
    {
        public int id_orden { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> fk_estado { get; set; }
        public Nullable<int> fk_usuario { get; set; }
        public Nullable<int> fk_producto { get; set; }
        public Nullable<int> fk_adicional { get; set; }
        public Nullable<int> fk_tamano { get; set; }
        public string instrucciones { get; set; }
    
        public virtual adicionales adicionales { get; set; }
        public virtual estados estados { get; set; }
        public virtual productos productos { get; set; }
        public virtual tamanos tamanos { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
