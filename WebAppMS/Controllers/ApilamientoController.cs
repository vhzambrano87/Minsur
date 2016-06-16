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
    public class ApilamientoController : Controller
    {
        // GET: Apilamiento
        public ActionResult Index()
        {
            ApilamientoBL oApilamientoBL = new ApilamientoBL();
            DTOApilamientoRespuesta oApilamientoRpta = new DTOApilamientoRespuesta();
            oApilamientoRpta = oApilamientoBL.obtenerApilamiento();
            DTOApilamientoM oApilamientoM = new DTOApilamientoM();
            List<DTOApilamientoM> oLista_ApilamientoM = new List<DTOApilamientoM>();

            if (oApilamientoRpta.DTOListaApilamiento != null)
            {
                foreach (var item in oApilamientoRpta.DTOListaApilamiento)
                {
                    oApilamientoM = new DTOApilamientoM();
                    oApilamientoM.apilamiento_id = item.apilamiento_id;
                    oApilamientoM.fecha = item.fecha;
                    oApilamientoM.turno_id = item.turno_id;
                    oApilamientoM.turno = item.turno;
                    oApilamientoM.tmh_mineral = item.tmh_mineral;
                    oApilamientoM.ley_au_mineral = item.ley_au_mineral;
                    oApilamientoM.ley_ag_mineral = item.ley_ag_mineral;
                    oApilamientoM.tmh_rom = item.tmh_rom;
                    oApilamientoM.ley_au_rom = item.ley_au_rom;
                    oApilamientoM.ley_ag_rom = item.ley_ag_rom;
                    oApilamientoM.origen = item.origen;
                    oApilamientoM.destino = item.destino;
                    oApilamientoM.ph = item.ph;
                    oApilamientoM.humedad = item.humedad;
                    oApilamientoM.ley_prom_au = item.ley_prom_au;
                    oApilamientoM.ley_prom_ag = item.ley_prom_ag;
                    oApilamientoM.onzas_au = item.onzas_au;
                    oApilamientoM.onzas_ag = item.onzas_ag;
                    oApilamientoM.densidad = item.densidad;
                    oApilamientoM.volumen = item.volumen;
                    oApilamientoM.activo = item.activo;
                    oApilamientoM.usuario_crea = item.usuario_crea;
                    oApilamientoM.fecha_crea = item.fecha_crea;
                    oApilamientoM.usuario_mod = item.usuario_mod;
                    oApilamientoM.fecha_mod = item.fecha_mod;
                    oLista_ApilamientoM.Add(oApilamientoM);
                }
            }


            return View(oLista_ApilamientoM);
        }

        // GET: Apilamiento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Apilamiento/Create
        public ActionResult Create()
        {
            DTOApilamientoM oApilamientoM = new DTOApilamientoM();
            cargarCombos(0);
            oApilamientoM.activo = true;
            oApilamientoM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oApilamientoM);
        }

        // POST: Apilamiento/Create
        [HttpPost]
        public ActionResult Create(DTOApilamientoM oApilamientoM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ApilamientoBL ApilamientoBL = new ApilamientoBL();
                    DTOApilamiento oApilamiento = new DTOApilamiento();
                    oApilamiento.apilamiento_id = oApilamientoM.apilamiento_id;
                    oApilamiento.fecha = Convert.ToDateTime(oApilamientoM.fecha_desc);
                    oApilamiento.turno_id = oApilamientoM.turno_id;
                    oApilamiento.tmh_mineral = oApilamientoM.tmh_mineral;
                    oApilamiento.ley_au_mineral = oApilamientoM.ley_au_mineral;
                    oApilamiento.ley_ag_mineral = oApilamientoM.ley_ag_mineral;
                    oApilamiento.tmh_rom = oApilamientoM.tmh_rom;
                    oApilamiento.ley_au_rom = oApilamientoM.ley_au_rom;
                    oApilamiento.ley_ag_rom = oApilamientoM.ley_ag_rom;
                    oApilamiento.origen = oApilamientoM.origen;
                    oApilamiento.destino = oApilamientoM.destino;
                    oApilamiento.ph = oApilamientoM.ph;
                    oApilamiento.humedad = oApilamientoM.humedad;
                    oApilamiento.ley_prom_au = oApilamientoM.ley_prom_au;
                    oApilamiento.ley_prom_ag = oApilamientoM.ley_prom_ag;
                    oApilamiento.onzas_au = oApilamientoM.onzas_au;
                    oApilamiento.onzas_ag = oApilamientoM.onzas_ag;
                    oApilamiento.densidad = oApilamientoM.densidad;
                    oApilamiento.volumen = oApilamientoM.volumen;
                    oApilamiento.activo = oApilamientoM.activo;
                    oApilamiento.usuario_crea = Session["USR_COD"].ToString();
                    oApilamiento.fecha_crea = oApilamientoM.fecha_crea;
                    oApilamiento.usuario_mod = oApilamientoM.usuario_mod;
                    oApilamiento.fecha_mod = oApilamientoM.fecha_mod;
                    ApilamientoBL.registrarApilamiento(oApilamiento);

                    oApilamientoM.resultado = 1;
                }
                cargarCombos(oApilamientoM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oApilamientoM.resultado = 2;
            }

            return View(oApilamientoM);
        }

        // GET: Apilamiento/Edit/5
        public ActionResult Edit(int id)
        {
            DTOApilamientoRespuesta oApilamientoRpta = new DTOApilamientoRespuesta();
            ApilamientoBL oApilamientoBL = new ApilamientoBL();
            DTOApilamientoM oApilamientoM = new DTOApilamientoM();
            try
            {
                oApilamientoRpta = oApilamientoBL.obtenerApilamiento_por_id(id);
                oApilamientoM.apilamiento_id = oApilamientoRpta.DTOApilamiento.apilamiento_id;
                oApilamientoM.fecha_desc = oApilamientoRpta.DTOApilamiento.fecha.ToShortDateString();

                oApilamientoM.turno_id = oApilamientoRpta.DTOApilamiento.turno_id;
                oApilamientoM.tmh_mineral = oApilamientoRpta.DTOApilamiento.tmh_mineral;
                oApilamientoM.ley_au_mineral = oApilamientoRpta.DTOApilamiento.ley_au_mineral;
                oApilamientoM.ley_ag_mineral = oApilamientoRpta.DTOApilamiento.ley_ag_mineral;
                oApilamientoM.tmh_rom = oApilamientoRpta.DTOApilamiento.tmh_rom;
                oApilamientoM.ley_au_rom = oApilamientoRpta.DTOApilamiento.ley_au_rom;
                oApilamientoM.ley_ag_rom = oApilamientoRpta.DTOApilamiento.ley_ag_rom;
                oApilamientoM.origen = oApilamientoRpta.DTOApilamiento.origen;
                oApilamientoM.destino = oApilamientoRpta.DTOApilamiento.destino;
                oApilamientoM.ph = oApilamientoRpta.DTOApilamiento.ph;
                oApilamientoM.humedad = oApilamientoRpta.DTOApilamiento.humedad;
                oApilamientoM.ley_prom_au = oApilamientoRpta.DTOApilamiento.ley_prom_au;
                oApilamientoM.ley_prom_ag = oApilamientoRpta.DTOApilamiento.ley_prom_ag;
                oApilamientoM.onzas_au = oApilamientoRpta.DTOApilamiento.onzas_au;
                oApilamientoM.onzas_ag = oApilamientoRpta.DTOApilamiento.onzas_ag;
                oApilamientoM.densidad = oApilamientoRpta.DTOApilamiento.densidad;
                oApilamientoM.volumen = oApilamientoRpta.DTOApilamiento.volumen;
                oApilamientoM.activo = oApilamientoRpta.DTOApilamiento.activo;
                oApilamientoM.usuario_crea = oApilamientoRpta.DTOApilamiento.usuario_crea;
                oApilamientoM.fecha_crea = oApilamientoRpta.DTOApilamiento.fecha_crea;
                oApilamientoM.usuario_mod = oApilamientoRpta.DTOApilamiento.usuario_mod;
                oApilamientoM.fecha_mod = oApilamientoRpta.DTOApilamiento.fecha_mod;
                cargarCombos(oApilamientoM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oApilamientoM);
        }

        // POST: Apilamiento/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOApilamientoM oApilamientoM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOApilamiento oApilamiento = new DTOApilamiento();
                    ApilamientoBL oApilamientoBL = new ApilamientoBL();
                    oApilamiento.apilamiento_id = oApilamientoM.apilamiento_id;
                    oApilamiento.fecha = Convert.ToDateTime(oApilamientoM.fecha_desc);
                    oApilamiento.turno_id = oApilamientoM.turno_id;
                    oApilamiento.tmh_mineral = oApilamientoM.tmh_mineral;
                    oApilamiento.ley_au_mineral = oApilamientoM.ley_au_mineral;
                    oApilamiento.ley_ag_mineral = oApilamientoM.ley_ag_mineral;
                    oApilamiento.tmh_rom = oApilamientoM.tmh_rom;
                    oApilamiento.ley_au_rom = oApilamientoM.ley_au_rom;
                    oApilamiento.ley_ag_rom = oApilamientoM.ley_ag_rom;
                    oApilamiento.origen = oApilamientoM.origen;
                    oApilamiento.destino = oApilamientoM.destino;
                    oApilamiento.ph = oApilamientoM.ph;
                    oApilamiento.humedad = oApilamientoM.humedad;
                    oApilamiento.ley_prom_au = oApilamientoM.ley_prom_au;
                    oApilamiento.ley_prom_ag = oApilamientoM.ley_prom_ag;
                    oApilamiento.onzas_au = oApilamientoM.onzas_au;
                    oApilamiento.onzas_ag = oApilamientoM.onzas_ag;
                    oApilamiento.densidad = oApilamientoM.densidad;
                    oApilamiento.volumen = oApilamientoM.volumen;
                    oApilamiento.activo = oApilamientoM.activo;
                    oApilamiento.usuario_crea = oApilamientoM.usuario_crea;
                    oApilamiento.fecha_crea = oApilamientoM.fecha_crea;
                    oApilamiento.usuario_mod = Session["USR_COD"].ToString();
                    oApilamiento.fecha_mod = oApilamientoM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oApilamientoBL.actualizarApilamiento(oApilamiento);
                    oApilamientoM.resultado = 1;
                }
                cargarCombos(oApilamientoM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oApilamientoM.resultado = 2;
            }

            return View(oApilamientoM);
        }

        // GET: Apilamiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Apilamiento/Delete/5
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