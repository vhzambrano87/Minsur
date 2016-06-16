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

    public class Prod_chancadoraBL : IProd_chancadoraBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOProd_chancadoraRespuesta obtenerProd_chancadora()
        {
            DTOProd_chancadoraRespuesta oProd_chancadoraRespuesta = new DTOProd_chancadoraRespuesta();
            List<DTOProd_chancadora> oProd_chancadora = new List<DTOProd_chancadora>();
            try
            {
                var oListaProd_chancadora = ounitOfWork.prod_chancadoraRepository.GetAll();
                foreach (var item in oListaProd_chancadora)
                {
                    oProd_chancadora.Add(new DTOProd_chancadora()
                    {
                        prod_chancadora_id = item.prod_chancadora_id,
                        produccion_id = Convert.ToInt32(item.produccion_id),
                        fecha_op = Convert.ToDateTime(item.fecha_op),
                        turno_id = Convert.ToInt32(item.turno_id),
                        viajes_ch = Convert.ToInt32(item.viajes_ch),
                        ton_ch_cam = Convert.ToDouble(item.ton_ch_cam),
                        ton_ch_ox = Convert.ToDouble(item.ton_ch_ox),
                        tmh_ch_ox = Convert.ToDouble(item.tmh_ch_ox),
                        ton_bal_faja = Convert.ToDouble(item.ton_bal_faja),
                        tm_acum_ini_ch = Convert.ToDouble(item.tm_acum_ini_ch),
                        tm_acum_fin_ch = Convert.ToDouble(item.tm_acum_fin_ch),
                        tmh_ch_bal = Convert.ToDouble(item.tmh_ch_bal),
                        h_op_ch = Convert.ToDouble(item.h_op_ch),
                        horas = Convert.ToDouble(item.horas),
                        minutos = Convert.ToDouble(item.minutos),
                        h_mantto_ch = Convert.ToDouble(item.h_mantto_ch),
                        horas_mantto = Convert.ToDouble(item.horas_mantto),
                        minutos_mantto = Convert.ToDouble(item.minutos_mantto),
                        h_operacion = Convert.ToDouble(item.h_operacion),
                        horas_operacion = Convert.ToDouble(item.horas_operacion),
                        minutos_operacion = Convert.ToDouble(item.minutos_operacion),
                        h_calendario = Convert.ToDouble(item.h_calendario),
                        porc_d_ch = Convert.ToDouble(item.porc_d_ch),
                        porc_ud_ch = Convert.ToDouble(item.porc_ud_ch),
                        porc_u_ch = Convert.ToDouble(item.porc_u_ch),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oProd_chancadoraRespuesta.DTOListaProd_chancadora = oProd_chancadora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_chancadoraRespuesta;
        }


        public void registrarProd_chancadora(DTOProd_chancadora oDTOProd_chancadora)
        {
            try
            {
                Mapper.CreateMap<DTOProd_chancadora, MS_PROD_CHANCADORA>()
                         .AfterMap((src, dest) => { dest.prod_chancadora_id = src.prod_chancadora_id; })
                         .AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.fecha_op = src.fecha_op; })
                         .AfterMap((src, dest) => { dest.turno_id = Convert.ToInt32(src.turno_id); })
                         .AfterMap((src, dest) => { dest.viajes_ch = Convert.ToInt32(src.viajes_ch); })
                         .AfterMap((src, dest) => { dest.ton_ch_cam = src.ton_ch_cam; })
                         .AfterMap((src, dest) => { dest.ton_ch_ox = src.ton_ch_ox; })
                         .AfterMap((src, dest) => { dest.tmh_ch_ox = src.tmh_ch_ox; })
                         .AfterMap((src, dest) => { dest.ton_bal_faja = src.ton_bal_faja; })
                         .AfterMap((src, dest) => { dest.tm_acum_ini_ch = src.tm_acum_ini_ch; })
                         .AfterMap((src, dest) => { dest.tm_acum_fin_ch = src.tm_acum_fin_ch; })
                         .AfterMap((src, dest) => { dest.tmh_ch_bal = src.tmh_ch_bal; })
                         .AfterMap((src, dest) => { dest.h_op_ch = src.h_op_ch; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.minutos = src.minutos; })
                         .AfterMap((src, dest) => { dest.h_mantto_ch = src.h_mantto_ch; })
                         .AfterMap((src, dest) => { dest.horas_mantto = src.horas_mantto; })
                         .AfterMap((src, dest) => { dest.minutos_mantto = src.minutos_mantto; })
                         .AfterMap((src, dest) => { dest.h_operacion = src.h_operacion; })
                         .AfterMap((src, dest) => { dest.horas_operacion = src.horas_operacion; })
                         .AfterMap((src, dest) => { dest.minutos_operacion = src.minutos_operacion; })
                         .AfterMap((src, dest) => { dest.h_calendario = src.h_calendario; })
                         .AfterMap((src, dest) => { dest.porc_d_ch = src.porc_d_ch; })
                         .AfterMap((src, dest) => { dest.porc_ud_ch = src.porc_ud_ch; })
                         .AfterMap((src, dest) => { dest.porc_u_ch = src.porc_u_ch; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oProd_chancadora = AutoMapper.Mapper.Map<DTOProd_chancadora, MS_PROD_CHANCADORA>(oDTOProd_chancadora);
                ounitOfWork.prod_chancadoraRepository.Insert(oProd_chancadora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarProd_chancadora(DTOProd_chancadora oDTOProd_chancadora)
        {
            try
            {
                Mapper.CreateMap<DTOProd_chancadora, MS_PROD_CHANCADORA>()
                         .AfterMap((src, dest) => { dest.prod_chancadora_id = src.prod_chancadora_id; })
                         .AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.fecha_op = src.fecha_op; })
                         .AfterMap((src, dest) => { dest.turno_id = Convert.ToInt32(src.turno_id); })
                         .AfterMap((src, dest) => { dest.viajes_ch = Convert.ToInt32(src.viajes_ch); })
                         .AfterMap((src, dest) => { dest.ton_ch_cam = src.ton_ch_cam; })
                         .AfterMap((src, dest) => { dest.ton_ch_ox = src.ton_ch_ox; })
                         .AfterMap((src, dest) => { dest.tmh_ch_ox = src.tmh_ch_ox; })
                         .AfterMap((src, dest) => { dest.ton_bal_faja = src.ton_bal_faja; })
                         .AfterMap((src, dest) => { dest.tm_acum_ini_ch = src.tm_acum_ini_ch; })
                         .AfterMap((src, dest) => { dest.tm_acum_fin_ch = src.tm_acum_fin_ch; })
                         .AfterMap((src, dest) => { dest.tmh_ch_bal = src.tmh_ch_bal; })
                         .AfterMap((src, dest) => { dest.h_op_ch = src.h_op_ch; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.minutos = src.minutos; })
                         .AfterMap((src, dest) => { dest.h_mantto_ch = src.h_mantto_ch; })
                         .AfterMap((src, dest) => { dest.horas_mantto = src.horas_mantto; })
                         .AfterMap((src, dest) => { dest.minutos_mantto = src.minutos_mantto; })
                         .AfterMap((src, dest) => { dest.h_operacion = src.h_operacion; })
                         .AfterMap((src, dest) => { dest.horas_operacion = src.horas_operacion; })
                         .AfterMap((src, dest) => { dest.minutos_operacion = src.minutos_operacion; })
                         .AfterMap((src, dest) => { dest.h_calendario = src.h_calendario; })
                         .AfterMap((src, dest) => { dest.porc_d_ch = src.porc_d_ch; })
                         .AfterMap((src, dest) => { dest.porc_ud_ch = src.porc_ud_ch; })
                         .AfterMap((src, dest) => { dest.porc_u_ch = src.porc_u_ch; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oProd_chancadora = AutoMapper.Mapper.Map<DTOProd_chancadora, MS_PROD_CHANCADORA>(oDTOProd_chancadora);
                ounitOfWork.prod_chancadoraRepository.Update(oProd_chancadora);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOProd_chancadoraRespuesta obtenerProd_chancadora_por_id(int id)
        {
            DTOProd_chancadoraRespuesta oProd_chancadoraRespuesta = new DTOProd_chancadoraRespuesta();
            DTOProd_chancadora oProd_chancadora = new DTOProd_chancadora();
            try
            {
                var objProd_chancadora = ounitOfWork.prod_chancadoraRepository.GetFirst(u => u.prod_chancadora_id == id);
                oProd_chancadora.prod_chancadora_id = objProd_chancadora.prod_chancadora_id;
                oProd_chancadora.produccion_id =Convert.ToInt32(objProd_chancadora.produccion_id);
                oProd_chancadora.fecha_op = Convert.ToDateTime(objProd_chancadora.fecha_op);
                oProd_chancadora.turno_id = Convert.ToInt32(objProd_chancadora.turno_id);
                oProd_chancadora.viajes_ch = Convert.ToInt32(objProd_chancadora.viajes_ch);
                oProd_chancadora.ton_ch_cam = Convert.ToDouble(objProd_chancadora.ton_ch_cam);
                oProd_chancadora.ton_ch_ox = Convert.ToDouble(objProd_chancadora.ton_ch_ox);
                oProd_chancadora.tmh_ch_ox = Convert.ToDouble(objProd_chancadora.tmh_ch_ox);
                oProd_chancadora.ton_bal_faja = Convert.ToDouble(objProd_chancadora.ton_bal_faja);
                oProd_chancadora.tm_acum_ini_ch = Convert.ToDouble(objProd_chancadora.tm_acum_ini_ch);
                oProd_chancadora.tm_acum_fin_ch = Convert.ToDouble(objProd_chancadora.tm_acum_fin_ch);
                oProd_chancadora.tmh_ch_bal = Convert.ToDouble(objProd_chancadora.tmh_ch_bal);
                oProd_chancadora.h_op_ch = Convert.ToDouble(objProd_chancadora.h_op_ch);
                oProd_chancadora.horas = Convert.ToDouble(objProd_chancadora.horas);
                oProd_chancadora.minutos = Convert.ToDouble(objProd_chancadora.minutos);
                oProd_chancadora.h_mantto_ch = Convert.ToDouble(objProd_chancadora.h_mantto_ch);
                oProd_chancadora.horas_mantto = Convert.ToDouble(objProd_chancadora.horas_mantto);
                oProd_chancadora.minutos_mantto = Convert.ToDouble(objProd_chancadora.minutos_mantto);
                oProd_chancadora.h_operacion = Convert.ToDouble(objProd_chancadora.h_operacion);
                oProd_chancadora.horas_operacion = Convert.ToDouble(objProd_chancadora.horas_operacion);
                oProd_chancadora.minutos_operacion = Convert.ToDouble(objProd_chancadora.minutos_operacion);
                oProd_chancadora.h_calendario = Convert.ToDouble(objProd_chancadora.h_calendario);
                oProd_chancadora.porc_d_ch = Convert.ToDouble(objProd_chancadora.porc_d_ch);
                oProd_chancadora.porc_ud_ch = Convert.ToDouble(objProd_chancadora.porc_ud_ch);
                oProd_chancadora.porc_u_ch = Convert.ToDouble(objProd_chancadora.porc_u_ch);
                oProd_chancadora.activo = Convert.ToBoolean(objProd_chancadora.activo);
                oProd_chancadora.usuario_crea = objProd_chancadora.usuario_crea;
                oProd_chancadora.fecha_crea = Convert.ToDateTime(objProd_chancadora.fecha_crea);
                oProd_chancadora.usuario_mod = objProd_chancadora.usuario_mod;
                oProd_chancadora.fecha_mod = Convert.ToDateTime(objProd_chancadora.fecha_mod);

                oProd_chancadoraRespuesta.DTOProd_chancadora = oProd_chancadora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_chancadoraRespuesta;
        }


        public DTOProd_chancadoraRespuesta obtenerProd_chancadora_por_prod_id(int prod_id)
        {
            DTOProd_chancadoraRespuesta oProd_chancadoraRespuesta = new DTOProd_chancadoraRespuesta();
            DTOProd_chancadora oProd_chancadora = new DTOProd_chancadora();
            try
            {
                var objProd_chancadora = ounitOfWork.prod_chancadoraRepository.GetFirst(u => u.produccion_id == prod_id);
                oProd_chancadora.prod_chancadora_id = objProd_chancadora.prod_chancadora_id;
                oProd_chancadora.produccion_id = Convert.ToInt32(objProd_chancadora.produccion_id);
                oProd_chancadora.fecha_op = Convert.ToDateTime(objProd_chancadora.fecha_op);
                oProd_chancadora.turno_id = Convert.ToInt32(objProd_chancadora.turno_id);
                oProd_chancadora.viajes_ch = Convert.ToInt32(objProd_chancadora.viajes_ch);
                oProd_chancadora.ton_ch_cam = Convert.ToDouble(objProd_chancadora.ton_ch_cam);
                oProd_chancadora.ton_ch_ox = Convert.ToDouble(objProd_chancadora.ton_ch_ox);
                oProd_chancadora.tmh_ch_ox = Convert.ToDouble(objProd_chancadora.tmh_ch_ox);
                oProd_chancadora.ton_bal_faja = Convert.ToDouble(objProd_chancadora.ton_bal_faja);
                oProd_chancadora.tm_acum_ini_ch = Convert.ToDouble(objProd_chancadora.tm_acum_ini_ch);
                oProd_chancadora.tm_acum_fin_ch = Convert.ToDouble(objProd_chancadora.tm_acum_fin_ch);
                oProd_chancadora.tmh_ch_bal = Convert.ToDouble(objProd_chancadora.tmh_ch_bal);
                oProd_chancadora.h_op_ch = Convert.ToDouble(objProd_chancadora.h_op_ch);
                oProd_chancadora.horas = Convert.ToDouble(objProd_chancadora.horas);
                oProd_chancadora.minutos = Convert.ToDouble(objProd_chancadora.minutos);
                oProd_chancadora.h_mantto_ch = Convert.ToDouble(objProd_chancadora.h_mantto_ch);
                oProd_chancadora.horas_mantto = Convert.ToDouble(objProd_chancadora.horas_mantto);
                oProd_chancadora.minutos_mantto = Convert.ToDouble(objProd_chancadora.minutos_mantto);
                oProd_chancadora.h_operacion = Convert.ToDouble(objProd_chancadora.h_operacion);
                oProd_chancadora.horas_operacion = Convert.ToDouble(objProd_chancadora.horas_operacion);
                oProd_chancadora.minutos_operacion = Convert.ToDouble(objProd_chancadora.minutos_operacion);
                oProd_chancadora.h_calendario = Convert.ToDouble(objProd_chancadora.h_calendario);
                oProd_chancadora.porc_d_ch = Convert.ToDouble(objProd_chancadora.porc_d_ch);
                oProd_chancadora.porc_ud_ch = Convert.ToDouble(objProd_chancadora.porc_ud_ch);
                oProd_chancadora.porc_u_ch = Convert.ToDouble(objProd_chancadora.porc_u_ch);
                oProd_chancadora.activo = Convert.ToBoolean(objProd_chancadora.activo);
                oProd_chancadora.usuario_crea = objProd_chancadora.usuario_crea;
                oProd_chancadora.fecha_crea = Convert.ToDateTime(objProd_chancadora.fecha_crea);
                oProd_chancadora.usuario_mod = objProd_chancadora.usuario_mod;
                oProd_chancadora.fecha_mod = Convert.ToDateTime(objProd_chancadora.fecha_mod);

                oProd_chancadoraRespuesta.DTOProd_chancadora = oProd_chancadora;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_chancadoraRespuesta;
        }


        public double ObtenerTM_Acum_Fin_CH()
        {
            double valor = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_OBTENER_ACUM_FIN_CH";

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        valor = reader.GetDouble(0);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return valor;
        }


        public void Recalcular_Acum_Ini_Ch(int produccion_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_RECALCULAR_ACUM_INI_CH";
                    cm.Parameters.AddWithValue(@"produccion_id", produccion_id);
                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }

    }
}