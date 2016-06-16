using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUtilizacionBL
    {
        DTOUtilizacionRespuesta obtenerUtilizacionRep(int area_id, int turno_id, string fecha_desde, string fecha_hasta);
    }
}
