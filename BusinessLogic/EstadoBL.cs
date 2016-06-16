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

    public class EstadoBL : IEstadoBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOEstadoRespuesta obtenerEstado()
        {
            DTOEstadoRespuesta oEstadoRespuesta = new DTOEstadoRespuesta();
            List<DTOEstado> oEstado = new List<DTOEstado>();
            try
            {
                var oListaEstado = ounitOfWork.estadoRepository.GetAll();
                foreach (var item in oListaEstado)
                {
                    oEstado.Add(new DTOEstado()
                    {
                        estado_id = item.estado_id,
                        codigo = item.codigo,
                        descripcion = item.descripcion,
                        tipo_mantenimiento =Convert.ToBoolean(item.tipo_mantenimiento),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oEstadoRespuesta.DTOListaEstado = oEstado;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oEstadoRespuesta;
        }


        public void registrarEstado(DTOEstado oDTOEstado)
        {
            try
            {
                Mapper.CreateMap<DTOEstado, MS_ESTADO>().AfterMap((src, dest) => { dest.estado_id = src.estado_id; })
                         .AfterMap((src, dest) => { dest.codigo = src.codigo; })
                         .AfterMap((src, dest) => { dest.descripcion = src.descripcion; })
                         .AfterMap((src, dest) => { dest.tipo_mantenimiento = src.tipo_mantenimiento; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oEstado = AutoMapper.Mapper.Map<DTOEstado, MS_ESTADO>(oDTOEstado);
                ounitOfWork.estadoRepository.Insert(oEstado);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarEstado(DTOEstado oDTOEstado)
        {
            try
            {
                Mapper.CreateMap<DTOEstado, MS_ESTADO>().AfterMap((src, dest) => { dest.estado_id = src.estado_id; })
                         .AfterMap((src, dest) => { dest.codigo = src.codigo; })
                         .AfterMap((src, dest) => { dest.descripcion = src.descripcion; })
                         .AfterMap((src, dest) => { dest.tipo_mantenimiento = src.tipo_mantenimiento; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oEstado = AutoMapper.Mapper.Map<DTOEstado, MS_ESTADO>(oDTOEstado);
                ounitOfWork.estadoRepository.Update(oEstado);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOEstadoRespuesta obtenerEstado_por_id(int id)
        {
            DTOEstadoRespuesta oEstadoRespuesta = new DTOEstadoRespuesta();
            DTOEstado oEstado = new DTOEstado();
            try
            {
                var objEstado = ounitOfWork.estadoRepository.GetFirst(u => u.estado_id == id);
                oEstado.estado_id = objEstado.estado_id;
                oEstado.codigo = objEstado.codigo;
                oEstado.descripcion = objEstado.descripcion;
                oEstado.tipo_mantenimiento = Convert.ToBoolean(objEstado.tipo_mantenimiento);
                oEstado.activo = Convert.ToBoolean(objEstado.activo);
                oEstado.usuario_crea = objEstado.usuario_crea;
                oEstado.fecha_crea = Convert.ToDateTime(objEstado.fecha_crea);
                oEstado.usuario_mod = objEstado.usuario_mod;
                oEstado.fecha_mod = Convert.ToDateTime(objEstado.fecha_mod);

                oEstadoRespuesta.DTOEstado = oEstado;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oEstadoRespuesta;
        }
    }
}