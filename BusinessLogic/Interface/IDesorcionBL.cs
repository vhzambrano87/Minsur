using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IDesorcionBL
    {
        DTODesorcionRespuesta obtenerDesorcion();
        void registrarDesorcion(DTODesorcion oDTODesorcion);
        void actualizarDesorcion(DTODesorcion oDTODesorcion);
        DTODesorcionRespuesta obtenerDesorcion_por_id(int id);
    }
}