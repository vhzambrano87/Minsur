using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IIngresonivelespozaBL
    {
        DTOIngresonivelespozaRespuesta obtenerIngresonivelespoza();
        void registrarIngresonivelespoza(DTOIngresonivelespoza oDTOIngresonivelespoza);
        void actualizarIngresonivelespoza(DTOIngresonivelespoza oDTOIngresonivelespoza);
        DTOIngresonivelespozaRespuesta obtenerIngresonivelespoza_por_id(int id);
    }
}