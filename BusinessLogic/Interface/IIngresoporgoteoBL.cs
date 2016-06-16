using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IIngresoporgoteoBL
    {
        DTOIngresoporgoteoRespuesta obtenerIngresoporgoteo();
        void registrarIngresoporgoteo(DTOIngresoporgoteo oDTOIngresoporgoteo);
        void actualizarIngresoporgoteo(DTOIngresoporgoteo oDTOIngresoporgoteo);
        DTOIngresoporgoteoRespuesta obtenerIngresoporgoteo_por_id(int id);
    }
}