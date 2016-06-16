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
    public class Prod_ore_binController : Controller
    {
        // GET: Prod_ore_bin
        public ActionResult Index()
        {
            Prod_ore_binBL oProd_ore_binBL = new Prod_ore_binBL();
            DTOProd_ore_binRespuesta oProd_ore_binRpta = new DTOProd_ore_binRespuesta();
            oProd_ore_binRpta = oProd_ore_binBL.obtenerProd_ore_bin();
            DTOProd_ore_binM oProd_ore_binM = new DTOProd_ore_binM();
            List<DTOProd_ore_binM> oLista_Prod_ore_binM = new List<DTOProd_ore_binM>();

            if (oProd_ore_binRpta.DTOListaProd_ore_bin != null)
            {
                foreach (var item in oProd_ore_binRpta.DTOListaProd_ore_bin)
                {
                    oProd_ore_binM = new DTOProd_ore_binM(); oProd_ore_binM.prod_ore_bin_id = item.prod_ore_bin_id;
                    oProd_ore_binM.fecha_op = item.fecha_op;
                    oProd_ore_binM.turno_id = item.turno_id;
                    oProd_ore_binM.viajes_ob = item.viajes_ob;
                    oProd_ore_binM.ton_ob_cam = item.ton_ob_cam;
                    oProd_ore_binM.ton_ob_ox = item.ton_ob_ox;
                    oProd_ore_binM.ton_bal_faja = item.ton_bal_faja;
                    oProd_ore_binM.tm_acum_ini_ob = item.tm_acum_ini_ob;
                    oProd_ore_binM.tm_acum_fin_ob = item.tm_acum_fin_ob;
                    oProd_ore_binM.tmh_ob_bal = item.tmh_ob_bal;
                    oProd_ore_binM.h_op_ob = item.h_op_ob;
                    oProd_ore_binM.horas = item.horas;
                    oProd_ore_binM.minutos = item.minutos;
                    oProd_ore_binM.h_mantto_ob = item.h_mantto_ob;
                    oProd_ore_binM.horas_mantto = item.horas_mantto;
                    oProd_ore_binM.minutos_mantto = item.minutos_mantto;
                    oProd_ore_binM.h_operacion = item.h_operacion;
                    oProd_ore_binM.horas_operacion = item.horas_operacion;
                    oProd_ore_binM.minutos_operacion = item.minutos_operacion;
                    oProd_ore_binM.h_calendario = item.h_calendario;
                    oProd_ore_binM.porc_d_ob = item.porc_d_ob;
                    oProd_ore_binM.porc_ud_ob = item.porc_ud_ob;
                    oProd_ore_binM.porc_u_ob = item.porc_u_ob;
                    oProd_ore_binM.activo = item.activo;
                    oProd_ore_binM.usuario_crea = item.usuario_crea;
                    oProd_ore_binM.fecha_crea = Convert.ToDateTime(item.fecha_crea);
                    oProd_ore_binM.usuario_mod = item.usuario_mod;
                    oProd_ore_binM.fecha_mod = Convert.ToDateTime(item.fecha_mod);
                    oLista_Prod_ore_binM.Add(oProd_ore_binM);
                }
            }


            return View(oLista_Prod_ore_binM);
        }
               
        // GET: Prod_ore_bin/Create
        public ActionResult Create(int id)
        {
            DTOProd_ore_binM oProd_ore_binM = new DTOProd_ore_binM();
            DTOProduccion oProduccion = new DTOProduccion();
            ProduccionBL oProduccionBL = new ProduccionBL();
            Prod_ore_binBL oProd_OBBL = new Prod_ore_binBL();
            oProduccion = oProduccionBL.obtenerProduccion_por_id(id).DTOProduccion;
            oProd_ore_binM.activo = true;
            cargarCombos(oProduccion.turno_id);
            oProd_ore_binM.fecha_desc = oProduccion.fecha_op.ToShortDateString();
            oProd_ore_binM.produccion_id = id;

            oProd_ore_binM.tm_acum_ini_ob = oProd_OBBL.ObtenerTM_Acum_Fin_OB();

            return View(oProd_ore_binM);
        }

        // POST: Prod_ore_bin/Create
        [HttpPost]
        public ActionResult Create(DTOProd_ore_binM oProd_ore_binM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Prod_ore_binBL Prod_ore_binBL = new Prod_ore_binBL();
                    DTOProd_ore_bin oProd_ore_bin = new DTOProd_ore_bin();
                    oProd_ore_bin.produccion_id = oProd_ore_binM.produccion_id;
                    oProd_ore_bin.prod_ore_bin_id = oProd_ore_binM.prod_ore_bin_id;
                    oProd_ore_bin.fecha_op = oProd_ore_binM.fecha_op;
                    oProd_ore_bin.turno_id = oProd_ore_binM.turno_id;
                    oProd_ore_bin.viajes_ob = oProd_ore_binM.viajes_ob;
                    oProd_ore_bin.ton_ob_cam = oProd_ore_binM.ton_ob_cam;
                    oProd_ore_bin.ton_ob_ox = oProd_ore_binM.ton_ob_ox;
                    oProd_ore_bin.ton_bal_faja = Convert.ToDouble(oProd_ore_binM.ton_bal_faja_desc);
                    oProd_ore_binM.ton_bal_faja = Convert.ToDouble(oProd_ore_binM.ton_bal_faja_desc);
                    oProd_ore_bin.tm_acum_ini_ob = oProd_ore_binM.tm_acum_ini_ob;
                    oProd_ore_bin.tm_acum_fin_ob = oProd_ore_binM.tm_acum_fin_ob;
                    oProd_ore_bin.tmh_ob_bal =Convert.ToDouble(oProd_ore_binM.tmh_ob_bal_desc);
                    oProd_ore_bin.h_op_ob = Convert.ToDouble(oProd_ore_binM.h_op_ob_desc);
                    oProd_ore_bin.horas = oProd_ore_binM.horas;
                    oProd_ore_bin.minutos = oProd_ore_binM.minutos;
                    oProd_ore_bin.h_mantto_ob = Convert.ToDouble(oProd_ore_binM.h_mantto_ob_desc);
                    oProd_ore_bin.horas_mantto = oProd_ore_binM.horas_mantto;
                    oProd_ore_bin.minutos_mantto = oProd_ore_binM.minutos_mantto;
                    oProd_ore_bin.h_operacion = Convert.ToDouble(oProd_ore_binM.h_operacion_desc);
                    oProd_ore_bin.horas_operacion = oProd_ore_binM.horas_operacion;
                    oProd_ore_bin.minutos_operacion = oProd_ore_binM.minutos_operacion;
                    oProd_ore_bin.h_calendario = oProd_ore_binM.h_calendario;
                    oProd_ore_bin.porc_d_ob = oProd_ore_binM.porc_d_ob;
                    oProd_ore_bin.porc_ud_ob = oProd_ore_binM.porc_ud_ob;
                    oProd_ore_bin.porc_u_ob = oProd_ore_binM.porc_u_ob;
                    oProd_ore_bin.activo = oProd_ore_binM.activo;
                    oProd_ore_bin.usuario_crea = Session["USR_COD"].ToString(); 
                    oProd_ore_bin.fecha_crea = oProd_ore_binM.fecha_crea;
                    oProd_ore_bin.usuario_mod = oProd_ore_binM.usuario_mod;
                    oProd_ore_bin.fecha_mod = oProd_ore_binM.fecha_mod;
                    oProd_ore_bin.fecha_op =  Convert.ToDateTime(oProd_ore_binM.fecha_desc);
                    Prod_ore_binBL.registrarProd_ore_bin(oProd_ore_bin);

                    oProd_ore_binM.resultado = 1;
                }
                cargarCombos(oProd_ore_binM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProd_ore_binM.resultado = 2;
            }

            return View(oProd_ore_binM);
        }

        // GET: Prod_ore_bin/Edit/5
        public ActionResult Edit(int id)
        {
            DTOProd_ore_binRespuesta oProd_ore_binRpta = new DTOProd_ore_binRespuesta();
            Prod_ore_binBL oProd_ore_binBL = new Prod_ore_binBL();
            DTOProd_ore_binM oProd_ore_binM = new DTOProd_ore_binM();
            try
            {
                oProd_ore_binRpta = oProd_ore_binBL.obtenerProd_ore_bin_por_id(id);
                oProd_ore_binM.produccion_id = oProd_ore_binRpta.DTOProd_ore_bin.produccion_id;
                oProd_ore_binM.prod_ore_bin_id = oProd_ore_binRpta.DTOProd_ore_bin.prod_ore_bin_id;
                oProd_ore_binM.fecha_op = oProd_ore_binRpta.DTOProd_ore_bin.fecha_op;
                oProd_ore_binM.turno_id = oProd_ore_binRpta.DTOProd_ore_bin.turno_id;
                oProd_ore_binM.viajes_ob = oProd_ore_binRpta.DTOProd_ore_bin.viajes_ob;
                oProd_ore_binM.ton_ob_cam = oProd_ore_binRpta.DTOProd_ore_bin.ton_ob_cam;
                oProd_ore_binM.ton_ob_ox = oProd_ore_binRpta.DTOProd_ore_bin.ton_ob_ox;
                oProd_ore_binM.ton_bal_faja = oProd_ore_binRpta.DTOProd_ore_bin.ton_bal_faja;
                oProd_ore_binM.ton_bal_faja_desc = oProd_ore_binRpta.DTOProd_ore_bin.ton_bal_faja.ToString();
                oProd_ore_binM.tm_acum_ini_ob = oProd_ore_binRpta.DTOProd_ore_bin.tm_acum_ini_ob;
                oProd_ore_binM.tm_acum_fin_ob = oProd_ore_binRpta.DTOProd_ore_bin.tm_acum_fin_ob;
                oProd_ore_binM.tmh_ob_bal = oProd_ore_binRpta.DTOProd_ore_bin.tmh_ob_bal;
                oProd_ore_binM.tmh_ob_bal_desc = oProd_ore_binRpta.DTOProd_ore_bin.tmh_ob_bal.ToString();
                oProd_ore_binM.h_op_ob = oProd_ore_binRpta.DTOProd_ore_bin.h_op_ob;
                oProd_ore_binM.h_op_ob_desc = oProd_ore_binRpta.DTOProd_ore_bin.h_op_ob.ToString();
                oProd_ore_binM.horas = oProd_ore_binRpta.DTOProd_ore_bin.horas;
                oProd_ore_binM.minutos = oProd_ore_binRpta.DTOProd_ore_bin.minutos;
                oProd_ore_binM.h_mantto_ob = oProd_ore_binRpta.DTOProd_ore_bin.h_mantto_ob;
                oProd_ore_binM.h_mantto_ob_desc = oProd_ore_binRpta.DTOProd_ore_bin.h_mantto_ob.ToString();
                oProd_ore_binM.horas_mantto = oProd_ore_binRpta.DTOProd_ore_bin.horas_mantto;
                oProd_ore_binM.minutos_mantto = oProd_ore_binRpta.DTOProd_ore_bin.minutos_mantto;
                oProd_ore_binM.h_operacion = oProd_ore_binRpta.DTOProd_ore_bin.h_operacion;
                oProd_ore_binM.h_operacion_desc = oProd_ore_binRpta.DTOProd_ore_bin.h_operacion.ToString();
                oProd_ore_binM.horas_operacion = oProd_ore_binRpta.DTOProd_ore_bin.horas_operacion;
                oProd_ore_binM.minutos_operacion = oProd_ore_binRpta.DTOProd_ore_bin.minutos_operacion;
                oProd_ore_binM.h_calendario = oProd_ore_binRpta.DTOProd_ore_bin.h_calendario;
                oProd_ore_binM.porc_d_ob = oProd_ore_binRpta.DTOProd_ore_bin.porc_d_ob;
                oProd_ore_binM.porc_ud_ob = oProd_ore_binRpta.DTOProd_ore_bin.porc_ud_ob;
                oProd_ore_binM.porc_u_ob = oProd_ore_binRpta.DTOProd_ore_bin.porc_u_ob;
                oProd_ore_binM.activo = oProd_ore_binRpta.DTOProd_ore_bin.activo;
                oProd_ore_binM.usuario_crea = oProd_ore_binRpta.DTOProd_ore_bin.usuario_crea;
                oProd_ore_binM.fecha_crea = Convert.ToDateTime(oProd_ore_binRpta.DTOProd_ore_bin.fecha_crea);
                oProd_ore_binM.usuario_mod = oProd_ore_binRpta.DTOProd_ore_bin.usuario_mod;
                oProd_ore_binM.fecha_mod = Convert.ToDateTime(oProd_ore_binRpta.DTOProd_ore_bin.fecha_mod);
                oProd_ore_binM.fecha_desc = oProd_ore_binRpta.DTOProd_ore_bin.fecha_op.ToShortDateString();
                cargarCombos(oProd_ore_binM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oProd_ore_binM);
        }

        // POST: Prod_ore_bin/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOProd_ore_binM oProd_ore_binM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOProd_ore_bin oProd_ore_bin = new DTOProd_ore_bin();
                    Prod_ore_binBL oProd_ore_binBL = new Prod_ore_binBL();
                    oProd_ore_bin.produccion_id = oProd_ore_binM.produccion_id;
                    oProd_ore_bin.prod_ore_bin_id = oProd_ore_binM.prod_ore_bin_id;
                    oProd_ore_bin.fecha_op = oProd_ore_binM.fecha_op;
                    oProd_ore_bin.turno_id = oProd_ore_binM.turno_id;
                    oProd_ore_bin.viajes_ob = oProd_ore_binM.viajes_ob;
                    oProd_ore_bin.ton_ob_cam = oProd_ore_binM.ton_ob_cam;
                    oProd_ore_bin.ton_ob_ox = oProd_ore_binM.ton_ob_ox;
                    oProd_ore_bin.ton_bal_faja = Convert.ToDouble(oProd_ore_binM.ton_bal_faja_desc);
                    oProd_ore_bin.tm_acum_ini_ob = oProd_ore_binM.tm_acum_ini_ob;
                    oProd_ore_bin.tm_acum_fin_ob = oProd_ore_binM.tm_acum_fin_ob;
                    oProd_ore_bin.tmh_ob_bal = Convert.ToDouble(oProd_ore_binM.tmh_ob_bal_desc);
                    oProd_ore_bin.h_op_ob = Convert.ToDouble(oProd_ore_binM.h_op_ob_desc);
                    oProd_ore_bin.horas = oProd_ore_binM.horas;
                    oProd_ore_bin.minutos = oProd_ore_binM.minutos;
                    oProd_ore_bin.h_mantto_ob = Convert.ToDouble(oProd_ore_binM.h_mantto_ob_desc);
                    oProd_ore_bin.horas_mantto = oProd_ore_binM.horas_mantto;
                    oProd_ore_bin.minutos_mantto = oProd_ore_binM.minutos_mantto;
                    oProd_ore_bin.h_operacion = Convert.ToDouble(oProd_ore_binM.h_operacion_desc);
                    oProd_ore_bin.horas_operacion = oProd_ore_binM.horas_operacion;
                    oProd_ore_bin.minutos_operacion = oProd_ore_binM.minutos_operacion;
                    oProd_ore_bin.h_calendario = oProd_ore_binM.h_calendario;
                    oProd_ore_bin.porc_d_ob = oProd_ore_binM.porc_d_ob;
                    oProd_ore_bin.porc_ud_ob = oProd_ore_binM.porc_ud_ob;
                    oProd_ore_bin.porc_u_ob = oProd_ore_binM.porc_u_ob;
                    oProd_ore_bin.activo = oProd_ore_binM.activo;
                    oProd_ore_bin.usuario_crea = oProd_ore_binM.usuario_crea;
                    oProd_ore_bin.fecha_crea = oProd_ore_binM.fecha_crea;
                    oProd_ore_bin.usuario_mod = Session["USR_COD"].ToString();
                    oProd_ore_bin.fecha_mod = oProd_ore_binM.fecha_mod;
                    oProd_ore_bin.fecha_op = Convert.ToDateTime(oProd_ore_binM.fecha_desc);

                    oProd_ore_binBL.actualizarProd_ore_bin(oProd_ore_bin);
                    oProd_ore_binM.resultado = 1;
                }
                cargarCombos(oProd_ore_binM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProd_ore_binM.resultado = 2;
            }

            return View(oProd_ore_binM);
        }

        public void cargarCombos(int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();

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