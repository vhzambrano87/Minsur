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
    public class CamionesController : Controller
    {
        // GET: Camiones
        public ActionResult Index()
        {
            CamionesBL oCamionesBL = new CamionesBL();
            DTOCamionesRespuesta oCamionesRpta = new DTOCamionesRespuesta();
            oCamionesRpta = oCamionesBL.obtenerCamiones();
            DTOCamionesM oCamionesM = new DTOCamionesM();
            List<DTOCamionesM> oLista_CamionesM = new List<DTOCamionesM>();

            if (oCamionesRpta.DTOListaCamiones != null)
            {
                foreach (var item in oCamionesRpta.DTOListaCamiones)
                {
                    oCamionesM = new DTOCamionesM(); oCamionesM.camion_id = item.camion_id;
                    oCamionesM.fecha = item.fecha;
                    oCamionesM.turno_id = item.turno_id;
                    oCamionesM.tipo_equipo_id = item.tipo_equipo_id;
                    oCamionesM.turno = item.turno;
                    oCamionesM.tipo_equipo = item.tipo_equipo;
                    oCamionesM.horas_maquina = item.horas_maquina;
                    oCamionesM.detalle = item.detalle;
                    oCamionesM.activo = item.activo;
                    oCamionesM.usuario_crea = item.usuario_crea;
                    oCamionesM.fecha_crea = item.fecha_crea;
                    oCamionesM.usuario_mod = item.usuario_mod;
                    oCamionesM.fecha_mod = item.fecha_mod;
                    oLista_CamionesM.Add(oCamionesM);
                }
            }


            return View(oLista_CamionesM);
        }

        // GET: Camiones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            DTOCamionesM oCamionM = new DTOCamionesM();
            oCamionM.activo = true;
            oCamionM.fecha_desc = DateTime.Today.ToShortDateString();
            cargarCombos(0,0);
            return View(oCamionM);
        }

        // POST: Camiones/Create
        [HttpPost]
        public ActionResult Create(DTOCamionesM oCamionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    CamionesBL CamionesBL = new CamionesBL();
                    DTOCamiones oCamiones = new DTOCamiones(); oCamiones.camion_id = oCamionesM.camion_id;
                    oCamiones.fecha = Convert.ToDateTime(oCamionesM.fecha_desc);
                    oCamiones.turno_id = oCamionesM.turno_id;
                    oCamiones.tipo_equipo_id = oCamionesM.tipo_equipo_id;
                    oCamiones.horas_maquina = oCamionesM.horas_maquina;
                    oCamiones.detalle = oCamionesM.detalle;
                    oCamiones.activo = oCamionesM.activo;
                    oCamiones.usuario_crea = Session["USR_COD"].ToString();
                    oCamiones.fecha_crea = oCamionesM.fecha_crea;
                    oCamiones.usuario_mod = oCamionesM.usuario_mod;
                    oCamiones.fecha_mod = oCamionesM.fecha_mod;
                    CamionesBL.registrarCamiones(oCamiones);
                    oCamionesM.resultado = 1;
                   }
                cargarCombos(oCamionesM.turno_id, oCamionesM.tipo_equipo_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oCamionesM.resultado = 2;
            }

            return View(oCamionesM);
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(int id)
        {
            DTOCamionesRespuesta oCamionesRpta = new DTOCamionesRespuesta();
            CamionesBL oCamionesBL = new CamionesBL();
            DTOCamionesM oCamionesM = new DTOCamionesM();
            try
            {
                oCamionesRpta = oCamionesBL.obtenerCamiones_por_id(id);
                oCamionesM.camion_id = oCamionesRpta.DTOCamiones.camion_id;
                oCamionesM.fecha_desc = oCamionesRpta.DTOCamiones.fecha.ToShortDateString();
                oCamionesM.turno_id = oCamionesRpta.DTOCamiones.turno_id;
                oCamionesM.tipo_equipo_id = oCamionesRpta.DTOCamiones.tipo_equipo_id;
                oCamionesM.horas_maquina = oCamionesRpta.DTOCamiones.horas_maquina;
                oCamionesM.detalle = oCamionesRpta.DTOCamiones.detalle;
                oCamionesM.activo = oCamionesRpta.DTOCamiones.activo;
                oCamionesM.usuario_crea = oCamionesRpta.DTOCamiones.usuario_crea;
                oCamionesM.fecha_crea = oCamionesRpta.DTOCamiones.fecha_crea;
                oCamionesM.usuario_mod = oCamionesRpta.DTOCamiones.usuario_mod;
                oCamionesM.fecha_mod = oCamionesRpta.DTOCamiones.fecha_mod;
                cargarCombos(oCamionesM.turno_id, oCamionesM.tipo_equipo_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oCamionesM);
        }

        // POST: Camiones/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOCamionesM oCamionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOCamiones oCamiones = new DTOCamiones();
                    CamionesBL oCamionesBL = new CamionesBL();
                    oCamiones.camion_id = oCamionesM.camion_id;
                    oCamiones.fecha = Convert.ToDateTime(oCamionesM.fecha_desc);
                    oCamiones.turno_id = oCamionesM.turno_id;
                    oCamiones.tipo_equipo_id = oCamionesM.tipo_equipo_id;
                    oCamiones.horas_maquina = oCamionesM.horas_maquina;
                    oCamiones.detalle = oCamionesM.detalle;
                    oCamiones.activo = oCamionesM.activo;
                    oCamiones.usuario_crea = oCamionesM.usuario_crea;
                    oCamiones.fecha_crea = oCamionesM.fecha_crea;
                    oCamiones.usuario_mod = Session["USR_COD"].ToString();
                    oCamiones.fecha_mod = oCamionesM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oCamionesBL.actualizarCamiones(oCamiones);
                    oCamionesM.resultado = 1;
                }
                cargarCombos(oCamionesM.turno_id, oCamionesM.tipo_equipo_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oCamionesM.resultado = 2;
            }

            return View(oCamionesM);
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Camiones/Delete/5
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

        public void cargarCombos(int turno_id, int tipo_equipo_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Tipo_Equipo = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_Tipo_Equipo = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTipoEquipo"]) && u.activo == true).ToList();
                ViewBag.ListaTipoEquipo = new SelectList(oLista_Tipo_Equipo, "lista_valor_id", "valor", tipo_equipo_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

    }
}