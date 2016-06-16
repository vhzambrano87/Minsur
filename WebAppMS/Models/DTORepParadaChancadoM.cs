using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTORepParadaChancadoM
    {
        public int area_id { get; set; }
        public int turno_id { get; set; }
        public int tipo_parada_id { get; set; }
        public int sub_tipo_parada_id { get; set; }
        public int estado_id { get; set; }
        public int serie_id { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
    }
}