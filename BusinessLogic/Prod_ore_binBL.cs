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

    public class Prod_ore_binBL : IProd_ore_binBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOProd_ore_binRespuesta obtenerProd_ore_bin()
        {
            DTOProd_ore_binRespuesta oProd_ore_binRespuesta = new DTOProd_ore_binRespuesta();
            List<DTOProd_ore_bin> oProd_ore_bin = new List<DTOProd_ore_bin>();
            try
            {
                var oListaProd_ore_bin = ounitOfWork.prod_ore_binRepository.GetAll();
                foreach (var item in oListaProd_ore_bin)
                {
                    oProd_ore_bin.Add(new DTOProd_ore_bin()
                    {
                        prod_ore_bin_id = item.prod_ore_bin_id,
                        produccion_id = item.produccion_id,
                        fecha_op = Convert.ToDateTime(item.fecha_op),
                        turno_id = Convert.ToInt32(item.turno_id),
                        viajes_ob = Convert.ToInt32(item.viajes_ob),
                        ton_ob_cam = Convert.ToDouble(item.ton_ob_cam),
                        ton_ob_ox = Convert.ToDouble(item.ton_ob_ox),
                        ton_bal_faja = Convert.ToDouble(item.ton_bal_faja),
                        tm_acum_ini_ob = Convert.ToDouble(item.tm_acum_ini_ob),
                        tm_acum_fin_ob = Convert.ToDouble(item.tm_acum_fin_ob),
                        tmh_ob_bal = Convert.ToDouble(item.tmh_ob_bal),
                        h_op_ob = Convert.ToDouble(item.h_op_ob),
                        horas = Convert.ToDouble(item.horas),
                        minutos = Convert.ToDouble(item.minutos),
                        h_mantto_ob = Convert.ToDouble(item.h_mantto_ob),
                        horas_mantto = Convert.ToDouble(item.horas_mantto),
                        minutos_mantto = Convert.ToDouble(item.minutos_mantto),
                        h_operacion = Convert.ToDouble(item.h_operacion),
                        horas_operacion = Convert.ToDouble(item.horas_operacion),
                        minutos_operacion = Convert.ToDouble(item.minutos_operacion),
                        h_calendario = Convert.ToDouble(item.h_calendario),
                        porc_d_ob = Convert.ToDouble(item.porc_d_ob),
                        porc_ud_ob = Convert.ToDouble(item.porc_ud_ob),
                        porc_u_ob = Convert.ToDouble(item.porc_u_ob),
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod)
                    });
                }


                oProd_ore_binRespuesta.DTOListaProd_ore_bin = oProd_ore_bin;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_ore_binRespuesta;
        }


        public void registrarProd_ore_bin(DTOProd_ore_bin oDTOProd_ore_bin)
        {
            try
            {
                Mapper.CreateMap<DTOProd_ore_bin, MS_PROD_ORE_BIN>()
                         .AfterMap((src, dest) => { dest.prod_ore_bin_id = src.prod_ore_bin_id; })
                         .AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.fecha_op =src.fecha_op; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.viajes_ob = Convert.ToInt32(src.viajes_ob); })
                         .AfterMap((src, dest) => { dest.ton_ob_cam = src.ton_ob_cam; })
                         .AfterMap((src, dest) => { dest.ton_ob_ox = src.ton_ob_ox; })
                         .AfterMap((src, dest) => { dest.ton_bal_faja = src.ton_bal_faja; })
                         .AfterMap((src, dest) => { dest.tm_acum_ini_ob = src.tm_acum_ini_ob; })
                         .AfterMap((src, dest) => { dest.tm_acum_fin_ob = src.tm_acum_fin_ob; })
                         .AfterMap((src, dest) => { dest.tmh_ob_bal = src.tmh_ob_bal; })
                         .AfterMap((src, dest) => { dest.h_op_ob = src.h_op_ob; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.minutos = src.minutos; })
                         .AfterMap((src, dest) => { dest.h_mantto_ob = src.h_mantto_ob; })
                         .AfterMap((src, dest) => { dest.horas_mantto = src.horas_mantto; })
                         .AfterMap((src, dest) => { dest.minutos_mantto = src.minutos_mantto; })
                         .AfterMap((src, dest) => { dest.h_operacion = src.h_operacion; })
                         .AfterMap((src, dest) => { dest.horas_operacion = src.horas_operacion; })
                         .AfterMap((src, dest) => { dest.minutos_operacion = src.minutos_operacion; })
                         .AfterMap((src, dest) => { dest.h_calendario = src.h_calendario; })
                         .AfterMap((src, dest) => { dest.porc_d_ob = src.porc_d_ob; })
                         .AfterMap((src, dest) => { dest.porc_ud_ob = src.porc_ud_ob; })
                         .AfterMap((src, dest) => { dest.porc_u_ob = src.porc_u_ob; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oProd_ore_bin = AutoMapper.Mapper.Map<DTOProd_ore_bin, MS_PROD_ORE_BIN>(oDTOProd_ore_bin);
                ounitOfWork.prod_ore_binRepository.Insert(oProd_ore_bin);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarProd_ore_bin(DTOProd_ore_bin oDTOProd_ore_bin)
        {
            try
            {
                Mapper.CreateMap<DTOProd_ore_bin, MS_PROD_ORE_BIN>()
                         .AfterMap((src, dest) => { dest.prod_ore_bin_id = src.prod_ore_bin_id; })
                         .AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.fecha_op = src.fecha_op; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.viajes_ob = Convert.ToInt32(src.viajes_ob); })
                         .AfterMap((src, dest) => { dest.ton_ob_cam = src.ton_ob_cam; })
                         .AfterMap((src, dest) => { dest.ton_ob_ox = src.ton_ob_ox; })
                         .AfterMap((src, dest) => { dest.ton_bal_faja = src.ton_bal_faja; })
                         .AfterMap((src, dest) => { dest.tm_acum_ini_ob = src.tm_acum_ini_ob; })
                         .AfterMap((src, dest) => { dest.tm_acum_fin_ob = src.tm_acum_fin_ob; })
                         .AfterMap((src, dest) => { dest.tmh_ob_bal = src.tmh_ob_bal; })
                         .AfterMap((src, dest) => { dest.h_op_ob = src.h_op_ob; })
                         .AfterMap((src, dest) => { dest.horas = src.horas; })
                         .AfterMap((src, dest) => { dest.minutos = src.minutos; })
                         .AfterMap((src, dest) => { dest.h_mantto_ob = src.h_mantto_ob; })
                         .AfterMap((src, dest) => { dest.horas_mantto = src.horas_mantto; })
                         .AfterMap((src, dest) => { dest.minutos_mantto = src.minutos_mantto; })
                         .AfterMap((src, dest) => { dest.h_operacion = src.h_operacion; })
                         .AfterMap((src, dest) => { dest.horas_operacion = src.horas_operacion; })
                         .AfterMap((src, dest) => { dest.minutos_operacion = src.minutos_operacion; })
                         .AfterMap((src, dest) => { dest.h_calendario = src.h_calendario; })
                         .AfterMap((src, dest) => { dest.porc_d_ob = src.porc_d_ob; })
                         .AfterMap((src, dest) => { dest.porc_ud_ob = src.porc_ud_ob; })
                         .AfterMap((src, dest) => { dest.porc_u_ob = src.porc_u_ob; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oProd_ore_bin = AutoMapper.Mapper.Map<DTOProd_ore_bin, MS_PROD_ORE_BIN>(oDTOProd_ore_bin);
                ounitOfWork.prod_ore_binRepository.Update(oProd_ore_bin);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOProd_ore_binRespuesta obtenerProd_ore_bin_por_id(int id)
        {
            DTOProd_ore_binRespuesta oProd_ore_binRespuesta = new DTOProd_ore_binRespuesta();
            DTOProd_ore_bin oProd_ore_bin = new DTOProd_ore_bin();
            try
            {
                var objProd_ore_bin = ounitOfWork.prod_ore_binRepository.GetFirst(u => u.prod_ore_bin_id == id);
                oProd_ore_bin.prod_ore_bin_id = objProd_ore_bin.prod_ore_bin_id;
                oProd_ore_bin.produccion_id = objProd_ore_bin.produccion_id;
                oProd_ore_bin.fecha_op = Convert.ToDateTime(objProd_ore_bin.fecha_op);
                oProd_ore_bin.turno_id = Convert.ToInt32(objProd_ore_bin.turno_id);
                oProd_ore_bin.viajes_ob = Convert.ToInt32(objProd_ore_bin.viajes_ob);
                oProd_ore_bin.ton_ob_cam = Convert.ToDouble(objProd_ore_bin.ton_ob_cam);
                oProd_ore_bin.ton_ob_ox = Convert.ToDouble(objProd_ore_bin.ton_ob_ox);
                oProd_ore_bin.ton_bal_faja = Convert.ToDouble(objProd_ore_bin.ton_bal_faja);
                oProd_ore_bin.tm_acum_ini_ob = Convert.ToDouble(objProd_ore_bin.tm_acum_ini_ob);
                oProd_ore_bin.tm_acum_fin_ob = Convert.ToDouble(objProd_ore_bin.tm_acum_fin_ob);
                oProd_ore_bin.tmh_ob_bal = Convert.ToDouble(objProd_ore_bin.tmh_ob_bal);
                oProd_ore_bin.h_op_ob = Convert.ToDouble(objProd_ore_bin.h_op_ob);
                oProd_ore_bin.horas = Convert.ToDouble(objProd_ore_bin.horas);
                oProd_ore_bin.minutos = Convert.ToDouble(objProd_ore_bin.minutos);
                oProd_ore_bin.h_mantto_ob = Convert.ToDouble(objProd_ore_bin.h_mantto_ob);
                oProd_ore_bin.horas_mantto = Convert.ToDouble(objProd_ore_bin.horas_mantto);
                oProd_ore_bin.minutos_mantto = Convert.ToDouble(objProd_ore_bin.minutos_mantto);
                oProd_ore_bin.h_operacion = Convert.ToDouble(objProd_ore_bin.h_operacion);
                oProd_ore_bin.horas_operacion = Convert.ToDouble(objProd_ore_bin.horas_operacion);
                oProd_ore_bin.minutos_operacion = Convert.ToDouble(objProd_ore_bin.minutos_operacion);
                oProd_ore_bin.h_calendario = Convert.ToDouble(objProd_ore_bin.h_calendario);
                oProd_ore_bin.porc_d_ob = Convert.ToDouble(objProd_ore_bin.porc_d_ob);
                oProd_ore_bin.porc_ud_ob = Convert.ToDouble(objProd_ore_bin.porc_ud_ob);
                oProd_ore_bin.porc_u_ob = Convert.ToDouble(objProd_ore_bin.porc_u_ob);
                oProd_ore_bin.activo = Convert.ToBoolean(objProd_ore_bin.activo);
                oProd_ore_bin.usuario_crea = objProd_ore_bin.usuario_crea;
                oProd_ore_bin.fecha_crea = Convert.ToDateTime(objProd_ore_bin.fecha_crea);
                oProd_ore_bin.usuario_mod = objProd_ore_bin.usuario_mod;
                oProd_ore_bin.fecha_mod = Convert.ToDateTime(objProd_ore_bin.fecha_mod);

                oProd_ore_binRespuesta.DTOProd_ore_bin = oProd_ore_bin;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_ore_binRespuesta;
        }


        public DTOProd_ore_binRespuesta obtenerProd_ore_bin_por_produccion_id(int prod_id)
        {
            DTOProd_ore_binRespuesta oProd_ore_binRespuesta = new DTOProd_ore_binRespuesta();
            DTOProd_ore_bin oProd_ore_bin = new DTOProd_ore_bin();
            try
            {
                var objProd_ore_bin = ounitOfWork.prod_ore_binRepository.GetFirst(u => u.produccion_id == prod_id);
                oProd_ore_bin.prod_ore_bin_id = objProd_ore_bin.prod_ore_bin_id;
                oProd_ore_bin.produccion_id = objProd_ore_bin.produccion_id;
                oProd_ore_bin.fecha_op = Convert.ToDateTime(objProd_ore_bin.fecha_op);
                oProd_ore_bin.turno_id = Convert.ToInt32(objProd_ore_bin.turno_id);
                oProd_ore_bin.viajes_ob = Convert.ToInt32(objProd_ore_bin.viajes_ob);
                oProd_ore_bin.ton_ob_cam = Convert.ToDouble(objProd_ore_bin.ton_ob_cam);
                oProd_ore_bin.ton_ob_ox = Convert.ToDouble(objProd_ore_bin.ton_ob_ox);
                oProd_ore_bin.ton_bal_faja = Convert.ToDouble(objProd_ore_bin.ton_bal_faja);
                oProd_ore_bin.tm_acum_ini_ob = Convert.ToDouble(objProd_ore_bin.tm_acum_ini_ob);
                oProd_ore_bin.tm_acum_fin_ob = Convert.ToDouble(objProd_ore_bin.tm_acum_fin_ob);
                oProd_ore_bin.tmh_ob_bal = Convert.ToDouble(objProd_ore_bin.tmh_ob_bal);
                oProd_ore_bin.h_op_ob = Convert.ToDouble(objProd_ore_bin.h_op_ob);
                oProd_ore_bin.horas = Convert.ToDouble(objProd_ore_bin.horas);
                oProd_ore_bin.minutos = Convert.ToDouble(objProd_ore_bin.minutos);
                oProd_ore_bin.h_mantto_ob = Convert.ToDouble(objProd_ore_bin.h_mantto_ob);
                oProd_ore_bin.horas_mantto = Convert.ToDouble(objProd_ore_bin.horas_mantto);
                oProd_ore_bin.minutos_mantto = Convert.ToDouble(objProd_ore_bin.minutos_mantto);
                oProd_ore_bin.h_operacion = Convert.ToDouble(objProd_ore_bin.h_operacion);
                oProd_ore_bin.horas_operacion = Convert.ToDouble(objProd_ore_bin.horas_operacion);
                oProd_ore_bin.minutos_operacion = Convert.ToDouble(objProd_ore_bin.minutos_operacion);
                oProd_ore_bin.h_calendario = Convert.ToDouble(objProd_ore_bin.h_calendario);
                oProd_ore_bin.porc_d_ob = Convert.ToDouble(objProd_ore_bin.porc_d_ob);
                oProd_ore_bin.porc_ud_ob = Convert.ToDouble(objProd_ore_bin.porc_ud_ob);
                oProd_ore_bin.porc_u_ob = Convert.ToDouble(objProd_ore_bin.porc_u_ob);
                oProd_ore_bin.activo = Convert.ToBoolean(objProd_ore_bin.activo);
                oProd_ore_bin.usuario_crea = objProd_ore_bin.usuario_crea;
                oProd_ore_bin.fecha_crea = Convert.ToDateTime(objProd_ore_bin.fecha_crea);
                oProd_ore_bin.usuario_mod = objProd_ore_bin.usuario_mod;
                oProd_ore_bin.fecha_mod = Convert.ToDateTime(objProd_ore_bin.fecha_mod);

                oProd_ore_binRespuesta.DTOProd_ore_bin = oProd_ore_bin;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProd_ore_binRespuesta;
        }



        public double ObtenerTM_Acum_Fin_OB()
        {
            double valor = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_OBTENER_ACUM_FIN_OB";

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



        public void Recalcular_Acum_Ini_Ob(int produccion_id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_RECALCULAR_ACUM_INI_OB";
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