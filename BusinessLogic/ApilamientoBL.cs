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

    public class ApilamientoBL : IApilamientoBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOApilamientoRespuesta obtenerApilamiento()
        {
            DTOApilamientoRespuesta oApilamientoRespuesta = new DTOApilamientoRespuesta();
            List<DTOApilamiento> oApilamiento = new List<DTOApilamiento>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                var oListaApilamiento = ounitOfWork.apilamientoRepository.GetAll();
                string turno = "";
                foreach (var item in oListaApilamiento)
                {
                    turno = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor;
                    oApilamiento.Add(new DTOApilamiento()
                    {
                        apilamiento_id = item.apilamiento_id,
                        fecha = Convert.ToDateTime( item.fecha),
                        turno_id = Convert.ToInt32( item.turno_id),
                        turno = turno,
                        tmh_mineral = Convert.ToDouble( item.tmh_mineral),
                        ley_au_mineral = Convert.ToDouble(item.ley_au_mineral),
                        ley_ag_mineral = Convert.ToDouble(item.ley_ag_mineral),
                        tmh_rom = Convert.ToDouble(item.tmh_rom),
                        ley_au_rom = Convert.ToDouble(item.ley_au_rom),
                        ley_ag_rom = Convert.ToDouble(item.ley_ag_rom),
                        origen = item.origen,
                        destino = item.destino,
                        ph = Convert.ToDouble(item.ph),
                        humedad = Convert.ToDouble(item.humedad),
                        ley_prom_au = Convert.ToDouble(item.ley_prom_au),
                        ley_prom_ag = Convert.ToDouble(item.ley_prom_ag),
                        onzas_au = Convert.ToDouble(item.onzas_au),
                        onzas_ag = Convert.ToDouble(item.onzas_ag),
                        densidad = Convert.ToDouble(item.densidad),
                        volumen = Convert.ToDouble(item.volumen),
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oApilamientoRespuesta.DTOListaApilamiento = oApilamiento;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oApilamientoRespuesta;
        }


        public void registrarApilamiento(DTOApilamiento oDTOApilamiento)
        {
            try
            {
                Mapper.CreateMap<DTOApilamiento, MS_APILAMIENTO>().AfterMap((src, dest) => { dest.apilamiento_id = src.apilamiento_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tmh_mineral = src.tmh_mineral; })
                         .AfterMap((src, dest) => { dest.ley_au_mineral = src.ley_au_mineral; })
                         .AfterMap((src, dest) => { dest.ley_ag_mineral = src.ley_ag_mineral; })
                         .AfterMap((src, dest) => { dest.tmh_rom = src.tmh_rom; })
                         .AfterMap((src, dest) => { dest.ley_au_rom = src.ley_au_rom; })
                         .AfterMap((src, dest) => { dest.ley_ag_rom = src.ley_ag_rom; })
                         .AfterMap((src, dest) => { dest.origen = src.origen; })
                         .AfterMap((src, dest) => { dest.destino = src.destino; })
                         .AfterMap((src, dest) => { dest.ph = src.ph; })
                         .AfterMap((src, dest) => { dest.humedad = src.humedad; })
                         .AfterMap((src, dest) => { dest.ley_prom_au = src.ley_prom_au; })
                         .AfterMap((src, dest) => { dest.ley_prom_ag = src.ley_prom_ag; })
                         .AfterMap((src, dest) => { dest.onzas_au = src.onzas_au; })
                         .AfterMap((src, dest) => { dest.onzas_ag = src.onzas_ag; })
                         .AfterMap((src, dest) => { dest.densidad = src.densidad; })
                         .AfterMap((src, dest) => { dest.volumen = src.volumen; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oApilamiento = AutoMapper.Mapper.Map<DTOApilamiento, MS_APILAMIENTO>(oDTOApilamiento);
                ounitOfWork.apilamientoRepository.Insert(oApilamiento);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarApilamiento(DTOApilamiento oDTOApilamiento)
        {
            try
            {
                Mapper.CreateMap<DTOApilamiento, MS_APILAMIENTO>().AfterMap((src, dest) => { dest.apilamiento_id = src.apilamiento_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tmh_mineral = src.tmh_mineral; })
                         .AfterMap((src, dest) => { dest.ley_au_mineral = src.ley_au_mineral; })
                         .AfterMap((src, dest) => { dest.ley_ag_mineral = src.ley_ag_mineral; })
                         .AfterMap((src, dest) => { dest.tmh_rom = src.tmh_rom; })
                         .AfterMap((src, dest) => { dest.ley_au_rom = src.ley_au_rom; })
                         .AfterMap((src, dest) => { dest.ley_ag_rom = src.ley_ag_rom; })
                         .AfterMap((src, dest) => { dest.origen = src.origen; })
                         .AfterMap((src, dest) => { dest.destino = src.destino; })
                         .AfterMap((src, dest) => { dest.ph = src.ph; })
                         .AfterMap((src, dest) => { dest.humedad = src.humedad; })
                         .AfterMap((src, dest) => { dest.ley_prom_au = src.ley_prom_au; })
                         .AfterMap((src, dest) => { dest.ley_prom_ag = src.ley_prom_ag; })
                         .AfterMap((src, dest) => { dest.onzas_au = src.onzas_au; })
                         .AfterMap((src, dest) => { dest.onzas_ag = src.onzas_ag; })
                         .AfterMap((src, dest) => { dest.densidad = src.densidad; })
                         .AfterMap((src, dest) => { dest.volumen = src.volumen; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oApilamiento = AutoMapper.Mapper.Map<DTOApilamiento, MS_APILAMIENTO>(oDTOApilamiento);
                ounitOfWork.apilamientoRepository.Update(oApilamiento);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOApilamientoRespuesta obtenerApilamiento_por_id(int id)
        {
            DTOApilamientoRespuesta oApilamientoRespuesta = new DTOApilamientoRespuesta();
            DTOApilamiento oApilamiento = new DTOApilamiento();
            try
            {
                var objApilamiento = ounitOfWork.apilamientoRepository.GetFirst(u => u.apilamiento_id == id);
                oApilamiento.apilamiento_id = objApilamiento.apilamiento_id;
                oApilamiento.fecha = Convert.ToDateTime( objApilamiento.fecha);
                oApilamiento.turno_id = Convert.ToInt32( objApilamiento.turno_id);
                oApilamiento.tmh_mineral = Convert.ToDouble(objApilamiento.tmh_mineral);
                oApilamiento.ley_au_mineral = Convert.ToDouble(objApilamiento.ley_au_mineral);
                oApilamiento.ley_ag_mineral = Convert.ToDouble(objApilamiento.ley_ag_mineral);
                oApilamiento.tmh_rom = Convert.ToDouble(objApilamiento.tmh_rom);
                oApilamiento.ley_au_rom = Convert.ToDouble(objApilamiento.ley_au_rom);
                oApilamiento.ley_ag_rom = Convert.ToDouble(objApilamiento.ley_ag_rom);
                oApilamiento.origen = objApilamiento.origen;
                oApilamiento.destino = objApilamiento.destino;
                oApilamiento.ph = Convert.ToDouble(objApilamiento.ph);
                oApilamiento.humedad = Convert.ToDouble(objApilamiento.humedad);
                oApilamiento.ley_prom_au = Convert.ToDouble(objApilamiento.ley_prom_au);
                oApilamiento.ley_prom_ag = Convert.ToDouble(objApilamiento.ley_prom_ag);
                oApilamiento.onzas_au = Convert.ToDouble(objApilamiento.onzas_au);
                oApilamiento.onzas_ag = Convert.ToDouble(objApilamiento.onzas_ag);
                oApilamiento.densidad = Convert.ToDouble(objApilamiento.densidad);
                oApilamiento.volumen = Convert.ToDouble(objApilamiento.volumen);
                oApilamiento.activo = Convert.ToBoolean( objApilamiento.activo);
                oApilamiento.usuario_crea = objApilamiento.usuario_crea;
                oApilamiento.fecha_crea = Convert.ToDateTime(objApilamiento.fecha_crea);
                oApilamiento.usuario_mod = objApilamiento.usuario_mod;
                oApilamiento.fecha_mod = Convert.ToDateTime(objApilamiento.fecha_mod);

                oApilamientoRespuesta.DTOApilamiento = oApilamiento;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oApilamientoRespuesta;
        }
    }
}