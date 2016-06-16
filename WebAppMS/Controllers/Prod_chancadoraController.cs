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
    public class Prod_chancadoraController : Controller
    {
        // GET: Prod_chancadora
        public ActionResult Index()
        {
            Prod_chancadoraBL oProd_chancadoraBL = new Prod_chancadoraBL();
            DTOProd_chancadoraRespuesta oProd_chancadoraRpta = new DTOProd_chancadoraRespuesta();
            oProd_chancadoraRpta = oProd_chancadoraBL.obtenerProd_chancadora();
            DTOProd_chancadoraM oProd_chancadoraM = new DTOProd_chancadoraM();
            List<DTOProd_chancadoraM> oLista_Prod_chancadoraM = new List<DTOProd_chancadoraM>();

            if (oProd_chancadoraRpta.DTOListaProd_chancadora != null)
            {
                foreach (var item in oProd_chancadoraRpta.DTOListaProd_chancadora)
                {
                    oProd_chancadoraM = new DTOProd_chancadoraM();
                    oProd_chancadoraM.prod_chancadora_id = item.prod_chancadora_id;
                    oProd_chancadoraM.fecha_op = item.fecha_op;
                    oProd_chancadoraM.turno_id = item.turno_id;
                    oProd_chancadoraM.viajes_ch = item.viajes_ch;
                    oProd_chancadoraM.ton_ch_cam = item.ton_ch_cam;
                    oProd_chancadoraM.ton_ch_ox = item.ton_ch_ox;
                    oProd_chancadoraM.tmh_ch_ox = item.tmh_ch_ox;
                    oProd_chancadoraM.ton_bal_faja = item.ton_bal_faja;
                    oProd_chancadoraM.tm_acum_ini_ch = item.tm_acum_ini_ch;
                    oProd_chancadoraM.tm_acum_fin_ch = item.tm_acum_fin_ch;
                    oProd_chancadoraM.tmh_ch_bal = item.tmh_ch_bal;
                    oProd_chancadoraM.h_op_ch = item.h_op_ch;
                    oProd_chancadoraM.horas = item.horas;
                    oProd_chancadoraM.minutos = item.minutos;
                    oProd_chancadoraM.h_mantto_ch = item.h_mantto_ch;
                    oProd_chancadoraM.horas_mantto = item.horas_mantto;
                    oProd_chancadoraM.minutos_mantto = item.minutos_mantto;
                    oProd_chancadoraM.h_operacion = item.h_operacion;
                    oProd_chancadoraM.horas_operacion = item.horas_operacion;
                    oProd_chancadoraM.minutos_operacion = item.minutos_operacion;
                    oProd_chancadoraM.h_calendario = item.h_calendario;
                    oProd_chancadoraM.porc_d_ch = item.porc_d_ch;
                    oProd_chancadoraM.porc_ud_ch = item.porc_ud_ch;
                    oProd_chancadoraM.porc_u_ch = item.porc_u_ch;
                    oProd_chancadoraM.activo = item.activo;
                    oProd_chancadoraM.usuario_crea = item.usuario_crea;
                    oProd_chancadoraM.fecha_crea = Convert.ToDateTime(item.fecha_crea);
                    oProd_chancadoraM.usuario_mod = item.usuario_mod;
                    oProd_chancadoraM.fecha_mod = Convert.ToDateTime(item.fecha_mod);
                    oLista_Prod_chancadoraM.Add(oProd_chancadoraM);
                }
            }


            return View(oLista_Prod_chancadoraM);
        }        

        // GET: Prod_chancadora/Create
        public ActionResult Create(int id)
        {            
            DTOProd_chancadoraM oProdChancadoraM = new DTOProd_chancadoraM();
            DTOProduccion oProduccion = new DTOProduccion();
            ProduccionBL oProduccionBL = new ProduccionBL();
            Prod_chancadoraBL oProd_CHBL = new Prod_chancadoraBL();
            oProduccion = oProduccionBL.obtenerProduccion_por_id(id).DTOProduccion;
            oProdChancadoraM.activo = true;
            oProdChancadoraM.fecha_desc = oProduccion.fecha_op.ToShortDateString();
            oProdChancadoraM.produccion_id = id;
            cargarCombos(oProduccion.turno_id);

            oProdChancadoraM.tm_acum_ini_ch = oProd_CHBL.ObtenerTM_Acum_Fin_CH();

            return View(oProdChancadoraM);
        }

        // POST: Prod_chancadora/Create
        [HttpPost]
        public ActionResult Create(DTOProd_chancadoraM oProd_chancadoraM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Prod_chancadoraBL Prod_chancadoraBL = new Prod_chancadoraBL();
                    DTOProd_chancadora oProd_chancadora = new DTOProd_chancadora();
                    oProd_chancadora.prod_chancadora_id = oProd_chancadoraM.prod_chancadora_id;
                    oProd_chancadora.produccion_id = oProd_chancadoraM.produccion_id;
                    oProd_chancadora.turno_id = oProd_chancadoraM.turno_id;
                    oProd_chancadora.viajes_ch = oProd_chancadoraM.viajes_ch;
                    oProd_chancadora.ton_ch_cam = oProd_chancadoraM.ton_ch_cam;
                    oProd_chancadora.ton_ch_ox = oProd_chancadoraM.ton_ch_ox;
                    oProd_chancadora.tmh_ch_ox = Convert.ToDouble(oProd_chancadoraM.tmh_ch_ox_desc);
                    oProd_chancadoraM.tmh_ch_ox = Convert.ToDouble(oProd_chancadoraM.tmh_ch_ox_desc);
                    oProd_chancadora.ton_bal_faja = Convert.ToDouble(oProd_chancadoraM.ton_bal_faja_desc);
                    oProd_chancadoraM.ton_bal_faja = Convert.ToDouble(oProd_chancadoraM.ton_bal_faja_desc);
                    oProd_chancadora.tm_acum_ini_ch = oProd_chancadoraM.tm_acum_ini_ch;
                    oProd_chancadora.tm_acum_fin_ch = oProd_chancadoraM.tm_acum_fin_ch;
                    oProd_chancadora.tmh_ch_bal = Convert.ToDouble(oProd_chancadoraM.tmh_ch_bal_desc);
                    oProd_chancadoraM.tmh_ch_bal = Convert.ToDouble(oProd_chancadoraM.tmh_ch_bal_desc);
                    oProd_chancadora.h_op_ch = Convert.ToDouble(oProd_chancadoraM.h_op_ch_desc);
                    oProd_chancadora.horas = oProd_chancadoraM.horas;
                    oProd_chancadora.minutos = oProd_chancadoraM.minutos;
                    oProd_chancadora.h_mantto_ch = Convert.ToDouble(oProd_chancadoraM.h_mantto_ch_desc);
                    oProd_chancadora.horas_mantto = oProd_chancadoraM.horas_mantto;
                    oProd_chancadora.minutos_mantto = oProd_chancadoraM.minutos_mantto;
                    oProd_chancadora.h_operacion = Convert.ToDouble(oProd_chancadoraM.h_operacion_desc);
                    oProd_chancadora.horas_operacion = oProd_chancadoraM.horas_operacion;
                    oProd_chancadora.minutos_operacion = oProd_chancadoraM.minutos_operacion;
                    oProd_chancadora.h_calendario = oProd_chancadoraM.h_calendario;
                    oProd_chancadora.porc_d_ch = oProd_chancadoraM.porc_d_ch;
                    oProd_chancadora.porc_ud_ch = oProd_chancadoraM.porc_ud_ch;
                    oProd_chancadora.porc_u_ch = oProd_chancadoraM.porc_u_ch;
                    oProd_chancadora.activo = oProd_chancadoraM.activo;
                    oProd_chancadora.usuario_crea = Session["USR_COD"].ToString(); 
                    oProd_chancadora.fecha_crea = oProd_chancadoraM.fecha_crea;
                    oProd_chancadora.usuario_mod = oProd_chancadoraM.usuario_mod;
                    oProd_chancadora.fecha_mod = oProd_chancadoraM.fecha_mod;
                    oProd_chancadora.fecha_op = Convert.ToDateTime(oProd_chancadoraM.fecha_desc);

                    Prod_chancadoraBL.registrarProd_chancadora(oProd_chancadora);
                    
                    oProd_chancadoraM.resultado = 1;
                }
                cargarCombos(oProd_chancadoraM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProd_chancadoraM.resultado = 2;
            }

            return View(oProd_chancadoraM);
        }

        // GET: Prod_chancadora/Edit/5
        public ActionResult Edit(int id)
        {
            DTOProd_chancadoraRespuesta oProd_chancadoraRpta = new DTOProd_chancadoraRespuesta();
            Prod_chancadoraBL oProd_chancadoraBL = new Prod_chancadoraBL();
            DTOProd_chancadoraM oProd_chancadoraM = new DTOProd_chancadoraM();
            try
            {
                oProd_chancadoraRpta = oProd_chancadoraBL.obtenerProd_chancadora_por_id(id);
                oProd_chancadoraM.produccion_id = oProd_chancadoraRpta.DTOProd_chancadora.produccion_id;
                oProd_chancadoraM.prod_chancadora_id = oProd_chancadoraRpta.DTOProd_chancadora.prod_chancadora_id;
                oProd_chancadoraM.fecha_op = oProd_chancadoraRpta.DTOProd_chancadora.fecha_op;
                oProd_chancadoraM.turno_id = oProd_chancadoraRpta.DTOProd_chancadora.turno_id;
                oProd_chancadoraM.viajes_ch = oProd_chancadoraRpta.DTOProd_chancadora.viajes_ch;
                oProd_chancadoraM.ton_ch_cam = oProd_chancadoraRpta.DTOProd_chancadora.ton_ch_cam;
                oProd_chancadoraM.ton_ch_ox = oProd_chancadoraRpta.DTOProd_chancadora.ton_ch_ox;
                oProd_chancadoraM.tmh_ch_ox = oProd_chancadoraRpta.DTOProd_chancadora.tmh_ch_ox;
                oProd_chancadoraM.ton_bal_faja = oProd_chancadoraRpta.DTOProd_chancadora.ton_bal_faja;
                oProd_chancadoraM.tm_acum_ini_ch = oProd_chancadoraRpta.DTOProd_chancadora.tm_acum_ini_ch;
                oProd_chancadoraM.tm_acum_fin_ch = oProd_chancadoraRpta.DTOProd_chancadora.tm_acum_fin_ch;
                oProd_chancadoraM.tmh_ch_bal = oProd_chancadoraRpta.DTOProd_chancadora.tmh_ch_bal;
                oProd_chancadoraM.h_op_ch = oProd_chancadoraRpta.DTOProd_chancadora.h_op_ch;
                oProd_chancadoraM.horas = oProd_chancadoraRpta.DTOProd_chancadora.horas;
                oProd_chancadoraM.minutos = oProd_chancadoraRpta.DTOProd_chancadora.minutos;
                oProd_chancadoraM.h_mantto_ch = oProd_chancadoraRpta.DTOProd_chancadora.h_mantto_ch;
                oProd_chancadoraM.horas_mantto = oProd_chancadoraRpta.DTOProd_chancadora.horas_mantto;
                oProd_chancadoraM.minutos_mantto = oProd_chancadoraRpta.DTOProd_chancadora.minutos_mantto;
                oProd_chancadoraM.h_operacion = oProd_chancadoraRpta.DTOProd_chancadora.h_operacion;
                oProd_chancadoraM.horas_operacion = oProd_chancadoraRpta.DTOProd_chancadora.horas_operacion;
                oProd_chancadoraM.minutos_operacion = oProd_chancadoraRpta.DTOProd_chancadora.minutos_operacion;
                oProd_chancadoraM.h_calendario = oProd_chancadoraRpta.DTOProd_chancadora.h_calendario;
                oProd_chancadoraM.porc_d_ch = oProd_chancadoraRpta.DTOProd_chancadora.porc_d_ch;
                oProd_chancadoraM.porc_ud_ch = oProd_chancadoraRpta.DTOProd_chancadora.porc_ud_ch;
                oProd_chancadoraM.porc_u_ch = oProd_chancadoraRpta.DTOProd_chancadora.porc_u_ch;
                oProd_chancadoraM.activo = oProd_chancadoraRpta.DTOProd_chancadora.activo;
                oProd_chancadoraM.usuario_crea = oProd_chancadoraRpta.DTOProd_chancadora.usuario_crea;
                oProd_chancadoraM.fecha_crea = Convert.ToDateTime(oProd_chancadoraRpta.DTOProd_chancadora.fecha_crea);
                oProd_chancadoraM.usuario_mod = oProd_chancadoraRpta.DTOProd_chancadora.usuario_mod;
                oProd_chancadoraM.fecha_mod = Convert.ToDateTime(oProd_chancadoraRpta.DTOProd_chancadora.fecha_mod);
                oProd_chancadoraM.fecha_desc = oProd_chancadoraRpta.DTOProd_chancadora.fecha_op.ToShortDateString();
                cargarCombos(oProd_chancadoraM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oProd_chancadoraM);
        }

        // POST: Prod_chancadora/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOProd_chancadoraM oProd_chancadoraM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOProd_chancadora oProd_chancadora = new DTOProd_chancadora();
                    Prod_chancadoraBL oProd_chancadoraBL = new Prod_chancadoraBL();
                    oProd_chancadora.prod_chancadora_id = oProd_chancadoraM.prod_chancadora_id;
                    oProd_chancadora.produccion_id = oProd_chancadoraM.produccion_id;
                    oProd_chancadora.turno_id = oProd_chancadoraM.turno_id;
                    oProd_chancadora.viajes_ch = oProd_chancadoraM.viajes_ch;
                    oProd_chancadora.ton_ch_cam = oProd_chancadoraM.ton_ch_cam;
                    oProd_chancadora.ton_ch_ox = oProd_chancadoraM.ton_ch_ox;
                    oProd_chancadora.tmh_ch_ox = Convert.ToDouble(oProd_chancadoraM.tmh_ch_ox_desc);
                    oProd_chancadoraM.tmh_ch_ox = Convert.ToDouble(oProd_chancadoraM.tmh_ch_ox_desc);
                    oProd_chancadora.ton_bal_faja = Convert.ToDouble(oProd_chancadoraM.ton_bal_faja_desc);
                    oProd_chancadoraM.ton_bal_faja = Convert.ToDouble(oProd_chancadoraM.ton_bal_faja_desc);
                    oProd_chancadora.tm_acum_ini_ch = oProd_chancadoraM.tm_acum_ini_ch;
                    oProd_chancadora.tm_acum_fin_ch = oProd_chancadoraM.tm_acum_fin_ch;
                    oProd_chancadora.tmh_ch_bal = Convert.ToDouble(oProd_chancadoraM.tmh_ch_bal_desc);
                    oProd_chancadoraM.tmh_ch_bal = Convert.ToDouble(oProd_chancadoraM.tmh_ch_bal_desc);
                    oProd_chancadora.h_op_ch = Convert.ToDouble(oProd_chancadoraM.h_op_ch_desc);
                    oProd_chancadora.horas = oProd_chancadoraM.horas;
                    oProd_chancadora.minutos = oProd_chancadoraM.minutos;
                    oProd_chancadora.h_mantto_ch = Convert.ToDouble(oProd_chancadoraM.h_mantto_ch_desc);
                    oProd_chancadora.horas_mantto = oProd_chancadoraM.horas_mantto;
                    oProd_chancadora.minutos_mantto = oProd_chancadoraM.minutos_mantto;
                    oProd_chancadora.h_operacion = Convert.ToDouble(oProd_chancadoraM.h_operacion_desc);
                    oProd_chancadora.horas_operacion = oProd_chancadoraM.horas_operacion;
                    oProd_chancadora.minutos_operacion = oProd_chancadoraM.minutos_operacion;
                    oProd_chancadora.h_calendario = oProd_chancadoraM.h_calendario;
                    oProd_chancadora.porc_d_ch = oProd_chancadoraM.porc_d_ch;
                    oProd_chancadora.porc_ud_ch = oProd_chancadoraM.porc_ud_ch;
                    oProd_chancadora.porc_u_ch = oProd_chancadoraM.porc_u_ch;
                    oProd_chancadora.activo = oProd_chancadoraM.activo;
                    oProd_chancadora.usuario_crea = oProd_chancadoraM.usuario_crea;
                    oProd_chancadora.fecha_crea = oProd_chancadoraM.fecha_crea;
                    oProd_chancadora.fecha_mod = oProd_chancadoraM.fecha_mod;
                    oProd_chancadora.usuario_mod = Session["USR_COD"].ToString();
                    oProd_chancadora.fecha_op = Convert.ToDateTime(oProd_chancadoraM.fecha_desc);
                    oProd_chancadoraBL.actualizarProd_chancadora(oProd_chancadora);
                    oProd_chancadoraM.resultado = 1;
                }
                cargarCombos(oProd_chancadoraM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProd_chancadoraM.resultado = 2;
            }

            return View(oProd_chancadoraM);
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