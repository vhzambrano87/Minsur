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

    public class ProcesoBL : IProcesoBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOProcesoRespuesta obtenerProceso()
        {
            DTOProcesoRespuesta oProcesoRespuesta = new DTOProcesoRespuesta();
            List<DTOProceso> oProceso = new List<DTOProceso>();
            try
            {
                var oListaProceso = ounitOfWork.procesoRepository.GetAll();
                foreach (var item in oListaProceso)
                {
                    oProceso.Add(new DTOProceso()
                    {
                        proceso_id = item.proceso_id,
                        codigo = item.codigo,
                        anho = item.anho,
                        mes = item.mes,
                        mcl_fecha_inicio = item.mcl_fecha_inicio,
                        mcl_fecha_fin = item.mcl_fecha_fin,
                        adr_fecha_inicio = item.adr_fecha_inicio,
                        adr_fecha_fin = item.adr_fecha_fin,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oProcesoRespuesta.DTOListaProceso = oProceso;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProcesoRespuesta;
        }


        public void registrarProceso(DTOProceso oDTOProceso)
        {
            try
            {
                Mapper.CreateMap<DTOProceso, MS_PROCESO>().AfterMap((src, dest) => { dest.proceso_id = src.proceso_id; })
                         .AfterMap((src, dest) => { dest.codigo = src.codigo; })
                         .AfterMap((src, dest) => { dest.anho = src.anho; })
                         .AfterMap((src, dest) => { dest.mes = src.mes; })
                         .AfterMap((src, dest) => { dest.mcl_fecha_inicio = Convert.ToDateTime(src.mcl_fecha_inicio); })
                         .AfterMap((src, dest) => { dest.mcl_fecha_fin = Convert.ToDateTime(src.mcl_fecha_fin); })
                         .AfterMap((src, dest) => { dest.adr_fecha_inicio = Convert.ToDateTime(src.adr_fecha_inicio); })
                         .AfterMap((src, dest) => { dest.adr_fecha_fin = Convert.ToDateTime(src.adr_fecha_fin); })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oProceso = AutoMapper.Mapper.Map<DTOProceso, MS_PROCESO>(oDTOProceso);
                ounitOfWork.procesoRepository.Insert(oProceso);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarProceso(DTOProceso oDTOProceso)
        {
            try
            {
                Mapper.CreateMap<DTOProceso, MS_PROCESO>().AfterMap((src, dest) => { dest.proceso_id = src.proceso_id; })
                         .AfterMap((src, dest) => { dest.codigo = src.codigo; })
                         .AfterMap((src, dest) => { dest.anho = src.anho; })
                         .AfterMap((src, dest) => { dest.mes = src.mes; })
                         .AfterMap((src, dest) => { dest.mcl_fecha_inicio = Convert.ToDateTime(src.mcl_fecha_inicio); })
                         .AfterMap((src, dest) => { dest.mcl_fecha_fin = Convert.ToDateTime(src.mcl_fecha_fin); })
                         .AfterMap((src, dest) => { dest.adr_fecha_inicio = Convert.ToDateTime(src.adr_fecha_inicio); })
                         .AfterMap((src, dest) => { dest.adr_fecha_fin = Convert.ToDateTime(src.adr_fecha_fin); })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oProceso = AutoMapper.Mapper.Map<DTOProceso, MS_PROCESO>(oDTOProceso);
                ounitOfWork.procesoRepository.Update(oProceso);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOProcesoRespuesta obtenerProceso_por_id(int id)
        {
            DTOProcesoRespuesta oProcesoRespuesta = new DTOProcesoRespuesta();
            DTOProceso oProceso = new DTOProceso();
            try
            {
                var objProceso = ounitOfWork.procesoRepository.GetFirst(u => u.proceso_id == id);
                oProceso.proceso_id = objProceso.proceso_id;
                oProceso.codigo = objProceso.codigo;
                oProceso.anho = objProceso.anho;
                oProceso.mes = objProceso.mes;
                oProceso.mcl_fecha_inicio = objProceso.mcl_fecha_inicio;
                oProceso.mcl_fecha_fin = objProceso.mcl_fecha_fin;
                oProceso.adr_fecha_inicio = objProceso.adr_fecha_inicio;
                oProceso.adr_fecha_fin = objProceso.adr_fecha_fin;
                oProceso.activo = Convert.ToBoolean(objProceso.activo);
                oProceso.usuario_crea = objProceso.usuario_crea;
                oProceso.fecha_crea = Convert.ToDateTime(objProceso.fecha_crea);
                oProceso.usuario_mod = objProceso.usuario_mod;
                oProceso.fecha_mod = Convert.ToDateTime(objProceso.fecha_mod);

                oProcesoRespuesta.DTOProceso = oProceso;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProcesoRespuesta;
        }
    }
}