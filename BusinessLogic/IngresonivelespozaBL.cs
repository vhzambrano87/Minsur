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

    public class IngresonivelespozaBL : IIngresonivelespozaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOIngresonivelespozaRespuesta obtenerIngresonivelespoza()
        {
            DTOIngresonivelespozaRespuesta oIngresonivelespozaRespuesta = new DTOIngresonivelespozaRespuesta();
            List<DTOIngresonivelespoza> oIngresonivelespoza = new List<DTOIngresonivelespoza>();
            try
            {
                var oListaIngresonivelespoza = ounitOfWork.ingresonivelespozaRepository.GetAll();
                foreach (var item in oListaIngresonivelespoza)
                {
                    oIngresonivelespoza.Add(new DTOIngresonivelespoza()
                    {
                        ingresonivelespoza_id = item.ingresoNivelesPoza_id,
                        fecha = item.fecha,
                        turno = item.turno,
                        cotapls = item.cotaPLS,
                        volumepls = item.volumePLS,
                        cotapge = item.cotaPGE,
                        volumepge = item.volumePGE,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oIngresonivelespozaRespuesta.DTOListaIngresonivelespoza = oIngresonivelespoza;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oIngresonivelespozaRespuesta;
        }


        public void registrarIngresonivelespoza(DTOIngresonivelespoza oDTOIngresonivelespoza)
        {
            try
            {
                Mapper.CreateMap<DTOIngresonivelespoza, MS_INGRESONIVELESPOZA>().AfterMap((src, dest) => { dest.ingresoNivelesPoza_id = src.ingresonivelespoza_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno = src.turno; })
                         .AfterMap((src, dest) => { dest.cotaPLS = src.cotapls; })
                         .AfterMap((src, dest) => { dest.volumePLS = src.volumepls; })
                         .AfterMap((src, dest) => { dest.cotaPGE = src.cotapge; })
                         .AfterMap((src, dest) => { dest.volumePGE = src.volumepge; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });
                var oIngresonivelespoza = AutoMapper.Mapper.Map<DTOIngresonivelespoza, MS_INGRESONIVELESPOZA>(oDTOIngresonivelespoza);
                ounitOfWork.ingresonivelespozaRepository.Insert(oIngresonivelespoza);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarIngresonivelespoza(DTOIngresonivelespoza oDTOIngresonivelespoza)
        {
            try
            {
                Mapper.CreateMap<DTOIngresonivelespoza, MS_INGRESONIVELESPOZA>().AfterMap((src, dest) => { dest.ingresoNivelesPoza_id = src.ingresonivelespoza_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno = src.turno; })
                         .AfterMap((src, dest) => { dest.cotaPLS = src.cotapls; })
                         .AfterMap((src, dest) => { dest.volumePLS = src.volumepls; })
                         .AfterMap((src, dest) => { dest.cotaPGE = src.cotapge; })
                         .AfterMap((src, dest) => { dest.volumePGE = src.volumepge; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oIngresonivelespoza = AutoMapper.Mapper.Map<DTOIngresonivelespoza, MS_INGRESONIVELESPOZA>(oDTOIngresonivelespoza);
                ounitOfWork.ingresonivelespozaRepository.Update(oIngresonivelespoza);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOIngresonivelespozaRespuesta obtenerIngresonivelespoza_por_id(int id)
        {
            DTOIngresonivelespozaRespuesta oIngresonivelespozaRespuesta = new DTOIngresonivelespozaRespuesta();
            DTOIngresonivelespoza oIngresonivelespoza = new DTOIngresonivelespoza();
            try
            {
                var objIngresonivelespoza = ounitOfWork.ingresonivelespozaRepository.GetFirst(u => u.ingresoNivelesPoza_id == id);
                oIngresonivelespoza.ingresonivelespoza_id = objIngresonivelespoza.ingresoNivelesPoza_id;
                oIngresonivelespoza.fecha = objIngresonivelespoza.fecha;
                oIngresonivelespoza.turno = objIngresonivelespoza.turno;
                oIngresonivelespoza.cotapls = objIngresonivelespoza.cotaPLS;
                oIngresonivelespoza.volumepls = objIngresonivelespoza.volumePLS;
                oIngresonivelespoza.cotapge = objIngresonivelespoza.cotaPGE;
                oIngresonivelespoza.volumepge = objIngresonivelespoza.volumePGE;
                oIngresonivelespoza.activo = Convert.ToBoolean(objIngresonivelespoza.activo);
                oIngresonivelespoza.usuario_crea = objIngresonivelespoza.usuario_crea;
                oIngresonivelespoza.fecha_crea = Convert.ToDateTime(objIngresonivelespoza.fecha_crea);
                oIngresonivelespoza.usuario_mod = objIngresonivelespoza.usuario_mod;
                oIngresonivelespoza.fecha_mod = Convert.ToDateTime(objIngresonivelespoza.fecha_mod);

                oIngresonivelespozaRespuesta.DTOIngresonivelespoza = oIngresonivelespoza;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oIngresonivelespozaRespuesta;
        }
    }
}