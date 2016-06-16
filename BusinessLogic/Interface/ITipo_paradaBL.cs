using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITipo_paradaBL
    {
        DTOTipo_paradaRespuesta obtenerTipo_parada();
        void registrarTipo_parada(DTOTipo_parada oDTOTipo_parada);
        void actualizarTipo_parada(DTOTipo_parada oDTOTipo_parada);
        DTOTipo_paradaRespuesta obtenerTipo_parada_por_id(int id);
    }
}