using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IOpcionBL
    {
        DTOOpcionRespuesta obtenerOpcion();
        void registrarOpcion(DTOOpcion oDTOOpcion);
        void actualizarOpcion(DTOOpcion oDTOOpcion);
        DTOOpcionRespuesta obtenerOpcion_por_id(int id);
        DTOOpcionRespuesta obtenerOpcionSelected(int rol_id);
    }
}