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

    public class ProduccionBL : IProduccionBL
    {
        private UnitOfWork ounitOfWork = new UnitOfWork();

        public DTOProduccionRespuesta obtenerProduccion()
        {
            DTOProduccionRespuesta oProduccionRespuesta = new DTOProduccionRespuesta();
            List<DTOProduccion> oProduccion = new List<DTOProduccion>();
            Prod_chancadoraBL oProdChancadoraBL = new Prod_chancadoraBL();
            Prod_ore_binBL oProdOreBinBL = new Prod_ore_binBL();
            bool flagChancadora = false;
            bool flagOreBin = false;
            try
            {
                var oListaProduccion = ounitOfWork.produccionRepository.GetAll().OrderBy(u=>u.fecha_op).OrderBy(u=>u.turno_id);
                foreach (var item in oListaProduccion)
                {
                    flagChancadora = false;
                    flagOreBin = false;

                    if (oProdChancadoraBL.obtenerProd_chancadora_por_prod_id(item.produccion_id).DTOProd_chancadora == null)
                    {
                        flagChancadora = true;
                    }
                    if (oProdOreBinBL.obtenerProd_ore_bin_por_produccion_id(item.produccion_id).DTOProd_ore_bin == null)
                    {
                        flagOreBin = true;
                    }

                    oProduccion.Add(new DTOProduccion()
                    {
                        produccion_id = item.produccion_id,
                        fecha_op = Convert.ToDateTime(item.fecha_op),
                        turno_id = Convert.ToInt32(item.turno_id),
                        tm_acum_faja1 = Convert.ToDouble(item.tm_acum_faja1),
                        tm_acum_ob = Convert.ToDouble(item.tm_acum_ob),
                        mps_porc = Convert.ToDouble(item.mps_porc),
                        presion_ntg = Convert.ToDouble(item.presion_ntg),
                        rpm_main_shaft = Convert.ToDouble(item.rpm_main_shaft),
                        amp_chancadora = Convert.ToDouble(item.amp_chancadora),
                        f_aceite_sup = Convert.ToDouble(item.f_aceite_sup),
                        f_aceite_inf = Convert.ToDouble(item.f_aceite_inf),
                        rpm_apron_feeder = Convert.ToDouble(item.rpm_apron_feeder),
                        a_apron_feeder = Convert.ToDouble(item.a_apron_feeder),
                        a_faja_uno = Convert.ToDouble(item.a_faja_uno),
                        a_faja_dos = Convert.ToDouble(item.a_faja_dos),
                        a_faja_tres = Convert.ToDouble(item.a_faja_tres),
                        tpm = item.tpm,
                        poligonos = item.poligonos,
                        celda = item.celda,
                        frec_av_a = Convert.ToDouble(item.frec_av_a),
                        frec_av_b = Convert.ToDouble(item.frec_av_b),
                        frec_av_c = Convert.ToDouble(item.frec_av_c),
                        pr_hidra_uno = Convert.ToDouble(item.pr_hidra_uno),
                        pr_hidra_dos = Convert.ToDouble(item.pr_hidra_dos),
                        tk_verde = Convert.ToDouble(item.tk_verde),
                        tk_rojo = Convert.ToDouble(item.tk_rojo),
                        stock_pile = Convert.ToDouble(item.stock_pile),
                        ratio_cal = Convert.ToDouble(item.ratio_cal),
                        silo_a = Convert.ToDouble(item.silo_a),
                        silo_b = Convert.ToDouble(item.silo_b),
                        observacion = item.observacion,
                        activo = Convert.ToBoolean(item.activo),
                        usuario_crea = item.usuario_crea,
                        fecha_crea = Convert.ToDateTime(item.fecha_crea),
                        usuario_mod = item.usuario_mod,
                        fecha_mod = Convert.ToDateTime(item.fecha_mod),
                        flag_chancadora = flagChancadora,
                        flag_orebin = flagOreBin
                    });
                }


                oProduccionRespuesta.DTOListaProduccion = oProduccion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProduccionRespuesta;
        }


        public void registrarProduccion(DTOProduccion oDTOProduccion)
        {
            try
            {
                Mapper.CreateMap<DTOProduccion, MS_PRODUCCION>().AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.fecha_op = src.fecha_op; })
                         .AfterMap((src, dest) => { dest.tm_acum_faja1 = src.tm_acum_faja1; })
                         .AfterMap((src, dest) => { dest.tm_acum_ob = src.tm_acum_ob; })
                         .AfterMap((src, dest) => { dest.mps_porc = src.mps_porc; })
                         .AfterMap((src, dest) => { dest.presion_ntg = src.presion_ntg; })
                         .AfterMap((src, dest) => { dest.rpm_main_shaft = src.rpm_main_shaft; })
                         .AfterMap((src, dest) => { dest.amp_chancadora = src.amp_chancadora; })
                         .AfterMap((src, dest) => { dest.f_aceite_sup = src.f_aceite_sup; })
                         .AfterMap((src, dest) => { dest.f_aceite_inf = src.f_aceite_inf; })
                         .AfterMap((src, dest) => { dest.rpm_apron_feeder = src.rpm_apron_feeder; })
                         .AfterMap((src, dest) => { dest.a_apron_feeder = src.a_apron_feeder; })
                         .AfterMap((src, dest) => { dest.a_faja_uno = src.a_faja_uno; })
                         .AfterMap((src, dest) => { dest.a_faja_dos = src.a_faja_dos; })
                         .AfterMap((src, dest) => { dest.a_faja_tres = src.a_faja_tres; })
                         .AfterMap((src, dest) => { dest.tpm = src.tpm; })
                         .AfterMap((src, dest) => { dest.poligonos = src.poligonos; })
                         .AfterMap((src, dest) => { dest.celda = src.celda; })
                         .AfterMap((src, dest) => { dest.frec_av_a = src.frec_av_a; })
                         .AfterMap((src, dest) => { dest.frec_av_b = src.frec_av_b; })
                         .AfterMap((src, dest) => { dest.frec_av_c = src.frec_av_c; })
                         .AfterMap((src, dest) => { dest.pr_hidra_uno = src.pr_hidra_uno; })
                         .AfterMap((src, dest) => { dest.pr_hidra_dos = src.pr_hidra_dos; })
                         .AfterMap((src, dest) => { dest.tk_verde = src.tk_verde; })
                         .AfterMap((src, dest) => { dest.tk_rojo = src.tk_rojo; })
                         .AfterMap((src, dest) => { dest.stock_pile = src.stock_pile; })
                         .AfterMap((src, dest) => { dest.ratio_cal = src.ratio_cal; })
                         .AfterMap((src, dest) => { dest.silo_a = src.silo_a; })
                         .AfterMap((src, dest) => { dest.silo_b = src.silo_b; })
                         .AfterMap((src, dest) => { dest.observacion = src.observacion; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = DateTime.Now; });


                var oProduccion = AutoMapper.Mapper.Map<DTOProduccion, MS_PRODUCCION>(oDTOProduccion);
                ounitOfWork.produccionRepository.Insert(oProduccion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void actualizarProduccion(DTOProduccion oDTOProduccion)
        {
            try
            {
                Mapper.CreateMap<DTOProduccion, MS_PRODUCCION>().AfterMap((src, dest) => { dest.produccion_id = src.produccion_id; })
                         .AfterMap((src, dest) => { dest.turno_id = src.turno_id; })
                         .AfterMap((src, dest) => { dest.fecha_op = src.fecha_op; })
                         .AfterMap((src, dest) => { dest.tm_acum_faja1 = src.tm_acum_faja1; })
                         .AfterMap((src, dest) => { dest.tm_acum_ob = src.tm_acum_ob; })
                         .AfterMap((src, dest) => { dest.mps_porc = src.mps_porc; })
                         .AfterMap((src, dest) => { dest.presion_ntg = src.presion_ntg; })
                         .AfterMap((src, dest) => { dest.rpm_main_shaft = src.rpm_main_shaft; })
                         .AfterMap((src, dest) => { dest.amp_chancadora = src.amp_chancadora; })
                         .AfterMap((src, dest) => { dest.f_aceite_sup = src.f_aceite_sup; })
                         .AfterMap((src, dest) => { dest.f_aceite_inf = src.f_aceite_inf; })
                         .AfterMap((src, dest) => { dest.rpm_apron_feeder = src.rpm_apron_feeder; })
                         .AfterMap((src, dest) => { dest.a_apron_feeder = src.a_apron_feeder; })
                         .AfterMap((src, dest) => { dest.a_faja_uno = src.a_faja_uno; })
                         .AfterMap((src, dest) => { dest.a_faja_dos = src.a_faja_dos; })
                         .AfterMap((src, dest) => { dest.a_faja_tres = src.a_faja_tres; })
                         .AfterMap((src, dest) => { dest.tpm = src.tpm; })
                         .AfterMap((src, dest) => { dest.poligonos = src.poligonos; })
                         .AfterMap((src, dest) => { dest.celda = src.celda; })
                         .AfterMap((src, dest) => { dest.frec_av_a = src.frec_av_a; })
                         .AfterMap((src, dest) => { dest.frec_av_b = src.frec_av_b; })
                         .AfterMap((src, dest) => { dest.frec_av_c = src.frec_av_c; })
                         .AfterMap((src, dest) => { dest.pr_hidra_uno = src.pr_hidra_uno; })
                         .AfterMap((src, dest) => { dest.pr_hidra_dos = src.pr_hidra_dos; })
                         .AfterMap((src, dest) => { dest.tk_verde = src.tk_verde; })
                         .AfterMap((src, dest) => { dest.tk_rojo = src.tk_rojo; })
                         .AfterMap((src, dest) => { dest.stock_pile = src.stock_pile; })
                         .AfterMap((src, dest) => { dest.ratio_cal = src.ratio_cal; })
                         .AfterMap((src, dest) => { dest.silo_a = src.silo_a; })
                         .AfterMap((src, dest) => { dest.silo_b = src.silo_b; })
                         .AfterMap((src, dest) => { dest.observacion = src.observacion; })
                         .AfterMap((src, dest) => { dest.activo = src.activo; })
                         .AfterMap((src, dest) => { dest.usuario_crea = src.usuario_crea; })
                         .AfterMap((src, dest) => { dest.fecha_crea = src.fecha_crea; })
                         .AfterMap((src, dest) => { dest.usuario_mod = src.usuario_mod; })
                         .AfterMap((src, dest) => { dest.fecha_mod = DateTime.Now; });
                var oProduccion = AutoMapper.Mapper.Map<DTOProduccion, MS_PRODUCCION>(oDTOProduccion);
                ounitOfWork.produccionRepository.Update(oProduccion);
                ounitOfWork.Save();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
        }


        public DTOProduccionRespuesta obtenerProduccion_por_id(int id)
        {
            DTOProduccionRespuesta oProduccionRespuesta = new DTOProduccionRespuesta();
            DTOProduccion oProduccion = new DTOProduccion();
            try
            {
                var objProduccion = ounitOfWork.produccionRepository.GetFirst(u => u.produccion_id == id);
                oProduccion.produccion_id = objProduccion.produccion_id;
                oProduccion.fecha_op = Convert.ToDateTime(objProduccion.fecha_op);
                oProduccion.turno_id = Convert.ToInt32(objProduccion.turno_id);
                oProduccion.tm_acum_faja1 = Convert.ToDouble(objProduccion.tm_acum_faja1);
                oProduccion.tm_acum_ob = Convert.ToDouble(objProduccion.tm_acum_ob);
                oProduccion.mps_porc = Convert.ToDouble(objProduccion.mps_porc);
                oProduccion.presion_ntg = Convert.ToDouble(objProduccion.presion_ntg);
                oProduccion.rpm_main_shaft = Convert.ToDouble(objProduccion.rpm_main_shaft);
                oProduccion.amp_chancadora = Convert.ToDouble(objProduccion.amp_chancadora);
                oProduccion.f_aceite_sup = Convert.ToDouble(objProduccion.f_aceite_sup);
                oProduccion.f_aceite_inf = Convert.ToDouble(objProduccion.f_aceite_inf);
                oProduccion.rpm_apron_feeder = Convert.ToDouble(objProduccion.rpm_apron_feeder);
                oProduccion.a_apron_feeder = Convert.ToDouble(objProduccion.a_apron_feeder);
                oProduccion.a_faja_uno = Convert.ToDouble(objProduccion.a_faja_uno);
                oProduccion.a_faja_dos = Convert.ToDouble(objProduccion.a_faja_dos);
                oProduccion.a_faja_tres = Convert.ToDouble(objProduccion.a_faja_tres);
                oProduccion.tpm = objProduccion.tpm;
                oProduccion.poligonos = objProduccion.poligonos;
                oProduccion.celda = objProduccion.celda;
                oProduccion.frec_av_a = Convert.ToDouble(objProduccion.frec_av_a);
                oProduccion.frec_av_b = Convert.ToDouble(objProduccion.frec_av_b);
                oProduccion.frec_av_c = Convert.ToDouble(objProduccion.frec_av_c);
                oProduccion.pr_hidra_uno = Convert.ToDouble(objProduccion.pr_hidra_uno);
                oProduccion.pr_hidra_dos = Convert.ToDouble(objProduccion.pr_hidra_dos);
                oProduccion.tk_verde = Convert.ToDouble(objProduccion.tk_verde);
                oProduccion.tk_rojo = Convert.ToDouble(objProduccion.tk_rojo);
                oProduccion.stock_pile = Convert.ToDouble(objProduccion.stock_pile);
                oProduccion.ratio_cal = Convert.ToDouble(objProduccion.ratio_cal);
                oProduccion.silo_a = Convert.ToDouble(objProduccion.silo_a);
                oProduccion.silo_b = Convert.ToDouble(objProduccion.silo_b);
                oProduccion.observacion = objProduccion.observacion;
                oProduccion.activo = Convert.ToBoolean(objProduccion.activo);
                oProduccion.usuario_crea = objProduccion.usuario_crea;
                oProduccion.fecha_crea = Convert.ToDateTime(objProduccion.fecha_crea);
                oProduccion.usuario_mod = objProduccion.usuario_mod;
                oProduccion.fecha_mod = Convert.ToDateTime(objProduccion.fecha_mod);

                oProduccionRespuesta.DTOProduccion = oProduccion;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return oProduccionRespuesta;
        }

        public DTOProduccionRespuesta ObtenerReporteProduccion(DTOProduccion oProduccion)
        {
            DTOProduccionRespuesta objRpta = new DTOProduccionRespuesta();
            DTOProduccion obj = new DTOProduccion();
            List<DTOProduccion> objList = new List<DTOProduccion>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MinsurRepo"].ConnectionString))
                {
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = connection;
                    cm.CommandText = "MS_REP_PRODUCCION";
                    cm.Parameters.AddWithValue("@turno_id", oProduccion.turno_id);
                    cm.Parameters.AddWithValue("@jefe_guardia_id", oProduccion.jefe_guardia_id);
                    cm.Parameters.AddWithValue("@operario_id", oProduccion.operario_id);
                    cm.Parameters.AddWithValue("@fecha_desde", oProduccion.fecha_desde);
                    cm.Parameters.AddWithValue("@fecha_hasta", oProduccion.fecha_hasta);

                    cm.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cm.ExecuteReader();

                    while (reader.Read())
                    {
                        obj = new DTOProduccion();
                        int cont = 0;
                        if (!reader.IsDBNull(cont))
                            obj.mes_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.dia_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.fecha_op = reader.GetDateTime(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.turno_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.jefe_guardia = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.operador_planta_chancado = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.viajes_ch = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_ch_cam = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_ch_ox = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tmh_ch_ox = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_bal_faja1 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tm_acum_ini_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tm_acum_fin_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tmh_ch_bal = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_op_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_mantto_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_mantto_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_mantto_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_operacion_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_operacion_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_operacion_ch = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.viajes_ob = reader.GetInt32(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_ob_cam = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_ob_ox = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ton_bal_faja3 = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tm_acum_ini_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tm_acum_fin_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tmh_ob_balanza = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_op_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_op_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_op_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_mantto_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_mantto_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_mantto_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.hrs_operacion_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.horas_operacion_ob = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.minutos_operacion_ob = reader.GetDouble(cont);




                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.mps_porc = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.presion_ntg = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.rpm_main_shaft = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.amp_chancadora = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.f_aceite_sup = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.f_aceite_inf = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.rpm_apron_feeder = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.a_apron_feeder = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.a_faja_uno = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.a_faja_dos = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.a_faja_tres = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.frec_av_a = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.frec_av_b = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.frec_av_c = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.pr_hidra_uno = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.pr_hidra_dos = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tk_verde = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tk_rojo = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.stock_pile = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.ratio_cal = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.silo_a = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.silo_b = reader.GetDouble(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.tpm_desc = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.poligonos = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.celda = reader.GetString(cont);
                        cont++;
                        if (!reader.IsDBNull(cont))
                            obj.observacion = reader.GetString(cont);
                        cont++;

                        objList.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            objRpta.DTOListaProduccion = objList;
            return objRpta;
        }


    }
}