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
    public class Turno_lixController : Controller
    {
        // GET: Turno_lix
        public ActionResult Index()
        {
            Turno_lixBL oTurno_lixBL = new Turno_lixBL();
            DTOTurno_lixRespuesta oTurno_lixRpta = new DTOTurno_lixRespuesta();
            oTurno_lixRpta = oTurno_lixBL.obtenerTurno_lix();
            DTOTurno_lixM oTurno_lixM = new DTOTurno_lixM();
            List<DTOTurno_lixM> oLista_Turno_lixM = new List<DTOTurno_lixM>();

            if (oTurno_lixRpta.DTOListaTurno_lix != null)
            {
                foreach (var item in oTurno_lixRpta.DTOListaTurno_lix)
                {
                    oTurno_lixM = new DTOTurno_lixM();
                    oTurno_lixM.turno_lix_id = item.turno_lix_id;
                    oTurno_lixM.fecha = item.fecha;
                    oTurno_lixM.turno = item.turno;
                    oTurno_lixM.turno_id = item.turno_id;
                    oTurno_lixM.poza_pls = item.poza_pls;
                    oTurno_lixM.lluvia = item.lluvia;
                    oTurno_lixM.ley_oro_m1_tren_1 = item.ley_oro_m1_tren_1;
                    oTurno_lixM.ley_oro_m1_tren_2 = item.ley_oro_m1_tren_2;
                    oTurno_lixM.ley_oro_m2_tren_1 = item.ley_oro_m2_tren_1;
                    oTurno_lixM.ley_oro_m2_tren_2 = item.ley_oro_m2_tren_2;
                    oTurno_lixM.ley_oro_m3 = item.ley_oro_m3;
                    oTurno_lixM.ley_plata_m1_tren_1 = item.ley_plata_m1_tren_1;
                    oTurno_lixM.ley_plata_m1_tren_2 = item.ley_plata_m1_tren_2;
                    oTurno_lixM.ley_plata_m2_tren_1 = item.ley_plata_m2_tren_1;
                    oTurno_lixM.ley_plata_m2_tren_2 = item.ley_plata_m2_tren_2;
                    oTurno_lixM.flujo_adr_tren_1 = item.flujo_adr_tren_1;
                    oTurno_lixM.flujo_adr_tren_2 = item.flujo_adr_tren_2;
                    oTurno_lixM.flujo_lixiviacion = item.flujo_lixiviacion;
                    oTurno_lixM.factor = item.factor;
                    oTurno_lixM.flujo_adr_tren_1_calc = item.flujo_adr_tren_1_calc;
                    oTurno_lixM.flujo_adr_tren_2_calc = item.flujo_adr_tren_2_calc;
                    oTurno_lixM.flujo_lixiviacion_calc = item.flujo_lixiviacion_calc;
                    oTurno_lixM.activo = item.activo;
                    oTurno_lixM.usuario_crea = item.usuario_crea;
                    oTurno_lixM.fecha_crea = item.fecha_crea;
                    oTurno_lixM.usuario_mod = item.usuario_mod;
                    oTurno_lixM.fecha_mod = item.fecha_mod;
                    oLista_Turno_lixM.Add(oTurno_lixM);
                }
            }


            return View(oLista_Turno_lixM);
        }

        // GET: Turno_lix/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Turno_lix/Create
        public ActionResult Create()
        {
            DTOTurno_lixM oTurno = new DTOTurno_lixM();
            cargarCombos(0);
            oTurno.activo = true;
            oTurno.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oTurno);
        }

        // POST: Turno_lix/Create
        [HttpPost]
        public ActionResult Create(DTOTurno_lixM oTurno_lixM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Turno_lixBL Turno_lixBL = new Turno_lixBL();
                    DTOTurno_lix oTurno_lix = new DTOTurno_lix();
                    oTurno_lix.turno_lix_id = oTurno_lixM.turno_lix_id;
                    oTurno_lix.fecha = Convert.ToDateTime(oTurno_lixM.fecha_desc);

                    oTurno_lix.turno_id = oTurno_lixM.turno_id;
                    oTurno_lix.poza_pls = oTurno_lixM.poza_pls;
                    oTurno_lix.lluvia = oTurno_lixM.lluvia;
                    oTurno_lix.ley_oro_m1_tren_1 = oTurno_lixM.ley_oro_m1_tren_1;
                    oTurno_lix.ley_oro_m1_tren_2 = oTurno_lixM.ley_oro_m1_tren_2;
                    oTurno_lix.ley_oro_m2_tren_1 = oTurno_lixM.ley_oro_m2_tren_1;
                    oTurno_lix.ley_oro_m2_tren_2 = oTurno_lixM.ley_oro_m2_tren_2;
                    oTurno_lix.ley_oro_m3 = oTurno_lixM.ley_oro_m3;
                    oTurno_lix.ley_plata_m1_tren_1 = oTurno_lixM.ley_plata_m1_tren_1;
                    oTurno_lix.ley_plata_m1_tren_2 = oTurno_lixM.ley_plata_m1_tren_2;
                    oTurno_lix.ley_plata_m2_tren_1 = oTurno_lixM.ley_plata_m2_tren_1;
                    oTurno_lix.ley_plata_m2_tren_2 = oTurno_lixM.ley_plata_m2_tren_2;
                    oTurno_lix.flujo_adr_tren_1 = oTurno_lixM.flujo_adr_tren_1;
                    oTurno_lix.flujo_adr_tren_2 = oTurno_lixM.flujo_adr_tren_2;
                    oTurno_lix.flujo_lixiviacion = oTurno_lixM.flujo_lixiviacion;
                    oTurno_lix.factor = oTurno_lixM.factor;
                    oTurno_lix.flujo_adr_tren_1_calc = oTurno_lixM.flujo_adr_tren_1_calc;
                    oTurno_lix.flujo_adr_tren_2_calc = oTurno_lixM.flujo_adr_tren_2_calc;
                    oTurno_lix.flujo_lixiviacion_calc = oTurno_lixM.flujo_lixiviacion_calc;
                    oTurno_lix.activo = oTurno_lixM.activo;
                    oTurno_lix.usuario_crea = Session["USR_COD"].ToString();
                    oTurno_lix.fecha_crea = oTurno_lixM.fecha_crea;
                    oTurno_lix.usuario_mod = oTurno_lixM.usuario_mod;
                    oTurno_lix.fecha_mod = oTurno_lixM.fecha_mod;
                    Turno_lixBL.registrarTurno_lix(oTurno_lix);

                    oTurno_lixM.resultado = 1;
                }
                cargarCombos(oTurno_lixM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oTurno_lixM.resultado = 2;
            }

            return View(oTurno_lixM);
        }

        // GET: Turno_lix/Edit/5
        public ActionResult Edit(int id)
        {
            DTOTurno_lixRespuesta oTurno_lixRpta = new DTOTurno_lixRespuesta();
            Turno_lixBL oTurno_lixBL = new Turno_lixBL();
            DTOTurno_lixM oTurno_lixM = new DTOTurno_lixM();
            try
            {
                oTurno_lixRpta = oTurno_lixBL.obtenerTurno_lix_por_id(id);
                oTurno_lixM.turno_lix_id = oTurno_lixRpta.DTOTurno_lix.turno_lix_id;
                oTurno_lixM.fecha = oTurno_lixRpta.DTOTurno_lix.fecha;
                oTurno_lixM.fecha_desc = oTurno_lixRpta.DTOTurno_lix.fecha.ToShortDateString();
                oTurno_lixM.turno_id = oTurno_lixRpta.DTOTurno_lix.turno_id;
                oTurno_lixM.poza_pls = oTurno_lixRpta.DTOTurno_lix.poza_pls;
                oTurno_lixM.lluvia = oTurno_lixRpta.DTOTurno_lix.lluvia;
                oTurno_lixM.ley_oro_m1_tren_1 = oTurno_lixRpta.DTOTurno_lix.ley_oro_m1_tren_1;
                oTurno_lixM.ley_oro_m1_tren_2 = oTurno_lixRpta.DTOTurno_lix.ley_oro_m1_tren_2;
                oTurno_lixM.ley_oro_m2_tren_1 = oTurno_lixRpta.DTOTurno_lix.ley_oro_m2_tren_1;
                oTurno_lixM.ley_oro_m2_tren_2 = oTurno_lixRpta.DTOTurno_lix.ley_oro_m2_tren_2;
                oTurno_lixM.ley_oro_m3 = oTurno_lixRpta.DTOTurno_lix.ley_oro_m3;
                oTurno_lixM.ley_plata_m1_tren_1 = oTurno_lixRpta.DTOTurno_lix.ley_plata_m1_tren_1;
                oTurno_lixM.ley_plata_m1_tren_2 = oTurno_lixRpta.DTOTurno_lix.ley_plata_m1_tren_2;
                oTurno_lixM.ley_plata_m2_tren_1 = oTurno_lixRpta.DTOTurno_lix.ley_plata_m2_tren_1;
                oTurno_lixM.ley_plata_m2_tren_2 = oTurno_lixRpta.DTOTurno_lix.ley_plata_m2_tren_2;
                oTurno_lixM.flujo_adr_tren_1 = oTurno_lixRpta.DTOTurno_lix.flujo_adr_tren_1;
                oTurno_lixM.flujo_adr_tren_2 = oTurno_lixRpta.DTOTurno_lix.flujo_adr_tren_2;
                oTurno_lixM.flujo_lixiviacion = oTurno_lixRpta.DTOTurno_lix.flujo_lixiviacion;
                oTurno_lixM.factor = oTurno_lixRpta.DTOTurno_lix.factor;
                oTurno_lixM.flujo_adr_tren_1_calc = oTurno_lixRpta.DTOTurno_lix.flujo_adr_tren_1_calc;
                oTurno_lixM.flujo_adr_tren_2_calc = oTurno_lixRpta.DTOTurno_lix.flujo_adr_tren_2_calc;
                oTurno_lixM.flujo_lixiviacion_calc = oTurno_lixRpta.DTOTurno_lix.flujo_lixiviacion_calc;
                oTurno_lixM.activo = oTurno_lixRpta.DTOTurno_lix.activo;
                oTurno_lixM.usuario_crea = oTurno_lixRpta.DTOTurno_lix.usuario_crea;
                oTurno_lixM.fecha_crea = oTurno_lixRpta.DTOTurno_lix.fecha_crea;
                oTurno_lixM.usuario_mod = oTurno_lixRpta.DTOTurno_lix.usuario_mod;
                oTurno_lixM.fecha_mod = oTurno_lixRpta.DTOTurno_lix.fecha_mod;
                cargarCombos(oTurno_lixM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oTurno_lixM);
        }

        // POST: Turno_lix/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOTurno_lixM oTurno_lixM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOTurno_lix oTurno_lix = new DTOTurno_lix();
                    Turno_lixBL oTurno_lixBL = new Turno_lixBL();
                    oTurno_lix.turno_lix_id = oTurno_lixM.turno_lix_id;
                    oTurno_lix.fecha = Convert.ToDateTime(oTurno_lixM.fecha_desc);
                   
                    oTurno_lix.turno_id = oTurno_lixM.turno_id;
                    oTurno_lix.poza_pls = oTurno_lixM.poza_pls;
                    oTurno_lix.lluvia = oTurno_lixM.lluvia;
                    oTurno_lix.ley_oro_m1_tren_1 = oTurno_lixM.ley_oro_m1_tren_1;
                    oTurno_lix.ley_oro_m1_tren_2 = oTurno_lixM.ley_oro_m1_tren_2;
                    oTurno_lix.ley_oro_m2_tren_1 = oTurno_lixM.ley_oro_m2_tren_1;
                    oTurno_lix.ley_oro_m2_tren_2 = oTurno_lixM.ley_oro_m2_tren_2;
                    oTurno_lix.ley_oro_m3 = oTurno_lixM.ley_oro_m3;
                    oTurno_lix.ley_plata_m1_tren_1 = oTurno_lixM.ley_plata_m1_tren_1;
                    oTurno_lix.ley_plata_m1_tren_2 = oTurno_lixM.ley_plata_m1_tren_2;
                    oTurno_lix.ley_plata_m2_tren_1 = oTurno_lixM.ley_plata_m2_tren_1;
                    oTurno_lix.ley_plata_m2_tren_2 = oTurno_lixM.ley_plata_m2_tren_2;
                    oTurno_lix.flujo_adr_tren_1 = oTurno_lixM.flujo_adr_tren_1;
                    oTurno_lix.flujo_adr_tren_2 = oTurno_lixM.flujo_adr_tren_2;
                    oTurno_lix.flujo_lixiviacion = oTurno_lixM.flujo_lixiviacion;
                    oTurno_lix.factor = oTurno_lixM.factor;
                    oTurno_lix.flujo_adr_tren_1_calc = oTurno_lixM.flujo_adr_tren_1_calc;
                    oTurno_lix.flujo_adr_tren_2_calc = oTurno_lixM.flujo_adr_tren_2_calc;
                    oTurno_lix.flujo_lixiviacion_calc = oTurno_lixM.flujo_lixiviacion_calc;
                    oTurno_lix.activo = oTurno_lixM.activo;
                    oTurno_lix.usuario_crea = oTurno_lixM.usuario_crea;
                    oTurno_lix.fecha_crea = oTurno_lixM.fecha_crea;
                    oTurno_lix.usuario_mod = Session["USR_COD"].ToString();
                    oTurno_lix.fecha_mod = oTurno_lixM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oTurno_lixBL.actualizarTurno_lix(oTurno_lix);
                    oTurno_lixM.resultado = 1;
                }
                cargarCombos(oTurno_lixM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oTurno_lixM.resultado = 2;
            }

            return View(oTurno_lixM);
        }

        // GET: Turno_lix/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Turno_lix/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void cargarCombos(int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurnoLix"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);


            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}