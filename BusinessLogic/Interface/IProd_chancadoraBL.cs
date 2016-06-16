using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProd_chancadoraBL
    {
        DTOProd_chancadoraRespuesta obtenerProd_chancadora();
        void registrarProd_chancadora(DTOProd_chancadora oDTOProd_chancadora);
        void actualizarProd_chancadora(DTOProd_chancadora oDTOProd_chancadora);
        DTOProd_chancadoraRespuesta obtenerProd_chancadora_por_id(int id);
        DTOProd_chancadoraRespuesta obtenerProd_chancadora_por_prod_id(int prod_id);
        double ObtenerTM_Acum_Fin_CH();
        void Recalcular_Acum_Ini_Ch(int produccion_id);
    }
}