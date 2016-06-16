using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IUsuario_rolBL
    {
        DTOUsuario_rolRespuesta obtenerUsuario_rol();
        void registrarUsuario_rol(DTOUsuario_rol oDTOUsuario_rol);
        void actualizarUsuario_rol(DTOUsuario_rol oDTOUsuario_rol);
        void EliminaUsuarioRol();
    }
}