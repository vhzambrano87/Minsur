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
    public class SegOpcionBL : ISegOpcionBL
    {

        public List<DTOSegOpcion> ObtenerSegOpcion(string usuarioCod)
        {
            DTOSegOpcion obj = new DTOSegOpcion();
            List<DTOSegOpcion> listObj = new List<DTOSegOpcion>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_OBTENER_OPCIONES";
                    cm.Parameters.AddWithValue("@usuario_cod", usuarioCod);
                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTOSegOpcion();
                        obj.opcion_cod = reader.GetString(0);
                        if(reader.GetInt32(1)==1)
                        obj.status = true;
                        listObj.Add(obj);                 
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
                        
            return listObj;
        }

    }
}
