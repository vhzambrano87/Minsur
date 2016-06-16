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

    public class GuardiaBL : IGuardiaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOGuardiaRespuesta obtenerGuardia()
        {
            DTOGuardiaRespuesta oGuardiaRespuesta = new DTOGuardiaRespuesta();
            List<DTOGuardia> oGuardia = new List<DTOGuardia>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var oListaGuardia = ounitOfWork.guardiaRepository.GetAll();
                foreach (var item in oListaGuardia)
                {
                    oGuardia.Add(new DTOGuardia()
                    {
                        guardia_id = item.guardia_id,
                        fecha = item.fecha,
                        turno_id = item.turno_id,
                        grupo = item.grupo,
                        jefe_guardia_id = item.jefe_guardia_id,
                        operador_planta_id = item.operador_planta_id,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(item.turno_id).DTOLista_valor.valor,
                        jefe_guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(item.jefe_guardia_id).DTOLista_valor.valor,
                        operador_planta_desc = oLista_valorBL.obtenerLista_valor_por_id(item.operador_planta_id).DTOLista_valor.valor,
                    });
                }


                oGuardiaRespuesta.DTOListaGuardia = oGuardia;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oGuardiaRespuesta;
        }


        public void registrarGuardia(DTOGuardia oDTOGuardia)
        {
            try
            {
                Mapper.CreateMap<DTOGuardia, MS_GUARDIA>().AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.grupo = src.grupo; })
                         .AfterMap((src, dest) => { dest.jefe_guardia_id = src.jefe_guardia_id; })
                         .AfterMap((src, dest) => { dest.operador_planta_id = src.operador_planta_id; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oGuardia = AutoMapper.Mapper.Map<DTOGuardia, MS_GUARDIA>(oDTOGuardia);
                ounitOfWork.guardiaRepository.Insert(oGuardia);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarGuardia(DTOGuardia oDTOGuardia)
        {
            try
            {
                Mapper.CreateMap<DTOGuardia, MS_GUARDIA>().AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.grupo = src.grupo; })
                         .AfterMap((src, dest) => { dest.jefe_guardia_id = src.jefe_guardia_id; })
                         .AfterMap((src, dest) => { dest.operador_planta_id = src.operador_planta_id; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oGuardia = AutoMapper.Mapper.Map<DTOGuardia, MS_GUARDIA>(oDTOGuardia);
                ounitOfWork.guardiaRepository.Update(oGuardia);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOGuardiaRespuesta obtenerGuardia_por_id(int id)
        {
            DTOGuardiaRespuesta oGuardiaRespuesta = new DTOGuardiaRespuesta();
            DTOGuardia oGuardia = new DTOGuardia();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var objGuardia = ounitOfWork.guardiaRepository.GetFirst(u => u.guardia_id == id);
                oGuardia.guardia_id = objGuardia.guardia_id;
                oGuardia.fecha = objGuardia.fecha;
                oGuardia.turno_id = objGuardia.turno_id;
                oGuardia.grupo = objGuardia.grupo;
                oGuardia.jefe_guardia_id = objGuardia.jefe_guardia_id;
                oGuardia.operador_planta_id = objGuardia.operador_planta_id;
                oGuardia.activo = Convert.ToBoolean(objGuardia.activo);
                oGuardia.usuario_crea = objGuardia.usuario_crea;
                oGuardia.fecha_crea = Convert.ToDateTime(objGuardia.fecha_crea);
                oGuardia.usuario_mod = objGuardia.usuario_mod;
                oGuardia.fecha_mod = Convert.ToDateTime(objGuardia.fecha_mod);

                oGuardia.turno_desc = oLista_valorBL.obtenerLista_valor_por_id(objGuardia.turno_id).DTOLista_valor.valor;
                oGuardia.jefe_guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(objGuardia.jefe_guardia_id).DTOLista_valor.valor;
                oGuardia.operador_planta_desc = oLista_valorBL.obtenerLista_valor_por_id(objGuardia.operador_planta_id).DTOLista_valor.valor;

                oGuardiaRespuesta.DTOGuardia = oGuardia;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oGuardiaRespuesta;
        }
    }
}