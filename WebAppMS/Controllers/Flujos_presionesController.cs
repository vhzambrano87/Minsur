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
    public class Flujos_presionesController : Controller
    {
        // GET: Flujos_presiones
        public ActionResult Index()
        {
            Flujos_presionesBL oFlujos_presionesBL = new Flujos_presionesBL();
            DTOFlujos_presionesRespuesta oFlujos_presionesRpta = new DTOFlujos_presionesRespuesta();
            oFlujos_presionesRpta = oFlujos_presionesBL.obtenerFlujos_presiones();
            DTOFlujos_presionesM oFlujos_presionesM = new DTOFlujos_presionesM();
            List<DTOFlujos_presionesM> oLista_Flujos_presionesM = new List<DTOFlujos_presionesM>();

            if (oFlujos_presionesRpta.DTOListaFlujos_presiones != null)
            {
                foreach (var item in oFlujos_presionesRpta.DTOListaFlujos_presiones)
                {
                    oFlujos_presionesM = new DTOFlujos_presionesM();
                    oFlujos_presionesM.flujo_presion_id = item.flujo_presion_id;
                    oFlujos_presionesM.fecha = item.fecha;
                    oFlujos_presionesM.celda_id = item.celda_id;
                    oFlujos_presionesM.operador_id = item.operador_id;
                    oFlujos_presionesM.ingeniero_id = item.ingeniero_id;

                    oFlujos_presionesM.celda = item.celda;
                    oFlujos_presionesM.operador = item.operador;
                    oFlujos_presionesM.ingeniero = item.ingeniero;

                    oFlujos_presionesM.flujo = item.flujo;
                    oFlujos_presionesM.presion = item.presion;
                    oFlujos_presionesM.flujo_real = item.flujo_real;
                    oFlujos_presionesM.presion_real = item.presion_real;
                    oFlujos_presionesM.flujo_corregido = item.flujo_corregido;
                    oFlujos_presionesM.presion_corregida = item.presion_corregida;
                    oFlujos_presionesM.totalizador = item.totalizador;
                    oFlujos_presionesM.comentarios = item.comentarios;
                    oFlujos_presionesM.activo = item.activo;
                    oFlujos_presionesM.usuario_crea = item.usuario_crea;
                    oFlujos_presionesM.fecha_crea = item.fecha_crea;
                    oFlujos_presionesM.usuario_mod = item.usuario_mod;
                    oFlujos_presionesM.fecha_mod = item.fecha_mod;
                    oLista_Flujos_presionesM.Add(oFlujos_presionesM);
                }
            }


            return View(oLista_Flujos_presionesM);
        }

        // GET: Flujos_presiones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Flujos_presiones/Create
        public ActionResult Create()
        {
            DTOFlujos_presionesM oflujosPresionesM = new DTOFlujos_presionesM();
            oflujosPresionesM.activo = true;
            oflujosPresionesM.fecha_desc = DateTime.Today.ToShortDateString();
            cargarCombos(0,0,0);
            return View(oflujosPresionesM);
        }

        // POST: Flujos_presiones/Create
        [HttpPost]
        public ActionResult Create(DTOFlujos_presionesM oFlujos_presionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Flujos_presionesBL Flujos_presionesBL = new Flujos_presionesBL();
                    DTOFlujos_presiones oFlujos_presiones = new DTOFlujos_presiones(); oFlujos_presiones.flujo_presion_id = oFlujos_presionesM.flujo_presion_id;
                    oFlujos_presiones.fecha = Convert.ToDateTime(oFlujos_presionesM.fecha_desc);
                    oFlujos_presiones.celda_id = oFlujos_presionesM.celda_id;
                    oFlujos_presiones.operador_id = oFlujos_presionesM.operador_id;
                    oFlujos_presiones.ingeniero_id = oFlujos_presionesM.ingeniero_id;
                    oFlujos_presiones.flujo = oFlujos_presionesM.flujo;
                    oFlujos_presiones.presion = oFlujos_presionesM.presion;
                    oFlujos_presiones.flujo_real = oFlujos_presionesM.flujo_real;
                    oFlujos_presiones.presion_real = oFlujos_presionesM.presion_real;
                    oFlujos_presiones.flujo_corregido = oFlujos_presionesM.flujo_corregido;
                    oFlujos_presiones.presion_corregida = oFlujos_presionesM.presion_corregida;
                    oFlujos_presiones.totalizador = oFlujos_presionesM.totalizador;
                    oFlujos_presiones.comentarios = oFlujos_presionesM.comentarios;
                    oFlujos_presiones.activo = oFlujos_presionesM.activo;
                    oFlujos_presiones.usuario_crea = Session["USR_COD"].ToString();
                    oFlujos_presiones.fecha_crea = oFlujos_presionesM.fecha_crea;
                    oFlujos_presiones.usuario_mod = oFlujos_presionesM.usuario_mod;
                    oFlujos_presiones.fecha_mod = oFlujos_presionesM.fecha_mod;
                    Flujos_presionesBL.registrarFlujos_presiones(oFlujos_presiones);

                    oFlujos_presionesM.resultado = 1;
                }
                cargarCombos(oFlujos_presionesM.celda_id, oFlujos_presionesM.operador_id, oFlujos_presionesM.ingeniero_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oFlujos_presionesM.resultado = 2;
            }

            return View(oFlujos_presionesM);
        }

        // GET: Flujos_presiones/Edit/5
        public ActionResult Edit(int id)
        {
            DTOFlujos_presionesRespuesta oFlujos_presionesRpta = new DTOFlujos_presionesRespuesta();
            Flujos_presionesBL oFlujos_presionesBL = new Flujos_presionesBL();
            DTOFlujos_presionesM oFlujos_presionesM = new DTOFlujos_presionesM();
            try
            {
                oFlujos_presionesRpta = oFlujos_presionesBL.obtenerFlujos_presiones_por_id(id);
                oFlujos_presionesM.flujo_presion_id = oFlujos_presionesRpta.DTOFlujos_presiones.flujo_presion_id;
                oFlujos_presionesM.fecha_desc = oFlujos_presionesRpta.DTOFlujos_presiones.fecha.ToShortDateString();

                oFlujos_presionesM.celda_id = oFlujos_presionesRpta.DTOFlujos_presiones.celda_id;
                oFlujos_presionesM.operador_id = oFlujos_presionesRpta.DTOFlujos_presiones.operador_id;
                oFlujos_presionesM.ingeniero_id = oFlujos_presionesRpta.DTOFlujos_presiones.ingeniero_id;
                oFlujos_presionesM.flujo = oFlujos_presionesRpta.DTOFlujos_presiones.flujo;
                oFlujos_presionesM.presion = oFlujos_presionesRpta.DTOFlujos_presiones.presion;
                oFlujos_presionesM.flujo_real = oFlujos_presionesRpta.DTOFlujos_presiones.flujo_real;
                oFlujos_presionesM.presion_real = oFlujos_presionesRpta.DTOFlujos_presiones.presion_real;
                oFlujos_presionesM.flujo_corregido = oFlujos_presionesRpta.DTOFlujos_presiones.flujo_corregido;
                oFlujos_presionesM.presion_corregida = oFlujos_presionesRpta.DTOFlujos_presiones.presion_corregida;
                oFlujos_presionesM.totalizador = oFlujos_presionesRpta.DTOFlujos_presiones.totalizador;
                oFlujos_presionesM.comentarios = oFlujos_presionesRpta.DTOFlujos_presiones.comentarios;
                oFlujos_presionesM.activo = oFlujos_presionesRpta.DTOFlujos_presiones.activo;
                oFlujos_presionesM.usuario_crea = oFlujos_presionesRpta.DTOFlujos_presiones.usuario_crea;
                oFlujos_presionesM.fecha_crea = oFlujos_presionesRpta.DTOFlujos_presiones.fecha_crea;
                oFlujos_presionesM.usuario_mod = oFlujos_presionesRpta.DTOFlujos_presiones.usuario_mod;
                oFlujos_presionesM.fecha_mod = oFlujos_presionesRpta.DTOFlujos_presiones.fecha_mod;
                cargarCombos(oFlujos_presionesRpta.DTOFlujos_presiones.celda_id, oFlujos_presionesRpta.DTOFlujos_presiones.operador_id, oFlujos_presionesRpta.DTOFlujos_presiones.ingeniero_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oFlujos_presionesM);
        }

        // POST: Flujos_presiones/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOFlujos_presionesM oFlujos_presionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOFlujos_presiones oFlujos_presiones = new DTOFlujos_presiones();
                    Flujos_presionesBL oFlujos_presionesBL = new Flujos_presionesBL();
                    oFlujos_presiones.flujo_presion_id = oFlujos_presionesM.flujo_presion_id;
                    oFlujos_presiones.fecha = Convert.ToDateTime(oFlujos_presionesM.fecha_desc);
                    oFlujos_presiones.celda_id = oFlujos_presionesM.celda_id;
                    oFlujos_presiones.operador_id = oFlujos_presionesM.operador_id;
                    oFlujos_presiones.ingeniero_id = oFlujos_presionesM.ingeniero_id;
                    oFlujos_presiones.flujo = oFlujos_presionesM.flujo;
                    oFlujos_presiones.presion = oFlujos_presionesM.presion;
                    oFlujos_presiones.flujo_real = oFlujos_presionesM.flujo_real;
                    oFlujos_presiones.presion_real = oFlujos_presionesM.presion_real;
                    oFlujos_presiones.flujo_corregido = oFlujos_presionesM.flujo_corregido;
                    oFlujos_presiones.presion_corregida = oFlujos_presionesM.presion_corregida;
                    oFlujos_presiones.totalizador = oFlujos_presionesM.totalizador;
                    oFlujos_presiones.comentarios = oFlujos_presionesM.comentarios;
                    oFlujos_presiones.activo = oFlujos_presionesM.activo;
                    oFlujos_presiones.usuario_crea = oFlujos_presionesM.usuario_crea;
                    oFlujos_presiones.fecha_crea = oFlujos_presionesM.fecha_crea;
                    oFlujos_presiones.usuario_mod = Session["USR_COD"].ToString();
                    oFlujos_presiones.fecha_mod = oFlujos_presionesM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oFlujos_presionesBL.actualizarFlujos_presiones(oFlujos_presiones);
                    oFlujos_presionesM.resultado = 1;
                }
                cargarCombos(oFlujos_presionesM.celda_id, oFlujos_presionesM.operador_id, oFlujos_presionesM.ingeniero_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oFlujos_presionesM.resultado = 2;
            }

            return View(oFlujos_presionesM);
        }

        // GET: Flujos_presiones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Flujos_presiones/Delete/5
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

        public void cargarCombos(int celda_id, int operador_id, int ingeniero_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Celda = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Operador = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Ingeniero = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Celda = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaCelda"]) && u.activo == true).ToList();
                ViewBag.ListaCelda = new SelectList(oLista_Celda, "lista_valor_id", "valor", celda_id);

                oLista_Operador = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaOperario"]) && u.activo == true).ToList();
                ViewBag.ListaOperador = new SelectList(oLista_Operador, "lista_valor_id", "valor", operador_id);

                oLista_Ingeniero = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaIngeniero"]) && u.activo == true).ToList();
                ViewBag.ListaIngeniero = new SelectList(oLista_Ingeniero, "lista_valor_id", "valor", ingeniero_id);


            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}