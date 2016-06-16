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

    public class Mant_produccion_x_horaBL : IMant_produccion_x_horaBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOMant_produccion_x_horaRespuesta obtenerMant_produccion_x_hora()
        {
            DTOMant_produccion_x_horaRespuesta oMant_produccion_x_horaRespuesta = new DTOMant_produccion_x_horaRespuesta();
            List<DTOMant_produccion_x_hora> oMant_produccion_x_hora = new List<DTOMant_produccion_x_hora>();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            try
            {
                var oListaMant_produccion_x_hora = ounitOfWork.mant_produccion_x_horaRepository.GetAll();
                foreach (var item in oListaMant_produccion_x_hora)
                {
                    oMant_produccion_x_hora.Add(new DTOMant_produccion_x_hora()
                    {
                        produccion_hora_id = item.produccion_hora_id,
                        fecha = item.fecha,
                        guardia_id = Convert.ToInt32(item.guardia_id),
                        turno_id = Convert.ToInt32(item.turno_id),
                        hora = item.hora,
                        camion = item.camion,
                        toneladas = Convert.ToDouble(item.toneladas),
                        viajes = Convert.ToInt32(item.viajes),
                        material_id = Convert.ToInt32(item.material_id),
                        ruta_id = Convert.ToInt32(item.ruta_id),
                        zona_cargio_id = Convert.ToInt32(item.zona_cargio_id),
                        equipo_cargio_id = Convert.ToInt32(item.equipo_cargio_id),
                        ton1 = Convert.ToDouble(item.ton1),
                        ton2 = Convert.ToDouble(item.ton2),
                        ton3 = Convert.ToDouble(item.ton3),
                        ton4 = Convert.ToDouble(item.ton4),
                        ton5 = Convert.ToDouble(item.ton5),
                        ton6 = Convert.ToDouble(item.ton6),
                        ton7 = Convert.ToDouble(item.ton7),
                        ton8 = Convert.ToDouble(item.ton8),
                        ton9 = Convert.ToDouble(item.ton9),
                        ton10 = Convert.ToDouble(item.ton10),
                        ton11 = Convert.ToDouble(item.ton11),
                        ton12 = Convert.ToDouble(item.ton12),
                        ton13 = Convert.ToDouble(item.ton13),
                        ton14 = Convert.ToDouble(item.ton14),
                        ton15 = Convert.ToDouble(item.ton15),
                        ton16 = Convert.ToDouble(item.ton16),
                        ton17 = Convert.ToDouble(item.ton17),
                        ton18 = Convert.ToDouble(item.ton18),
                        ton19 = Convert.ToDouble(item.ton19),
                        ton20 = Convert.ToDouble(item.ton20),
                        ton21 = Convert.ToDouble(item.ton21),
                        ton22 = Convert.ToDouble(item.ton22),
                        ton23 = Convert.ToDouble(item.ton23),
                        ton24 = Convert.ToDouble(item.ton24),
                        ton25 = Convert.ToDouble(item.ton25),
                        ton26 = Convert.ToDouble(item.ton26),
                        ton27 = Convert.ToDouble(item.ton27),
                        ton28 = Convert.ToDouble(item.ton28),
                        ton29 = Convert.ToDouble(item.ton29),
                        ton30 = Convert.ToDouble(item.ton30),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        guardia_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.guardia_id)).DTOLista_valor.valor,
                        turno_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno_id)).DTOLista_valor.valor,
                        material_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.material_id)).DTOLista_valor.valor,
                        ruta_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.ruta_id)).DTOLista_valor.valor,
                        zona_cargio_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.zona_cargio_id)).DTOLista_valor.valor,
                        equipo_cargio_desc = oLista_valorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.equipo_cargio_id)).DTOLista_valor.valor,

                    });
                }


                oMant_produccion_x_horaRespuesta.DTOListaMant_produccion_x_hora = oMant_produccion_x_hora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oMant_produccion_x_horaRespuesta;
        }


        public void registrarMant_produccion_x_hora(DTOMant_produccion_x_hora oDTOMant_produccion_x_hora)
        {
            try
            {
                Mapper.CreateMap<DTOMant_produccion_x_hora, MS_MANT_PRODUCCION_X_HORA>().AfterMap((src, dest) => { dest.produccion_hora_id = src.produccion_hora_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.hora = src.hora; })
                         .AfterMap((src, dest) => { dest.camion = src.camion; })
                         .AfterMap((src, dest) => { dest.toneladas = src.toneladas; })
                         .AfterMap((src, dest) => { dest.viajes = src.viajes; })
                         .AfterMap((src, dest) => { dest.material_id = src.material_id; })
                         .AfterMap((src, dest) => { dest.ruta_id = src.ruta_id; })
                         .AfterMap((src, dest) => { dest.zona_cargio_id = src.zona_cargio_id; })
                         .AfterMap((src, dest) => { dest.equipo_cargio_id = src.equipo_cargio_id; })
                         .AfterMap((src, dest) => { dest.ton1 = src.ton1; })
                         .AfterMap((src, dest) => { dest.ton2 = src.ton2; })
                         .AfterMap((src, dest) => { dest.ton3 = src.ton3; })
                         .AfterMap((src, dest) => { dest.ton4 = src.ton4; })
                         .AfterMap((src, dest) => { dest.ton5 = src.ton5; })
                         .AfterMap((src, dest) => { dest.ton6 = src.ton6; })
                         .AfterMap((src, dest) => { dest.ton7 = src.ton7; })
                         .AfterMap((src, dest) => { dest.ton8 = src.ton8; })
                         .AfterMap((src, dest) => { dest.ton9 = src.ton9; })
                         .AfterMap((src, dest) => { dest.ton10 = src.ton10; })
                         .AfterMap((src, dest) => { dest.ton11 = src.ton11; })
                         .AfterMap((src, dest) => { dest.ton12 = src.ton12; })
                         .AfterMap((src, dest) => { dest.ton13 = src.ton13; })
                         .AfterMap((src, dest) => { dest.ton14 = src.ton14; })
                         .AfterMap((src, dest) => { dest.ton15 = src.ton15; })
                         .AfterMap((src, dest) => { dest.ton16 = src.ton16; })
                         .AfterMap((src, dest) => { dest.ton17 = src.ton17; })
                         .AfterMap((src, dest) => { dest.ton18 = src.ton18; })
                         .AfterMap((src, dest) => { dest.ton19 = src.ton19; })
                         .AfterMap((src, dest) => { dest.ton20 = src.ton20; })
                         .AfterMap((src, dest) => { dest.ton21 = src.ton21; })
                         .AfterMap((src, dest) => { dest.ton22 = src.ton22; })
                         .AfterMap((src, dest) => { dest.ton23 = src.ton23; })
                         .AfterMap((src, dest) => { dest.ton24 = src.ton24; })
                         .AfterMap((src, dest) => { dest.ton25 = src.ton25; })
                         .AfterMap((src, dest) => { dest.ton26 = src.ton26; })
                         .AfterMap((src, dest) => { dest.ton27 = src.ton27; })
                         .AfterMap((src, dest) => { dest.ton28 = src.ton28; })
                         .AfterMap((src, dest) => { dest.ton29 = src.ton29; })
                         .AfterMap((src, dest) => { dest.ton30 = src.ton30; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oMant_produccion_x_hora = AutoMapper.Mapper.Map<DTOMant_produccion_x_hora, MS_MANT_PRODUCCION_X_HORA>(oDTOMant_produccion_x_hora);
                ounitOfWork.mant_produccion_x_horaRepository.Insert(oMant_produccion_x_hora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarMant_produccion_x_hora(DTOMant_produccion_x_hora oDTOMant_produccion_x_hora)
        {
            try
            {
                Mapper.CreateMap<DTOMant_produccion_x_hora, MS_MANT_PRODUCCION_X_HORA>().AfterMap((src, dest) => { dest.produccion_hora_id = src.produccion_hora_id; })
                         .AfterMap((src, dest) => { dest.fecha = Convert.ToDateTime(src.fecha); })
                         .AfterMap((src, dest) => { dest.guardia_id = src.guardia_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.hora = src.hora; })
                         .AfterMap((src, dest) => { dest.camion = src.camion; })
                         .AfterMap((src, dest) => { dest.toneladas = src.toneladas; })
                         .AfterMap((src, dest) => { dest.viajes = src.viajes; })
                         .AfterMap((src, dest) => { dest.material_id = src.material_id; })
                         .AfterMap((src, dest) => { dest.ruta_id = src.ruta_id; })
                         .AfterMap((src, dest) => { dest.zona_cargio_id = src.zona_cargio_id; })
                         .AfterMap((src, dest) => { dest.equipo_cargio_id = src.equipo_cargio_id; })
                         .AfterMap((src, dest) => { dest.ton1 = src.ton1; })
                         .AfterMap((src, dest) => { dest.ton2 = src.ton2; })
                         .AfterMap((src, dest) => { dest.ton3 = src.ton3; })
                         .AfterMap((src, dest) => { dest.ton4 = src.ton4; })
                         .AfterMap((src, dest) => { dest.ton5 = src.ton5; })
                         .AfterMap((src, dest) => { dest.ton6 = src.ton6; })
                         .AfterMap((src, dest) => { dest.ton7 = src.ton7; })
                         .AfterMap((src, dest) => { dest.ton8 = src.ton8; })
                         .AfterMap((src, dest) => { dest.ton9 = src.ton9; })
                         .AfterMap((src, dest) => { dest.ton10 = src.ton10; })
                         .AfterMap((src, dest) => { dest.ton11 = src.ton11; })
                         .AfterMap((src, dest) => { dest.ton12 = src.ton12; })
                         .AfterMap((src, dest) => { dest.ton13 = src.ton13; })
                         .AfterMap((src, dest) => { dest.ton14 = src.ton14; })
                         .AfterMap((src, dest) => { dest.ton15 = src.ton15; })
                         .AfterMap((src, dest) => { dest.ton16 = src.ton16; })
                         .AfterMap((src, dest) => { dest.ton17 = src.ton17; })
                         .AfterMap((src, dest) => { dest.ton18 = src.ton18; })
                         .AfterMap((src, dest) => { dest.ton19 = src.ton19; })
                         .AfterMap((src, dest) => { dest.ton20 = src.ton20; })
                         .AfterMap((src, dest) => { dest.ton21 = src.ton21; })
                         .AfterMap((src, dest) => { dest.ton22 = src.ton22; })
                         .AfterMap((src, dest) => { dest.ton23 = src.ton23; })
                         .AfterMap((src, dest) => { dest.ton24 = src.ton24; })
                         .AfterMap((src, dest) => { dest.ton25 = src.ton25; })
                         .AfterMap((src, dest) => { dest.ton26 = src.ton26; })
                         .AfterMap((src, dest) => { dest.ton27 = src.ton27; })
                         .AfterMap((src, dest) => { dest.ton28 = src.ton28; })
                         .AfterMap((src, dest) => { dest.ton29 = src.ton29; })
                         .AfterMap((src, dest) => { dest.ton30 = src.ton30; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oMant_produccion_x_hora = AutoMapper.Mapper.Map<DTOMant_produccion_x_hora, MS_MANT_PRODUCCION_X_HORA>(oDTOMant_produccion_x_hora);
                ounitOfWork.mant_produccion_x_horaRepository.Update(oMant_produccion_x_hora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOMant_produccion_x_horaRespuesta obtenerMant_produccion_x_hora_por_id(int id)
        {
            DTOMant_produccion_x_horaRespuesta oMant_produccion_x_horaRespuesta = new DTOMant_produccion_x_horaRespuesta();
            DTOMant_produccion_x_hora oMant_produccion_x_hora = new DTOMant_produccion_x_hora();
            try
            {
                var objMant_produccion_x_hora = ounitOfWork.mant_produccion_x_horaRepository.GetFirst(u => u.produccion_hora_id == id);
                oMant_produccion_x_hora.produccion_hora_id = objMant_produccion_x_hora.produccion_hora_id;
                oMant_produccion_x_hora.fecha = objMant_produccion_x_hora.fecha;
                oMant_produccion_x_hora.guardia_id = Convert.ToInt32(objMant_produccion_x_hora.guardia_id);
                oMant_produccion_x_hora.turno_id = Convert.ToInt32(objMant_produccion_x_hora.turno_id);
                oMant_produccion_x_hora.hora = objMant_produccion_x_hora.hora;
                oMant_produccion_x_hora.camion = objMant_produccion_x_hora.camion;
                oMant_produccion_x_hora.toneladas = Convert.ToDouble(objMant_produccion_x_hora.toneladas);
                oMant_produccion_x_hora.viajes = Convert.ToInt32(objMant_produccion_x_hora.viajes);
                oMant_produccion_x_hora.material_id = Convert.ToInt32(objMant_produccion_x_hora.material_id);
                oMant_produccion_x_hora.ruta_id = Convert.ToInt32(objMant_produccion_x_hora.ruta_id);
                oMant_produccion_x_hora.zona_cargio_id = Convert.ToInt32(objMant_produccion_x_hora.zona_cargio_id);
                oMant_produccion_x_hora.equipo_cargio_id = Convert.ToInt32(objMant_produccion_x_hora.equipo_cargio_id);
                oMant_produccion_x_hora.ton1 = Convert.ToDouble(objMant_produccion_x_hora.ton1);
                oMant_produccion_x_hora.ton2 = Convert.ToDouble(objMant_produccion_x_hora.ton2);
                oMant_produccion_x_hora.ton3 = Convert.ToDouble(objMant_produccion_x_hora.ton3);
                oMant_produccion_x_hora.ton4 = Convert.ToDouble(objMant_produccion_x_hora.ton4);
                oMant_produccion_x_hora.ton5 = Convert.ToDouble(objMant_produccion_x_hora.ton5);
                oMant_produccion_x_hora.ton6 = Convert.ToDouble(objMant_produccion_x_hora.ton6);
                oMant_produccion_x_hora.ton7 = Convert.ToDouble(objMant_produccion_x_hora.ton7);
                oMant_produccion_x_hora.ton8 = Convert.ToDouble(objMant_produccion_x_hora.ton8);
                oMant_produccion_x_hora.ton9 = Convert.ToDouble(objMant_produccion_x_hora.ton9);
                oMant_produccion_x_hora.ton10 = Convert.ToDouble(objMant_produccion_x_hora.ton10);
                oMant_produccion_x_hora.ton11 = Convert.ToDouble(objMant_produccion_x_hora.ton11);
                oMant_produccion_x_hora.ton12 = Convert.ToDouble(objMant_produccion_x_hora.ton12);
                oMant_produccion_x_hora.ton13 = Convert.ToDouble(objMant_produccion_x_hora.ton13);
                oMant_produccion_x_hora.ton14 = Convert.ToDouble(objMant_produccion_x_hora.ton14);
                oMant_produccion_x_hora.ton15 = Convert.ToDouble(objMant_produccion_x_hora.ton15);
                oMant_produccion_x_hora.ton16 = Convert.ToDouble(objMant_produccion_x_hora.ton16);
                oMant_produccion_x_hora.ton17 = Convert.ToDouble(objMant_produccion_x_hora.ton17);
                oMant_produccion_x_hora.ton18 = Convert.ToDouble(objMant_produccion_x_hora.ton18);
                oMant_produccion_x_hora.ton19 = Convert.ToDouble(objMant_produccion_x_hora.ton19);
                oMant_produccion_x_hora.ton20 = Convert.ToDouble(objMant_produccion_x_hora.ton20);
                oMant_produccion_x_hora.ton21 = Convert.ToDouble(objMant_produccion_x_hora.ton21);
                oMant_produccion_x_hora.ton22 = Convert.ToDouble(objMant_produccion_x_hora.ton22);
                oMant_produccion_x_hora.ton23 = Convert.ToDouble(objMant_produccion_x_hora.ton23);
                oMant_produccion_x_hora.ton24 = Convert.ToDouble(objMant_produccion_x_hora.ton24);
                oMant_produccion_x_hora.ton25 = Convert.ToDouble(objMant_produccion_x_hora.ton25);
                oMant_produccion_x_hora.ton26 = Convert.ToDouble(objMant_produccion_x_hora.ton26);
                oMant_produccion_x_hora.ton27 = Convert.ToDouble(objMant_produccion_x_hora.ton27);
                oMant_produccion_x_hora.ton28 = Convert.ToDouble(objMant_produccion_x_hora.ton28);
                oMant_produccion_x_hora.ton29 = Convert.ToDouble(objMant_produccion_x_hora.ton29);
                oMant_produccion_x_hora.ton30 = Convert.ToDouble(objMant_produccion_x_hora.ton30);
                oMant_produccion_x_hora.activo = Convert.ToBoolean(objMant_produccion_x_hora.activo);
                oMant_produccion_x_hora.usuario_crea = objMant_produccion_x_hora.usuario_crea;
                oMant_produccion_x_hora.fecha_crea = Convert.ToDateTime(objMant_produccion_x_hora.fecha_crea);
                oMant_produccion_x_hora.usuario_mod = objMant_produccion_x_hora.usuario_mod;
                oMant_produccion_x_hora.fecha_mod = Convert.ToDateTime(objMant_produccion_x_hora.fecha_mod);

                oMant_produccion_x_horaRespuesta.DTOMant_produccion_x_hora = oMant_produccion_x_hora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oMant_produccion_x_horaRespuesta;
        }
    }
}
