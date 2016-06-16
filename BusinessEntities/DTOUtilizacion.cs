using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class DTOUtilizacionRespuesta
    {
        public DTOUtilizacion DTOUtilizacion { get; set; }
        public List<DTOUtilizacion> DTOListaUtilizacion { get; set; }
    }
    public class DTOUtilizacion
    {
        public string fecha_op { get; set; }
        public string mes { get; set; }
        public int semana { get; set; }
        public string dia { get; set; }
        public double hop { get; set; }
        public double dmtto { get; set; }
        public double tmpd { get; set; }
        public double disp { get; set; }
        public double tmph { get; set; }
        public double util { get; set; }
        public double oee { get; set; }
    }
}
