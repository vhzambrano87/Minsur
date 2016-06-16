using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IProd_ore_binBL
    {
        DTOProd_ore_binRespuesta obtenerProd_ore_bin();
        void registrarProd_ore_bin(DTOProd_ore_bin oDTOProd_ore_bin);
        void actualizarProd_ore_bin(DTOProd_ore_bin oDTOProd_ore_bin);
        DTOProd_ore_binRespuesta obtenerProd_ore_bin_por_id(int id);
        DTOProd_ore_binRespuesta obtenerProd_ore_bin_por_produccion_id(int prod_id);
        double ObtenerTM_Acum_Fin_OB();
        void Recalcular_Acum_Ini_Ob(int produccion_id);
    }
}