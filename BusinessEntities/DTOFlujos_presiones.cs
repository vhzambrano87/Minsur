using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOFlujos_presionesRespuesta
    {
        public DTOFlujos_presiones DTOFlujos_presiones { get; set; }
        public List<DTOFlujos_presiones> DTOListaFlujos_presiones { get; set; }
    }
    public class DTOFlujos_presiones
    {
        public int flujo_presion_id { get; set; }
        public DateTime fecha { get; set; }
        public int celda_id { get; set; }
        public string celda { get; set; }
        public int operador_id { get; set; }
        public string operador { get; set; }
        public int ingeniero_id { get; set; }
        public string ingeniero { get; set; }
        public double flujo { get; set; }
        public double presion { get; set; }
        public double flujo_real { get; set; }
        public double presion_real { get; set; }
        public double flujo_corregido { get; set; }
        public double presion_corregida { get; set; }
        public double totalizador { get; set; }
        public string comentarios { get; set; }
        public bool activo { get; set; }
        public string usuario_crea { get; set; }
        public Nullable<System.DateTime> fecha_crea { get; set; }
        public string usuario_mod { get; set; }
        public Nullable<System.DateTime> fecha_mod { get; set; }
    }
}