using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOIngresoporgoteoRespuesta
    {
        public DTOIngresoporgoteo DTOIngresoporgoteo { get; set; }
        public List<DTOIngresoporgoteo> DTOListaIngresoporgoteo { get; set; }
    }
    public class DTOIngresoporgoteo
    {
        public Int64 ingresoporgoteo_id { get; set; }
        public string codarea { get; set; }
        public int? flujo { get; set; }
        public int? celdaId { get; set; }
        public decimal? tonelajechancado { get; set; }
        public decimal? leyauchancado { get; set; }
        public decimal? leyagchancado { get; set; }
        public decimal? tonelaje_overliner_ { get; set; }
        public decimal? leyauoverliner { get; set; }
        public decimal? leyagoverliner { get; set; }
        public Nullable<System.DateTime> fechainicioapilamiento { get; set; }
        public Nullable<System.DateTime> fechafinapilamiento { get; set; }
        public Nullable<System.DateTime> fechainicioriego { get; set; }
        public Nullable<System.DateTime> fechafinriego { get; set; }
        public Nullable<System.DateTime> fechafinrealriego { get; set; }
        public int? diariegoalafecha { get; set; }
        public int? diaprograriego { get; set; }
        public decimal? onzasau { get; set; }
        public decimal? onzasag { get; set; }
        public decimal? tms { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}