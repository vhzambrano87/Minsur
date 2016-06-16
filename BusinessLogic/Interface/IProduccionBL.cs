using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProduccionBL
    {
        DTOProduccionRespuesta obtenerProduccion();
        void registrarProduccion(DTOProduccion oDTOProduccion);
        void actualizarProduccion(DTOProduccion oDTOProduccion);
        DTOProduccionRespuesta obtenerProduccion_por_id(int id);
    }
}