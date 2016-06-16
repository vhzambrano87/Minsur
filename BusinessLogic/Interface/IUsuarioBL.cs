using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUsuarioBL
    {
        DTOUsuarioRespuesta obtenerUsuario();
        void registrarUsuario(DTOUsuario oDTOUsuario);
        void actualizarUsuario(DTOUsuario oDTOUsuario);
        DTOUsuarioRespuesta obtenerUsuario_por_id(int id);
    }
}