using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IEstadoBL
    {
        DTOEstadoRespuesta obtenerEstado();
        void registrarEstado(DTOEstado oDTOEstado);
        void actualizarEstado(DTOEstado oDTOEstado);
        DTOEstadoRespuesta obtenerEstado_por_id(int id);
    }
}