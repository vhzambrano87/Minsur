using AutoMapper;
using BusinessEntities;
using BusinessLogic.Interface;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public class Rol_opcionBL : IRol_opcionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTORol_opcionRespuesta obtenerRol_opcion()
        {
            DTORol_opcionRespuesta oRol_opcionRespuesta = new DTORol_opcionRespuesta();
            List<DTORol_opcion> oRol_opcion = new List<DTORol_opcion>();
            try
            {
                var oListaRol_opcion = ounitOfWork.rol_opcionRepository.GetAll();
                foreach (var item in oListaRol_opcion)
                {
                    oRol_opcion.Add(new DTORol_opcion()
                    {
                        rol_id = item.rol_id,
                        opcion_id = item.opcion_id,
                    });
                }


                oRol_opcionRespuesta.DTOListaRol_opcion = oRol_opcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oRol_opcionRespuesta;
        }


        public void registrarRol_opcion(DTORol_opcion oDTORol_opcion)
        {
            try
            {
                Mapper.CreateMap<DTORol_opcion, MS_ROL_OPCION>().AfterMap((src, dest) => { dest.rol_id = src.rol_id; })
                         .AfterMap((src, dest) => { dest.opcion_id = src.opcion_id; });
                var oRol_opcion = AutoMapper.Mapper.Map<DTORol_opcion, MS_ROL_OPCION>(oDTORol_opcion);
                ounitOfWork.rol_opcionRepository.Insert(oRol_opcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarRol_opcion(DTORol_opcion oDTORol_opcion)
        {
            try
            {
                Mapper.CreateMap<DTORol_opcion, MS_ROL_OPCION>().AfterMap((src, dest) => { dest.rol_id = src.rol_id; })
                         .AfterMap((src, dest) => { dest.opcion_id = src.opcion_id; });
                var oRol_opcion = AutoMapper.Mapper.Map<DTORol_opcion, MS_ROL_OPCION>(oDTORol_opcion);
                ounitOfWork.rol_opcionRepository.Update(oRol_opcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }
        
    }
}