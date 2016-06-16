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
    public class UtilizacionBL:IUtilizacionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();
        public DTOUtilizacionRespuesta obtenerUtilizacionRep(int area_id, int turno_id, string fecha_desde, string fecha_hasta)
        {
            DTOUtilizacionRespuesta oUtilizacionRpta = new DTOUtilizacionRespuesta();
            
            DTOUtilizacion obj = new DTOUtilizacion();
            List<DTOUtilizacion> objList = new List<DTOUtilizacion>();
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
                    cm.CommandText = "MS_REP_UTILIZACION";
                    cm.Parameters.AddWithValue("@area_id", area_id);
                    cm.Parameters.AddWithValue("@turno_id", turno_id);
                    cm.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                    cm.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTOUtilizacion();
                        int cont = 0; if (!reader.IsDBNull(cont))
                            obj.fecha_op = reader.GetDateTime(cont).ToShortDateString();
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.mes = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.semana = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.dia = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hop = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.dmtto = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tmpd = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.disp = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tmph = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.util = reader.GetDouble(cont);

                        try
                        {
                            obj.oee = (obj.disp * obj.util * obj.tmph)/ 1450;
                        }
                        catch (Exception ex)
                        {
                            Logger.Write(ex);
                        }

                        cont++;

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            oUtilizacionRpta.DTOListaUtilizacion = objList;
            return oUtilizacionRpta;

        }
    }
}
