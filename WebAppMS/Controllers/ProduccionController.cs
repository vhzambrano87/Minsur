using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMS.Models;
using System.Configuration;

namespace WebAppMS.Controllers
{
    public class ProduccionController : Controller
    {
        // GET: Produccion
        public ActionResult Index()
        {
            ProduccionBL oProduccionBL = new ProduccionBL();
            DTOProduccionRespuesta oProduccionRpta = new DTOProduccionRespuesta();
            oProduccionRpta = oProduccionBL.obtenerProduccion();
            DTOProduccionM oProduccionM = new DTOProduccionM();
            List<DTOProduccionM> oLista_ProduccionM = new List<DTOProduccionM>();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            try
            {
                if (oProduccionRpta.DTOListaProduccion != null)
                {
                    foreach (var item in oProduccionRpta.DTOListaProduccion)
                    {
                        oProduccionM = new DTOProduccionM(); oProduccionM.produccion_id = item.produccion_id;
                        oProduccionM.turno_id = item.turno_id;
                        oProduccionM.turno_desc = oListaValorBL.obtenerLista_valor_por_id(item.turno_id).DTOLista_valor.valor;
                        oProduccionM.fecha_op = item.fecha_op;
                        oProduccionM.tm_acum_faja1 = item.tm_acum_faja1;
                        oProduccionM.tm_acum_ob = item.tm_acum_ob;
                        oProduccionM.mps_porc = item.mps_porc;
                        oProduccionM.presion_ntg = item.presion_ntg;
                        oProduccionM.rpm_main_shaft = item.rpm_main_shaft;
                        oProduccionM.amp_chancadora = item.amp_chancadora;
                        oProduccionM.f_aceite_sup = item.f_aceite_sup;
                        oProduccionM.f_aceite_inf = item.f_aceite_inf;
                        oProduccionM.rpm_apron_feeder = item.rpm_apron_feeder;
                        oProduccionM.a_apron_feeder = item.a_apron_feeder;
                        oProduccionM.a_faja_uno = item.a_faja_uno;
                        oProduccionM.a_faja_dos = item.a_faja_dos;
                        oProduccionM.a_faja_tres = item.a_faja_tres;
                        oProduccionM.tpm = item.tpm;
                        oProduccionM.poligonos = item.poligonos;
                        oProduccionM.celda = item.celda;
                        oProduccionM.frec_av_a = item.frec_av_a;
                        oProduccionM.frec_av_b = item.frec_av_b;
                        oProduccionM.frec_av_c = item.frec_av_c;
                        oProduccionM.pr_hidra_uno = item.pr_hidra_uno;
                        oProduccionM.pr_hidra_dos = item.pr_hidra_dos;
                        oProduccionM.tk_verde = item.tk_verde;
                        oProduccionM.tk_rojo = item.tk_rojo;
                        oProduccionM.stock_pile = item.stock_pile;
                        oProduccionM.ratio_cal = item.ratio_cal;
                        oProduccionM.silo_a = item.silo_a;
                        oProduccionM.silo_b = item.silo_b;
                        oProduccionM.observacion = item.observacion;
                        oProduccionM.activo = item.activo;
                        oProduccionM.usuario_crea = item.usuario_crea;
                        oProduccionM.fecha_crea = item.fecha_crea;
                        oProduccionM.usuario_mod = item.usuario_mod;
                        oProduccionM.fecha_mod = item.fecha_mod;
                        oProduccionM.flagChancadora = item.flag_chancadora;
                        oProduccionM.flagOreBin = item.flag_orebin;
                        oLista_ProduccionM.Add(oProduccionM);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }


            return View(oLista_ProduccionM);
        }

        // GET: Produccion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produccion/Create
        public ActionResult Create()
        {
            DTOProduccionM oProduccionM = new DTOProduccionM();
            cargarCombos(0);
            oProduccionM.activo = true;
            oProduccionM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oProduccionM);
        }

        // POST: Produccion/Create
        [HttpPost]
        public ActionResult Create(DTOProduccionM oProduccionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ProduccionBL ProduccionBL = new ProduccionBL();
                    DTOProduccion oProduccion = new DTOProduccion(); oProduccion.produccion_id = oProduccionM.produccion_id;
                    oProduccion.turno_id = oProduccionM.turno_id;
                    oProduccion.fecha_op = Convert.ToDateTime(oProduccionM.fecha_desc);
                    oProduccion.tm_acum_faja1 = oProduccionM.tm_acum_faja1;
                    oProduccion.tm_acum_ob = oProduccionM.tm_acum_ob;
                    oProduccion.mps_porc = oProduccionM.mps_porc;
                    oProduccion.presion_ntg = oProduccionM.presion_ntg;
                    oProduccion.rpm_main_shaft = oProduccionM.rpm_main_shaft;
                    oProduccion.amp_chancadora = oProduccionM.amp_chancadora;
                    oProduccion.f_aceite_sup = oProduccionM.f_aceite_sup;
                    oProduccion.f_aceite_inf = oProduccionM.f_aceite_inf;
                    oProduccion.rpm_apron_feeder = oProduccionM.rpm_apron_feeder;
                    oProduccion.a_apron_feeder = oProduccionM.a_apron_feeder;
                    oProduccion.a_faja_uno = oProduccionM.a_faja_uno;
                    oProduccion.a_faja_dos = oProduccionM.a_faja_dos;
                    oProduccion.a_faja_tres = oProduccionM.a_faja_tres;
                    oProduccion.tpm = oProduccionM.tpm;
                    oProduccion.poligonos = oProduccionM.poligonos;
                    oProduccion.celda = oProduccionM.celda;
                    oProduccion.frec_av_a = oProduccionM.frec_av_a;
                    oProduccion.frec_av_b = oProduccionM.frec_av_b;
                    oProduccion.frec_av_c = oProduccionM.frec_av_c;
                    oProduccion.pr_hidra_uno = oProduccionM.pr_hidra_uno;
                    oProduccion.pr_hidra_dos = oProduccionM.pr_hidra_dos;
                    oProduccion.tk_verde = oProduccionM.tk_verde;
                    oProduccion.tk_rojo = oProduccionM.tk_rojo;
                    oProduccion.stock_pile = oProduccionM.stock_pile;
                    oProduccion.ratio_cal = oProduccionM.ratio_cal;
                    oProduccion.silo_a = oProduccionM.silo_a;
                    oProduccion.silo_b = oProduccionM.silo_b;
                    oProduccion.observacion = oProduccionM.observacion;
                    oProduccion.activo = oProduccionM.activo;
                    oProduccion.usuario_crea = Session["USR_COD"].ToString();
                    oProduccion.fecha_crea = oProduccionM.fecha_crea;
                    oProduccion.usuario_mod = oProduccionM.usuario_mod;
                    oProduccion.fecha_mod = oProduccionM.fecha_mod;
                    ProduccionBL.registrarProduccion(oProduccion);

                    
                    oProduccionM.resultado = 1;
                }
                cargarCombos(oProduccionM.turno_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProduccionM.resultado = 2;
            }

            return View(oProduccionM);
        }

        // GET: Produccion/Edit/5
        public ActionResult Edit(int id)
        {
            DTOProduccionRespuesta oProduccionRpta = new DTOProduccionRespuesta();
            ProduccionBL oProduccionBL = new ProduccionBL();
            DTOProduccionM oProduccionM = new DTOProduccionM();
            try
            {
                oProduccionRpta = oProduccionBL.obtenerProduccion_por_id(id);
                oProduccionM.produccion_id = oProduccionRpta.DTOProduccion.produccion_id;
                oProduccionM.fecha_op = oProduccionRpta.DTOProduccion.fecha_op;
                oProduccionM.fecha_desc = oProduccionRpta.DTOProduccion.fecha_op.ToShortDateString();
                oProduccionM.turno_id = oProduccionRpta.DTOProduccion.turno_id;
                oProduccionM.tm_acum_faja1 = oProduccionRpta.DTOProduccion.tm_acum_faja1;
                oProduccionM.tm_acum_ob = oProduccionRpta.DTOProduccion.tm_acum_ob;
                oProduccionM.mps_porc = oProduccionRpta.DTOProduccion.mps_porc;
                oProduccionM.presion_ntg = oProduccionRpta.DTOProduccion.presion_ntg;
                oProduccionM.rpm_main_shaft = oProduccionRpta.DTOProduccion.rpm_main_shaft;
                oProduccionM.amp_chancadora = oProduccionRpta.DTOProduccion.amp_chancadora;
                oProduccionM.f_aceite_sup = oProduccionRpta.DTOProduccion.f_aceite_sup;
                oProduccionM.f_aceite_inf = oProduccionRpta.DTOProduccion.f_aceite_inf;
                oProduccionM.rpm_apron_feeder = oProduccionRpta.DTOProduccion.rpm_apron_feeder;
                oProduccionM.a_apron_feeder = oProduccionRpta.DTOProduccion.a_apron_feeder;
                oProduccionM.a_faja_uno = oProduccionRpta.DTOProduccion.a_faja_uno;
                oProduccionM.a_faja_dos = oProduccionRpta.DTOProduccion.a_faja_dos;
                oProduccionM.a_faja_tres = oProduccionRpta.DTOProduccion.a_faja_tres;
                oProduccionM.tpm = oProduccionRpta.DTOProduccion.tpm;
                oProduccionM.poligonos = oProduccionRpta.DTOProduccion.poligonos;
                oProduccionM.celda = oProduccionRpta.DTOProduccion.celda;
                oProduccionM.frec_av_a = oProduccionRpta.DTOProduccion.frec_av_a;
                oProduccionM.frec_av_b = oProduccionRpta.DTOProduccion.frec_av_b;
                oProduccionM.frec_av_c = oProduccionRpta.DTOProduccion.frec_av_c;
                oProduccionM.pr_hidra_uno = oProduccionRpta.DTOProduccion.pr_hidra_uno;
                oProduccionM.pr_hidra_dos = oProduccionRpta.DTOProduccion.pr_hidra_dos;
                oProduccionM.tk_verde = oProduccionRpta.DTOProduccion.tk_verde;
                oProduccionM.tk_rojo = oProduccionRpta.DTOProduccion.tk_rojo;
                oProduccionM.stock_pile = oProduccionRpta.DTOProduccion.stock_pile;
                oProduccionM.ratio_cal = oProduccionRpta.DTOProduccion.ratio_cal;
                oProduccionM.silo_a = oProduccionRpta.DTOProduccion.silo_a;
                oProduccionM.silo_b = oProduccionRpta.DTOProduccion.silo_b;
                oProduccionM.observacion = oProduccionRpta.DTOProduccion.observacion;
                oProduccionM.activo = oProduccionRpta.DTOProduccion.activo;
                oProduccionM.usuario_crea = oProduccionRpta.DTOProduccion.usuario_crea;
                oProduccionM.fecha_crea = oProduccionRpta.DTOProduccion.fecha_crea;
                oProduccionM.usuario_mod = oProduccionRpta.DTOProduccion.usuario_mod;
                oProduccionM.fecha_mod = oProduccionRpta.DTOProduccion.fecha_mod;
                cargarCombos(oProduccionM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oProduccionM);
        }

        // POST: Produccion/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOProduccionM oProduccionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOProduccion oProduccion = new DTOProduccion();
                    ProduccionBL oProduccionBL = new ProduccionBL();
                    Prod_chancadoraBL oProduccionChancadoraBL = new Prod_chancadoraBL();
                    Prod_ore_binBL oProduccionOreBinBL = new Prod_ore_binBL();
                    DTOProd_chancadora oProdChancadora = new DTOProd_chancadora();
                    DTOProd_ore_bin oProdOreBin = new DTOProd_ore_bin();


                    oProdChancadora = oProduccionChancadoraBL.obtenerProd_chancadora_por_prod_id(oProduccionM.produccion_id).DTOProd_chancadora;
                    oProdOreBin = oProduccionOreBinBL.obtenerProd_ore_bin_por_produccion_id(oProduccionM.produccion_id).DTOProd_ore_bin;

                    oProdChancadora.fecha_op = Convert.ToDateTime(oProduccionM.fecha_desc);
                    oProdChancadora.turno_id = oProduccionM.turno_id;
                    oProdOreBin.turno_id = oProduccionM.turno_id;

                    oProduccionChancadoraBL.actualizarProd_chancadora(oProdChancadora);
                    oProduccionOreBinBL.actualizarProd_ore_bin(oProdOreBin);

                    oProduccion.produccion_id = oProduccionM.produccion_id;
                    oProduccion.turno_id = oProduccionM.turno_id;

                    oProduccion.fecha_op = Convert.ToDateTime(oProduccionM.fecha_desc);
                    oProduccion.tm_acum_faja1 = oProduccionM.tm_acum_faja1;
                    oProduccion.tm_acum_ob = oProduccionM.tm_acum_ob;
                    oProduccion.mps_porc = oProduccionM.mps_porc;
                    oProduccion.presion_ntg = oProduccionM.presion_ntg;
                    oProduccion.rpm_main_shaft = oProduccionM.rpm_main_shaft;
                    oProduccion.amp_chancadora = oProduccionM.amp_chancadora;
                    oProduccion.f_aceite_sup = oProduccionM.f_aceite_sup;
                    oProduccion.f_aceite_inf = oProduccionM.f_aceite_inf;
                    oProduccion.rpm_apron_feeder = oProduccionM.rpm_apron_feeder;
                    oProduccion.a_apron_feeder = oProduccionM.a_apron_feeder;
                    oProduccion.a_faja_uno = oProduccionM.a_faja_uno;
                    oProduccion.a_faja_dos = oProduccionM.a_faja_dos;
                    oProduccion.a_faja_tres = oProduccionM.a_faja_tres;
                    oProduccion.tpm = oProduccionM.tpm;
                    oProduccion.poligonos = oProduccionM.poligonos;
                    oProduccion.celda = oProduccionM.celda;
                    oProduccion.frec_av_a = oProduccionM.frec_av_a;
                    oProduccion.frec_av_b = oProduccionM.frec_av_b;
                    oProduccion.frec_av_c = oProduccionM.frec_av_c;
                    oProduccion.pr_hidra_uno = oProduccionM.pr_hidra_uno;
                    oProduccion.pr_hidra_dos = oProduccionM.pr_hidra_dos;
                    oProduccion.tk_verde = oProduccionM.tk_verde;
                    oProduccion.tk_rojo = oProduccionM.tk_rojo;
                    oProduccion.stock_pile = oProduccionM.stock_pile;
                    oProduccion.ratio_cal = oProduccionM.ratio_cal;
                    oProduccion.silo_a = oProduccionM.silo_a;
                    oProduccion.silo_b = oProduccionM.silo_b;
                    oProduccion.observacion = oProduccionM.observacion;
                    oProduccion.activo = oProduccionM.activo;
                    oProduccion.usuario_crea = oProduccionM.usuario_crea;
                    oProduccion.fecha_crea = oProduccionM.fecha_crea;
                    oProduccion.usuario_mod = Session["USR_COD"].ToString();
                    oProduccion.fecha_mod = oProduccionM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oProduccionBL.actualizarProduccion(oProduccion);
                    oProduccionM.resultado = 1;
                }
                cargarCombos(oProduccionM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProduccionM.resultado = 2;
            }

            return View(oProduccionM);
        }


        public void cargarCombos(int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                
                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);
                

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

    }
}