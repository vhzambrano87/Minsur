﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTORepUtilizacionChancadoM
    {
        public int turno_id { get; set; }
        public int area_id { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
    }
}