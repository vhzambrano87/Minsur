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

    public class Aguas_operacionesBL : IAguas_operacionesBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOAguas_operacionesRespuesta obtenerAguas_operaciones()
        {
            DTOAguas_operacionesRespuesta oAguas_operacionesRespuesta = new DTOAguas_operacionesRespuesta();
            List<DTOAguas_operaciones> oAguas_operaciones = new List<DTOAguas_operaciones>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                var oListaAguas_operaciones = ounitOfWork.aguas_operacionesRepository.GetAll();
                string turno = "";
                foreach (var item in oListaAguas_operaciones)
                {
                    turno = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor;
                    oAguas_operaciones.Add(new DTOAguas_operaciones()
                    {
                        agua_op_id = item.agua_op_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        turno_id = Convert.ToInt32(item.turno_id),
                        turno = turno,
                        tecnico_id = Convert.ToInt32(item.tecnico_id),
                        nivel_tk_1 = Convert.ToDouble( item.nivel_tk_1),
                        nivel_tk_2 = Convert.ToDouble(item.nivel_tk_2),
                        nivel_tk_contraincendio = Convert.ToDouble(item.nivel_tk_contraincendio),
                        nivel_tk_chancado = Convert.ToDouble(item.nivel_tk_chancado),
                        nivel_pm_pad = Convert.ToDouble(item.nivel_pm_pad),
                        nivel_pm_pls = Convert.ToDouble(item.nivel_pm_pls),
                        nivel_tk_botadero = Convert.ToDouble(item.nivel_tk_botadero),
                        consumo_mina_cat_777 = Convert.ToDouble(item.consumo_mina_cat_777),
                        consumo_mina_riego_vias = Convert.ToDouble(item.consumo_mina_riego_vias),
                        consumo_mina_riego_caliza = Convert.ToDouble(item.consumo_mina_riego_caliza),
                        consumo_geologia = Convert.ToDouble(item.consumo_geologia),
                        consumo_exploracion = Convert.ToDouble(item.consumo_exploracion),
                        consumo_proy_campamento = Convert.ToDouble(item.consumo_proy_campamento),
                        consumo_proy_obras = Convert.ToDouble(item.consumo_proy_obras),
                        consumo_rrhh_timpure = Convert.ToDouble(item.consumo_rrhh_timpure),
                        consumo_rrhh_pucamara = Convert.ToDouble(item.consumo_rrhh_pucamara),
                        pluviometro_lixiviacion = Convert.ToDouble(item.pluviometro_lixiviacion),
                        pluviometro_planta_adr = Convert.ToDouble(item.pluviometro_planta_adr),
                        pluviomento_pozos_agua = Convert.ToDouble(item.pluviomento_pozos_agua),
                        bombeo_chancado_niv_inicial = Convert.ToDouble(item.bombeo_chancado_niv_inicial),
                        bombeo_chancado_niv_final = Convert.ToDouble(item.bombeo_chancado_niv_final),
                        totalizador_pozo_1 = Convert.ToDouble(item.totalizador_pozo_1),
                        totalizador_pozo_2 = Convert.ToDouble(item.totalizador_pozo_2),
                        totalizador_pozo_3 = Convert.ToDouble(item.totalizador_pozo_3),
                        totalizador_pozo_4 = Convert.ToDouble(item.totalizador_pozo_4),
                        totalizador_pozo_5 = Convert.ToDouble(item.totalizador_pozo_5),
                        totalizador_pozo_6 = Convert.ToDouble(item.totalizador_pozo_6),
                        totalizador_ingreso_tk_2 = Convert.ToDouble(item.totalizador_ingreso_tk_2),
                        totalizador_make_up_planta = Convert.ToDouble(item.totalizador_make_up_planta),
                        nivel_freatico_pozo_1 = Convert.ToDouble(item.nivel_freatico_pozo_1),
                        nivel_freatico_pozo_2 = Convert.ToDouble(item.nivel_freatico_pozo_2),
                        nivel_freatico_pozo_3 = Convert.ToDouble(item.nivel_freatico_pozo_3),
                        nivel_freatico_pozo_4 = Convert.ToDouble(item.nivel_freatico_pozo_4),
                        nivel_freatico_pozo_5 = Convert.ToDouble(item.nivel_freatico_pozo_5),
                        nivel_freatico_pozo_6 = Convert.ToDouble(item.nivel_freatico_pozo_6),
                        variador_velocidad_pozo_1 = Convert.ToDouble(item.variador_velocidad_pozo_1),
                        variador_velocidad_pozo_2 = Convert.ToDouble(item.variador_velocidad_pozo_2),
                        variador_velocidad_pozo_3 = Convert.ToDouble(item.variador_velocidad_pozo_3),
                        variador_velocidad_pozo_4 = Convert.ToDouble(item.variador_velocidad_pozo_4),
                        variador_velocidad_pozo_5 = Convert.ToDouble(item.variador_velocidad_pozo_5),
                        variador_velocidad_pozo_6 = Convert.ToDouble(item.variador_velocidad_pozo_6),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oAguas_operacionesRespuesta.DTOListaAguas_operaciones = oAguas_operaciones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oAguas_operacionesRespuesta;
        }


        public void registrarAguas_operaciones(DTOAguas_operaciones oDTOAguas_operaciones)
        {
            try
            {
                Mapper.CreateMap<DTOAguas_operaciones, MS_AGUAS_OPERACIONES>().AfterMap((src, dest) => { dest.agua_op_id = src.agua_op_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tecnico_id = src.tecnico_id; })
                         .AfterMap((src, dest) => { dest.nivel_tk_1 = src.nivel_tk_1; })
                         .AfterMap((src, dest) => { dest.nivel_tk_2 = src.nivel_tk_2; })
                         .AfterMap((src, dest) => { dest.nivel_tk_contraincendio = src.nivel_tk_contraincendio; })
                         .AfterMap((src, dest) => { dest.nivel_tk_chancado = src.nivel_tk_chancado; })
                         .AfterMap((src, dest) => { dest.nivel_pm_pad = src.nivel_pm_pad; })
                         .AfterMap((src, dest) => { dest.nivel_pm_pls = src.nivel_pm_pls; })
                         .AfterMap((src, dest) => { dest.nivel_tk_botadero = src.nivel_tk_botadero; })
                         .AfterMap((src, dest) => { dest.consumo_mina_cat_777 = src.consumo_mina_cat_777; })
                         .AfterMap((src, dest) => { dest.consumo_mina_riego_vias = src.consumo_mina_riego_vias; })
                         .AfterMap((src, dest) => { dest.consumo_mina_riego_caliza = src.consumo_mina_riego_caliza; })
                         .AfterMap((src, dest) => { dest.consumo_geologia = src.consumo_geologia; })
                         .AfterMap((src, dest) => { dest.consumo_exploracion = src.consumo_exploracion; })
                         .AfterMap((src, dest) => { dest.consumo_proy_campamento = src.consumo_proy_campamento; })
                         .AfterMap((src, dest) => { dest.consumo_proy_obras = src.consumo_proy_obras; })
                         .AfterMap((src, dest) => { dest.consumo_rrhh_timpure = src.consumo_rrhh_timpure; })
                         .AfterMap((src, dest) => { dest.consumo_rrhh_pucamara = src.consumo_rrhh_pucamara; })
                         .AfterMap((src, dest) => { dest.pluviometro_lixiviacion = src.pluviometro_lixiviacion; })
                         .AfterMap((src, dest) => { dest.pluviometro_planta_adr = src.pluviometro_planta_adr; })
                         .AfterMap((src, dest) => { dest.pluviomento_pozos_agua = src.pluviomento_pozos_agua; })
                         .AfterMap((src, dest) => { dest.bombeo_chancado_niv_inicial = src.bombeo_chancado_niv_inicial; })
                         .AfterMap((src, dest) => { dest.bombeo_chancado_niv_final = src.bombeo_chancado_niv_final; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_1 = src.totalizador_pozo_1; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_2 = src.totalizador_pozo_2; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_3 = src.totalizador_pozo_3; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_4 = src.totalizador_pozo_4; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_5 = src.totalizador_pozo_5; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_6 = src.totalizador_pozo_6; })
                         .AfterMap((src, dest) => { dest.totalizador_ingreso_tk_2 = src.totalizador_ingreso_tk_2; })
                         .AfterMap((src, dest) => { dest.totalizador_make_up_planta = src.totalizador_make_up_planta; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_1 = src.nivel_freatico_pozo_1; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_2 = src.nivel_freatico_pozo_2; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_3 = src.nivel_freatico_pozo_3; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_4 = src.nivel_freatico_pozo_4; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_5 = src.nivel_freatico_pozo_5; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_6 = src.nivel_freatico_pozo_6; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_1 = src.variador_velocidad_pozo_1; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_2 = src.variador_velocidad_pozo_2; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_3 = src.variador_velocidad_pozo_3; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_4 = src.variador_velocidad_pozo_4; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_5 = src.variador_velocidad_pozo_5; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_6 = src.variador_velocidad_pozo_6; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oAguas_operaciones = AutoMapper.Mapper.Map<DTOAguas_operaciones, MS_AGUAS_OPERACIONES>(oDTOAguas_operaciones);
                ounitOfWork.aguas_operacionesRepository.Insert(oAguas_operaciones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarAguas_operaciones(DTOAguas_operaciones oDTOAguas_operaciones)
        {
            try
            {
                Mapper.CreateMap<DTOAguas_operaciones, MS_AGUAS_OPERACIONES>().AfterMap((src, dest) => { dest.agua_op_id = src.agua_op_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tecnico_id = src.tecnico_id; })
                         .AfterMap((src, dest) => { dest.nivel_tk_1 = src.nivel_tk_1; })
                         .AfterMap((src, dest) => { dest.nivel_tk_2 = src.nivel_tk_2; })
                         .AfterMap((src, dest) => { dest.nivel_tk_contraincendio = src.nivel_tk_contraincendio; })
                         .AfterMap((src, dest) => { dest.nivel_tk_chancado = src.nivel_tk_chancado; })
                         .AfterMap((src, dest) => { dest.nivel_pm_pad = src.nivel_pm_pad; })
                         .AfterMap((src, dest) => { dest.nivel_pm_pls = src.nivel_pm_pls; })
                         .AfterMap((src, dest) => { dest.nivel_tk_botadero = src.nivel_tk_botadero; })
                         .AfterMap((src, dest) => { dest.consumo_mina_cat_777 = src.consumo_mina_cat_777; })
                         .AfterMap((src, dest) => { dest.consumo_mina_riego_vias = src.consumo_mina_riego_vias; })
                         .AfterMap((src, dest) => { dest.consumo_mina_riego_caliza = src.consumo_mina_riego_caliza; })
                         .AfterMap((src, dest) => { dest.consumo_geologia = src.consumo_geologia; })
                         .AfterMap((src, dest) => { dest.consumo_exploracion = src.consumo_exploracion; })
                         .AfterMap((src, dest) => { dest.consumo_proy_campamento = src.consumo_proy_campamento; })
                         .AfterMap((src, dest) => { dest.consumo_proy_obras = src.consumo_proy_obras; })
                         .AfterMap((src, dest) => { dest.consumo_rrhh_timpure = src.consumo_rrhh_timpure; })
                         .AfterMap((src, dest) => { dest.consumo_rrhh_pucamara = src.consumo_rrhh_pucamara; })
                         .AfterMap((src, dest) => { dest.pluviometro_lixiviacion = src.pluviometro_lixiviacion; })
                         .AfterMap((src, dest) => { dest.pluviometro_planta_adr = src.pluviometro_planta_adr; })
                         .AfterMap((src, dest) => { dest.pluviomento_pozos_agua = src.pluviomento_pozos_agua; })
                         .AfterMap((src, dest) => { dest.bombeo_chancado_niv_inicial = src.bombeo_chancado_niv_inicial; })
                         .AfterMap((src, dest) => { dest.bombeo_chancado_niv_final = src.bombeo_chancado_niv_final; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_1 = src.totalizador_pozo_1; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_2 = src.totalizador_pozo_2; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_3 = src.totalizador_pozo_3; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_4 = src.totalizador_pozo_4; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_5 = src.totalizador_pozo_5; })
                         .AfterMap((src, dest) => { dest.totalizador_pozo_6 = src.totalizador_pozo_6; })
                         .AfterMap((src, dest) => { dest.totalizador_ingreso_tk_2 = src.totalizador_ingreso_tk_2; })
                         .AfterMap((src, dest) => { dest.totalizador_make_up_planta = src.totalizador_make_up_planta; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_1 = src.nivel_freatico_pozo_1; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_2 = src.nivel_freatico_pozo_2; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_3 = src.nivel_freatico_pozo_3; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_4 = src.nivel_freatico_pozo_4; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_5 = src.nivel_freatico_pozo_5; })
                         .AfterMap((src, dest) => { dest.nivel_freatico_pozo_6 = src.nivel_freatico_pozo_6; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_1 = src.variador_velocidad_pozo_1; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_2 = src.variador_velocidad_pozo_2; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_3 = src.variador_velocidad_pozo_3; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_4 = src.variador_velocidad_pozo_4; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_5 = src.variador_velocidad_pozo_5; })
                         .AfterMap((src, dest) => { dest.variador_velocidad_pozo_6 = src.variador_velocidad_pozo_6; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oAguas_operaciones = AutoMapper.Mapper.Map<DTOAguas_operaciones, MS_AGUAS_OPERACIONES>(oDTOAguas_operaciones);
                ounitOfWork.aguas_operacionesRepository.Update(oAguas_operaciones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOAguas_operacionesRespuesta obtenerAguas_operaciones_por_id(int id)
        {
            DTOAguas_operacionesRespuesta oAguas_operacionesRespuesta = new DTOAguas_operacionesRespuesta();
            DTOAguas_operaciones oAguas_operaciones = new DTOAguas_operaciones();
            try
            {
                var objAguas_operaciones = ounitOfWork.aguas_operacionesRepository.GetFirst(u => u.agua_op_id == id);
                oAguas_operaciones.agua_op_id = objAguas_operaciones.agua_op_id;
                oAguas_operaciones.fecha = Convert.ToDateTime(objAguas_operaciones.fecha);
                oAguas_operaciones.turno_id = Convert.ToInt32(objAguas_operaciones.turno_id);
                oAguas_operaciones.tecnico_id = Convert.ToInt32( objAguas_operaciones.tecnico_id);
                oAguas_operaciones.nivel_tk_1 = Convert.ToDouble(objAguas_operaciones.nivel_tk_1);
                oAguas_operaciones.nivel_tk_2 = Convert.ToDouble(objAguas_operaciones.nivel_tk_2);
                oAguas_operaciones.nivel_tk_contraincendio = Convert.ToDouble(objAguas_operaciones.nivel_tk_contraincendio);
                oAguas_operaciones.nivel_tk_chancado = Convert.ToDouble(objAguas_operaciones.nivel_tk_chancado);
                oAguas_operaciones.nivel_pm_pad = Convert.ToDouble(objAguas_operaciones.nivel_pm_pad);
                oAguas_operaciones.nivel_pm_pls = Convert.ToDouble(objAguas_operaciones.nivel_pm_pls);
                oAguas_operaciones.nivel_tk_botadero = Convert.ToDouble(objAguas_operaciones.nivel_tk_botadero);
                oAguas_operaciones.consumo_mina_cat_777 = Convert.ToDouble(objAguas_operaciones.consumo_mina_cat_777);
                oAguas_operaciones.consumo_mina_riego_vias = Convert.ToDouble(objAguas_operaciones.consumo_mina_riego_vias);
                oAguas_operaciones.consumo_mina_riego_caliza = Convert.ToDouble(objAguas_operaciones.consumo_mina_riego_caliza);
                oAguas_operaciones.consumo_geologia = Convert.ToDouble(objAguas_operaciones.consumo_geologia);
                oAguas_operaciones.consumo_exploracion = Convert.ToDouble(objAguas_operaciones.consumo_exploracion);
                oAguas_operaciones.consumo_proy_campamento = Convert.ToDouble(objAguas_operaciones.consumo_proy_campamento);
                oAguas_operaciones.consumo_proy_obras = Convert.ToDouble(objAguas_operaciones.consumo_proy_obras);
                oAguas_operaciones.consumo_rrhh_timpure = Convert.ToDouble(objAguas_operaciones.consumo_rrhh_timpure);
                oAguas_operaciones.consumo_rrhh_pucamara = Convert.ToDouble(objAguas_operaciones.consumo_rrhh_pucamara);
                oAguas_operaciones.pluviometro_lixiviacion = Convert.ToDouble(objAguas_operaciones.pluviometro_lixiviacion);
                oAguas_operaciones.pluviometro_planta_adr = Convert.ToDouble(objAguas_operaciones.pluviometro_planta_adr);
                oAguas_operaciones.pluviomento_pozos_agua = Convert.ToDouble(objAguas_operaciones.pluviomento_pozos_agua);
                oAguas_operaciones.bombeo_chancado_niv_inicial = Convert.ToDouble(objAguas_operaciones.bombeo_chancado_niv_inicial);
                oAguas_operaciones.bombeo_chancado_niv_final = Convert.ToDouble(objAguas_operaciones.bombeo_chancado_niv_final);
                oAguas_operaciones.totalizador_pozo_1 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_1);
                oAguas_operaciones.totalizador_pozo_2 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_2);
                oAguas_operaciones.totalizador_pozo_3 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_3);
                oAguas_operaciones.totalizador_pozo_4 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_4);
                oAguas_operaciones.totalizador_pozo_5 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_5);
                oAguas_operaciones.totalizador_pozo_6 = Convert.ToDouble(objAguas_operaciones.totalizador_pozo_6);
                oAguas_operaciones.totalizador_ingreso_tk_2 = Convert.ToDouble(objAguas_operaciones.totalizador_ingreso_tk_2);
                oAguas_operaciones.totalizador_make_up_planta = Convert.ToDouble(objAguas_operaciones.totalizador_make_up_planta);
                oAguas_operaciones.nivel_freatico_pozo_1 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_1);
                oAguas_operaciones.nivel_freatico_pozo_2 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_2);
                oAguas_operaciones.nivel_freatico_pozo_3 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_3);
                oAguas_operaciones.nivel_freatico_pozo_4 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_4);
                oAguas_operaciones.nivel_freatico_pozo_5 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_5);
                oAguas_operaciones.nivel_freatico_pozo_6 = Convert.ToDouble(objAguas_operaciones.nivel_freatico_pozo_6);
                oAguas_operaciones.variador_velocidad_pozo_1 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_1);
                oAguas_operaciones.variador_velocidad_pozo_2 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_2);
                oAguas_operaciones.variador_velocidad_pozo_3 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_3);
                oAguas_operaciones.variador_velocidad_pozo_4 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_4);
                oAguas_operaciones.variador_velocidad_pozo_5 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_5);
                oAguas_operaciones.variador_velocidad_pozo_6 = Convert.ToDouble(objAguas_operaciones.variador_velocidad_pozo_6);
                oAguas_operaciones.activo = Convert.ToBoolean( objAguas_operaciones.activo);
                oAguas_operaciones.usuario_crea = objAguas_operaciones.usuario_crea;
                oAguas_operaciones.fecha_crea = Convert.ToDateTime(objAguas_operaciones.fecha_crea);
                oAguas_operaciones.usuario_mod = objAguas_operaciones.usuario_mod;
                oAguas_operaciones.fecha_mod = Convert.ToDateTime(objAguas_operaciones.fecha_mod);

                oAguas_operacionesRespuesta.DTOAguas_operaciones = oAguas_operaciones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oAguas_operacionesRespuesta;
        }
    }
}