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
    
    public partial class MS_APILAMIENTO
    {
        public int apilamiento_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> turno_id { get; set; }
        public Nullable<double> tmh_mineral { get; set; }
        public Nullable<double> ley_au_mineral { get; set; }
        public Nullable<double> ley_ag_mineral { get; set; }
        public Nullable<double> tmh_rom { get; set; }
        public Nullable<double> ley_au_rom { get; set; }
        public Nullable<double> ley_ag_rom { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public Nullable<double> ph { get; set; }
        public Nullable<double> humedad { get; set; }
        public Nullable<double> ley_prom_au { get; set; }
        public Nullable<double> ley_prom_ag { get; set; }
        public Nullable<double> onzas_au { get; set; }
        public Nullable<double> onzas_ag { get; set; }
        public Nullable<double> densidad { get; set; }
        public Nullable<double> volumen { get; set; }
        public Nullable<bool> activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}
