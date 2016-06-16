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

    public class IngresoporgoteoBL : IIngresoporgoteoBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOIngresoporgoteoRespuesta obtenerIngresoporgoteo()
        {
            DTOIngresoporgoteoRespuesta oIngresoporgoteoRespuesta = new DTOIngresoporgoteoRespuesta();
            List<DTOIngresoporgoteo> oIngresoporgoteo = new List<DTOIngresoporgoteo>();
            try
            {
                var oListaIngresoporgoteo = ounitOfWork.ingresoporgoteoRepository.GetAll();
                foreach (var item in oListaIngresoporgoteo)
                {
                    oIngresoporgoteo.Add(new DTOIngresoporgoteo()
                    {
                        ingresoporgoteo_id = item.ingresoporgoteo_id,
                        codarea = item.codArea,
                        flujo = item.flujo,
                        tonelajechancado = item.tonelajeChancado,
                        leyauchancado = item.leyAuChancado,
                        leyagchancado = item.leyAgChancado,
                        tonelaje_overliner_ = item.Tonelaje_Overliner_,
                        leyauoverliner = item.leyAuOverliner,
                        leyagoverliner = item.leyAgOverliner,
                        fechainicioapilamiento = item.fechaInicioApilamiento,
                        fechafinapilamiento = item.fechaFinApilamiento,
                        fechainicioriego = item.fechaInicioRiego,
                        fechafinriego = item.fechaFinRiego,
                        fechafinrealriego = item.fechaFinRealRiego,
                        diariegoalafecha = item.diaRiegoAlaFecha,
                        diaprograriego = item.diaPrograRiego,
                        onzasau = item.onzasAu,
                        onzasag = item.onzasAg,
                        tms = item.TMS,
                        celdaId = item.celdaId,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oIngresoporgoteoRespuesta.DTOListaIngresoporgoteo = oIngresoporgoteo;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oIngresoporgoteoRespuesta;
        }


        public void registrarIngresoporgoteo(DTOIngresoporgoteo oDTOIngresoporgoteo)
        {
            try
            {
                Mapper.CreateMap<DTOIngresoporgoteo, MS_INGRESOPORGOTEO>().AfterMap((src, dest) => { dest.ingresoporgoteo_id = src.ingresoporgoteo_id; })
                         .AfterMap((src, dest) => { dest.codArea = src.codarea; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.tonelajeChancado = src.tonelajechancado; })
                         .AfterMap((src, dest) => { dest.leyAuChancado = src.leyauchancado; })
                         .AfterMap((src, dest) => { dest.leyAgChancado = src.leyagchancado; })
                         .AfterMap((src, dest) => { dest.Tonelaje_Overliner_ = src.tonelaje_overliner_; })
                         .AfterMap((src, dest) => { dest.leyAuOverliner = src.leyauoverliner; })
                         .AfterMap((src, dest) => { dest.leyAgOverliner = src.leyagoverliner; })
                         .AfterMap((src, dest) => { dest.fechaInicioApilamiento = src.fechainicioapilamiento; })
                         .AfterMap((src, dest) => { dest.fechaFinApilamiento = src.fechafinapilamiento; })
                         .AfterMap((src, dest) => { dest.fechaInicioRiego = src.fechainicioriego; })
                         .AfterMap((src, dest) => { dest.fechaFinRiego = src.fechafinriego; })
                         .AfterMap((src, dest) => { dest.fechaFinRealRiego = src.fechafinrealriego; })
                         .AfterMap((src, dest) => { dest.diaRiegoAlaFecha = src.diariegoalafecha; })
                         .AfterMap((src, dest) => { dest.diaPrograRiego = src.diaprograriego; })
                         .AfterMap((src, dest) => { dest.onzasAu = src.onzasau; })
                         .AfterMap((src, dest) => { dest.onzasAg = src.onzasag; })
                         .AfterMap((src, dest) => { dest.TMS = src.tms; })
                         .AfterMap((src, dest) => { dest.celdaId = src.celdaId; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });

                var oIngresoporgoteo = AutoMapper.Mapper.Map<DTOIngresoporgoteo, MS_INGRESOPORGOTEO>(oDTOIngresoporgoteo);
                ounitOfWork.ingresoporgoteoRepository.Insert(oIngresoporgoteo);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarIngresoporgoteo(DTOIngresoporgoteo oDTOIngresoporgoteo)
        {
            try
            {
                Mapper.CreateMap<DTOIngresoporgoteo, MS_INGRESOPORGOTEO>().AfterMap((src, dest) => { dest.ingresoporgoteo_id = src.ingresoporgoteo_id; })
                         .AfterMap((src, dest) => { dest.codArea = src.codarea; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.tonelajeChancado = src.tonelajechancado; })
                         .AfterMap((src, dest) => { dest.leyAuChancado = src.leyauchancado; })
                         .AfterMap((src, dest) => { dest.leyAgChancado = src.leyagchancado; })
                         .AfterMap((src, dest) => { dest.Tonelaje_Overliner_ = src.tonelaje_overliner_; })
                         .AfterMap((src, dest) => { dest.leyAuOverliner = src.leyauoverliner; })
                         .AfterMap((src, dest) => { dest.leyAgOverliner = src.leyagoverliner; })
                         .AfterMap((src, dest) => { dest.fechaInicioApilamiento = src.fechainicioapilamiento; })
                         .AfterMap((src, dest) => { dest.fechaFinApilamiento = src.fechafinapilamiento; })
                         .AfterMap((src, dest) => { dest.fechaInicioRiego = src.fechainicioriego; })
                         .AfterMap((src, dest) => { dest.fechaFinRiego = src.fechafinriego; })
                         .AfterMap((src, dest) => { dest.fechaFinRealRiego = src.fechafinrealriego; })
                         .AfterMap((src, dest) => { dest.diaRiegoAlaFecha = src.diariegoalafecha; })
                         .AfterMap((src, dest) => { dest.diaPrograRiego = src.diaprograriego; })
                         .AfterMap((src, dest) => { dest.onzasAu = src.onzasau; })
                         .AfterMap((src, dest) => { dest.onzasAg = src.onzasag; })
                         .AfterMap((src, dest) => { dest.TMS = src.tms; })
                         .AfterMap((src, dest) => { dest.celdaId = src.celdaId; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oIngresoporgoteo = AutoMapper.Mapper.Map<DTOIngresoporgoteo, MS_INGRESOPORGOTEO>(oDTOIngresoporgoteo);
                ounitOfWork.ingresoporgoteoRepository.Update(oIngresoporgoteo);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOIngresoporgoteoRespuesta obtenerIngresoporgoteo_por_id(int id)
        {
            DTOIngresoporgoteoRespuesta oIngresoporgoteoRespuesta = new DTOIngresoporgoteoRespuesta();
            DTOIngresoporgoteo oIngresoporgoteo = new DTOIngresoporgoteo();
            try
            {
                var objIngresoporgoteo = ounitOfWork.ingresoporgoteoRepository.GetFirst(u => u.ingresoporgoteo_id == id);
                oIngresoporgoteo.ingresoporgoteo_id = objIngresoporgoteo.ingresoporgoteo_id;
                oIngresoporgoteo.codarea = objIngresoporgoteo.codArea;
                oIngresoporgoteo.flujo = objIngresoporgoteo.flujo;
                oIngresoporgoteo.tonelajechancado = objIngresoporgoteo.tonelajeChancado;
                oIngresoporgoteo.leyauchancado = objIngresoporgoteo.leyAuChancado;
                oIngresoporgoteo.leyagchancado = objIngresoporgoteo.leyAgChancado;
                oIngresoporgoteo.tonelaje_overliner_ = objIngresoporgoteo.Tonelaje_Overliner_;
                oIngresoporgoteo.leyauoverliner = objIngresoporgoteo.leyAuOverliner;
                oIngresoporgoteo.leyagoverliner = objIngresoporgoteo.leyAgOverliner;
                oIngresoporgoteo.fechainicioapilamiento = objIngresoporgoteo.fechaInicioApilamiento;
                oIngresoporgoteo.fechafinapilamiento = objIngresoporgoteo.fechaFinApilamiento;
                oIngresoporgoteo.fechainicioriego = objIngresoporgoteo.fechaInicioRiego;
                oIngresoporgoteo.fechafinriego = objIngresoporgoteo.fechaFinRiego;
                oIngresoporgoteo.fechafinrealriego = objIngresoporgoteo.fechaFinRealRiego;
                oIngresoporgoteo.diariegoalafecha = objIngresoporgoteo.diaRiegoAlaFecha;
                oIngresoporgoteo.diaprograriego = objIngresoporgoteo.diaPrograRiego;
                oIngresoporgoteo.onzasau = objIngresoporgoteo.onzasAu;
                oIngresoporgoteo.onzasag = objIngresoporgoteo.onzasAg;
                oIngresoporgoteo.tms = objIngresoporgoteo.TMS;
                oIngresoporgoteo.celdaId = objIngresoporgoteo.celdaId;
                oIngresoporgoteo.activo = Convert.ToBoolean(objIngresoporgoteo.activo);
                oIngresoporgoteo.usuario_crea = objIngresoporgoteo.usuario_crea;
                oIngresoporgoteo.fecha_crea = Convert.ToDateTime(objIngresoporgoteo.fecha_crea);
                oIngresoporgoteo.usuario_mod = objIngresoporgoteo.usuario_mod;
                oIngresoporgoteo.fecha_mod = Convert.ToDateTime(objIngresoporgoteo.fecha_mod);

                oIngresoporgoteoRespuesta.DTOIngresoporgoteo = oIngresoporgoteo;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oIngresoporgoteoRespuesta;
        }
    }
}