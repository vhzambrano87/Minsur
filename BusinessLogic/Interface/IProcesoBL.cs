using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProcesoBL
    {
        DTOProcesoRespuesta obtenerProceso();
        void registrarProceso(DTOProceso oDTOProceso);
        void actualizarProceso(DTOProceso oDTOProceso);
        DTOProcesoRespuesta obtenerProceso_por_id(int id);
    }
}