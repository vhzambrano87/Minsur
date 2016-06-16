using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IApilamientoBL
    {
        DTOApilamientoRespuesta obtenerApilamiento();
        void registrarApilamiento(DTOApilamiento oDTOApilamiento);
        void actualizarApilamiento(DTOApilamiento oDTOApilamiento);
        DTOApilamientoRespuesta obtenerApilamiento_por_id(int id);
    }
}