using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOMant_produccion_x_horaRespuesta
    {
        public DTOMant_produccion_x_hora DTOMant_produccion_x_hora { get; set; }
        public List<DTOMant_produccion_x_hora> DTOListaMant_produccion_x_hora { get; set; }
    }
    public class DTOMant_produccion_x_hora
    {
        public int produccion_hora_id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public int guardia_id { get; set; }
        public int turno_id { get; set; }
        public string hora { get; set; }
        public string camion { get; set; }
        public double toneladas { get; set; }
        public int viajes { get; set; }
        public int material_id { get; set; }
        public int ruta_id { get; set; }
        public int zona_cargio_id { get; set; }
        public int equipo_cargio_id { get; set; }
        public double ton1 { get; set; }
        public double ton2 { get; set; }
        public double ton3 { get; set; }
        public double ton4 { get; set; }
        public double ton5 { get; set; }
        public double ton6 { get; set; }
        public double ton7 { get; set; }
        public double ton8 { get; set; }
        public double ton9 { get; set; }
        public double ton10 { get; set; }
        public double ton11 { get; set; }
        public double ton12 { get; set; }
        public double ton13 { get; set; }
        public double ton14 { get; set; }
        public double ton15 { get; set; }
        public double ton16 { get; set; }
        public double ton17 { get; set; }
        public double ton18 { get; set; }
        public double ton19 { get; set; }
        public double ton20 { get; set; }
        public double ton21 { get; set; }
        public double ton22 { get; set; }
        public double ton23 { get; set; }
        public double ton24 { get; set; }
        public double ton25 { get; set; }
        public double ton26 { get; set; }
        public double ton27 { get; set; }
        public double ton28 { get; set; }
        public double ton29 { get; set; }
        public double ton30 { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }

        public string guardia_desc { get; set; }
        public string turno_desc { get; set; }
        public string material_desc { get; set; }
        public string ruta_desc { get; set; }
        public string zona_cargio_desc { get; set; }
        public string equipo_cargio_desc { get; set; }
    }
}