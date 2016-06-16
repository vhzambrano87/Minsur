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

    public class Consumo_combustibleBL : IConsumo_combustibleBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOConsumo_combustibleRespuesta obtenerConsumo_combustible()
        {
            DTOConsumo_combustibleRespuesta oConsumo_combustibleRespuesta = new DTOConsumo_combustibleRespuesta();
            List<DTOConsumo_combustible> oConsumo_combustible = new List<DTOConsumo_combustible>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var oListaConsumo_combustible = ounitOfWork.consumo_combustibleRepository.GetAll();
                foreach (var item in oListaConsumo_combustible)
                {
                    oConsumo_combustible.Add(new DTOConsumo_combustible()
                    {
                        consumo_combustible_id = item.consumo_combustible_id,
                        fecha = item.fecha,
                        guardia_id = Convert.ToInt32(item.guardia_id),
                        turno_id = Convert.ToInt32(item.turno_id),
                        equipo_id = Convert.ToInt32(item.equipo_id),
                        galones = Convert.ToDouble(item.galones),
                        operador_id = Convert.ToInt32(item.operador_id),
                        activo = item.activo.Value,
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.guardia_id)).DTOLista_valor.valor,
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor,
                        equipo_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.equipo_id)).DTOLista_valor.valor,
                        operador_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.operador_id)).DTOLista_valor.valor,
                    });
                }


                oConsumo_combustibleRespuesta.DTOListaConsumo_combustible = oConsumo_combustible;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oConsumo_combustibleRespuesta;
        }


        public void registrarConsumo_combustible(DTOConsumo_combustible oDTOConsumo_combustible)
        {
            try
            {
                Mapper.CreateMap<DTOConsumo_combustible, MS_CONSUMO_COMBUSTIBLE>().AfterMap((src, dest) => { dest.consumo_combustible_id = src.consumo_combustible_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.equipo_id = src.equipo_id; })
                         .AfterMap((src, dest) => { dest.galones = src.galones; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oConsumo_combustible = AutoMapper.Mapper.Map<DTOConsumo_combustible, MS_CONSUMO_COMBUSTIBLE>(oDTOConsumo_combustible);
                ounitOfWork.consumo_combustibleRepository.Insert(oConsumo_combustible);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarConsumo_combustible(DTOConsumo_combustible oDTOConsumo_combustible)
        {
            try
            {
                Mapper.CreateMap<DTOConsumo_combustible, MS_CONSUMO_COMBUSTIBLE>().AfterMap((src, dest) => { dest.consumo_combustible_id = src.consumo_combustible_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.equipo_id = src.equipo_id; })
                         .AfterMap((src, dest) => { dest.galones = src.galones; })
                         .AfterMap((src, dest) => { dest.operador_id = src.operador_id; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oConsumo_combustible = AutoMapper.Mapper.Map<DTOConsumo_combustible, MS_CONSUMO_COMBUSTIBLE>(oDTOConsumo_combustible);
                ounitOfWork.consumo_combustibleRepository.Update(oConsumo_combustible);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOConsumo_combustibleRespuesta obtenerConsumo_combustible_por_id(int id)
        {
            DTOConsumo_combustibleRespuesta oConsumo_combustibleRespuesta = new DTOConsumo_combustibleRespuesta();
            DTOConsumo_combustible oConsumo_combustible = new DTOConsumo_combustible();
            try
            {
                var objConsumo_combustible = ounitOfWork.consumo_combustibleRepository.GetFirst(u => u.consumo_combustible_id == id);
                oConsumo_combustible.consumo_combustible_id = objConsumo_combustible.consumo_combustible_id;
                oConsumo_combustible.fecha = objConsumo_combustible.fecha;
                oConsumo_combustible.guardia_id = Convert.ToInt32(objConsumo_combustible.guardia_id);
                oConsumo_combustible.turno_id = Convert.ToInt32(objConsumo_combustible.turno_id);
                oConsumo_combustible.equipo_id = Convert.ToInt32(objConsumo_combustible.equipo_id);
                oConsumo_combustible.galones = Convert.ToDouble(objConsumo_combustible.galones);
                oConsumo_combustible.operador_id = Convert.ToInt32(objConsumo_combustible.operador_id);
                oConsumo_combustible.activo = objConsumo_combustible.activo.Value;
                oConsumo_combustible.usuario_crea = objConsumo_combustible.usuario_crea;
                oConsumo_combustible.fecha_crea = Convert.ToDateTime(objConsumo_combustible.fecha_crea);
                oConsumo_combustible.usuario_mod = objConsumo_combustible.usuario_mod;
                oConsumo_combustible.fecha_mod = Convert.ToDateTime(objConsumo_combustible.fecha_mod);



                oConsumo_combustibleRespuesta.DTOConsumo_combustible = oConsumo_combustible;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oConsumo_combustibleRespuesta;
        }
    }
}