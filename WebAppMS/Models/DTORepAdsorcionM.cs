﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTORepAdsorcionM
    {
        public int tipo_id { get; set; }
        public string periodo { get; set; }
        public string fecha_desde { get; set; }
        public string fecha_hasta { get; set; }
    }
}