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

    public class Mant_equiposBL : IMant_equiposBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOMant_equiposRespuesta obtenerMant_equipos()
        {
            DTOMant_equiposRespuesta oMant_equiposRespuesta = new DTOMant_equiposRespuesta();
            List<DTOMant_equipos> oMant_equipos = new List<DTOMant_equipos>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var oListaMant_equipos = ounitOfWork.mant_equiposRepository.GetAll();
                foreach (var item in oListaMant_equipos)
                {
                    oMant_equipos.Add(new DTOMant_equipos()
                    {
                        equipo_id = item.equipo_id,
                        fecha = Convert.ToDateTime( item.fecha),
                        guardia_id = Convert.ToInt32(item.guardia_id),
                        turno_id = Convert.ToInt32(item.turno_id),
                        camiom_cargador = item.camiom_cargador,
                        tipo_actividad_id = Convert.ToInt32(item.tipo_actividad_id),
                        operador_id = Convert.ToInt32(item.operador_id),
                        hora_inicial = item.hora_inicial,
                        hora_fin = item.hora_fin,
                        tancada = Convert.ToDouble(item.tancada),
                        hora_ini_mant = item.hora_ini_mant,
                        hora_fin_mant = item.hora_fin_mant,
                        comentarios = item.comentarios,
                        equipo_cargio_id = Convert.ToInt32(item.equipo_cargio_id),
                        material_id = Convert.ToInt32(item.material_id),
                        zona_carguio = Convert.ToInt32(item.zona_carguio),
                        punto_descarga = Convert.ToInt32(item.punto_descarga),
                        numero_viajes = Convert.ToInt32(item.numero_viajes),
                        produccion_total = Convert.ToDouble(item.produccion_total),
                        activo = item.activo.Value,
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.guardia_id)).DTOLista_valor.valor,
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor,
                        tipo_actividad_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.tipo_actividad_id)).DTOLista_valor.valor,
                        operador_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.operador_id)).DTOLista_valor.valor,
                        equipo_cargio_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.equipo_cargio_id)).DTOLista_valor.valor,
                        material_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.material_id)).DTOLista_valor.valor,
                        zona_carguio_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.zona_carguio)).DTOLista_valor.valor,
                        punto_descarga_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.punto_descarga)).DTOLista_valor.valor,
                    });
                }


                oMant_equiposRespuesta.DTOListaMant_equipos = oMant_equipos;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oMant_equiposRespuesta;
        }


        public void registrarMant_equipos(DTOMant_equipos oDTOMant_equipos)
        {
            try
            {
                Mapper.CreateMap<DTOMant_equipos, MS_MANT_EQUIPOS>().AfterMap((src, dest) => { dest.equipo_id = src.equipo_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.camiom_cargador = src.camiom_cargador; })
                         .AfterMap((src, dest) => { dest.tipo_actividad_id = src.tipo_actividad_id; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.hora_inicial = src.hora_inicial; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.tancada = src.tancada; })
                         .AfterMap((src, dest) => { dest.hora_ini_mant = src.hora_ini_mant; })
                         .AfterMap((src, dest) => { dest.hora_fin_mant = src.hora_fin_mant; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.equipo_cargio_id = src.equipo_cargio_id; })
                         .AfterMap((src, dest) => { dest.material_id = src.material_id; })
                         .AfterMap((src, dest) => { dest.zona_carguio = src.zona_carguio; })
                         .AfterMap((src, dest) => { dest.punto_descarga = src.punto_descarga; })
                         .AfterMap((src, dest) => { dest.numero_viajes = src.numero_viajes; })
                         .AfterMap((src, dest) => { dest.produccion_total = src.produccion_total; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });
                var oMant_equipos = AutoMapper.Mapper.Map<DTOMant_equipos, MS_MANT_EQUIPOS>(oDTOMant_equipos);
                ounitOfWork.mant_equiposRepository.Insert(oMant_equipos);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarMant_equipos(DTOMant_equipos oDTOMant_equipos)
        {
            try
            {
                Mapper.CreateMap<DTOMant_equipos, MS_MANT_EQUIPOS>().AfterMap((src, dest) => { dest.equipo_id = src.equipo_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.camiom_cargador = src.camiom_cargador; })
                         .AfterMap((src, dest) => { dest.tipo_actividad_id = src.tipo_actividad_id; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.hora_inicial = src.hora_inicial; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.tancada = src.tancada; })
                         .AfterMap((src, dest) => { dest.hora_ini_mant = src.hora_ini_mant; })
                         .AfterMap((src, dest) => { dest.hora_fin_mant = src.hora_fin_mant; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.equipo_cargio_id = src.equipo_cargio_id; })
                         .AfterMap((src, dest) => { dest.material_id = src.material_id; })
                         .AfterMap((src, dest) => { dest.zona_carguio = src.zona_carguio; })
                         .AfterMap((src, dest) => { dest.punto_descarga = src.punto_descarga; })
                         .AfterMap((src, dest) => { dest.numero_viajes = src.numero_viajes; })
                         .AfterMap((src, dest) => { dest.produccion_total = src.produccion_total; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                          .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oMant_equipos = AutoMapper.Mapper.Map<DTOMant_equipos, MS_MANT_EQUIPOS>(oDTOMant_equipos);
                ounitOfWork.mant_equiposRepository.Update(oMant_equipos);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOMant_equiposRespuesta obtenerMant_equipos_por_id(int id)
        {
            DTOMant_equiposRespuesta oMant_equiposRespuesta = new DTOMant_equiposRespuesta();
            DTOMant_equipos oMant_equipos = new DTOMant_equipos();
            try
            {
                var objMant_equipos = ounitOfWork.mant_equiposRepository.GetFirst(u => u.equipo_id == id);
                oMant_equipos.equipo_id = objMant_equipos.equipo_id;
                oMant_equipos.fecha = Convert.ToDateTime(objMant_equipos.fecha);
                oMant_equipos.guardia_id = Convert.ToInt32(objMant_equipos.guardia_id);
                oMant_equipos.turno_id = Convert.ToInt32(objMant_equipos.turno_id);
                oMant_equipos.camiom_cargador = objMant_equipos.camiom_cargador;
                oMant_equipos.tipo_actividad_id = Convert.ToInt32(objMant_equipos.tipo_actividad_id);
                oMant_equipos.operador_id = Convert.ToInt32(objMant_equipos.operador_id);
                oMant_equipos.hora_inicial = objMant_equipos.hora_inicial;
                oMant_equipos.hora_fin = objMant_equipos.hora_fin;
                oMant_equipos.tancada = Convert.ToDouble(objMant_equipos.tancada);
                oMant_equipos.hora_ini_mant = objMant_equipos.hora_ini_mant;
                oMant_equipos.hora_fin_mant = objMant_equipos.hora_fin_mant;
                oMant_equipos.comentarios = objMant_equipos.comentarios;
                oMant_equipos.equipo_cargio_id = Convert.ToInt32(objMant_equipos.equipo_cargio_id);
                oMant_equipos.material_id = Convert.ToInt32(objMant_equipos.material_id);
                oMant_equipos.zona_carguio = Convert.ToInt32(objMant_equipos.zona_carguio);
                oMant_equipos.punto_descarga = Convert.ToInt32(objMant_equipos.punto_descarga);
                oMant_equipos.numero_viajes = Convert.ToInt32(objMant_equipos.numero_viajes);
                oMant_equipos.produccion_total = Convert.ToDouble(objMant_equipos.produccion_total);
                oMant_equipos.activo = objMant_equipos.activo.Value;
                oMant_equipos.usuario_crea = objMant_equipos.usuario_crea;
                oMant_equipos.fecha_crea = Convert.ToDateTime(objMant_equipos.fecha_crea);
                oMant_equipos.usuario_mod = objMant_equipos.usuario_mod;
                oMant_equipos.fecha_mod = Convert.ToDateTime(objMant_equipos.fecha_mod);
                oMant_equiposRespuesta.DTOMant_equipos = oMant_equipos;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oMant_equiposRespuesta;
        }
    }
}