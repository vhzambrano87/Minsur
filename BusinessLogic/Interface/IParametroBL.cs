using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IParametroBL
    {
        DTOParametroRespuesta obtenerParametro();
        void registrarParametro(DTOParametro oDTOParametro);
        void actualizarParametro(DTOParametro oDTOParametro);
        DTOParametroRespuesta obtenerParametro_por_id(int id);
    }
}