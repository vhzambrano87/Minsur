using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IRol_opcionBL
    {
        DTORol_opcionRespuesta obtenerRol_opcion();
        void registrarRol_opcion(DTORol_opcion oDTORol_opcion);
        void actualizarRol_opcion(DTORol_opcion oDTORol_opcion);
    }
}