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

    public class Tipo_paradaBL : ITipo_paradaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOTipo_paradaRespuesta obtenerTipo_parada()
        {
            DTOTipo_paradaRespuesta oTipo_paradaRespuesta = new DTOTipo_paradaRespuesta();
            List<DTOTipo_parada> oTipo_parada = new List<DTOTipo_parada>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            EstadoBL oEstadoBL = new EstadoBL();
            try
            {
                var oListaTipo_parada = ounitOfWork.tipo_paradaRepository.GetAll();
                foreach (var item in oListaTipo_parada)
                {
                    oTipo_parada.Add(new DTOTipo_parada()
                    {
                        tipo_parada_id = item.tipo_parada_id,
                        tipo_parada = item.tipo_parada,
                        sub_tipo_parada = item.sub_tipo_parada,
                        codigo_serie = item.codigo_serie,
                        descripcion_serie = item.descripcion_serie,
                        estado_serie = Convert.ToInt32(item.estado_serie),
                        observaciones = item.observaciones,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(item.tipo_parada).DTOLista_valor.valor,
                        sub_tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(item.sub_tipo_parada).DTOLista_valor.valor,
                        estado_desc = oEstadoBL.obtenerEstado_por_id(Convert.ToInt32(item.estado_serie)).DTOEstado.codigo,
                    });
                }


                oTipo_paradaRespuesta.DTOListaTipo_parada = oTipo_parada;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oTipo_paradaRespuesta;
        }


        public void registrarTipo_parada(DTOTipo_parada oDTOTipo_parada)
        {
            try
            {
                Mapper.CreateMap<DTOTipo_parada, MS_TIPO_PARADA>().AfterMap((src, dest) => { dest.tipo_parada_id = src.tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.tipo_parada = src.tipo_parada; })
                         .AfterMap((src, dest) => { dest.sub_tipo_parada = src.sub_tipo_parada; })
                         .AfterMap((src, dest) => { dest.codigo_serie = src.codigo_serie; })
                         .AfterMap((src, dest) => { dest.descripcion_serie = src.descripcion_serie; })
                         .AfterMap((src, dest) => { dest.estado_serie = src.estado_serie; })
                         .AfterMap((src, dest) => { dest.observaciones = src.observaciones; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oTipo_parada = AutoMapper.Mapper.Map<DTOTipo_parada, MS_TIPO_PARADA>(oDTOTipo_parada);
                ounitOfWork.tipo_paradaRepository.Insert(oTipo_parada);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarTipo_parada(DTOTipo_parada oDTOTipo_parada)
        {
            try
            {
                Mapper.CreateMap<DTOTipo_parada, MS_TIPO_PARADA>().AfterMap((src, dest) => { dest.tipo_parada_id = src.tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.tipo_parada = src.tipo_parada; })
                         .AfterMap((src, dest) => { dest.sub_tipo_parada = src.sub_tipo_parada; })
                         .AfterMap((src, dest) => { dest.codigo_serie = src.codigo_serie; })
                         .AfterMap((src, dest) => { dest.descripcion_serie = src.descripcion_serie; })
                         .AfterMap((src, dest) => { dest.estado_serie = src.estado_serie; })
                         .AfterMap((src, dest) => { dest.observaciones = src.observaciones; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oTipo_parada = AutoMapper.Mapper.Map<DTOTipo_parada, MS_TIPO_PARADA>(oDTOTipo_parada);
                ounitOfWork.tipo_paradaRepository.Update(oTipo_parada);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOTipo_paradaRespuesta obtenerTipo_parada_por_id(int id)
        {
            DTOTipo_paradaRespuesta oTipo_paradaRespuesta = new DTOTipo_paradaRespuesta();
            DTOTipo_parada oTipo_parada = new DTOTipo_parada();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            EstadoBL oEstadoBL = new EstadoBL();
            try
            {
                var objTipo_parada = ounitOfWork.tipo_paradaRepository.GetFirst(u => u.tipo_parada_id == id);
                oTipo_parada.tipo_parada_id = objTipo_parada.tipo_parada_id;
                oTipo_parada.tipo_parada = objTipo_parada.tipo_parada;
                oTipo_parada.sub_tipo_parada = objTipo_parada.sub_tipo_parada;
                oTipo_parada.codigo_serie = objTipo_parada.codigo_serie;
                oTipo_parada.descripcion_serie = objTipo_parada.descripcion_serie;
                oTipo_parada.estado_serie = Convert.ToInt32(objTipo_parada.estado_serie);
                oTipo_parada.observaciones = objTipo_parada.observaciones;
                oTipo_parada.activo = Convert.ToBoolean(objTipo_parada.activo);
                oTipo_parada.usuario_crea = objTipo_parada.usuario_crea;
                oTipo_parada.fecha_crea = Convert.ToDateTime(objTipo_parada.fecha_crea);
                oTipo_parada.usuario_mod = objTipo_parada.usuario_mod;
                oTipo_parada.fecha_mod = Convert.ToDateTime(objTipo_parada.fecha_mod);
                oTipo_parada.tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(objTipo_parada.tipo_parada).DTOLista_valor.valor;
                oTipo_parada.sub_tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(objTipo_parada.sub_tipo_parada).DTOLista_valor.valor;
                oTipo_parada.estado_desc = oEstadoBL.obtenerEstado_por_id(Convert.ToInt32(objTipo_parada.estado_serie)).DTOEstado.codigo;
                oTipo_paradaRespuesta.DTOTipo_parada = oTipo_parada;
                

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oTipo_paradaRespuesta;
        }
    }
}