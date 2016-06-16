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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLogic
{

    public class Usuario_rolBL : IUsuario_rolBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOUsuario_rolRespuesta obtenerUsuario_rol()
        {
            DTOUsuario_rolRespuesta oUsuario_rolRespuesta = new DTOUsuario_rolRespuesta();
            List<DTOUsuario_rol> oUsuario_rol = new List<DTOUsuario_rol>();
            try
            {
                var oListaUsuario_rol = ounitOfWork.usuario_rolRepository.GetAll();
                foreach (var item in oListaUsuario_rol)
                {
                    oUsuario_rol.Add(new DTOUsuario_rol()
                    {
                        usuario_id = item.usuario_id,
                        rol_id = item.rol_id,
                    });
                }


                oUsuario_rolRespuesta.DTOListaUsuario_rol = oUsuario_rol;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oUsuario_rolRespuesta;
        }


        public void registrarUsuario_rol(DTOUsuario_rol oDTOUsuario_rol)
        {
            try
            {
                Mapper.CreateMap<DTOUsuario_rol, MS_USUARIO_ROL>().AfterMap((src, dest) => { dest.usuario_id = src.usuario_id; })
                         .AfterMap((src, dest) => { dest.rol_id = src.rol_id; });
                var oUsuario_rol = AutoMapper.Mapper.Map<DTOUsuario_rol, MS_USUARIO_ROL>(oDTOUsuario_rol);
                ounitOfWork.usuario_rolRepository.Insert(oUsuario_rol);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarUsuario_rol(DTOUsuario_rol oDTOUsuario_rol)
        {
            try
            {
                Mapper.CreateMap<DTOUsuario_rol, MS_USUARIO_ROL>().AfterMap((src, dest) => { dest.usuario_id = src.usuario_id; })
                         .AfterMap((src, dest) => { dest.rol_id = src.rol_id; });
                var oUsuario_rol = AutoMapper.Mapper.Map<DTOUsuario_rol, MS_USUARIO_ROL>(oDTOUsuario_rol);
                ounitOfWork.usuario_rolRepository.Update(oUsuario_rol);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public void EliminaUsuarioRol()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = connection;
                cm.CommandText = "MS_ELIMINA_USUARIO_ROL";
                cm.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cm.ExecuteNonQuery();
            }
        }

        public void EliminaRolOpcion()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
            {
                SqlCommand cm = new SqlCommand();
                cm.Connection = connection;
                cm.CommandText = "MS_ELIMINA_ROL_OPCION";
                cm.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cm.ExecuteNonQuery();
            }
        }

    }
}