//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class MS_INGRESONIVELESPOZA
    {
        public int ingresoNivelesPoza_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string turno { get; set; }
        public Nullable<decimal> cotaPLS { get; set; }
        public Nullable<decimal> volumePLS { get; set; }
        public Nullable<decimal> cotaPGE { get; set; }
        public Nullable<decimal> volumePGE { get; set; }
        public Nullable<bool> activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}
