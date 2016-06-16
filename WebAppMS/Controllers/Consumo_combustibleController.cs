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
    public class Consumo_combustibleController : Controller
    {
        // GET: Consumo_combustible
        public ActionResult Index()
        {
            Consumo_combustibleBL oConsumo_combustibleBL = new Consumo_combustibleBL();
            DTOConsumo_combustibleRespuesta oConsumo_combustibleRpta = new DTOConsumo_combustibleRespuesta();
            oConsumo_combustibleRpta = oConsumo_combustibleBL.obtenerConsumo_combustible();
            DTOConsumo_combustibleM oConsumo_combustibleM = new DTOConsumo_combustibleM();
            List<DTOConsumo_combustibleM> oLista_Consumo_combustibleM = new List<DTOConsumo_combustibleM>();

            if (oConsumo_combustibleRpta.DTOListaConsumo_combustible != null)
            {
                foreach (var item in oConsumo_combustibleRpta.DTOListaConsumo_combustible)
                {
                    oConsumo_combustibleM = new DTOConsumo_combustibleM(); oConsumo_combustibleM.consumo_combustible_id = item.consumo_combustible_id;
                    oConsumo_combustibleM.fecha = item.fecha;
                    oConsumo_combustibleM.guardia_id = item.guardia_id;
                    oConsumo_combustibleM.turno_id = item.turno_id;
                    oConsumo_combustibleM.equipo_id = item.equipo_id;
                    oConsumo_combustibleM.galones = item.galones;
                    oConsumo_combustibleM.operador_id = item.operador_id;
                    oConsumo_combustibleM.activo = item.activo;
                    oConsumo_combustibleM.usuario_crea = item.usuario_crea;
                    oConsumo_combustibleM.fecha_crea = item.fecha_crea;
                    oConsumo_combustibleM.usuario_mod = item.usuario_mod;
                    oConsumo_combustibleM.fecha_mod = item.fecha_mod;
                    oConsumo_combustibleM.guardia_desc = item.guardia_desc;
                    oConsumo_combustibleM.turno_desc = item.turno_desc;
                    oConsumo_combustibleM.operador_desc = item.operador_desc;
                    oConsumo_combustibleM.equipo_desc = item.equipo_desc;
                    oLista_Consumo_combustibleM.Add(oConsumo_combustibleM);
                }
            }


            return View(oLista_Consumo_combustibleM);
        }

        // GET: Consumo_combustible/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consumo_combustible/Create
        public ActionResult Create()
        {
            DTOConsumo_combustibleM oConsumo_combustibleM = new DTOConsumo_combustibleM();
            cargarCombos(0, 0, 0, 0);
            oConsumo_combustibleM.activo = true;
            oConsumo_combustibleM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oConsumo_combustibleM);
        }

        // POST: Consumo_combustible/Create
        [HttpPost]
        public ActionResult Create(DTOConsumo_combustibleM oConsumo_combustibleM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Consumo_combustibleBL Consumo_combustibleBL = new Consumo_combustibleBL();
                    DTOConsumo_combustible oConsumo_combustible = new DTOConsumo_combustible(); oConsumo_combustible.consumo_combustible_id = oConsumo_combustibleM.consumo_combustible_id;
                    oConsumo_combustible.fecha = oConsumo_combustibleM.fecha;
                    oConsumo_combustible.guardia_id = oConsumo_combustibleM.guardia_id;
                    oConsumo_combustible.turno_id = oConsumo_combustibleM.turno_id;
                    oConsumo_combustible.equipo_id = oConsumo_combustibleM.equipo_id;
                    oConsumo_combustible.galones = oConsumo_combustibleM.galones;
                    oConsumo_combustible.operador_id = oConsumo_combustibleM.operador_id;
                    oConsumo_combustible.activo = oConsumo_combustibleM.activo;
                    oConsumo_combustible.usuario_crea = Session["USR_COD"].ToString();
                    oConsumo_combustible.fecha_crea = oConsumo_combustibleM.fecha_crea;
                    oConsumo_combustible.usuario_mod = oConsumo_combustibleM.usuario_mod;
                    oConsumo_combustible.fecha_mod = oConsumo_combustibleM.fecha_mod;
                    Consumo_combustibleBL.registrarConsumo_combustible(oConsumo_combustible);

                    oConsumo_combustibleM.resultado = 1;
                }
                cargarCombos(oConsumo_combustibleM.guardia_id, oConsumo_combustibleM.turno_id, oConsumo_combustibleM.equipo_id, oConsumo_combustibleM.operador_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oConsumo_combustibleM.resultado = 2;
            }

            return View(oConsumo_combustibleM);
        }

        // GET: Consumo_combustible/Edit/5
        public ActionResult Edit(int id)
        {
            DTOConsumo_combustibleRespuesta oConsumo_combustibleRpta = new DTOConsumo_combustibleRespuesta();
            Consumo_combustibleBL oConsumo_combustibleBL = new Consumo_combustibleBL();
            DTOConsumo_combustibleM oConsumo_combustibleM = new DTOConsumo_combustibleM();
            try
            {
                oConsumo_combustibleRpta = oConsumo_combustibleBL.obtenerConsumo_combustible_por_id(id);
                oConsumo_combustibleM.consumo_combustible_id = oConsumo_combustibleRpta.DTOConsumo_combustible.consumo_combustible_id;
                oConsumo_combustibleM.fecha = oConsumo_combustibleRpta.DTOConsumo_combustible.fecha;
                oConsumo_combustibleM.guardia_id = oConsumo_combustibleRpta.DTOConsumo_combustible.guardia_id;
                oConsumo_combustibleM.turno_id = oConsumo_combustibleRpta.DTOConsumo_combustible.turno_id;
                oConsumo_combustibleM.equipo_id = oConsumo_combustibleRpta.DTOConsumo_combustible.equipo_id;
                oConsumo_combustibleM.galones = oConsumo_combustibleRpta.DTOConsumo_combustible.galones;
                oConsumo_combustibleM.operador_id = oConsumo_combustibleRpta.DTOConsumo_combustible.operador_id;
                oConsumo_combustibleM.activo = oConsumo_combustibleRpta.DTOConsumo_combustible.activo;
                oConsumo_combustibleM.usuario_crea = oConsumo_combustibleRpta.DTOConsumo_combustible.usuario_crea;
                oConsumo_combustibleM.fecha_crea = oConsumo_combustibleRpta.DTOConsumo_combustible.fecha_crea;
                oConsumo_combustibleM.usuario_mod = oConsumo_combustibleRpta.DTOConsumo_combustible.usuario_mod;
                oConsumo_combustibleM.fecha_mod = oConsumo_combustibleRpta.DTOConsumo_combustible.fecha_mod;
                cargarCombos(oConsumo_combustibleRpta.DTOConsumo_combustible.guardia_id, oConsumo_combustibleRpta.DTOConsumo_combustible.turno_id, oConsumo_combustibleRpta.DTOConsumo_combustible.equipo_id, oConsumo_combustibleRpta.DTOConsumo_combustible.operador_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oConsumo_combustibleM);
        }

        // POST: Consumo_combustible/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOConsumo_combustibleM oConsumo_combustibleM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOConsumo_combustible oConsumo_combustible = new DTOConsumo_combustible();
                    Consumo_combustibleBL oConsumo_combustibleBL = new Consumo_combustibleBL();
                    oConsumo_combustible.consumo_combustible_id = oConsumo_combustibleM.consumo_combustible_id;
                    oConsumo_combustible.fecha = oConsumo_combustibleM.fecha;
                    oConsumo_combustible.guardia_id = oConsumo_combustibleM.guardia_id;
                    oConsumo_combustible.turno_id = oConsumo_combustibleM.turno_id;
                    oConsumo_combustible.equipo_id = oConsumo_combustibleM.equipo_id;
                    oConsumo_combustible.galones = oConsumo_combustibleM.galones;
                    oConsumo_combustible.operador_id = oConsumo_combustibleM.operador_id;
                    oConsumo_combustible.activo = oConsumo_combustibleM.activo;
                    oConsumo_combustible.usuario_crea = oConsumo_combustibleM.usuario_crea;
                    oConsumo_combustible.fecha_crea = oConsumo_combustibleM.fecha_crea;
                    oConsumo_combustible.usuario_mod = Session["USR_COD"].ToString();
                    oConsumo_combustible.fecha_mod = oConsumo_combustibleM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oConsumo_combustibleBL.actualizarConsumo_combustible(oConsumo_combustible);
                    oConsumo_combustibleM.resultado = 1;
                }
                cargarCombos(oConsumo_combustibleM.guardia_id, oConsumo_combustibleM.turno_id, oConsumo_combustibleM.equipo_id, oConsumo_combustibleM.operador_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oConsumo_combustibleM.resultado = 2;
            }

            return View(oConsumo_combustibleM);
        }

        // GET: Consumo_combustible/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consumo_combustible/Delete/5
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

        public void cargarCombos(int guardia_id, int turno_id, int equipo_id, int operador_id)
        {
            try
            {
                DTOLista_valorRespuesta oListaTurnoRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_guardia = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_equipo = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_operador = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();

                int lista_gardia_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaGuardia"]);
                int lista_turno_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaTurno"]);
                int lista_equipo_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaEquipo"]);
                int lista_operador_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaOperario"]);

                oLista_guardia = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_gardia_id).ToList();
                ViewBag.ListaGuardia = new SelectList(oLista_guardia, "lista_valor_id", "valor", guardia_id);

                oLista_turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_turno_id).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_turno, "lista_valor_id", "valor", turno_id);

                oLista_equipo = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_equipo_id).ToList();
                ViewBag.ListaEquipo = new SelectList(oLista_equipo, "lista_valor_id", "valor", equipo_id);

                oLista_operador = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_operador_id).ToList();
                ViewBag.ListaOperador = new SelectList(oLista_operador, "lista_valor_id", "valor", operador_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}