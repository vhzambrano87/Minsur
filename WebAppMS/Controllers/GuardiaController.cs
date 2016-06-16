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
    public class GuardiaController : Controller
    {
        // GET: Guardia
        public ActionResult Index()
        {
            GuardiaBL oGuardiaBL = new GuardiaBL();
            DTOGuardiaRespuesta oGuardiaRpta = new DTOGuardiaRespuesta();
            oGuardiaRpta = oGuardiaBL.obtenerGuardia();
            DTOGuardiaM oGuardiaM = new DTOGuardiaM();
            List<DTOGuardiaM> oLista_GuardiaM = new List<DTOGuardiaM>();

            if (oGuardiaRpta.DTOListaGuardia != null)
            {
                foreach (var item in oGuardiaRpta.DTOListaGuardia)
                {
                    oGuardiaM = new DTOGuardiaM();
                    oGuardiaM.guardia_id = item.guardia_id;
                    oGuardiaM.fecha = item.fecha;
                    oGuardiaM.turno_id = item.turno_id;
                    oGuardiaM.grupo = item.grupo;
                    oGuardiaM.jefe_guardia_id = item.jefe_guardia_id;
                    oGuardiaM.operador_planta_id = item.operador_planta_id;
                    oGuardiaM.activo = item.activo;
                    oGuardiaM.usuario_crea = item.usuario_crea;
                    oGuardiaM.fecha_crea = item.fecha_crea;
                    oGuardiaM.usuario_mod = item.usuario_mod;
                    oGuardiaM.fecha_mod = item.fecha_mod;

                    oGuardiaM.turno_desc = item.turno_desc;
                    oGuardiaM.jefe_guardia_desc = item.jefe_guardia_desc;
                    oGuardiaM.operador_planta_desc = item.operador_planta_desc;

                    oLista_GuardiaM.Add(oGuardiaM);
                }
            }


            return View(oLista_GuardiaM);
        }

        // GET: Guardia/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Guardia/Create
        public ActionResult Create()
        {
            DTOGuardiaM oGuardiaM = new DTOGuardiaM();
            cargarCombos(0,0,0);
            oGuardiaM.activo = true;
            oGuardiaM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oGuardiaM);
        }

        // POST: Guardia/Create
        [HttpPost]
        public ActionResult Create(DTOGuardiaM oGuardiaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    GuardiaBL GuardiaBL = new GuardiaBL();
                    DTOGuardia oGuardia = new DTOGuardia(); oGuardia.guardia_id = oGuardiaM.guardia_id;
                    oGuardia.fecha = Convert.ToDateTime(oGuardiaM.fecha_desc);
                    oGuardia.turno_id = oGuardiaM.turno_id;
                    oGuardia.grupo = oGuardiaM.grupo;
                    oGuardia.jefe_guardia_id = oGuardiaM.jefe_guardia_id;
                    oGuardia.operador_planta_id = oGuardiaM.operador_planta_id;
                    oGuardia.activo = oGuardiaM.activo;
                    oGuardia.usuario_crea = Session["USR_COD"].ToString();
                    oGuardia.fecha_crea = oGuardiaM.fecha_crea;
                    oGuardia.usuario_mod = oGuardiaM.usuario_mod;
                    oGuardia.fecha_mod = oGuardiaM.fecha_mod;

                    GuardiaBL.registrarGuardia(oGuardia);
                    
                    oGuardiaM.resultado = 1;

                }
                
               
                cargarCombos(oGuardiaM.turno_id, oGuardiaM.jefe_guardia_id, oGuardiaM.operador_planta_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oGuardiaM.resultado = 2;
            }

            return View(oGuardiaM);
        }

        // GET: Guardia/Edit/5
        public ActionResult Edit(int id)
        {
            DTOGuardiaRespuesta oGuardiaRpta = new DTOGuardiaRespuesta();
            GuardiaBL oGuardiaBL = new GuardiaBL();
            DTOGuardiaM oGuardiaM = new DTOGuardiaM();
            try
            {
                oGuardiaRpta = oGuardiaBL.obtenerGuardia_por_id(id);
                oGuardiaM.guardia_id = oGuardiaRpta.DTOGuardia.guardia_id;
                oGuardiaM.fecha = oGuardiaRpta.DTOGuardia.fecha;
                oGuardiaM.fecha_desc = Convert.ToDateTime(oGuardiaRpta.DTOGuardia.fecha).ToShortDateString();
                oGuardiaM.turno_id = oGuardiaRpta.DTOGuardia.turno_id;
                oGuardiaM.grupo = oGuardiaRpta.DTOGuardia.grupo;
                oGuardiaM.jefe_guardia_id = oGuardiaRpta.DTOGuardia.jefe_guardia_id;
                oGuardiaM.operador_planta_id = oGuardiaRpta.DTOGuardia.operador_planta_id;
                oGuardiaM.activo = oGuardiaRpta.DTOGuardia.activo;
                oGuardiaM.usuario_crea = oGuardiaRpta.DTOGuardia.usuario_crea;
                oGuardiaM.fecha_crea = oGuardiaRpta.DTOGuardia.fecha_crea;
                oGuardiaM.usuario_mod = oGuardiaRpta.DTOGuardia.usuario_mod;
                oGuardiaM.fecha_mod = oGuardiaRpta.DTOGuardia.fecha_mod;
                oGuardiaM.fecha_desc = Convert.ToDateTime(oGuardiaRpta.DTOGuardia.fecha).ToShortDateString();
                cargarCombos(oGuardiaRpta.DTOGuardia.turno_id, oGuardiaRpta.DTOGuardia.jefe_guardia_id, oGuardiaRpta.DTOGuardia.operador_planta_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oGuardiaM);
        }

        // POST: Guardia/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOGuardiaM oGuardiaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOGuardia oGuardia = new DTOGuardia();
                    GuardiaBL oGuardiaBL = new GuardiaBL();
                    oGuardia.guardia_id = oGuardiaM.guardia_id;
                    oGuardia.fecha =Convert.ToDateTime(oGuardiaM.fecha_desc);
                    oGuardia.turno_id = oGuardiaM.turno_id;
                    oGuardia.grupo = oGuardiaM.grupo;
                    oGuardia.jefe_guardia_id = oGuardiaM.jefe_guardia_id;
                    oGuardia.operador_planta_id = oGuardiaM.operador_planta_id;
                    oGuardia.activo = oGuardiaM.activo;
                    oGuardia.usuario_crea = oGuardiaM.usuario_crea;
                    oGuardia.fecha_crea = oGuardiaM.fecha_crea;
                    oGuardia.usuario_mod = Session["USR_COD"].ToString();
                    oGuardia.fecha_mod = oGuardiaM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oGuardiaBL.actualizarGuardia(oGuardia);
                    oGuardiaM.resultado = 1;
                }
                cargarCombos(oGuardiaM.turno_id, oGuardiaM.jefe_guardia_id, oGuardiaM.operador_planta_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oGuardiaM.resultado = 2;
            }

            return View(oGuardiaM);
        }

        // GET: Guardia/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Guardia/Delete/5
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

        public void cargarCombos(int turno_id, int jefe_id, int operador_id)
        {
            try
            {
                DTOLista_valorRespuesta oListaTurnoRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Jefe = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Operador = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                                
                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"])&& u.activo==true ).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_Jefe = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaJefe"]) && u.activo==true).ToList();
                ViewBag.ListaJefe = new SelectList(oLista_Jefe, "lista_valor_id", "valor", jefe_id);

                oLista_Operador = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaOperario"]) && u.activo == true).ToList();
                ViewBag.ListaOperador = new SelectList(oLista_Operador, "lista_valor_id", "valor", operador_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}