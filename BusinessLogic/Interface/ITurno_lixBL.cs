using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITurno_lixBL
    {
        DTOTurno_lixRespuesta obtenerTurno_lix();
        void registrarTurno_lix(DTOTurno_lix oDTOTurno_lix);
        void actualizarTurno_lix(DTOTurno_lix oDTOTurno_lix);
        DTOTurno_lixRespuesta obtenerTurno_lix_por_id(int id);
    }
}