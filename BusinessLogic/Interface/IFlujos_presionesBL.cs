using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IFlujos_presionesBL
    {
        DTOFlujos_presionesRespuesta obtenerFlujos_presiones();
        void registrarFlujos_presiones(DTOFlujos_presiones oDTOFlujos_presiones);
        void actualizarFlujos_presiones(DTOFlujos_presiones oDTOFlujos_presiones);
        DTOFlujos_presionesRespuesta obtenerFlujos_presiones_por_id(int id);
    }
}