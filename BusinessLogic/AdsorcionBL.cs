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

    public class AdsorcionBL : IAdsorcionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOAdsorcionRespuesta obtenerAdsorcion()
        {
            DTOAdsorcionRespuesta oAdsorcionRespuesta = new DTOAdsorcionRespuesta();
            List<DTOAdsorcion> oAdsorcion = new List<DTOAdsorcion>();
            try
            {
                var oListaAdsorcion = ounitOfWork.adsorcionRepository.GetAll();
                foreach (var item in oListaAdsorcion)
                {
                    oAdsorcion.Add(new DTOAdsorcion()
                    {
                        adsorcion_id = item.adsorcion_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        horas = Convert.ToInt32(item.horas),
                        au_ing_n1 = Convert.ToDouble(item.au_ing_n1),
                        au_ing_n2 = Convert.ToDouble(item.au_ing_n2),
                        au_sal_n1 = Convert.ToDouble(item.au_sal_n1),
                        au_sal_n2 = Convert.ToDouble(item.au_sal_n2),

                        ag_ing_n1 = Convert.ToDouble(item.ag_ing_n1),
                        ag_ing_n2 = Convert.ToDouble(item.ag_ing_n2),
                        ag_sal_n1 = Convert.ToDouble(item.ag_sal_n1),
                        ag_sal_n2 = Convert.ToDouble(item.ag_sal_n2),

                        flujo_ini_1 = Convert.ToDouble(item.flujo_ini_1),
                        flujo_ini_2 = Convert.ToDouble(item.flujo_ini_2),
                        flujo_fin_1 = Convert.ToDouble(item.flujo_fin_1),
                        flujo_fin_2 = Convert.ToDouble(item.flujo_fin_2),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oAdsorcionRespuesta.DTOListaAdsorcion = oAdsorcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oAdsorcionRespuesta;
        }


        public void registrarAdsorcion(DTOAdsorcion oDTOAdsorcion)
        {
            try
            {
                Mapper.CreateMap<DTOAdsorcion, MS_ADSORCION>().AfterMap((src, dest) => { dest.adsorcion_id = src.adsorcion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.au_ing_n1 = src.au_ing_n1; })
                         .AfterMap((src, dest) => { dest.au_ing_n2 = src.au_ing_n2; })
                         .AfterMap((src, dest) => { dest.au_sal_n1 = src.au_sal_n1; })
                         .AfterMap((src, dest) => { dest.au_sal_n2 = src.au_sal_n2; })

                         .AfterMap((src, dest) => { dest.ag_ing_n1 = src.ag_ing_n1; })
                         .AfterMap((src, dest) => { dest.ag_ing_n2 = src.ag_ing_n2; })
                         .AfterMap((src, dest) => { dest.ag_sal_n1 = src.ag_sal_n1; })
                         .AfterMap((src, dest) => { dest.ag_sal_n2 = src.ag_sal_n2; })

                         .AfterMap((src, dest) => { dest.flujo_ini_1 = src.flujo_ini_1; })
                         .AfterMap((src, dest) => { dest.flujo_ini_2 = src.flujo_ini_2; })
                         .AfterMap((src, dest) => { dest.flujo_fin_1 = src.flujo_fin_1; })
                         .AfterMap((src, dest) => { dest.flujo_fin_2 = src.flujo_fin_2; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oAdsorcion = AutoMapper.Mapper.Map<DTOAdsorcion, MS_ADSORCION>(oDTOAdsorcion);
                ounitOfWork.adsorcionRepository.Insert(oAdsorcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarAdsorcion(DTOAdsorcion oDTOAdsorcion)
        {
            try
            {
                Mapper.CreateMap<DTOAdsorcion, MS_ADSORCION>().AfterMap((src, dest) => { dest.adsorcion_id = src.adsorcion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.au_ing_n1 = src.au_ing_n1; })
                         .AfterMap((src, dest) => { dest.au_ing_n2 = src.au_ing_n2; })
                         .AfterMap((src, dest) => { dest.au_sal_n1 = src.au_sal_n1; })
                         .AfterMap((src, dest) => { dest.au_sal_n2 = src.au_sal_n2; })

                         .AfterMap((src, dest) => { dest.ag_ing_n1 = src.ag_ing_n1; })
                         .AfterMap((src, dest) => { dest.ag_ing_n2 = src.ag_ing_n2; })
                         .AfterMap((src, dest) => { dest.ag_sal_n1 = src.ag_sal_n1; })
                         .AfterMap((src, dest) => { dest.ag_sal_n2 = src.ag_sal_n2; })

                         .AfterMap((src, dest) => { dest.flujo_ini_1 = src.flujo_ini_1; })
                         .AfterMap((src, dest) => { dest.flujo_ini_2 = src.flujo_ini_2; })
                         .AfterMap((src, dest) => { dest.flujo_fin_1 = src.flujo_fin_1; })
                         .AfterMap((src, dest) => { dest.flujo_fin_2 = src.flujo_fin_2; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oAdsorcion = AutoMapper.Mapper.Map<DTOAdsorcion, MS_ADSORCION>(oDTOAdsorcion);
                ounitOfWork.adsorcionRepository.Update(oAdsorcion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOAdsorcionRespuesta obtenerAdsorcion_por_id(int id)
        {
            DTOAdsorcionRespuesta oAdsorcionRespuesta = new DTOAdsorcionRespuesta();
            DTOAdsorcion oAdsorcion = new DTOAdsorcion();
            try
            {
                var objAdsorcion = ounitOfWork.adsorcionRepository.GetFirst(u => u.adsorcion_id == id);
                oAdsorcion.adsorcion_id = objAdsorcion.adsorcion_id;
                oAdsorcion.fecha = Convert.ToDateTime(objAdsorcion.fecha);
                oAdsorcion.horas = Convert.ToInt32(objAdsorcion.horas);
                oAdsorcion.au_ing_n1 = Convert.ToDouble(objAdsorcion.au_ing_n1);
                oAdsorcion.au_ing_n2 = Convert.ToDouble(objAdsorcion.au_ing_n2);
                oAdsorcion.au_sal_n1 = Convert.ToDouble(objAdsorcion.au_sal_n1);
                oAdsorcion.au_sal_n2 = Convert.ToDouble(objAdsorcion.au_sal_n2);

                oAdsorcion.ag_ing_n1 = Convert.ToDouble(objAdsorcion.ag_ing_n1);
                oAdsorcion.ag_ing_n2 = Convert.ToDouble(objAdsorcion.ag_ing_n2);
                oAdsorcion.ag_sal_n1 = Convert.ToDouble(objAdsorcion.ag_sal_n1);
                oAdsorcion.ag_sal_n2 = Convert.ToDouble(objAdsorcion.ag_sal_n2);

                oAdsorcion.flujo_ini_1 = Convert.ToDouble(objAdsorcion.flujo_ini_1);
                oAdsorcion.flujo_ini_2 = Convert.ToDouble(objAdsorcion.flujo_ini_2);
                oAdsorcion.flujo_fin_1 = Convert.ToDouble(objAdsorcion.flujo_fin_1);
                oAdsorcion.flujo_fin_2 = Convert.ToDouble(objAdsorcion.flujo_fin_2);
                oAdsorcion.activo = Convert.ToBoolean(objAdsorcion.activo);
                oAdsorcion.usuario_crea = objAdsorcion.usuario_crea;
                oAdsorcion.fecha_crea = Convert.ToDateTime(objAdsorcion.fecha_crea);
                oAdsorcion.usuario_mod = objAdsorcion.usuario_mod;
                oAdsorcion.fecha_mod = Convert.ToDateTime(objAdsorcion.fecha_mod);

                oAdsorcionRespuesta.DTOAdsorcion = oAdsorcion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oAdsorcionRespuesta;
        }


        public DTOAdsorcionRespuesta ObtenerReporteAdsorcion(int tipo_id,string fecha_desde, string fecha_hasta)
        {
            DTOAdsorcionRespuesta objRpta = new DTOAdsorcionRespuesta();
            DTOAdsorcion obj = new DTOAdsorcion();
            List<DTOAdsorcion> objList = new List<DTOAdsorcion>();
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
                    cm.CommandText = "MS_REP_ADSORCION";
                    cm.Parameters.AddWithValue("@tipo_id", tipo_id);
                    cm.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                    cm.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTOAdsorcion();
                        int cont = 0; if (!reader.IsDBNull(cont))
                            obj.fecha_desc = reader.GetDateTime(cont).ToShortDateString();
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.mes = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.flujo_ini_1 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.flujo_ini_2 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.flujo_fin_1 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.flujo_fin_2 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_ing_n1 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_sal_n1 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_ing_n2 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.au_sal_n2 = reader.GetDouble(cont);
                        cont++;
                        

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            objRpta.DTOListaAdsorcion = objList;
            return objRpta;
        }


    }
}