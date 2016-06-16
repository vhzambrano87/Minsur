using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IParadaBL
    {
        DTOParadaRespuesta obtenerParada();
        void registrarParada(DTOParada oDTOParada);
        void actualizarParada(DTOParada oDTOParada);
        DTOParadaRespuesta obtenerParada_por_id(int id);
    }
}