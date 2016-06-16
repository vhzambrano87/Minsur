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

    public class CamionesBL : ICamionesBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOCamionesRespuesta obtenerCamiones()
        {
            DTOCamionesRespuesta oCamionesRespuesta = new DTOCamionesRespuesta();
            List<DTOCamiones> oCamiones = new List<DTOCamiones>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                var oListaCamiones = ounitOfWork.camionesRepository.GetAll();
                string turno = "";
                string tipo_equipo = "";
                foreach (var item in oListaCamiones)
                {
                    turno = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor;
                    tipo_equipo = oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.tipo_equipo_id)).DTOLista_valor.valor;
                    oCamiones.Add(new DTOCamiones()
                    {
                        camion_id = item.camion_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        turno_id = Convert.ToInt32( item.turno_id),
                        tipo_equipo_id = Convert.ToInt32( item.tipo_equipo_id),
                        turno = turno,
                        tipo_equipo = tipo_equipo,
                        horas_maquina = Convert.ToDouble( item.horas_maquina),
                        detalle = item.detalle,
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oCamionesRespuesta.DTOListaCamiones = oCamiones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oCamionesRespuesta;
        }


        public void registrarCamiones(DTOCamiones oDTOCamiones)
        {
            try
            {
                Mapper.CreateMap<DTOCamiones, MS_CAMIONES>().AfterMap((src, dest) => { dest.camion_id = src.camion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tipo_equipo_id = src.tipo_equipo_id; })
                         .AfterMap((src, dest) => { dest.horas_maquina = src.horas_maquina; })
                         .AfterMap((src, dest) => { dest.detalle = src.detalle; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oCamiones = AutoMapper.Mapper.Map<DTOCamiones, MS_CAMIONES>(oDTOCamiones);
                ounitOfWork.camionesRepository.Insert(oCamiones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarCamiones(DTOCamiones oDTOCamiones)
        {
            try
            {
                Mapper.CreateMap<DTOCamiones, MS_CAMIONES>().AfterMap((src, dest) => { dest.camion_id = src.camion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.tipo_equipo_id = src.tipo_equipo_id; })
                         .AfterMap((src, dest) => { dest.horas_maquina = src.horas_maquina; })
                         .AfterMap((src, dest) => { dest.detalle = src.detalle; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oCamiones = AutoMapper.Mapper.Map<DTOCamiones, MS_CAMIONES>(oDTOCamiones);
                ounitOfWork.camionesRepository.Update(oCamiones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOCamionesRespuesta obtenerCamiones_por_id(int id)
        {
            DTOCamionesRespuesta oCamionesRespuesta = new DTOCamionesRespuesta();
            DTOCamiones oCamiones = new DTOCamiones();
            try
            {
                var objCamiones = ounitOfWork.camionesRepository.GetFirst(u => u.camion_id == id);
                oCamiones.camion_id = objCamiones.camion_id;
                oCamiones.fecha = Convert.ToDateTime( objCamiones.fecha);
                oCamiones.turno_id = Convert.ToInt32( objCamiones.turno_id);
                oCamiones.tipo_equipo_id = Convert.ToInt32( objCamiones.tipo_equipo_id);
                oCamiones.horas_maquina = Convert.ToDouble( objCamiones.horas_maquina);
                oCamiones.detalle = objCamiones.detalle;
                oCamiones.activo = Convert.ToBoolean( objCamiones.activo);
                oCamiones.usuario_crea = objCamiones.usuario_crea;
                oCamiones.fecha_crea = Convert.ToDateTime(objCamiones.fecha_crea);
                oCamiones.usuario_mod = objCamiones.usuario_mod;
                oCamiones.fecha_mod = Convert.ToDateTime(objCamiones.fecha_mod);

                oCamionesRespuesta.DTOCamiones = oCamiones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oCamionesRespuesta;
        }
    }
}