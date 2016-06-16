using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMS.Models;

namespace WebAppMS.Controllers
{
    public class Control_dig_lixiviacionController : Controller
    {
        // GET: Control_dig_lixiviacion
        public ActionResult Index()
        {
            Control_dig_lixiviacionBL oControl_dig_lixiviacionBL = new Control_dig_lixiviacionBL();
            DTOControl_dig_lixiviacionRespuesta oControl_dig_lixiviacionRpta = new DTOControl_dig_lixiviacionRespuesta();
            oControl_dig_lixiviacionRpta = oControl_dig_lixiviacionBL.obtenerControl_dig_lixiviacion();
            DTOControl_dig_lixiviacionM oControl_dig_lixiviacionM = new DTOControl_dig_lixiviacionM();
            List<DTOControl_dig_lixiviacionM> oLista_Control_dig_lixiviacionM = new List<DTOControl_dig_lixiviacionM>();

            if (oControl_dig_lixiviacionRpta.DTOListaControl_dig_lixiviacion != null)
            {
                foreach (var item in oControl_dig_lixiviacionRpta.DTOListaControl_dig_lixiviacion)
                {
                    oControl_dig_lixiviacionM = new DTOControl_dig_lixiviacionM(); oControl_dig_lixiviacionM.control_dig_lix_id = item.control_dig_lix_id;
                    oControl_dig_lixiviacionM.fecha = item.fecha;
                    oControl_dig_lixiviacionM.turno_id = item.turno_id;
                    oControl_dig_lixiviacionM.celda_id = item.celda_id;
                    oControl_dig_lixiviacionM.tecnico_lixiviacion_id = item.tecnico_lixiviacion_id;
                    oControl_dig_lixiviacionM.tecnico_apilamiento_id = item.tecnico_apilamiento_id;

                    oControl_dig_lixiviacionM.turno = item.turno;
                    oControl_dig_lixiviacionM.celda = item.celda;
                    oControl_dig_lixiviacionM.tecnico_lixiviacion = item.tecnico_lixiviacion;
                    oControl_dig_lixiviacionM.tecnico_apilamiento = item.tecnico_apilamiento;
                    oControl_dig_lixiviacionM.nro_viajes = item.nro_viajes;
                    oControl_dig_lixiviacionM.celda_opc = item.celda_opc;
                    oControl_dig_lixiviacionM.nro_camiones = item.nro_camiones;
                    oControl_dig_lixiviacionM.ley_mineral = item.ley_mineral;
                    oControl_dig_lixiviacionM.poligono = item.poligono;
                    oControl_dig_lixiviacionM.pluviometro = item.pluviometro;
                    oControl_dig_lixiviacionM.cal_viva = item.cal_viva;
                    oControl_dig_lixiviacionM.cal_hidratada = item.cal_hidratada;
                    oControl_dig_lixiviacionM.corte = item.corte;
                    oControl_dig_lixiviacionM.ripeo = item.ripeo;
                    oControl_dig_lixiviacionM.totalizador_tk_2 = item.totalizador_tk_2;
                    oControl_dig_lixiviacionM.nivel_tk_2 = item.nivel_tk_2;
                    oControl_dig_lixiviacionM.presion_flujo = item.presion_flujo;
                    oControl_dig_lixiviacionM.comentarios = item.comentarios;
                    oControl_dig_lixiviacionM.flujo = item.flujo;
                    oControl_dig_lixiviacionM.presion_adr = item.presion_adr;
                    oControl_dig_lixiviacionM.presion_sump = item.presion_sump;
                    oControl_dig_lixiviacionM.presion_925 = item.presion_925;
                    oControl_dig_lixiviacionM.activo = item.activo;
                    oControl_dig_lixiviacionM.usuario_crea = item.usuario_crea;
                    oControl_dig_lixiviacionM.fecha_crea = item.fecha_crea;
                    oControl_dig_lixiviacionM.usuario_mod = item.usuario_mod;
                    oControl_dig_lixiviacionM.fecha_mod = item.fecha_mod;
                    oLista_Control_dig_lixiviacionM.Add(oControl_dig_lixiviacionM);
                }
            }


            return View(oLista_Control_dig_lixiviacionM);
        }

        // GET: Control_dig_lixiviacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Control_dig_lixiviacion/Create
        public ActionResult Create()
        {
            DTOControl_dig_lixiviacionM oControlM = new DTOControl_dig_lixiviacionM();
            oControlM.activo = true;
            oControlM.fecha_desc = DateTime.Today.ToShortDateString();
            
            cargarCombos(0,0,0,0);
            return View(oControlM);
        }

        // POST: Control_dig_lixiviacion/Create
        [HttpPost]
        public ActionResult Create(DTOControl_dig_lixiviacionM oControl_dig_lixiviacionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Control_dig_lixiviacionBL Control_dig_lixiviacionBL = new Control_dig_lixiviacionBL();
                    DTOControl_dig_lixiviacion oControl_dig_lixiviacion = new DTOControl_dig_lixiviacion(); oControl_dig_lixiviacion.control_dig_lix_id = oControl_dig_lixiviacionM.control_dig_lix_id;
                    oControl_dig_lixiviacion.fecha = Convert.ToDateTime(oControl_dig_lixiviacionM.fecha_desc);
                    oControl_dig_lixiviacion.turno_id = oControl_dig_lixiviacionM.turno_id;
                    oControl_dig_lixiviacion.celda_id = oControl_dig_lixiviacionM.celda_id;
                    oControl_dig_lixiviacion.tecnico_lixiviacion_id = oControl_dig_lixiviacionM.tecnico_lixiviacion_id;
                    oControl_dig_lixiviacion.tecnico_apilamiento_id = oControl_dig_lixiviacionM.tecnico_apilamiento_id;
                    oControl_dig_lixiviacion.nro_viajes = oControl_dig_lixiviacionM.nro_viajes;
                    oControl_dig_lixiviacion.celda_opc = oControl_dig_lixiviacionM.celda_opc;
                    oControl_dig_lixiviacion.nro_camiones = oControl_dig_lixiviacionM.nro_camiones;
                    oControl_dig_lixiviacion.ley_mineral = oControl_dig_lixiviacionM.ley_mineral;
                    oControl_dig_lixiviacion.poligono = oControl_dig_lixiviacionM.poligono;
                    oControl_dig_lixiviacion.pluviometro = oControl_dig_lixiviacionM.pluviometro;
                    oControl_dig_lixiviacion.cal_viva = oControl_dig_lixiviacionM.cal_viva;
                    oControl_dig_lixiviacion.cal_hidratada = oControl_dig_lixiviacionM.cal_hidratada;
                    oControl_dig_lixiviacion.corte = oControl_dig_lixiviacionM.corte;
                    oControl_dig_lixiviacion.ripeo = oControl_dig_lixiviacionM.ripeo;
                    oControl_dig_lixiviacion.totalizador_tk_2 = oControl_dig_lixiviacionM.totalizador_tk_2;
                    oControl_dig_lixiviacion.nivel_tk_2 = oControl_dig_lixiviacionM.nivel_tk_2;
                    oControl_dig_lixiviacion.presion_flujo = oControl_dig_lixiviacionM.presion_flujo;
                    oControl_dig_lixiviacion.comentarios = oControl_dig_lixiviacionM.comentarios;
                    oControl_dig_lixiviacion.flujo = oControl_dig_lixiviacionM.flujo;
                    oControl_dig_lixiviacion.presion_adr = oControl_dig_lixiviacionM.presion_adr;
                    oControl_dig_lixiviacion.presion_sump = oControl_dig_lixiviacionM.presion_sump;
                    oControl_dig_lixiviacion.presion_925 = oControl_dig_lixiviacionM.presion_925;
                    oControl_dig_lixiviacion.activo = oControl_dig_lixiviacionM.activo;
                    oControl_dig_lixiviacion.usuario_crea = Session["USR_COD"].ToString();
                    oControl_dig_lixiviacion.fecha_crea = oControl_dig_lixiviacionM.fecha_crea;
                    oControl_dig_lixiviacion.usuario_mod = oControl_dig_lixiviacionM.usuario_mod;
                    oControl_dig_lixiviacion.fecha_mod = oControl_dig_lixiviacionM.fecha_mod;
                    Control_dig_lixiviacionBL.registrarControl_dig_lixiviacion(oControl_dig_lixiviacion);

                    oControl_dig_lixiviacionM.resultado = 1;
                }
                cargarCombos(oControl_dig_lixiviacionM.turno_id, oControl_dig_lixiviacionM.celda_id, oControl_dig_lixiviacionM.tecnico_lixiviacion_id, oControl_dig_lixiviacionM.tecnico_apilamiento_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oControl_dig_lixiviacionM.resultado = 2;
            }

            return View(oControl_dig_lixiviacionM);
        }

        // GET: Control_dig_lixiviacion/Edit/5
        public ActionResult Edit(int id)
        {
            DTOControl_dig_lixiviacionRespuesta oControl_dig_lixiviacionRpta = new DTOControl_dig_lixiviacionRespuesta();
            Control_dig_lixiviacionBL oControl_dig_lixiviacionBL = new Control_dig_lixiviacionBL();
            DTOControl_dig_lixiviacionM oControl_dig_lixiviacionM = new DTOControl_dig_lixiviacionM();
            try
            {
                oControl_dig_lixiviacionRpta = oControl_dig_lixiviacionBL.obtenerControl_dig_lixiviacion_por_id(id);
                oControl_dig_lixiviacionM.control_dig_lix_id = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.control_dig_lix_id;
                oControl_dig_lixiviacionM.fecha_desc = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.fecha.ToShortDateString();
                oControl_dig_lixiviacionM.turno_id = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.turno_id;
                oControl_dig_lixiviacionM.celda_id = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.celda_id;
                oControl_dig_lixiviacionM.tecnico_lixiviacion_id = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.tecnico_lixiviacion_id;
                oControl_dig_lixiviacionM.tecnico_apilamiento_id = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.tecnico_apilamiento_id;
                oControl_dig_lixiviacionM.nro_viajes = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.nro_viajes;
                oControl_dig_lixiviacionM.celda_opc = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.celda_opc;
                oControl_dig_lixiviacionM.nro_camiones = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.nro_camiones;
                oControl_dig_lixiviacionM.ley_mineral = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.ley_mineral;
                oControl_dig_lixiviacionM.poligono = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.poligono;
                oControl_dig_lixiviacionM.pluviometro = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.pluviometro;
                oControl_dig_lixiviacionM.cal_viva = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.cal_viva;
                oControl_dig_lixiviacionM.cal_hidratada = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.cal_hidratada;
                oControl_dig_lixiviacionM.corte = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.corte;
                oControl_dig_lixiviacionM.ripeo = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.ripeo;
                oControl_dig_lixiviacionM.totalizador_tk_2 = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.totalizador_tk_2;
                oControl_dig_lixiviacionM.nivel_tk_2 = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.nivel_tk_2;
                oControl_dig_lixiviacionM.presion_flujo = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.presion_flujo;
                oControl_dig_lixiviacionM.comentarios = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.comentarios;
                oControl_dig_lixiviacionM.flujo = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.flujo;
                oControl_dig_lixiviacionM.presion_adr = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.presion_adr;
                oControl_dig_lixiviacionM.presion_sump = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.presion_sump;
                oControl_dig_lixiviacionM.presion_925 = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.presion_925;
                oControl_dig_lixiviacionM.activo = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.activo;
                oControl_dig_lixiviacionM.usuario_crea = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.usuario_crea;
                oControl_dig_lixiviacionM.fecha_crea = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.fecha_crea;
                oControl_dig_lixiviacionM.usuario_mod = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.usuario_mod;
                oControl_dig_lixiviacionM.fecha_mod = oControl_dig_lixiviacionRpta.DTOControl_dig_lixiviacion.fecha_mod;
                cargarCombos(oControl_dig_lixiviacionM.turno_id, oControl_dig_lixiviacionM.celda_id, oControl_dig_lixiviacionM.tecnico_lixiviacion_id, oControl_dig_lixiviacionM.tecnico_apilamiento_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oControl_dig_lixiviacionM);
        }

        // POST: Control_dig_lixiviacion/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOControl_dig_lixiviacionM oControl_dig_lixiviacionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOControl_dig_lixiviacion oControl_dig_lixiviacion = new DTOControl_dig_lixiviacion();
                    Control_dig_lixiviacionBL oControl_dig_lixiviacionBL = new Control_dig_lixiviacionBL();
                    oControl_dig_lixiviacion.control_dig_lix_id = oControl_dig_lixiviacionM.control_dig_lix_id;
                    oControl_dig_lixiviacion.fecha =  Convert.ToDateTime(oControl_dig_lixiviacionM.fecha_desc);
                    oControl_dig_lixiviacion.turno_id = oControl_dig_lixiviacionM.turno_id;
                    oControl_dig_lixiviacion.celda_id = oControl_dig_lixiviacionM.celda_id;
                    oControl_dig_lixiviacion.tecnico_lixiviacion_id = oControl_dig_lixiviacionM.tecnico_lixiviacion_id;
                    oControl_dig_lixiviacion.tecnico_apilamiento_id = oControl_dig_lixiviacionM.tecnico_apilamiento_id;
                    oControl_dig_lixiviacion.nro_viajes = oControl_dig_lixiviacionM.nro_viajes;
                    oControl_dig_lixiviacion.celda_opc = oControl_dig_lixiviacionM.celda_opc;
                    oControl_dig_lixiviacion.nro_camiones = oControl_dig_lixiviacionM.nro_camiones;
                    oControl_dig_lixiviacion.ley_mineral = oControl_dig_lixiviacionM.ley_mineral;
                    oControl_dig_lixiviacion.poligono = oControl_dig_lixiviacionM.poligono;
                    oControl_dig_lixiviacion.pluviometro = oControl_dig_lixiviacionM.pluviometro;
                    oControl_dig_lixiviacion.cal_viva = oControl_dig_lixiviacionM.cal_viva;
                    oControl_dig_lixiviacion.cal_hidratada = oControl_dig_lixiviacionM.cal_hidratada;
                    oControl_dig_lixiviacion.corte = oControl_dig_lixiviacionM.corte;
                    oControl_dig_lixiviacion.ripeo = oControl_dig_lixiviacionM.ripeo;
                    oControl_dig_lixiviacion.totalizador_tk_2 = oControl_dig_lixiviacionM.totalizador_tk_2;
                    oControl_dig_lixiviacion.nivel_tk_2 = oControl_dig_lixiviacionM.nivel_tk_2;
                    oControl_dig_lixiviacion.presion_flujo = oControl_dig_lixiviacionM.presion_flujo;
                    oControl_dig_lixiviacion.comentarios = oControl_dig_lixiviacionM.comentarios;
                    oControl_dig_lixiviacion.flujo = oControl_dig_lixiviacionM.flujo;
                    oControl_dig_lixiviacion.presion_adr = oControl_dig_lixiviacionM.presion_adr;
                    oControl_dig_lixiviacion.presion_sump = oControl_dig_lixiviacionM.presion_sump;
                    oControl_dig_lixiviacion.presion_925 = oControl_dig_lixiviacionM.presion_925;
                    oControl_dig_lixiviacion.activo = oControl_dig_lixiviacionM.activo;
                    oControl_dig_lixiviacion.usuario_crea = oControl_dig_lixiviacionM.usuario_crea;
                    oControl_dig_lixiviacion.fecha_crea = oControl_dig_lixiviacionM.fecha_crea;
                    oControl_dig_lixiviacion.usuario_mod = Session["USR_COD"].ToString();
                    oControl_dig_lixiviacion.fecha_mod = oControl_dig_lixiviacionM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oControl_dig_lixiviacionBL.actualizarControl_dig_lixiviacion(oControl_dig_lixiviacion);
                    oControl_dig_lixiviacionM.resultado = 1;
                }
                cargarCombos(oControl_dig_lixiviacionM.turno_id, oControl_dig_lixiviacionM.celda_id, oControl_dig_lixiviacionM.tecnico_lixiviacion_id, oControl_dig_lixiviacionM.tecnico_apilamiento_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oControl_dig_lixiviacionM.resultado = 2;
            }

            return View(oControl_dig_lixiviacionM);
        }

        // GET: Control_dig_lixiviacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Control_dig_lixiviacion/Delete/5
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


        public void cargarCombos(int turno_id, int celda_id, int tec_lix_id, int tec_api_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Celda = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Tec_Lix = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Tec_Api = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_Celda = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaCelda"]) && u.activo == true).ToList();
                ViewBag.ListaCelda = new SelectList(oLista_Celda, "lista_valor_id", "valor", celda_id);

                oLista_Tec_Lix = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTecLix"]) && u.activo == true).ToList();
                ViewBag.ListaTecLix = new SelectList(oLista_Tec_Lix, "lista_valor_id", "valor", tec_lix_id);

                oLista_Tec_Api = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTecApi"]) && u.activo == true).ToList();
                ViewBag.ListaTecApi = new SelectList(oLista_Tec_Api, "lista_valor_id", "valor", tec_api_id);


            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}