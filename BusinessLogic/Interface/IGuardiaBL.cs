using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IGuardiaBL
    {
        DTOGuardiaRespuesta obtenerGuardia();
        void registrarGuardia(DTOGuardia oDTOGuardia);
        void actualizarGuardia(DTOGuardia oDTOGuardia);
        DTOGuardiaRespuesta obtenerGuardia_por_id(int id);
    }
}