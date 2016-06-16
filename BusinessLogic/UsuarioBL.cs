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

    public class UsuarioBL : IUsuarioBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOUsuarioRespuesta obtenerUsuario()
        {
            DTOUsuarioRespuesta oUsuarioRespuesta = new DTOUsuarioRespuesta();
            List<DTOUsuario> oUsuario = new List<DTOUsuario>();
            try
            {
                var oListaUsuario = ounitOfWork.usuarioRepository.GetAll();
                foreach (var item in oListaUsuario)
                {
                    oUsuario.Add(new DTOUsuario()
                    {
                        usuario_id = item.usuario_id,
                        usuario = item.usuario,
                        password = item.password,
                        nombres = item.nombres,
                        correo = item.correo,
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oUsuarioRespuesta.DTOListaUsuario = oUsuario;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oUsuarioRespuesta;
        }


        public void registrarUsuario(DTOUsuario oDTOUsuario)
        {
            try
            {
                Mapper.CreateMap<DTOUsuario, MS_USUARIO>().AfterMap((src, dest) => { dest.usuario_id = src.usuario_id; })
                         .AfterMap((src, dest) => { dest.usuario = src.usuario; })
                         .AfterMap((src, dest) => { dest.password = src.password; })
                         .AfterMap((src, dest) => { dest.nombres = src.nombres; })
                         .AfterMap((src, dest) => { dest.correo = src.correo; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oUsuario = AutoMapper.Mapper.Map<DTOUsuario, MS_USUARIO>(oDTOUsuario);
                ounitOfWork.usuarioRepository.Insert(oUsuario);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarUsuario(DTOUsuario oDTOUsuario)
        {
            try
            {
                Mapper.CreateMap<DTOUsuario, MS_USUARIO>().AfterMap((src, dest) => { dest.usuario_id = src.usuario_id; })
                         .AfterMap((src, dest) => { dest.usuario = src.usuario; })
                         .AfterMap((src, dest) => { dest.password = src.password; })
                         .AfterMap((src, dest) => { dest.nombres = src.nombres; })
                         .AfterMap((src, dest) => { dest.correo = src.correo; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oUsuario = AutoMapper.Mapper.Map<DTOUsuario, MS_USUARIO>(oDTOUsuario);
                ounitOfWork.usuarioRepository.Update(oUsuario);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOUsuarioRespuesta obtenerUsuario_por_id(int id)
        {
            DTOUsuarioRespuesta oUsuarioRespuesta = new DTOUsuarioRespuesta();
            DTOUsuario oUsuario = new DTOUsuario();
            try
            {
                var objUsuario = ounitOfWork.usuarioRepository.GetFirst(u => u.usuario_id == id);
                oUsuario.usuario_id = objUsuario.usuario_id;
                oUsuario.usuario = objUsuario.usuario;
                oUsuario.password = objUsuario.password;
                oUsuario.nombres = objUsuario.nombres;
                oUsuario.correo = objUsuario.correo;
                oUsuario.activo = Convert.ToBoolean(objUsuario.activo);
                oUsuario.usuario_crea = objUsuario.usuario_crea;
                oUsuario.fecha_crea = Convert.ToDateTime(objUsuario.fecha_crea);
                oUsuario.usuario_mod = objUsuario.usuario_mod;
                oUsuario.fecha_mod = Convert.ToDateTime(objUsuario.fecha_mod);

                oUsuarioRespuesta.DTOUsuario = oUsuario;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oUsuarioRespuesta;
        }


        public DTOUsuarioRespuesta obtenerUsuarioSelected(int rol_id)
        {
            DTOUsuarioRespuesta oUsuarioRespuesta = new DTOUsuarioRespuesta();
            List<DTOUsuario> oUsuario = new List<DTOUsuario>();
            Usuario_rolBL oUsuarioRolBL = new Usuario_rolBL();
            bool flag = false;
            string asociados = "";
            try
            {
                var oListaUsuario = ounitOfWork.usuarioRepository.GetAll();
                var oListaUsuarioRol = oUsuarioRolBL.obtenerUsuario_rol().DTOListaUsuario_rol.Where(u=>u.rol_id==rol_id);

                foreach (var item in oListaUsuario)
                {

                    if (oListaUsuarioRol.Where(u => u.usuario_id == item.usuario_id).Count()==1)
                    {
                        flag = true;
                        asociados = "[" + item.usuario_id + "]";
                    }
                    else
                    {
                        flag = false;
                        asociados = "";
                    }

                    oUsuario.Add(new DTOUsuario()
                    {
                        usuario_id = item.usuario_id,
                        usuario = item.usuario,
                        password = item.password,
                        nombres = item.nombres,
                        correo = item.correo,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        asociar = flag,
                        asociados = asociados
                    });
                }


                oUsuarioRespuesta.DTOListaUsuario = oUsuario;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oUsuarioRespuesta;
        }



    }
}