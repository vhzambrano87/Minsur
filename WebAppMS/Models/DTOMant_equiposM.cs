﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMS.Models
{
    public class DTOMant_equiposM
    {
        public int equipo_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string fecha_desc { get; set; }
        public int guardia_id { get; set; }
        public int turno_id { get; set; }
        public string camiom_cargador { get; set; }
        public int tipo_actividad_id { get; set; }
        public int operador_id { get; set; }
        public string hora_inicial { get; set; }
        public string hora_fin { get; set; }
        public double tancada { get; set; }
        public string hora_ini_mant { get; set; }
        public string hora_fin_mant { get; set; }
        public string comentarios { get; set; }
        public int equipo_cargio_id { get; set; }
        public int material_id { get; set; }
        public int zona_carguio { get; set; }
        public int punto_descarga { get; set; }
        public int numero_viajes { get; set; }
        public double produccion_total { get; set; }
        public int resultado { get; set; }

        public string guardia_desc { get; set; }
        public string turno_desc { get; set; }
        public string tipo_actividad_desc { get; set; }
        public string operador_desc { get; set; }
        public string equipo_cargio_desc { get; set; }
        public string material_desc { get; set; }
        public string zona_carguio_desc { get; set; }
        public string punto_descarga_desc { get; set; }

        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string hora_hora_ini { get; set; }
        public string hora_hora_fin { get; set; }
        public string hora_min_ini { get; set; }
        public string hora_min_fin { get; set; }

        public string hora_hora_ini_mant { get; set; }
        public string hora_hora_fin_mant { get; set; }
        public string hora_min_ini_mant { get; set; }
        public string hora_min_fin_mant { get; set; }
        public bool activo { get; set; }
    }
}