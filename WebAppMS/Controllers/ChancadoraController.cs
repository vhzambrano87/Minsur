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
    public class ChancadoraController : Controller
    {
        // GET: Chancadora
        public ActionResult Index()
        {
            ChancadoraBL oChancadoraBL = new ChancadoraBL();
            DTOChancadoraRespuesta oChancadoraRpta = new DTOChancadoraRespuesta();
            oChancadoraRpta = oChancadoraBL.obtenerChancadora();
            DTOChancadoraM oChancadoraM = new DTOChancadoraM();
            List<DTOChancadoraM> oLista_ChancadoraM = new List<DTOChancadoraM>();

            if (oChancadoraRpta.DTOListaChancadora != null)
            {
                foreach (var item in oChancadoraRpta.DTOListaChancadora)
                {
                    oChancadoraM = new DTOChancadoraM(); oChancadoraM.chancadora_id = item.chancadora_id;
                    oChancadoraM.fecha = item.fecha;
                    oChancadoraM.guardia_id = item.guardia_id;
                    oChancadoraM.turno_id = item.turno_id;
                    oChancadoraM.ch_ore_bin_id = item.ch_ore_bin_id;
                    oChancadoraM.tipo_actividad_id = item.tipo_actividad_id;
                    oChancadoraM.hora_inicio = item.hora_inicio;
                    oChancadoraM.hora_fin = item.hora_fin;
                    oChancadoraM.comentarios = item.comentarios;
                    oChancadoraM.activo = item.activo;
                    oChancadoraM.usuario_crea = item.usuario_crea;
                    oChancadoraM.fecha_crea = item.fecha_crea;
                    oChancadoraM.usuario_mod = item.usuario_mod;
                    oChancadoraM.fecha_mod = item.fecha_mod;
                    oChancadoraM.guardia_desc = item.guardia_desc;
                    oChancadoraM.turno_desc = item.turno_desc;
                    oChancadoraM.ch_ore_bin_desc = item.ch_ore_bin_desc;
                    oChancadoraM.tipo_actividad_desc = item.tipo_actividad_desc;
                    oLista_ChancadoraM.Add(oChancadoraM);
                }
            }


            return View(oLista_ChancadoraM);
        }

        // GET: Chancadora/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Chancadora/Create
        public ActionResult Create()
        {
            DTOChancadoraM oChancadoraM = new DTOChancadoraM();
            cargarCombos(0, 0, 0, 0);
            oChancadoraM.activo = true;
            oChancadoraM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oChancadoraM);
        }

        // POST: Chancadora/Create
        [HttpPost]
        public ActionResult Create(DTOChancadoraM oChancadoraM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ChancadoraBL ChancadoraBL = new ChancadoraBL();
                    DTOChancadora oChancadora = new DTOChancadora(); oChancadora.chancadora_id = oChancadoraM.chancadora_id;
                    oChancadora.fecha = oChancadoraM.fecha;
                    oChancadora.guardia_id = oChancadoraM.guardia_id;
                    oChancadora.turno_id = oChancadoraM.turno_id;
                    oChancadora.ch_ore_bin_id = oChancadoraM.ch_ore_bin_id;
                    oChancadora.tipo_actividad_id = oChancadoraM.tipo_actividad_id;
                    oChancadora.hora_inicio = oChancadoraM.hora_inicio;
                    oChancadora.hora_fin = oChancadoraM.hora_fin;
                    oChancadora.comentarios = oChancadoraM.comentarios;
                    oChancadora.activo = oChancadoraM.activo;
                    oChancadora.usuario_crea = oChancadoraM.usuario_crea;
                    oChancadora.fecha_crea = oChancadoraM.fecha_crea;
                    oChancadora.usuario_mod = oChancadoraM.usuario_mod;
                    oChancadora.fecha_mod = oChancadoraM.fecha_mod;
                    ChancadoraBL.registrarChancadora(oChancadora);
                    oChancadoraM.chancadora_id = 0;
                    oChancadoraM.fecha = null;
                    oChancadoraM.guardia_id = 0;
                    oChancadoraM.turno_id = 0;
                    oChancadoraM.ch_ore_bin_id = 0;
                    oChancadoraM.tipo_actividad_id = 0;
                    oChancadoraM.hora_inicio = "";
                    oChancadoraM.hora_fin = "";
                    oChancadoraM.comentarios = "";
                    oChancadoraM.activo = false;
                    oChancadoraM.usuario_crea = Session["USR_COD"].ToString();
                    oChancadoraM.fecha_crea = null;
                    oChancadoraM.usuario_mod = "";
                    oChancadoraM.fecha_mod = null;
                    oChancadoraM.resultado = 1;
                }
                cargarCombos(oChancadoraM.guardia_id, oChancadoraM.turno_id, oChancadoraM.ch_ore_bin_id, oChancadoraM.tipo_actividad_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oChancadoraM.resultado = 2;
            }

            return View(oChancadoraM);
        }

        // GET: Chancadora/Edit/5
        public ActionResult Edit(int id)
        {
            DTOChancadoraRespuesta oChancadoraRpta = new DTOChancadoraRespuesta();
            ChancadoraBL oChancadoraBL = new ChancadoraBL();
            DTOChancadoraM oChancadoraM = new DTOChancadoraM();
            try
            {

                oChancadoraRpta = oChancadoraBL.obtenerChancadora_por_id(id);
                oChancadoraM.chancadora_id = oChancadoraRpta.DTOChancadora.chancadora_id;
                oChancadoraM.fecha = oChancadoraRpta.DTOChancadora.fecha;
                oChancadoraM.guardia_id = oChancadoraRpta.DTOChancadora.guardia_id;
                oChancadoraM.turno_id = oChancadoraRpta.DTOChancadora.turno_id;
                oChancadoraM.ch_ore_bin_id = oChancadoraRpta.DTOChancadora.ch_ore_bin_id;
                oChancadoraM.tipo_actividad_id = oChancadoraRpta.DTOChancadora.tipo_actividad_id;
                oChancadoraM.hora_inicio = oChancadoraRpta.DTOChancadora.hora_inicio;
                oChancadoraM.hora_fin = oChancadoraRpta.DTOChancadora.hora_fin;
                oChancadoraM.comentarios = oChancadoraRpta.DTOChancadora.comentarios;
                oChancadoraM.activo = oChancadoraRpta.DTOChancadora.activo;
                oChancadoraM.usuario_crea = oChancadoraRpta.DTOChancadora.usuario_crea;
                oChancadoraM.fecha_crea = oChancadoraRpta.DTOChancadora.fecha_crea;
                oChancadoraM.usuario_mod = oChancadoraRpta.DTOChancadora.usuario_mod;
                oChancadoraM.fecha_mod = oChancadoraRpta.DTOChancadora.fecha_mod;

                oChancadoraM.hora_hora_ini = oChancadoraM.hora_inicio.Substring(0, 2);
                oChancadoraM.hora_min_ini = oChancadoraM.hora_inicio.Substring(3, 2);


                oChancadoraM.hora_hora_fin = oChancadoraM.hora_fin.Substring(0, 2);
                oChancadoraM.hora_min_fin = oChancadoraM.hora_fin.Substring(3, 2);

                cargarCombos(oChancadoraRpta.DTOChancadora.guardia_id, oChancadoraRpta.DTOChancadora.turno_id, oChancadoraRpta.DTOChancadora.ch_ore_bin_id, oChancadoraRpta.DTOChancadora.tipo_actividad_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oChancadoraM);
        }

        // POST: Chancadora/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOChancadoraM oChancadoraM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOChancadora oChancadora = new DTOChancadora();
                    ChancadoraBL oChancadoraBL = new ChancadoraBL();
                    oChancadora.chancadora_id = oChancadoraM.chancadora_id;
                    oChancadora.fecha = oChancadoraM.fecha;
                    oChancadora.guardia_id = oChancadoraM.guardia_id;
                    oChancadora.turno_id = oChancadoraM.turno_id;
                    oChancadora.ch_ore_bin_id = oChancadoraM.ch_ore_bin_id;
                    oChancadora.tipo_actividad_id = oChancadoraM.tipo_actividad_id;
                    oChancadora.hora_inicio = oChancadoraM.hora_inicio;
                    oChancadoraM.hora_hora_ini = oChancadoraM.hora_inicio.Substring(0, 2);
                    oChancadoraM.hora_min_ini = oChancadoraM.hora_inicio.Substring(3, 2);

                    oChancadoraM.hora_hora_fin = oChancadoraM.hora_fin.Substring(0, 2);
                    oChancadoraM.hora_min_fin = oChancadoraM.hora_fin.Substring(3, 2);


                    oChancadora.hora_fin = oChancadoraM.hora_fin;
                    oChancadora.comentarios = oChancadoraM.comentarios;
                    oChancadora.activo = oChancadoraM.activo;
                    oChancadora.usuario_crea = oChancadoraM.usuario_crea;
                    oChancadora.fecha_crea = oChancadoraM.fecha_crea;
                    oChancadora.usuario_mod = Session["USR_COD"].ToString();
                    oChancadora.fecha_mod = oChancadoraM.fecha_mod;


                    //oLista.usuario_mod = "MS_USER";

                    oChancadoraBL.actualizarChancadora(oChancadora);
                    oChancadoraM.resultado = 1;
                }
                cargarCombos(oChancadoraM.guardia_id, oChancadoraM.turno_id, oChancadoraM.ch_ore_bin_id, oChancadoraM.tipo_actividad_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oChancadoraM.resultado = 2;
            }

            return View(oChancadoraM);
        }

        // GET: Chancadora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chancadora/Delete/5
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

        public void cargarCombos(int guardia_id, int turno_id, int ch_ore_bin_id, int tipo_actividad_id)
        {
            try
            {
                DTOLista_valorRespuesta oListaTurnoRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_guardia = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_tipo_actividad = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_ch_ore_bin = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();

                int lista_gardia_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaGuardia"]);
                int lista_turno_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaTurno"]);
                int lista_ch_ore_bin_id = Convert.ToInt16(ConfigurationManager.AppSettings["Listach_ore_bin"]);
                int lista_tipo_actividad_id = Convert.ToInt16(ConfigurationManager.AppSettings["Listatipo_actividad"]);


                oLista_guardia = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_gardia_id).ToList();
                ViewBag.ListaGuardia = new SelectList(oLista_guardia, "lista_valor_id", "valor", guardia_id);

                oLista_turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_turno_id).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_turno, "lista_valor_id", "valor", turno_id);

                oLista_ch_ore_bin = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_ch_ore_bin_id).ToList();
                ViewBag.Lista_ch_ore_bin = new SelectList(oLista_ch_ore_bin, "lista_valor_id", "valor", ch_ore_bin_id);

                oLista_tipo_actividad = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_tipo_actividad_id).ToList();
                ViewBag.Lista_tipo_actividad = new SelectList(oLista_tipo_actividad, "lista_valor_id", "valor", tipo_actividad_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}