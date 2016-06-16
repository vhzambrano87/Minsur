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

    public class RolBL : IRolBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTORolRespuesta obtenerRol()
        {
            DTORolRespuesta oRolRespuesta = new DTORolRespuesta();
            List<DTORol> oRol = new List<DTORol>();
            try
            {
                var oListaRol = ounitOfWork.rolRepository.GetAll();
                foreach (var item in oListaRol)
                {
                    oRol.Add(new DTORol()
                    {
                        rol_id = item.rol_id,
                        nombre = item.nombre,
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oRolRespuesta.DTOListaRol = oRol;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oRolRespuesta;
        }


        public void registrarRol(DTORol oDTORol)
        {
            try
            {
                Mapper.CreateMap<DTORol, MS_ROL>().AfterMap((src, dest) => { dest.rol_id = src.rol_id; })
                         .AfterMap((src, dest) => { dest.nombre = src.nombre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oRol = AutoMapper.Mapper.Map<DTORol, MS_ROL>(oDTORol);
                ounitOfWork.rolRepository.Insert(oRol);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarRol(DTORol oDTORol)
        {
            try
            {
                Mapper.CreateMap<DTORol, MS_ROL>().AfterMap((src, dest) => { dest.rol_id = src.rol_id; })
                         .AfterMap((src, dest) => { dest.nombre = src.nombre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oRol = AutoMapper.Mapper.Map<DTORol, MS_ROL>(oDTORol);
                ounitOfWork.rolRepository.Update(oRol);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTORolRespuesta obtenerRol_por_id(int id)
        {
            DTORolRespuesta oRolRespuesta = new DTORolRespuesta();
            DTORol oRol = new DTORol();
            try
            {
                var objRol = ounitOfWork.rolRepository.GetFirst(u => u.rol_id == id);
                oRol.rol_id = objRol.rol_id;
                oRol.nombre = objRol.nombre;
                oRol.activo = Convert.ToBoolean( objRol.activo);
                oRol.usuario_crea = objRol.usuario_crea;
                oRol.fecha_crea = Convert.ToDateTime(objRol.fecha_crea);
                oRol.usuario_mod = objRol.usuario_mod;
                oRol.fecha_mod = Convert.ToDateTime(objRol.fecha_mod);

                oRolRespuesta.DTORol = oRol;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oRolRespuesta;
        }
    }
}