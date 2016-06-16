using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IRolBL
    {
        DTORolRespuesta obtenerRol();
        void registrarRol(DTORol oDTORol);
        void actualizarRol(DTORol oDTORol);
        DTORolRespuesta obtenerRol_por_id(int id);
    }
}