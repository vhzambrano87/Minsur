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

    public class OpcionBL : IOpcionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOOpcionRespuesta obtenerOpcion()
        {
            DTOOpcionRespuesta oOpcionRespuesta = new DTOOpcionRespuesta();
            List<DTOOpcion> oOpcion = new List<DTOOpcion>();
            try
            {
                var oListaOpcion = ounitOfWork.opcionRepository.GetAll();
                foreach (var item in oListaOpcion)
                {
                    oOpcion.Add(new DTOOpcion()
                    {
                        opcion_id = item.opcion_id,
                        opcion_cod = item.opcion_cod,
                        nombre = item.nombre,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oOpcionRespuesta.DTOListaOpcion = oOpcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oOpcionRespuesta;
        }


        public void registrarOpcion(DTOOpcion oDTOOpcion)
        {
            try
            {
                Mapper.CreateMap<DTOOpcion, MS_OPCION>().AfterMap((src, dest) => { dest.opcion_id = src.opcion_id; })
                         .AfterMap((src, dest) => { dest.opcion_cod = src.opcion_cod; })
                         .AfterMap((src, dest) => { dest.nombre = src.nombre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oOpcion = AutoMapper.Mapper.Map<DTOOpcion, MS_OPCION>(oDTOOpcion);
                ounitOfWork.opcionRepository.Insert(oOpcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarOpcion(DTOOpcion oDTOOpcion)
        {
            try
            {
                Mapper.CreateMap<DTOOpcion, MS_OPCION>().AfterMap((src, dest) => { dest.opcion_id = src.opcion_id; })
                         .AfterMap((src, dest) => { dest.opcion_cod = src.opcion_cod; })
                         .AfterMap((src, dest) => { dest.nombre = src.nombre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oOpcion = AutoMapper.Mapper.Map<DTOOpcion, MS_OPCION>(oDTOOpcion);
                ounitOfWork.opcionRepository.Update(oOpcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOOpcionRespuesta obtenerOpcion_por_id(int id)
        {
            DTOOpcionRespuesta oOpcionRespuesta = new DTOOpcionRespuesta();
            DTOOpcion oOpcion = new DTOOpcion();
            try
            {
                var objOpcion = ounitOfWork.opcionRepository.GetFirst(u => u.opcion_id == id);
                oOpcion.opcion_id = objOpcion.opcion_id;
                oOpcion.opcion_cod = objOpcion.opcion_cod;
                oOpcion.nombre = objOpcion.nombre;
                oOpcion.activo = Convert.ToBoolean(objOpcion.activo);
                oOpcion.usuario_crea = objOpcion.usuario_crea;
                oOpcion.fecha_crea = Convert.ToDateTime(objOpcion.fecha_crea);
                oOpcion.usuario_mod = objOpcion.usuario_mod;
                oOpcion.fecha_mod = Convert.ToDateTime(objOpcion.fecha_mod);

                oOpcionRespuesta.DTOOpcion = oOpcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oOpcionRespuesta;
        }

        public DTOOpcionRespuesta obtenerOpcionSelected(int rol_id)
        {
            DTOOpcionRespuesta oOpcionRespuesta = new DTOOpcionRespuesta();
            List<DTOOpcion> oOpcion = new List<DTOOpcion>();
            Rol_opcionBL oRolOpcionBL = new Rol_opcionBL();
            bool flag = false;
            string asociados = "";
            try
            {
                var oListaOpcion = ounitOfWork.opcionRepository.GetAll();
                var oListaRolOpcion = oRolOpcionBL.obtenerRol_opcion().DTOListaRol_opcion.Where(u => u.rol_id == rol_id);

                foreach (var item in oListaOpcion)
                {

                    if (oListaRolOpcion.Where(u => u.opcion_id == item.opcion_id).Count() == 1)
                    {
                        flag = true;
                        asociados = "[" + item.opcion_id + "]";
                    }
                    else
                    {
                        flag = false;
                        asociados = "";
                    }

                    oOpcion.Add(new DTOOpcion()
                    {
                        opcion_id = item.opcion_id,
                        opcion_cod = item.opcion_cod,
                        nombre = item.nombre,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        asociar = flag,
                        asociados = asociados
                    });
                }


                oOpcionRespuesta.DTOListaOpcion= oOpcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oOpcionRespuesta;
        }

    }
}