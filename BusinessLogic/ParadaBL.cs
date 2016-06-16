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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BusinessLogic
{

    public class ParadaBL : IParadaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOParadaRespuesta obtenerParada()
        {
            DTOParadaRespuesta oParadaRespuesta = new DTOParadaRespuesta();
            List<DTOParada> oParada = new List<DTOParada>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            EstadoBL oEstadoBL = new EstadoBL();
            try
            {
                var oListaParada = ounitOfWork.paradaRepository.GetAll();
                foreach (var item in oListaParada)
                {
                    oParada.Add(new DTOParada()
                    {
                        parada_id = item.parada_id,
                        area_id = item.area_id,
                        fecha = item.fecha,
                        turno_id = item.turno_id,
                        hora_inicio = item.hora_inicio,
                        hora_fin = item.hora_fin,
                        duracion = Convert.ToDouble(item.duracion),
                        tipo_parada_id = item.tipo_parada_id,
                        sub_tipo_parada_id = item.sub_tipo_parada_id,
                        estado_id = item.estado_id,
                        serie_id = item.serie_id,
                        comentario = item.comentario,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),

                        area_desc = oLista_valorBL.obtenerLista_valor_por_id(item.area_id).DTOLista_valor.valor,
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(item.turno_id).DTOLista_valor.valor,
                        tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(item.tipo_parada_id).DTOLista_valor.valor,
                        sub_tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(item.sub_tipo_parada_id).DTOLista_valor.valor,
                        estado_desc = oEstadoBL.obtenerEstado_por_id(item.estado_id).DTOEstado.codigo,
                        serie_desc = oLista_valorBL.obtenerLista_valor_por_id(item.serie_id).DTOLista_valor.valor,
                    });
                }


                oParadaRespuesta.DTOListaParada = oParada;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oParadaRespuesta;
        }


        public void registrarParada(DTOParada oDTOParada)
        {
            try
            {
                Mapper.CreateMap<DTOParada, MS_PARADA>().AfterMap((src, dest) => { dest.parada_id = src.parada_id; })
                         .AfterMap((src, dest) => { dest.area_id = src.area_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.duracion = src.duracion; })
                         .AfterMap((src, dest) => { dest.tipo_parada_id = src.tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.sub_tipo_parada_id = src.sub_tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.estado_id = src.estado_id; })
                         .AfterMap((src, dest) => { dest.serie_id = src.serie_id; })
                         .AfterMap((src, dest) => { dest.comentario = src.comentario; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oParada = AutoMapper.Mapper.Map<DTOParada, MS_PARADA>(oDTOParada);
                ounitOfWork.paradaRepository.Insert(oParada);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarParada(DTOParada oDTOParada)
        {
            try
            {
                Mapper.CreateMap<DTOParada, MS_PARADA>().AfterMap((src, dest) => { dest.parada_id = src.parada_id; })
                         .AfterMap((src, dest) => { dest.area_id = src.area_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.duracion = src.duracion; })
                         .AfterMap((src, dest) => { dest.tipo_parada_id = src.tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.sub_tipo_parada_id = src.sub_tipo_parada_id; })
                         .AfterMap((src, dest) => { dest.estado_id = src.estado_id; })
                         .AfterMap((src, dest) => { dest.serie_id = src.serie_id; })
                         .AfterMap((src, dest) => { dest.comentario = src.comentario; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oParada = AutoMapper.Mapper.Map<DTOParada, MS_PARADA>(oDTOParada);
                ounitOfWork.paradaRepository.Update(oParada);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOParadaRespuesta obtenerParada_por_id(int id)
        {
            DTOParadaRespuesta oParadaRespuesta = new DTOParadaRespuesta();
            DTOParada oParada = new DTOParada();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            EstadoBL oEstadoBL = new EstadoBL();
            try
            {
                var objParada = ounitOfWork.paradaRepository.GetFirst(u => u.parada_id == id);
                oParada.parada_id = objParada.parada_id;
                oParada.area_id = objParada.area_id;
                oParada.fecha = objParada.fecha;
                oParada.turno_id = objParada.turno_id;
                oParada.hora_inicio = objParada.hora_inicio;
                oParada.hora_fin = objParada.hora_fin;
                oParada.duracion = objParada.duracion;
                oParada.tipo_parada_id = objParada.tipo_parada_id;
                oParada.sub_tipo_parada_id = objParada.sub_tipo_parada_id;
                oParada.estado_id = objParada.estado_id;
                oParada.serie_id = objParada.serie_id;
                oParada.comentario = objParada.comentario;
                oParada.activo = Convert.ToBoolean(objParada.activo);
                oParada.usuario_crea = objParada.usuario_crea;
                oParada.fecha_crea = Convert.ToDateTime(objParada.fecha_crea);
                oParada.usuario_mod = objParada.usuario_mod;
                oParada.fecha_mod = Convert.ToDateTime(objParada.fecha_mod);
                oParada.area_desc = oLista_valorBL.obtenerLista_valor_por_id(objParada.area_id).DTOLista_valor.valor;
                oParada.turno_desc = oLista_valorBL.obtenerLista_valor_por_id(objParada.turno_id).DTOLista_valor.valor;
                oParada.tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(objParada.tipo_parada_id).DTOLista_valor.valor;
                oParada.sub_tipo_parada_desc = oLista_valorBL.obtenerLista_valor_por_id(objParada.sub_tipo_parada_id).DTOLista_valor.valor;
                oParada.estado_desc = oEstadoBL.obtenerEstado_por_id(objParada.estado_id).DTOEstado.codigo;
                oParada.serie_desc = oLista_valorBL.obtenerLista_valor_por_id(objParada.serie_id).DTOLista_valor.valor;
                
                oParadaRespuesta.DTOParada = oParada;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oParadaRespuesta;
        }


        public DTOParadaRespuesta ObtenerReporteParadaChancado(int area_id, int tipo_parada_id, int sub_tipo_parada_id, int estado_id, int serie_id, int turno_id, string fecha_desde, string fecha_hasta)
        {
            DTOParadaRespuesta objRpta = new DTOParadaRespuesta();
            DTOParada obj = new DTOParada();
            List<DTOParada> objList = new List<DTOParada>();
            if (fecha_desde == null)
                fecha_desde = "";
            if (fecha_hasta == null)
                fecha_hasta = "";


            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_REP_PARADA_CHANCADO";
                    cm.Parameters.AddWithValue("@area_id", area_id);
                    cm.Parameters.AddWithValue("@tipo_parada_id", tipo_parada_id);
                    cm.Parameters.AddWithValue("@sub_tipo_parada_id", sub_tipo_parada_id);
                    cm.Parameters.AddWithValue("@estado_id", estado_id);
                    cm.Parameters.AddWithValue("@serie_id", serie_id);
                    cm.Parameters.AddWithValue("@turno_id", turno_id);
                    cm.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                    cm.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTOParada();
                        int cont = 0; if (!reader.IsDBNull(cont))
                            obj.operario_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.mes = reader.GetInt32(cont).ToString();
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.area_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tipo_parada_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.sub_tipo_parada_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.estado_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.serie_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.comentario = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.fecha_desc = reader.GetDateTime(cont).ToShortDateString();
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.turno_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hora_inicio = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hora_fin = reader.GetString(cont);
                        cont++;

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }            

            objRpta.DTOListaParada = objList;
            return objRpta;
        }
    }
}