using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IControl_dig_lixiviacionBL
    {
        DTOControl_dig_lixiviacionRespuesta obtenerControl_dig_lixiviacion();
        void registrarControl_dig_lixiviacion(DTOControl_dig_lixiviacion oDTOControl_dig_lixiviacion);
        void actualizarControl_dig_lixiviacion(DTOControl_dig_lixiviacion oDTOControl_dig_lixiviacion);
        DTOControl_dig_lixiviacionRespuesta obtenerControl_dig_lixiviacion_por_id(int id);
    }
}