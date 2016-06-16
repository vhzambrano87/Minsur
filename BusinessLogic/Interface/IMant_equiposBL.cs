using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IMant_equiposBL
    {
        DTOMant_equiposRespuesta obtenerMant_equipos();
        void registrarMant_equipos(DTOMant_equipos oDTOMant_equipos);
        void actualizarMant_equipos(DTOMant_equipos oDTOMant_equipos);
        DTOMant_equiposRespuesta obtenerMant_equipos_por_id(int id);
    }
}