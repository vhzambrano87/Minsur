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

    public class ParametroBL : IParametroBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOParametroRespuesta obtenerParametro()
        {
            DTOParametroRespuesta oParametroRespuesta = new DTOParametroRespuesta();
            List<DTOParametro> oParametro = new List<DTOParametro>();
            try
            {
                var oListaParametro = ounitOfWork.parametroRepository.GetAll();
                foreach (var item in oListaParametro)
                {
                    oParametro.Add(new DTOParametro()
                    {
                        parametro_id = item.parametro_id,
                        horas = Convert.ToDouble(item.horas),
                        total_ini = Convert.ToDouble(item.total_ini),
                        total_fin = Convert.ToDouble(item.total_fin),
                        flujo_dia = Convert.ToDouble(item.flujo_dia),
                        nivel_poza_pls = Convert.ToDouble(item.nivel_poza_pls),
                        nivel_poza_may = Convert.ToDouble(item.nivel_poza_may),
                        vol_poza_pls = Convert.ToDouble(item.vol_poza_pls),
                        vol_poza_may = Convert.ToDouble(item.vol_poza_may),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oParametroRespuesta.DTOListaParametro = oParametro;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oParametroRespuesta;
        }


        public void registrarParametro(DTOParametro oDTOParametro)
        {
            try
            {
                Mapper.CreateMap<DTOParametro, MS_PARAMETRO>().AfterMap((src, dest) => { dest.parametro_id = src.parametro_id; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.total_ini = src.total_ini; })
                         .AfterMap((src, dest) => { dest.total_fin = src.total_fin; })
                         .AfterMap((src, dest) => { dest.flujo_dia = src.flujo_dia; })
                         .AfterMap((src, dest) => { dest.nivel_poza_pls = src.nivel_poza_pls; })
                         .AfterMap((src, dest) => { dest.nivel_poza_may = src.nivel_poza_may; })
                         .AfterMap((src, dest) => { dest.vol_poza_pls = src.vol_poza_pls; })
                         .AfterMap((src, dest) => { dest.vol_poza_may = src.vol_poza_may; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oParametro = AutoMapper.Mapper.Map<DTOParametro, MS_PARAMETRO>(oDTOParametro);
                ounitOfWork.parametroRepository.Insert(oParametro);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarParametro(DTOParametro oDTOParametro)
        {
            try
            {
                Mapper.CreateMap<DTOParametro, MS_PARAMETRO>().AfterMap((src, dest) => { dest.parametro_id = src.parametro_id; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.total_ini = src.total_ini; })
                         .AfterMap((src, dest) => { dest.total_fin = src.total_fin; })
                         .AfterMap((src, dest) => { dest.flujo_dia = src.flujo_dia; })
                         .AfterMap((src, dest) => { dest.nivel_poza_pls = src.nivel_poza_pls; })
                         .AfterMap((src, dest) => { dest.nivel_poza_may = src.nivel_poza_may; })
                         .AfterMap((src, dest) => { dest.vol_poza_pls = src.vol_poza_pls; })
                         .AfterMap((src, dest) => { dest.vol_poza_may = src.vol_poza_may; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oParametro = AutoMapper.Mapper.Map<DTOParametro, MS_PARAMETRO>(oDTOParametro);
                ounitOfWork.parametroRepository.Update(oParametro);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOParametroRespuesta obtenerParametro_por_id(int id)
        {
            DTOParametroRespuesta oParametroRespuesta = new DTOParametroRespuesta();
            DTOParametro oParametro = new DTOParametro();
            try
            {
                var objParametro = ounitOfWork.parametroRepository.GetFirst(u => u.parametro_id == id);
                oParametro.parametro_id = objParametro.parametro_id;
                oParametro.horas = Convert.ToDouble(objParametro.horas);
                oParametro.total_ini = Convert.ToDouble(objParametro.total_ini);
                oParametro.total_fin = Convert.ToDouble(objParametro.total_fin);
                oParametro.flujo_dia = Convert.ToDouble(objParametro.flujo_dia);
                oParametro.nivel_poza_pls = Convert.ToDouble(objParametro.nivel_poza_pls);
                oParametro.nivel_poza_may = Convert.ToDouble(objParametro.nivel_poza_may);
                oParametro.vol_poza_pls = Convert.ToDouble(objParametro.vol_poza_pls);
                oParametro.vol_poza_may = Convert.ToDouble(objParametro.vol_poza_may);
                oParametro.activo = Convert.ToBoolean(objParametro.activo);
                oParametro.usuario_crea = objParametro.usuario_crea;
                oParametro.fecha_crea = Convert.ToDateTime(objParametro.fecha_crea);
                oParametro.usuario_mod = objParametro.usuario_mod;
                oParametro.fecha_mod = Convert.ToDateTime(objParametro.fecha_mod);

                oParametroRespuesta.DTOParametro = oParametro;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oParametroRespuesta;
        }
    }
}