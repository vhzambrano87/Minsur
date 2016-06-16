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

    public class Control_dig_lixiviacionBL : IControl_dig_lixiviacionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOControl_dig_lixiviacionRespuesta obtenerControl_dig_lixiviacion()
        {
            DTOControl_dig_lixiviacionRespuesta oControl_dig_lixiviacionRespuesta = new DTOControl_dig_lixiviacionRespuesta();
            List<DTOControl_dig_lixiviacion> oControl_dig_lixiviacion = new List<DTOControl_dig_lixiviacion>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                var oListaControl_dig_lixiviacion = ounitOfWork.control_dig_lixiviacionRepository.GetAll();
                string turno = "";
                string celda = "";
                string tecnico_lix = "";
                string tecnico_api = "";
                foreach (var item in oListaControl_dig_lixiviacion)
                {
                    turno = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor;
                    celda = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.celda_id)).DTOLista_valor.valor;
                    tecnico_lix = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.tecnico_lixiviacion_id)).DTOLista_valor.valor;
                    tecnico_api = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.tecnico_apilamiento_id)).DTOLista_valor.valor;


                    oControl_dig_lixiviacion.Add(new DTOControl_dig_lixiviacion()
                    {
                        control_dig_lix_id = item.control_dig_lix_id,
                        fecha = Convert.ToDateTime( item.fecha),
                        turno_id = Convert.ToInt32( item.turno_id),
                        celda_id = Convert.ToInt32(item.celda_id),
                        tecnico_lixiviacion_id = Convert.ToInt32(item.tecnico_lixiviacion_id),
                        tecnico_apilamiento_id = Convert.ToInt32(item.tecnico_apilamiento_id),
                        
                        turno = turno,
                        celda = celda,
                        tecnico_lixiviacion = tecnico_lix,
                        tecnico_apilamiento = tecnico_api,

                        nro_viajes = Convert.ToInt32(item.nro_viajes),
                        celda_opc = item.celda_opc,
                        nro_camiones = Convert.ToInt32(item.nro_camiones),
                        ley_mineral = Convert.ToDouble( item.ley_mineral),
                        poligono = Convert.ToDouble(item.poligono),
                        pluviometro = Convert.ToDouble(item.pluviometro),
                        cal_viva = Convert.ToDouble(item.cal_viva),
                        cal_hidratada = Convert.ToDouble(item.cal_hidratada),
                        corte = Convert.ToDouble(item.corte),
                        ripeo = Convert.ToDouble(item.ripeo),
                        totalizador_tk_2 = Convert.ToDouble(item.totalizador_tk_2),
                        nivel_tk_2 = Convert.ToDouble(item.nivel_tk_2),
                        presion_flujo = Convert.ToDouble(item.presion_flujo),
                        comentarios = item.comentarios,
                        flujo = Convert.ToDouble(item.flujo),
                        presion_adr = Convert.ToDouble(item.presion_adr),
                        presion_sump = Convert.ToDouble(item.presion_sump),
                        presion_925 = Convert.ToDouble(item.presion_925),
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oControl_dig_lixiviacionRespuesta.DTOListaControl_dig_lixiviacion = oControl_dig_lixiviacion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oControl_dig_lixiviacionRespuesta;
        }


        public void registrarControl_dig_lixiviacion(DTOControl_dig_lixiviacion oDTOControl_dig_lixiviacion)
        {
            try
            {
                Mapper.CreateMap<DTOControl_dig_lixiviacion, MS_CONTROL_DIG_LIXIVIACION>().AfterMap((src, dest) => { dest.control_dig_lix_id = src.control_dig_lix_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.celda_id = src.celda_id; })
                         .AfterMap((src, dest) => { dest.tecnico_lixiviacion_id = src.tecnico_lixiviacion_id; })
                         .AfterMap((src, dest) => { dest.tecnico_apilamiento_id = src.tecnico_apilamiento_id; })
                         .AfterMap((src, dest) => { dest.nro_viajes = src.nro_viajes; })
                         .AfterMap((src, dest) => { dest.celda_opc = src.celda_opc; })
                         .AfterMap((src, dest) => { dest.nro_camiones = src.nro_camiones; })
                         .AfterMap((src, dest) => { dest.ley_mineral = src.ley_mineral; })
                         .AfterMap((src, dest) => { dest.poligono = src.poligono; })
                         .AfterMap((src, dest) => { dest.pluviometro = src.pluviometro; })
                         .AfterMap((src, dest) => { dest.cal_viva = src.cal_viva; })
                         .AfterMap((src, dest) => { dest.cal_hidratada = src.cal_hidratada; })
                         .AfterMap((src, dest) => { dest.corte = src.corte; })
                         .AfterMap((src, dest) => { dest.ripeo = src.ripeo; })
                         .AfterMap((src, dest) => { dest.totalizador_tk_2 = src.totalizador_tk_2; })
                         .AfterMap((src, dest) => { dest.nivel_tk_2 = src.nivel_tk_2; })
                         .AfterMap((src, dest) => { dest.presion_flujo = src.presion_flujo; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.presion_adr = src.presion_adr; })
                         .AfterMap((src, dest) => { dest.presion_sump = src.presion_sump; })
                         .AfterMap((src, dest) => { dest.presion_925 = src.presion_925; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oControl_dig_lixiviacion = AutoMapper.Mapper.Map<DTOControl_dig_lixiviacion, MS_CONTROL_DIG_LIXIVIACION>(oDTOControl_dig_lixiviacion);
                ounitOfWork.control_dig_lixiviacionRepository.Insert(oControl_dig_lixiviacion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarControl_dig_lixiviacion(DTOControl_dig_lixiviacion oDTOControl_dig_lixiviacion)
        {
            try
            {
                Mapper.CreateMap<DTOControl_dig_lixiviacion, MS_CONTROL_DIG_LIXIVIACION>().AfterMap((src, dest) => { dest.control_dig_lix_id = src.control_dig_lix_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.celda_id = src.celda_id; })
                         .AfterMap((src, dest) => { dest.tecnico_lixiviacion_id = src.tecnico_lixiviacion_id; })
                         .AfterMap((src, dest) => { dest.tecnico_apilamiento_id = src.tecnico_apilamiento_id; })
                         .AfterMap((src, dest) => { dest.nro_viajes = src.nro_viajes; })
                         .AfterMap((src, dest) => { dest.celda_opc = src.celda_opc; })
                         .AfterMap((src, dest) => { dest.nro_camiones = src.nro_camiones; })
                         .AfterMap((src, dest) => { dest.ley_mineral = src.ley_mineral; })
                         .AfterMap((src, dest) => { dest.poligono = src.poligono; })
                         .AfterMap((src, dest) => { dest.pluviometro = src.pluviometro; })
                         .AfterMap((src, dest) => { dest.cal_viva = src.cal_viva; })
                         .AfterMap((src, dest) => { dest.cal_hidratada = src.cal_hidratada; })
                         .AfterMap((src, dest) => { dest.corte = src.corte; })
                         .AfterMap((src, dest) => { dest.ripeo = src.ripeo; })
                         .AfterMap((src, dest) => { dest.totalizador_tk_2 = src.totalizador_tk_2; })
                         .AfterMap((src, dest) => { dest.nivel_tk_2 = src.nivel_tk_2; })
                         .AfterMap((src, dest) => { dest.presion_flujo = src.presion_flujo; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.presion_adr = src.presion_adr; })
                         .AfterMap((src, dest) => { dest.presion_sump = src.presion_sump; })
                         .AfterMap((src, dest) => { dest.presion_925 = src.presion_925; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oControl_dig_lixiviacion = AutoMapper.Mapper.Map<DTOControl_dig_lixiviacion, MS_CONTROL_DIG_LIXIVIACION>(oDTOControl_dig_lixiviacion);
                ounitOfWork.control_dig_lixiviacionRepository.Update(oControl_dig_lixiviacion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOControl_dig_lixiviacionRespuesta obtenerControl_dig_lixiviacion_por_id(int id)
        {
            DTOControl_dig_lixiviacionRespuesta oControl_dig_lixiviacionRespuesta = new DTOControl_dig_lixiviacionRespuesta();
            DTOControl_dig_lixiviacion oControl_dig_lixiviacion = new DTOControl_dig_lixiviacion();
            try
            {
                var objControl_dig_lixiviacion = ounitOfWork.control_dig_lixiviacionRepository.GetFirst(u => u.control_dig_lix_id == id);
                oControl_dig_lixiviacion.control_dig_lix_id = objControl_dig_lixiviacion.control_dig_lix_id;
                oControl_dig_lixiviacion.fecha = Convert.ToDateTime(objControl_dig_lixiviacion.fecha);
                oControl_dig_lixiviacion.turno_id = Convert.ToInt32( objControl_dig_lixiviacion.turno_id);
                oControl_dig_lixiviacion.celda_id = Convert.ToInt32(objControl_dig_lixiviacion.celda_id);
                oControl_dig_lixiviacion.tecnico_lixiviacion_id = Convert.ToInt32( objControl_dig_lixiviacion.tecnico_lixiviacion_id);
                oControl_dig_lixiviacion.tecnico_apilamiento_id = Convert.ToInt32(objControl_dig_lixiviacion.tecnico_apilamiento_id);
                oControl_dig_lixiviacion.nro_viajes = Convert.ToInt32(objControl_dig_lixiviacion.nro_viajes);
                oControl_dig_lixiviacion.celda_opc = objControl_dig_lixiviacion.celda_opc;
                oControl_dig_lixiviacion.nro_camiones = Convert.ToInt32( objControl_dig_lixiviacion.nro_camiones);
                oControl_dig_lixiviacion.ley_mineral = Convert.ToDouble( objControl_dig_lixiviacion.ley_mineral);
                oControl_dig_lixiviacion.poligono = Convert.ToDouble(objControl_dig_lixiviacion.poligono);
                oControl_dig_lixiviacion.pluviometro = Convert.ToDouble(objControl_dig_lixiviacion.pluviometro);
                oControl_dig_lixiviacion.cal_viva = Convert.ToDouble(objControl_dig_lixiviacion.cal_viva);
                oControl_dig_lixiviacion.cal_hidratada = Convert.ToDouble(objControl_dig_lixiviacion.cal_hidratada);
                oControl_dig_lixiviacion.corte = Convert.ToDouble(objControl_dig_lixiviacion.corte);
                oControl_dig_lixiviacion.ripeo = Convert.ToDouble(objControl_dig_lixiviacion.ripeo);
                oControl_dig_lixiviacion.totalizador_tk_2 = Convert.ToDouble(objControl_dig_lixiviacion.totalizador_tk_2);
                oControl_dig_lixiviacion.nivel_tk_2 = Convert.ToDouble(objControl_dig_lixiviacion.nivel_tk_2);
                oControl_dig_lixiviacion.presion_flujo = Convert.ToDouble(objControl_dig_lixiviacion.presion_flujo);
                oControl_dig_lixiviacion.comentarios = objControl_dig_lixiviacion.comentarios;
                oControl_dig_lixiviacion.flujo = Convert.ToDouble(objControl_dig_lixiviacion.flujo);
                oControl_dig_lixiviacion.presion_adr = Convert.ToDouble(objControl_dig_lixiviacion.presion_adr);
                oControl_dig_lixiviacion.presion_sump = Convert.ToDouble(objControl_dig_lixiviacion.presion_sump);
                oControl_dig_lixiviacion.presion_925 = Convert.ToDouble(objControl_dig_lixiviacion.presion_925);
                oControl_dig_lixiviacion.activo = Convert.ToBoolean(objControl_dig_lixiviacion.activo);
                oControl_dig_lixiviacion.usuario_crea = objControl_dig_lixiviacion.usuario_crea;
                oControl_dig_lixiviacion.fecha_crea = Convert.ToDateTime(objControl_dig_lixiviacion.fecha_crea);
                oControl_dig_lixiviacion.usuario_mod = objControl_dig_lixiviacion.usuario_mod;
                oControl_dig_lixiviacion.fecha_mod = Convert.ToDateTime(objControl_dig_lixiviacion.fecha_mod);

                oControl_dig_lixiviacionRespuesta.DTOControl_dig_lixiviacion = oControl_dig_lixiviacion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oControl_dig_lixiviacionRespuesta;
        }
    }
}