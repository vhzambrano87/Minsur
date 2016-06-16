using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IMant_produccion_x_horaBL
    {
        DTOMant_produccion_x_horaRespuesta obtenerMant_produccion_x_hora();
        void registrarMant_produccion_x_hora(DTOMant_produccion_x_hora oDTOMant_produccion_x_hora);
        void actualizarMant_produccion_x_hora(DTOMant_produccion_x_hora oDTOMant_produccion_x_hora);
        DTOMant_produccion_x_horaRespuesta obtenerMant_produccion_x_hora_por_id(int id);
    }
}