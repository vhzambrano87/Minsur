using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IConsumo_combustibleBL
    {
        DTOConsumo_combustibleRespuesta obtenerConsumo_combustible();
        void registrarConsumo_combustible(DTOConsumo_combustible oDTOConsumo_combustible);
        void actualizarConsumo_combustible(DTOConsumo_combustible oDTOConsumo_combustible);
        DTOConsumo_combustibleRespuesta obtenerConsumo_combustible_por_id(int id);
    }
}