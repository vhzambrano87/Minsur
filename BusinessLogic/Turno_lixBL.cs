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

    public class Turno_lixBL : ITurno_lixBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOTurno_lixRespuesta obtenerTurno_lix()
        {
            DTOTurno_lixRespuesta oTurno_lixRespuesta = new DTOTurno_lixRespuesta();
            List<DTOTurno_lix> oTurno_lix = new List<DTOTurno_lix>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                var oListaTurno_lix = ounitOfWork.turno_lixRepository.GetAll();
                string turno = "";
                foreach (var item in oListaTurno_lix)
                {
                    turno = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor;
                    
                    oTurno_lix.Add(new DTOTurno_lix()
                    {
                        turno_lix_id = item.turno_lix_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        turno_id = Convert.ToInt32(item.turno_id),
                        turno = turno,
                        poza_pls = Convert.ToDouble(item.poza_pls),
                        lluvia = Convert.ToDouble(item.lluvia),
                        ley_oro_m1_tren_1 = Convert.ToDouble(item.ley_oro_m1_tren_1),
                        ley_oro_m1_tren_2 = Convert.ToDouble(item.ley_oro_m1_tren_2),
                        ley_oro_m2_tren_1 = Convert.ToDouble(item.ley_oro_m2_tren_1),
                        ley_oro_m2_tren_2 = Convert.ToDouble(item.ley_oro_m2_tren_2),
                        ley_oro_m3 = Convert.ToDouble(item.ley_oro_m3),
                        ley_plata_m1_tren_1 = Convert.ToDouble(item.ley_plata_m1_tren_1),
                        ley_plata_m1_tren_2 = Convert.ToDouble(item.ley_plata_m1_tren_2),
                        ley_plata_m2_tren_1 = Convert.ToDouble(item.ley_plata_m2_tren_1),
                        ley_plata_m2_tren_2 = Convert.ToDouble(item.ley_plata_m2_tren_2),
                        flujo_adr_tren_1 = Convert.ToDouble(item.flujo_adr_tren_1),
                        flujo_adr_tren_2 = Convert.ToDouble(item.flujo_adr_tren_2),
                        flujo_lixiviacion = Convert.ToDouble(item.flujo_lixiviacion),
                        factor = Convert.ToDouble(item.factor),
                        flujo_adr_tren_1_calc = Convert.ToDouble(item.flujo_adr_tren_1_calc),
                        flujo_adr_tren_2_calc = Convert.ToDouble(item.flujo_adr_tren_2_calc),
                        flujo_lixiviacion_calc = Convert.ToDouble(item.flujo_lixiviacion_calc),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oTurno_lixRespuesta.DTOListaTurno_lix = oTurno_lix;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oTurno_lixRespuesta;
        }


        public void registrarTurno_lix(DTOTurno_lix oDTOTurno_lix)
        {
            try
            {
                Mapper.CreateMap<DTOTurno_lix, MS_TURNO_LIX>().AfterMap((src, dest) =>{ dest.turno_lix_id = src.turno_lix_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.poza_pls = src.poza_pls; })
                         .AfterMap((src, dest) => { dest.lluvia = src.lluvia; })
                         .AfterMap((src, dest) => { dest.ley_oro_m1_tren_1 = src.ley_oro_m1_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_oro_m1_tren_2 = src.ley_oro_m1_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_oro_m2_tren_1 = src.ley_oro_m2_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_oro_m2_tren_2 = src.ley_oro_m2_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_oro_m3 = src.ley_oro_m3; })
                         .AfterMap((src, dest) => { dest.ley_plata_m1_tren_1 = src.ley_plata_m1_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_plata_m1_tren_2 = src.ley_plata_m1_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_plata_m2_tren_1 = src.ley_plata_m2_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_plata_m2_tren_2 = src.ley_plata_m2_tren_2; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_1 = src.flujo_adr_tren_1; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_2 = src.flujo_adr_tren_2; })
                         .AfterMap((src, dest) => { dest.flujo_lixiviacion = src.flujo_lixiviacion; })
                         .AfterMap((src, dest) => { dest.factor = src.factor; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_1_calc = src.flujo_adr_tren_1_calc; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_2_calc = src.flujo_adr_tren_2_calc; })
                         .AfterMap((src, dest) => { dest.flujo_lixiviacion_calc = src.flujo_lixiviacion_calc; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oTurno_lix = AutoMapper.Mapper.Map<DTOTurno_lix, MS_TURNO_LIX>(oDTOTurno_lix);
                ounitOfWork.turno_lixRepository.Insert(oTurno_lix);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarTurno_lix(DTOTurno_lix oDTOTurno_lix)
        {
            try
            {
                Mapper.CreateMap<DTOTurno_lix, MS_TURNO_LIX>().AfterMap((src, dest) => { dest.turno_lix_id = src.turno_lix_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.poza_pls = src.poza_pls; })
                         .AfterMap((src, dest) => { dest.lluvia = src.lluvia; })
                         .AfterMap((src, dest) => { dest.ley_oro_m1_tren_1 = src.ley_oro_m1_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_oro_m1_tren_2 = src.ley_oro_m1_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_oro_m2_tren_1 = src.ley_oro_m2_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_oro_m2_tren_2 = src.ley_oro_m2_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_oro_m3 = src.ley_oro_m3; })
                         .AfterMap((src, dest) => { dest.ley_plata_m1_tren_1 = src.ley_plata_m1_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_plata_m1_tren_2 = src.ley_plata_m1_tren_2; })
                         .AfterMap((src, dest) => { dest.ley_plata_m2_tren_1 = src.ley_plata_m2_tren_1; })
                         .AfterMap((src, dest) => { dest.ley_plata_m2_tren_2 = src.ley_plata_m2_tren_2; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_1 = src.flujo_adr_tren_1; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_2 = src.flujo_adr_tren_2; })
                         .AfterMap((src, dest) => { dest.flujo_lixiviacion = src.flujo_lixiviacion; })
                         .AfterMap((src, dest) => { dest.factor = src.factor; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_1_calc = src.flujo_adr_tren_1_calc; })
                         .AfterMap((src, dest) => { dest.flujo_adr_tren_2_calc = src.flujo_adr_tren_2_calc; })
                         .AfterMap((src, dest) => { dest.flujo_lixiviacion_calc = src.flujo_lixiviacion_calc; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oTurno_lix = AutoMapper.Mapper.Map<DTOTurno_lix, MS_TURNO_LIX>(oDTOTurno_lix);
                ounitOfWork.turno_lixRepository.Update(oTurno_lix);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOTurno_lixRespuesta obtenerTurno_lix_por_id(int id)
        {
            DTOTurno_lixRespuesta oTurno_lixRespuesta = new DTOTurno_lixRespuesta();
            DTOTurno_lix oTurno_lix = new DTOTurno_lix();
            try
            {
                var objTurno_lix = ounitOfWork.turno_lixRepository.GetFirst(u => u.turno_lix_id == id);
                oTurno_lix.turno_lix_id = objTurno_lix.turno_lix_id;
                oTurno_lix.fecha =Convert.ToDateTime( objTurno_lix.fecha);
                oTurno_lix.turno_id = Convert.ToInt32(objTurno_lix.turno_id);
                oTurno_lix.poza_pls = Convert.ToDouble( objTurno_lix.poza_pls);
                oTurno_lix.lluvia = Convert.ToDouble(objTurno_lix.lluvia);
                oTurno_lix.ley_oro_m1_tren_1 = Convert.ToDouble(objTurno_lix.ley_oro_m1_tren_1);
                oTurno_lix.ley_oro_m1_tren_2 = Convert.ToDouble(objTurno_lix.ley_oro_m1_tren_2);
                oTurno_lix.ley_oro_m2_tren_1 = Convert.ToDouble(objTurno_lix.ley_oro_m2_tren_1);
                oTurno_lix.ley_oro_m2_tren_2 = Convert.ToDouble(objTurno_lix.ley_oro_m2_tren_2);
                oTurno_lix.ley_oro_m3 = Convert.ToDouble(objTurno_lix.ley_oro_m3);
                oTurno_lix.ley_plata_m1_tren_1 = Convert.ToDouble(objTurno_lix.ley_plata_m1_tren_1);
                oTurno_lix.ley_plata_m1_tren_2 = Convert.ToDouble(objTurno_lix.ley_plata_m1_tren_2);
                oTurno_lix.ley_plata_m2_tren_1 = Convert.ToDouble(objTurno_lix.ley_plata_m2_tren_1);
                oTurno_lix.ley_plata_m2_tren_2 = Convert.ToDouble(objTurno_lix.ley_plata_m2_tren_2);
                oTurno_lix.flujo_adr_tren_1 = Convert.ToDouble(objTurno_lix.flujo_adr_tren_1);
                oTurno_lix.flujo_adr_tren_2 = Convert.ToDouble(objTurno_lix.flujo_adr_tren_2);
                oTurno_lix.flujo_lixiviacion = Convert.ToDouble(objTurno_lix.flujo_lixiviacion);
                oTurno_lix.factor = Convert.ToDouble(objTurno_lix.factor);
                oTurno_lix.flujo_adr_tren_1_calc = Convert.ToDouble(objTurno_lix.flujo_adr_tren_1_calc);
                oTurno_lix.flujo_adr_tren_2_calc = Convert.ToDouble(objTurno_lix.flujo_adr_tren_2_calc);
                oTurno_lix.flujo_lixiviacion_calc = Convert.ToDouble(objTurno_lix.flujo_lixiviacion_calc);
                oTurno_lix.activo = Convert.ToBoolean( objTurno_lix.activo);
                oTurno_lix.usuario_crea = objTurno_lix.usuario_crea;
                oTurno_lix.fecha_crea = Convert.ToDateTime(objTurno_lix.fecha_crea);
                oTurno_lix.usuario_mod = objTurno_lix.usuario_mod;
                oTurno_lix.fecha_mod = Convert.ToDateTime(objTurno_lix.fecha_mod);

                oTurno_lixRespuesta.DTOTurno_lix = oTurno_lix;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oTurno_lixRespuesta;
        }
    }
}