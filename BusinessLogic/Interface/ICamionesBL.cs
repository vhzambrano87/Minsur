using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ICamionesBL
    {
        DTOCamionesRespuesta obtenerCamiones();
        void registrarCamiones(DTOCamiones oDTOCamiones);
        void actualizarCamiones(DTOCamiones oDTOCamiones);
        DTOCamionesRespuesta obtenerCamiones_por_id(int id);
    }
}