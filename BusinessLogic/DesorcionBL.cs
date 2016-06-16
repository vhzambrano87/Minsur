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

    public class DesorcionBL : IDesorcionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTODesorcionRespuesta obtenerDesorcion()
        {
            DTODesorcionRespuesta oDesorcionRespuesta = new DTODesorcionRespuesta();
            List<DTODesorcion> oDesorcion = new List<DTODesorcion>();
            try
            {
                var oListaDesorcion = ounitOfWork.desorcionRepository.GetAll();
                foreach (var item in oListaDesorcion)
                {
                    oDesorcion.Add(new DTODesorcion()
                    {
                        desorcion_id = item.desorcion_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        num_fundicion = item.num_fundicion,
                        mes = item.mes,
                        num_desorcion = Convert.ToInt32(item.num_desorcion),
                        num_desorcion_mes = Convert.ToInt32(item.num_desorcion_mes),
                        num_col_desc = Convert.ToInt32(item.num_col_desc),
                        peso_col_desc = Convert.ToDouble(item.peso_col_desc),
                        hora_inicio = item.hora_inicio,
                        hora_fin = item.hora_fin,
                        au_rico = Convert.ToDouble(item.au_rico),
                        au_pobre = Convert.ToDouble(item.au_pobre),
                        ag_rico = Convert.ToDouble(item.ag_rico),
                        ag_pobre = Convert.ToDouble(item.ag_pobre),
                        hg_rico = Convert.ToDouble(item.hg_rico),
                        hg_pobre = Convert.ToDouble(item.hg_pobre),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oDesorcionRespuesta.DTOListaDesorcion = oDesorcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oDesorcionRespuesta;
        }


        public void registrarDesorcion(DTODesorcion oDTODesorcion)
        {
            try
            {
                Mapper.CreateMap<DTODesorcion, MS_DESORCION>().AfterMap((src, dest) => { dest.desorcion_id = src.desorcion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.num_fundicion = src.num_fundicion; })
                         .AfterMap((src, dest) => { dest.mes = src.mes; })
                         .AfterMap((src, dest) => { dest.num_desorcion = src.num_desorcion; })
                         .AfterMap((src, dest) => { dest.num_desorcion_mes = src.num_desorcion_mes; })
                         .AfterMap((src, dest) => { dest.num_col_desc = src.num_col_desc; })
                         .AfterMap((src, dest) => { dest.peso_col_desc = src.peso_col_desc; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.au_rico = src.au_rico; })
                         .AfterMap((src, dest) => { dest.au_pobre = src.au_pobre; })
                         .AfterMap((src, dest) => { dest.ag_rico = src.ag_rico; })
                         .AfterMap((src, dest) => { dest.ag_pobre = src.ag_pobre; })
                         .AfterMap((src, dest) => { dest.hg_rico = src.hg_rico; })
                         .AfterMap((src, dest) => { dest.hg_pobre = src.hg_pobre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oDesorcion = AutoMapper.Mapper.Map<DTODesorcion, MS_DESORCION>(oDTODesorcion);
                ounitOfWork.desorcionRepository.Insert(oDesorcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarDesorcion(DTODesorcion oDTODesorcion)
        {
            try
            {
                Mapper.CreateMap<DTODesorcion, MS_DESORCION>().AfterMap((src, dest) => { dest.desorcion_id = src.desorcion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.num_fundicion = src.num_fundicion; })
                         .AfterMap((src, dest) => { dest.mes = src.mes; })
                         .AfterMap((src, dest) => { dest.num_desorcion = src.num_desorcion; })
                         .AfterMap((src, dest) => { dest.num_desorcion_mes = src.num_desorcion_mes; })
                         .AfterMap((src, dest) => { dest.num_col_desc = src.num_col_desc; })
                         .AfterMap((src, dest) => { dest.peso_col_desc = src.peso_col_desc; })
                         .AfterMap((src, dest) => { dest.hora_inicio = src.hora_inicio; })
                         .AfterMap((src, dest) => { dest.hora_fin = src.hora_fin; })
                         .AfterMap((src, dest) => { dest.au_rico = src.au_rico; })
                         .AfterMap((src, dest) => { dest.au_pobre = src.au_pobre; })
                         .AfterMap((src, dest) => { dest.ag_rico = src.ag_rico; })
                         .AfterMap((src, dest) => { dest.ag_pobre = src.ag_pobre; })
                         .AfterMap((src, dest) => { dest.hg_rico = src.hg_rico; })
                         .AfterMap((src, dest) => { dest.hg_pobre = src.hg_pobre; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oDesorcion = AutoMapper.Mapper.Map<DTODesorcion, MS_DESORCION>(oDTODesorcion);
                ounitOfWork.desorcionRepository.Update(oDesorcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTODesorcionRespuesta obtenerDesorcion_por_id(int id)
        {
            DTODesorcionRespuesta oDesorcionRespuesta = new DTODesorcionRespuesta();
            DTODesorcion oDesorcion = new DTODesorcion();
            try
            {
                var objDesorcion = ounitOfWork.desorcionRepository.GetFirst(u => u.desorcion_id == id);
                oDesorcion.desorcion_id = objDesorcion.desorcion_id;
                oDesorcion.fecha = Convert.ToDateTime(objDesorcion.fecha);
                oDesorcion.num_fundicion = objDesorcion.num_fundicion;
                oDesorcion.mes = objDesorcion.mes;
                oDesorcion.num_desorcion = Convert.ToInt32(objDesorcion.num_desorcion);
                oDesorcion.num_desorcion_mes = Convert.ToInt32(objDesorcion.num_desorcion_mes);
                oDesorcion.num_col_desc = Convert.ToInt32(objDesorcion.num_col_desc);
                oDesorcion.peso_col_desc = Convert.ToDouble(objDesorcion.peso_col_desc);
                oDesorcion.hora_inicio = objDesorcion.hora_inicio;
                oDesorcion.hora_fin = objDesorcion.hora_fin;
                oDesorcion.au_rico = Convert.ToDouble(objDesorcion.au_rico);
                oDesorcion.au_pobre = Convert.ToDouble(objDesorcion.au_pobre);
                oDesorcion.ag_rico = Convert.ToDouble(objDesorcion.ag_rico);
                oDesorcion.ag_pobre = Convert.ToDouble(objDesorcion.ag_pobre);
                oDesorcion.hg_rico = Convert.ToDouble(objDesorcion.hg_rico);
                oDesorcion.hg_pobre = Convert.ToDouble(objDesorcion.hg_pobre);
                oDesorcion.activo = Convert.ToBoolean(objDesorcion.activo);
                oDesorcion.usuario_crea = objDesorcion.usuario_crea;
                oDesorcion.fecha_crea = Convert.ToDateTime(objDesorcion.fecha_crea);
                oDesorcion.usuario_mod = objDesorcion.usuario_mod;
                oDesorcion.fecha_mod = Convert.ToDateTime(objDesorcion.fecha_mod);

                oDesorcionRespuesta.DTODesorcion = oDesorcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oDesorcionRespuesta;
        }


        public DTODesorcionRespuesta ObtenerReporteDesorcion(string fecha_desde, string fecha_hasta)
        {
            DTODesorcionRespuesta objRpta = new DTODesorcionRespuesta();
            DTODesorcion obj = new DTODesorcion();
            List<DTODesorcion> objList = new List<DTODesorcion>();
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
                    cm.CommandText = "MS_REP_DESORCION";
                    cm.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                    cm.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTODesorcion();
                        int cont = 0; if (!reader.IsDBNull(cont))
                            obj.fecha_desc = reader.GetDateTime(cont).ToShortDateString();
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.num_desorcion_mes = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.num_fundicion = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.num_desorcion = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.num_col_desc = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hora_inicio = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hora_fin = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tiempo_desorcion = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_rico = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_pobre = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ag_rico = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ag_pobre = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hg_rico = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hg_pobre = reader.GetDouble(cont);
                        cont++;

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            objRpta.DTOListaDesorcion = objList;
            return objRpta;
        }


    }
}