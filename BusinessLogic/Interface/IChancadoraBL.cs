using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IChancadoraBL
    {
        DTOChancadoraRespuesta obtenerChancadora();
        void registrarChancadora(DTOChancadora oDTOChancadora);
        void actualizarChancadora(DTOChancadora oDTOChancadora);
        DTOChancadoraRespuesta obtenerChancadora_por_id(int id);
    }
}