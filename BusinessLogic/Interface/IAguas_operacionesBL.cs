using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IAguas_operacionesBL
    {
        DTOAguas_operacionesRespuesta obtenerAguas_operaciones();
        void registrarAguas_operaciones(DTOAguas_operaciones oDTOAguas_operaciones);
        void actualizarAguas_operaciones(DTOAguas_operaciones oDTOAguas_operaciones);
        DTOAguas_operacionesRespuesta obtenerAguas_operaciones_por_id(int id);
    }
}