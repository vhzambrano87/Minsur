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

    public class ChancadoraBL : IChancadoraBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOChancadoraRespuesta obtenerChancadora()
        {
            DTOChancadoraRespuesta oChancadoraRespuesta = new DTOChancadoraRespuesta();
            List<DTOChancadora> oChancadora = new List<DTOChancadora>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var oListaChancadora = ounitOfWork.chancadoraRepository.GetAll();
                foreach (var item in oListaChancadora)
                {
                    oChancadora.Add(new DTOChancadora()
                    {
                        chancadora_id = item.chancadora_id,
                        fecha = item.fecha,
                        guardia_id = Convert.ToInt32(item.guardia_id),
                        turno_id = Convert.ToInt32(item.turno_id),
                        ch_ore_bin_id = Convert.ToInt32(item.ch_ore_bin_id),
                        tipo_actividad_id = Convert.ToInt32(item.tipo_actividad_id),
                        hora_inicio = item.hora_inicio,
                        hora_fin = item.hora_fin,
                        comentarios = item.comentarios,
                        activo = item.activo.Value,
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.guardia_id)).DTOLista_valor.valor,
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor,
                        ch_ore_bin_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.ch_ore_bin_id)).DTOLista_valor.valor,
                        tipo_actividad_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.tipo_actividad_id)).DTOLista_valor.valor
                    });
                }


                oChancadoraRespuesta.DTOListaChancadora = oChancadora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oChancadoraRespuesta;
        }


        public void registrarChancadora(DTOChancadora oDTOChancadora)
        {
            try
            {
                Mapper.CreateMap<DTOChancadora, MS_CHANCADORA>().AfterMap((src, dest) => { dest.chancadora_id = src.chancadora_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.ch_ore_bin_id = src.ch_ore_bin_id; })
                         .AfterMap((src, dest) => { dest.tipo_actividad_id = src.tipo_actividad_id; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oChancadora = AutoMapper.Mapper.Map<DTOChancadora, MS_CHANCADORA>(oDTOChancadora);
                ounitOfWork.chancadoraRepository.Insert(oChancadora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarChancadora(DTOChancadora oDTOChancadora)
        {
            try
            {
                Mapper.CreateMap<DTOChancadora, MS_CHANCADORA>().AfterMap((src, dest) => { dest.chancadora_id = src.chancadora_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.ch_ore_bin_id = src.ch_ore_bin_id; })
                         .AfterMap((src, dest) => { dest.tipo_actividad_id = src.tipo_actividad_id; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oChancadora = AutoMapper.Mapper.Map<DTOChancadora, MS_CHANCADORA>(oDTOChancadora);
                ounitOfWork.chancadoraRepository.Update(oChancadora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOChancadoraRespuesta obtenerChancadora_por_id(int id)
        {
            DTOChancadoraRespuesta oChancadoraRespuesta = new DTOChancadoraRespuesta();
            DTOChancadora oChancadora = new DTOChancadora();
            try
            {
                var objChancadora = ounitOfWork.chancadoraRepository.GetFirst(u => u.chancadora_id == id);
                oChancadora.chancadora_id = objChancadora.chancadora_id;
                oChancadora.fecha = objChancadora.fecha;
                oChancadora.guardia_id = Convert.ToInt32(objChancadora.guardia_id);
                oChancadora.turno_id = Convert.ToInt32(objChancadora.turno_id);
                oChancadora.ch_ore_bin_id = Convert.ToInt32(objChancadora.ch_ore_bin_id);
                oChancadora.tipo_actividad_id = Convert.ToInt32(objChancadora.tipo_actividad_id);
                oChancadora.hora_inicio = objChancadora.hora_inicio;
                oChancadora.hora_fin = objChancadora.hora_fin;
                oChancadora.comentarios = objChancadora.comentarios;
                oChancadora.activo = Convert.ToBoolean(objChancadora.activo);
                oChancadora.usuario_crea = objChancadora.usuario_crea;
                oChancadora.fecha_crea = Convert.ToDateTime(objChancadora.fecha_crea);
                oChancadora.usuario_mod = objChancadora.usuario_mod;
                oChancadora.fecha_mod = Convert.ToDateTime(objChancadora.fecha_mod);

                oChancadoraRespuesta.DTOChancadora = oChancadora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oChancadoraRespuesta;
        }
    }
}