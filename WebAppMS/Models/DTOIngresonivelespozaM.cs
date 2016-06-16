using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebAppMS.Models
{
    public class DTOIngresonivelespozaM
    {
        public DTOIngresonivelespozaM()
        {
            this.cotapge = 0;
        }

        public static string BoxLengthRequired { get; set; }

        public static string BoxLengthRange { get; set; }
        public int ingresonivelespoza_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

        public string strfecha
        {
            get
            {
                string x = string.Empty;
                if (this.fecha.HasValue)
                {
                    x = this.fecha.Value.ToString("dd/MM/yyyy");
                }
                return x;
            }
        }
        public string fecha_desc { get; set; }

        public string turno { get; set; }
        public decimal? cotapls { get; set; }
        public decimal? volumepls { get; set; }

        //[Required(ErrorMessageResourceName = "BoxLengthRequired", ErrorMessageResourceType = typeof(DTOIngresonivelespozaM))]
        //[Range(0.0, 100.0, ErrorMessageResourceName = "BoxLengthRange", ErrorMessageResourceType = typeof(DTOIngresonivelespozaM))]
        public decimal? cotapge { get; set; }

        public decimal? volumepge { get; set; }
        public int resultado { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}