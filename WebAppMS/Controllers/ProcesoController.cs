using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMS.Models;

namespace WebAppMS.Controllers
{
    public class ProcesoController : Controller
    {
        // GET: Proceso
        public ActionResult Index()
        {
            ProcesoBL oProcesoBL = new ProcesoBL();
            DTOProcesoRespuesta oProcesoRpta = new DTOProcesoRespuesta();
            oProcesoRpta = oProcesoBL.obtenerProceso();
            DTOProcesoM oProcesoM = new DTOProcesoM();
            List<DTOProcesoM> oLista_ProcesoM = new List<DTOProcesoM>();

            if (oProcesoRpta.DTOListaProceso != null)
            {
                foreach (var item in oProcesoRpta.DTOListaProceso)
                {
                    oProcesoM = new DTOProcesoM(); oProcesoM.proceso_id = item.proceso_id;
                    oProcesoM.codigo = item.codigo;
                    oProcesoM.anho = item.anho;
                    oProcesoM.mes = item.mes;
                    oProcesoM.mcl_fecha_inicio = item.mcl_fecha_inicio;
                    oProcesoM.mcl_fecha_fin = item.mcl_fecha_fin;
                    oProcesoM.adr_fecha_inicio = item.adr_fecha_inicio;
                    oProcesoM.adr_fecha_fin = item.adr_fecha_fin;
                    oProcesoM.activo = item.activo;
                    oProcesoM.usuario_crea = item.usuario_crea;
                    oProcesoM.fecha_crea = item.fecha_crea;
                    oProcesoM.usuario_mod = item.usuario_mod;
                    oProcesoM.fecha_mod = item.fecha_mod;
                    oLista_ProcesoM.Add(oProcesoM);
                }
            }


            return View(oLista_ProcesoM);
        }

        // GET: Proceso/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proceso/Create
        public ActionResult Create()
        {
            DTOProcesoM oProcesoM = new DTOProcesoM();
            oProcesoM.activo = true;
            oProcesoM.adr_fecha_fin_desc = DateTime.Today.ToShortDateString();
            oProcesoM.adr_fecha_inicio_desc = DateTime.Today.ToShortDateString(); 
            oProcesoM.mcl_fecha_fin_desc = DateTime.Today.ToShortDateString();
            oProcesoM.mcl_fecha_inicio_desc = DateTime.Today.ToShortDateString();
            return View(oProcesoM);
        }

        // POST: Proceso/Create
        [HttpPost]
        public ActionResult Create(DTOProcesoM oProcesoM)
        {
            try
            {
                // TODO: Add insert logic here
                ProcesoBL ProcesoBL = new ProcesoBL();
                DTOProceso oProceso = new DTOProceso();
                oProceso.proceso_id = oProcesoM.proceso_id;
                oProceso.codigo = oProcesoM.codigo;
                oProceso.anho = oProcesoM.anho;
                oProceso.mes = oProcesoM.mes;
                oProceso.mcl_fecha_inicio = oProcesoM.mcl_fecha_inicio;
                oProceso.mcl_fecha_fin = oProcesoM.mcl_fecha_fin;
                oProceso.adr_fecha_inicio = oProcesoM.adr_fecha_inicio;
                oProceso.adr_fecha_fin = oProcesoM.adr_fecha_fin;
                oProceso.activo = oProcesoM.activo;
                oProceso.usuario_crea = oProcesoM.usuario_crea;
                oProceso.fecha_crea = oProcesoM.fecha_crea;
                oProceso.usuario_mod = oProcesoM.usuario_mod;
                oProceso.fecha_mod = oProcesoM.fecha_mod;
                ProcesoBL.registrarProceso(oProceso);
                oProcesoM.proceso_id = 0;
                oProcesoM.codigo = "";
                oProcesoM.anho = "";
                oProcesoM.mes = "";
                oProcesoM.mcl_fecha_inicio = null;
                oProcesoM.mcl_fecha_fin = null;
                oProcesoM.adr_fecha_inicio = null;
                oProcesoM.adr_fecha_fin = null;
                oProcesoM.activo = true;
                oProcesoM.usuario_crea = Session["USR_COD"].ToString();
                oProcesoM.fecha_crea = null;
                oProcesoM.usuario_mod = "";
                oProcesoM.fecha_mod = null;
                oProcesoM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProcesoM.resultado = 2;
            }

            return View(oProcesoM);
        }

        // GET: Proceso/Edit/5
        public ActionResult Edit(int id)
        {
            DTOProcesoRespuesta oProcesoRpta = new DTOProcesoRespuesta();
            ProcesoBL oProcesoBL = new ProcesoBL();
            DTOProcesoM oProcesoM = new DTOProcesoM();
            try
            {
                oProcesoRpta = oProcesoBL.obtenerProceso_por_id(id);
                oProcesoM.proceso_id = oProcesoRpta.DTOProceso.proceso_id;
                oProcesoM.codigo = oProcesoRpta.DTOProceso.codigo;
                oProcesoM.anho = oProcesoRpta.DTOProceso.anho;
                oProcesoM.mes = oProcesoRpta.DTOProceso.mes;
                oProcesoM.mcl_fecha_inicio = oProcesoRpta.DTOProceso.mcl_fecha_inicio;
                oProcesoM.mcl_fecha_fin = oProcesoRpta.DTOProceso.mcl_fecha_fin;
                oProcesoM.adr_fecha_inicio = oProcesoRpta.DTOProceso.adr_fecha_inicio;
                oProcesoM.adr_fecha_fin = oProcesoRpta.DTOProceso.adr_fecha_fin;
                oProcesoM.activo = oProcesoRpta.DTOProceso.activo;
                oProcesoM.usuario_crea = oProcesoRpta.DTOProceso.usuario_crea;
                oProcesoM.fecha_crea = oProcesoRpta.DTOProceso.fecha_crea;
                oProcesoM.usuario_mod = oProcesoRpta.DTOProceso.usuario_mod;
                oProcesoM.fecha_mod = oProcesoRpta.DTOProceso.fecha_mod;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oProcesoM);
        }

        // POST: Proceso/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOProcesoM oProcesoM)
        {
            try
            {
                DTOProceso oProceso = new DTOProceso();
                ProcesoBL oProcesoBL = new ProcesoBL();
                oProceso.proceso_id = oProcesoM.proceso_id;
                oProceso.codigo = oProcesoM.codigo;
                oProceso.anho = oProcesoM.anho;
                oProceso.mes = oProcesoM.mes;
                oProceso.mcl_fecha_inicio = oProcesoM.mcl_fecha_inicio;
                oProceso.mcl_fecha_fin = oProcesoM.mcl_fecha_fin;
                oProceso.adr_fecha_inicio = oProcesoM.adr_fecha_inicio;
                oProceso.adr_fecha_fin = oProcesoM.adr_fecha_fin;
                oProceso.activo = oProcesoM.activo;
                oProceso.usuario_crea = oProcesoM.usuario_crea;
                oProceso.fecha_crea = oProcesoM.fecha_crea;
                oProceso.usuario_mod = Session["USR_COD"].ToString();
                oProceso.fecha_mod = oProcesoM.fecha_mod;
                //oLista.usuario_mod = "MS_USER";

                oProcesoBL.actualizarProceso(oProceso);
                oProcesoM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oProcesoM.resultado = 2;
            }

            return View(oProcesoM);
        }

        // GET: Proceso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proceso/Delete/5
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
    }
}