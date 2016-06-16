using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOCamionesRespuesta
    {
        public DTOCamiones DTOCamiones { get; set; }
        public List<DTOCamiones> DTOListaCamiones { get; set; }
    }
    public class DTOCamiones
    {
        public int camion_id { get; set; }
        public DateTime fecha { get; set; }
        public int turno_id { get; set; }
        public string turno { get; set; }
        public string tipo_equipo { get; set; }
        public int tipo_equipo_id { get; set; }
        public double horas_maquina { get; set; }
        public string detalle { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}