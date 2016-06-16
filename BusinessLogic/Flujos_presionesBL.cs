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

    public class Flujos_presionesBL : IFlujos_presionesBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOFlujos_presionesRespuesta obtenerFlujos_presiones()
        {
            DTOFlujos_presionesRespuesta oFlujos_presionesRespuesta = new DTOFlujos_presionesRespuesta();
            List<DTOFlujos_presiones> oFlujos_presiones = new List<DTOFlujos_presiones>();
            Lista_valorBL olista_valorBL = new Lista_valorBL();
            try
            {
                var oListaFlujos_presiones = ounitOfWork.flujos_presionesRepository.GetAll();
                string celda = "";
                string operador = "";
                string ingeniero = "";
                foreach (var item in oListaFlujos_presiones)
                {
                    celda = olista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.celda_id)).DTOLista_valor.valor;
                    operador = olista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.operador_id)).DTOLista_valor.valor;
                    ingeniero = olista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.ingeniero_id)).DTOLista_valor.valor;
                    oFlujos_presiones.Add(new DTOFlujos_presiones()
                    {
                        flujo_presion_id = item.flujo_presion_id,
                        fecha = Convert.ToDateTime(item.fecha),
                        celda_id = Convert.ToInt32( item.celda_id),
                        operador_id = Convert.ToInt32( item.operador_id),
                        ingeniero_id = Convert.ToInt32( item.ingeniero_id),
                        celda = celda,
                        operador = operador,
                        ingeniero = ingeniero,
                        flujo = Convert.ToDouble( item.flujo),
                        presion = Convert.ToDouble(item.presion),
                        flujo_real = Convert.ToDouble(item.flujo_real),
                        presion_real = Convert.ToDouble(item.presion_real),
                        flujo_corregido = Convert.ToDouble(item.flujo_corregido),
                        presion_corregida = Convert.ToDouble(item.presion_corregida),
                        totalizador = Convert.ToDouble(item.totalizador),
                        comentarios = item.comentarios,
                        activo = Convert.ToBoolean( item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oFlujos_presionesRespuesta.DTOListaFlujos_presiones = oFlujos_presiones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oFlujos_presionesRespuesta;
        }


        public void registrarFlujos_presiones(DTOFlujos_presiones oDTOFlujos_presiones)
        {
            try
            {
                Mapper.CreateMap<DTOFlujos_presiones, MS_FLUJOS_PRESIONES>().AfterMap((src, dest) => { dest.flujo_presion_id = src.flujo_presion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.celda_id = src.celda_id; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.ingeniero_id = src.ingeniero_id; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.presion = src.presion; })
                         .AfterMap((src, dest) => { dest.flujo_real = src.flujo_real; })
                         .AfterMap((src, dest) => { dest.presion_real = src.presion_real; })
                         .AfterMap((src, dest) => { dest.flujo_corregido = src.flujo_corregido; })
                         .AfterMap((src, dest) => { dest.presion_corregida = src.presion_corregida; })
                         .AfterMap((src, dest) => { dest.totalizador = src.totalizador; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oFlujos_presiones = AutoMapper.Mapper.Map<DTOFlujos_presiones, MS_FLUJOS_PRESIONES>(oDTOFlujos_presiones);
                ounitOfWork.flujos_presionesRepository.Insert(oFlujos_presiones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarFlujos_presiones(DTOFlujos_presiones oDTOFlujos_presiones)
        {
            try
            {
                Mapper.CreateMap<DTOFlujos_presiones, MS_FLUJOS_PRESIONES>().AfterMap((src, dest) => { dest.flujo_presion_id = src.flujo_presion_id; })
                         .AfterMap((src, dest) => { dest.fecha = src.fecha; })
                         .AfterMap((src, dest) => { dest.celda_id = src.celda_id; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.ingeniero_id = src.ingeniero_id; })
                         .AfterMap((src, dest) => { dest.flujo = src.flujo; })
                         .AfterMap((src, dest) => { dest.presion = src.presion; })
                         .AfterMap((src, dest) => { dest.flujo_real = src.flujo_real; })
                         .AfterMap((src, dest) => { dest.presion_real = src.presion_real; })
                         .AfterMap((src, dest) => { dest.flujo_corregido = src.flujo_corregido; })
                         .AfterMap((src, dest) => { dest.presion_corregida = src.presion_corregida; })
                         .AfterMap((src, dest) => { dest.totalizador = src.totalizador; })
                         .AfterMap((src, dest) => { dest.comentarios = src.comentarios; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oFlujos_presiones = AutoMapper.Mapper.Map<DTOFlujos_presiones, MS_FLUJOS_PRESIONES>(oDTOFlujos_presiones);
                ounitOfWork.flujos_presionesRepository.Update(oFlujos_presiones);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOFlujos_presionesRespuesta obtenerFlujos_presiones_por_id(int id)
        {
            DTOFlujos_presionesRespuesta oFlujos_presionesRespuesta = new DTOFlujos_presionesRespuesta();
            DTOFlujos_presiones oFlujos_presiones = new DTOFlujos_presiones();
            try
            {
                var objFlujos_presiones = ounitOfWork.flujos_presionesRepository.GetFirst(u => u.flujo_presion_id == id);
                oFlujos_presiones.flujo_presion_id = objFlujos_presiones.flujo_presion_id;
                oFlujos_presiones.fecha = Convert.ToDateTime( objFlujos_presiones.fecha);
                oFlujos_presiones.celda_id = Convert.ToInt32( objFlujos_presiones.celda_id);
                oFlujos_presiones.operador_id = Convert.ToInt32( objFlujos_presiones.operador_id);
                oFlujos_presiones.ingeniero_id = Convert.ToInt32(objFlujos_presiones.ingeniero_id);
                oFlujos_presiones.flujo = Convert.ToDouble(objFlujos_presiones.flujo);
                oFlujos_presiones.presion = Convert.ToDouble(objFlujos_presiones.presion);
                oFlujos_presiones.flujo_real = Convert.ToDouble(objFlujos_presiones.flujo_real);
                oFlujos_presiones.presion_real = Convert.ToDouble(objFlujos_presiones.presion_real);
                oFlujos_presiones.flujo_corregido = Convert.ToDouble(objFlujos_presiones.flujo_corregido);
                oFlujos_presiones.presion_corregida = Convert.ToDouble(objFlujos_presiones.presion_corregida);
                oFlujos_presiones.totalizador = Convert.ToDouble(objFlujos_presiones.totalizador);
                oFlujos_presiones.comentarios = objFlujos_presiones.comentarios;
                oFlujos_presiones.activo = Convert.ToBoolean(objFlujos_presiones.activo);
                oFlujos_presiones.usuario_crea = objFlujos_presiones.usuario_crea;
                oFlujos_presiones.fecha_crea = Convert.ToDateTime(objFlujos_presiones.fecha_crea);
                oFlujos_presiones.usuario_mod = objFlujos_presiones.usuario_mod;
                oFlujos_presiones.fecha_mod = Convert.ToDateTime(objFlujos_presiones.fecha_mod);

                oFlujos_presionesRespuesta.DTOFlujos_presiones = oFlujos_presiones;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oFlujos_presionesRespuesta;
        }
    }
}