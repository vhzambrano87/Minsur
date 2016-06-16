using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IAdsorcionBL
    {
        DTOAdsorcionRespuesta obtenerAdsorcion();
        void registrarAdsorcion(DTOAdsorcion oDTOAdsorcion);
        void actualizarAdsorcion(DTOAdsorcion oDTOAdsorcion);
        DTOAdsorcionRespuesta obtenerAdsorcion_por_id(int id);
    }
}