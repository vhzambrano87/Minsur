using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ILista_valorBL
    {
        DTOLista_valorRespuesta obtenerLista_valor();
        void registrarLista_valor(DTOLista_valor oDTOLista_valor);
        void actualizarLista_valor(DTOLista_valor oDTOLista_valor);
        DTOLista_valorRespuesta obtenerLista_valor_por_id(int id);
    }
}