//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PostEngine.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comments
    {
        public int id { get; set; }
        public System.DateTime created { get; set; }
        public string author_name { get; set; }
        public string email { get; set; }
        public int post_id { get; set; }
        public string text { get; set; }
    
        public virtual Post Post { get; set; }
    }
}
