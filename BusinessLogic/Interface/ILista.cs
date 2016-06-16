using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IListaBL
    {
        DTOListaRespuesta obtenerLista();
        void registrarLista(DTOLista oDTOLista);
        void actualizarLista(DTOLista oDTOLista);
        DTOListaRespuesta obtenerLista_por_id(int id);
    }
}