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
    public class AdsorcionController : Controller
    {
        // GET: Adsorcion
        public ActionResult Index()
        {
            AdsorcionBL oAdsorcionBL = new AdsorcionBL();
            DTOAdsorcionRespuesta oAdsorcionRpta = new DTOAdsorcionRespuesta();
            oAdsorcionRpta = oAdsorcionBL.obtenerAdsorcion();
            DTOAdsorcionM oAdsorcionM = new DTOAdsorcionM();
            List<DTOAdsorcionM> oLista_AdsorcionM = new List<DTOAdsorcionM>();

            if (oAdsorcionRpta.DTOListaAdsorcion != null)
            {
                foreach (var item in oAdsorcionRpta.DTOListaAdsorcion)
                {
                    oAdsorcionM = new DTOAdsorcionM(); oAdsorcionM.adsorcion_id = item.adsorcion_id;
                    oAdsorcionM.fecha = item.fecha;
                    oAdsorcionM.horas = item.horas;
                    oAdsorcionM.au_ing_n1 = item.au_ing_n1;
                    oAdsorcionM.au_ing_n2 = item.au_ing_n2;
                    oAdsorcionM.au_sal_n1 = item.au_sal_n1;
                    oAdsorcionM.au_sal_n2 = item.au_sal_n2;

                    oAdsorcionM.ag_ing_n1 = item.ag_ing_n1;
                    oAdsorcionM.ag_ing_n2 = item.ag_ing_n2;
                    oAdsorcionM.ag_sal_n1 = item.ag_sal_n1;
                    oAdsorcionM.ag_sal_n2 = item.ag_sal_n2;

                    oAdsorcionM.flujo_ini_1 = item.flujo_ini_1;
                    oAdsorcionM.flujo_ini_2 = item.flujo_ini_2;
                    oAdsorcionM.flujo_fin_1 = item.flujo_fin_1;
                    oAdsorcionM.flujo_fin_2 = item.flujo_fin_2;
                    oAdsorcionM.activo = item.activo;
                    oAdsorcionM.usuario_crea = item.usuario_crea;
                    oAdsorcionM.fecha_crea = item.fecha_crea;
                    oAdsorcionM.usuario_mod = item.usuario_mod;
                    oAdsorcionM.fecha_mod = item.fecha_mod;
                    oLista_AdsorcionM.Add(oAdsorcionM);
                }
            }


            return View(oLista_AdsorcionM);
        }

        // GET: Adsorcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Adsorcion/Create
        public ActionResult Create()
        {
            DTOAdsorcionM oAdsorcionM = new DTOAdsorcionM();
            oAdsorcionM.fecha_desc = DateTime.Today.ToShortDateString();
            oAdsorcionM.activo = true;
            return View(oAdsorcionM);
        }

        // POST: Adsorcion/Create
        [HttpPost]
        public ActionResult Create(DTOAdsorcionM oAdsorcionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    AdsorcionBL AdsorcionBL = new AdsorcionBL();
                    DTOAdsorcion oAdsorcion = new DTOAdsorcion(); oAdsorcion.adsorcion_id = oAdsorcionM.adsorcion_id;
                    oAdsorcion.fecha = Convert.ToDateTime(oAdsorcionM.fecha);
                    oAdsorcion.horas = oAdsorcionM.horas;
                    oAdsorcion.au_ing_n1 = oAdsorcionM.au_ing_n1;
                    oAdsorcion.au_ing_n2 = oAdsorcionM.au_ing_n2;
                    oAdsorcion.au_sal_n1 = oAdsorcionM.au_sal_n1;
                    oAdsorcion.au_sal_n2 = oAdsorcionM.au_sal_n2;

                    oAdsorcion.ag_ing_n1 = oAdsorcionM.ag_ing_n1;
                    oAdsorcion.ag_ing_n2 = oAdsorcionM.ag_ing_n2;
                    oAdsorcion.ag_sal_n1 = oAdsorcionM.ag_sal_n1;
                    oAdsorcion.ag_sal_n2 = oAdsorcionM.ag_sal_n2;

                    oAdsorcion.flujo_ini_1 = oAdsorcionM.flujo_ini_1;
                    oAdsorcion.flujo_ini_2 = oAdsorcionM.flujo_ini_2;
                    oAdsorcion.flujo_fin_1 = oAdsorcionM.flujo_fin_1;
                    oAdsorcion.flujo_fin_2 = oAdsorcionM.flujo_fin_2;
                    oAdsorcion.activo = oAdsorcionM.activo;
                    oAdsorcion.usuario_crea = Session["USR_COD"].ToString();
                    oAdsorcion.fecha_crea = oAdsorcionM.fecha_crea;
                    oAdsorcion.usuario_mod = oAdsorcionM.usuario_mod;
                    oAdsorcion.fecha_mod = oAdsorcionM.fecha_mod;
                    AdsorcionBL.registrarAdsorcion(oAdsorcion);
                    //oAdsorcionM.adsorcion_id = 0;
                    //oAdsorcionM.fecha = null;
                    //oAdsorcionM.horas = 0;
                    //oAdsorcionM.au_ing_n1 = 0;
                    //oAdsorcionM.au_ing_n2 = 0;
                    //oAdsorcionM.au_sal_n1 = 0;
                    //oAdsorcionM.au_sal_n2 = 0;

                    //oAdsorcionM.ag_ing_n1 = 0;
                    //oAdsorcionM.ag_ing_n2 = 0;
                    //oAdsorcionM.ag_sal_n1 = 0;
                    //oAdsorcionM.ag_sal_n2 = 0;

                    //oAdsorcionM.flujo_ini_1 = 0;
                    //oAdsorcionM.flujo_ini_2 = 0;
                    //oAdsorcionM.flujo_fin_1 = 0;
                    //oAdsorcionM.flujo_fin_2 = 0;
                    //oAdsorcionM.activo = true;
                    //oAdsorcionM.usuario_crea = "";
                    //oAdsorcionM.fecha_crea = null;
                    //oAdsorcionM.usuario_mod = "";
                    //oAdsorcionM.fecha_mod = null;
                    oAdsorcionM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oAdsorcionM.resultado = 2;
            }

            return View(oAdsorcionM);
        }

        // GET: Adsorcion/Edit/5
        public ActionResult Edit(int id)
        {
            DTOAdsorcionRespuesta oAdsorcionRpta = new DTOAdsorcionRespuesta();
            AdsorcionBL oAdsorcionBL = new AdsorcionBL();
            DTOAdsorcionM oAdsorcionM = new DTOAdsorcionM();
            try
            {

                oAdsorcionRpta = oAdsorcionBL.obtenerAdsorcion_por_id(id);
                oAdsorcionM.adsorcion_id = oAdsorcionRpta.DTOAdsorcion.adsorcion_id;
                oAdsorcionM.fecha = oAdsorcionRpta.DTOAdsorcion.fecha;
                oAdsorcionM.horas = oAdsorcionRpta.DTOAdsorcion.horas;
                oAdsorcionM.au_ing_n1 = oAdsorcionRpta.DTOAdsorcion.au_ing_n1;
                oAdsorcionM.au_ing_n2 = oAdsorcionRpta.DTOAdsorcion.au_ing_n2;
                oAdsorcionM.au_sal_n1 = oAdsorcionRpta.DTOAdsorcion.au_sal_n1;
                oAdsorcionM.au_sal_n2 = oAdsorcionRpta.DTOAdsorcion.au_sal_n2;

                oAdsorcionM.ag_ing_n1 = oAdsorcionRpta.DTOAdsorcion.ag_ing_n1;
                oAdsorcionM.ag_ing_n2 = oAdsorcionRpta.DTOAdsorcion.ag_ing_n2;
                oAdsorcionM.ag_sal_n1 = oAdsorcionRpta.DTOAdsorcion.ag_sal_n1;
                oAdsorcionM.ag_sal_n2 = oAdsorcionRpta.DTOAdsorcion.ag_sal_n2;

                oAdsorcionM.flujo_ini_1 = oAdsorcionRpta.DTOAdsorcion.flujo_ini_1;
                oAdsorcionM.flujo_ini_2 = oAdsorcionRpta.DTOAdsorcion.flujo_ini_2;
                oAdsorcionM.flujo_fin_1 = oAdsorcionRpta.DTOAdsorcion.flujo_fin_1;
                oAdsorcionM.flujo_fin_2 = oAdsorcionRpta.DTOAdsorcion.flujo_fin_2;
                oAdsorcionM.activo = oAdsorcionRpta.DTOAdsorcion.activo;
                oAdsorcionM.usuario_crea = oAdsorcionRpta.DTOAdsorcion.usuario_crea;
                oAdsorcionM.fecha_crea = oAdsorcionRpta.DTOAdsorcion.fecha_crea;
                oAdsorcionM.usuario_mod = oAdsorcionRpta.DTOAdsorcion.usuario_mod;
                oAdsorcionM.fecha_mod = oAdsorcionRpta.DTOAdsorcion.fecha_mod;
                oAdsorcionM.fecha_desc = oAdsorcionRpta.DTOAdsorcion.fecha.ToShortDateString();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oAdsorcionM);
        }

        // POST: Adsorcion/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOAdsorcionM oAdsorcionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOAdsorcion oAdsorcion = new DTOAdsorcion();
                    AdsorcionBL oAdsorcionBL = new AdsorcionBL();
                    oAdsorcion.adsorcion_id = oAdsorcionM.adsorcion_id;
                    oAdsorcion.fecha = Convert.ToDateTime(oAdsorcionM.fecha);
                    oAdsorcionM.fecha_desc = Convert.ToDateTime(oAdsorcionM.fecha).ToShortDateString();
                    oAdsorcion.horas = oAdsorcionM.horas;
                    oAdsorcion.au_ing_n1 = oAdsorcionM.au_ing_n1;
                    oAdsorcion.au_ing_n2 = oAdsorcionM.au_ing_n2;
                    oAdsorcion.au_sal_n1 = oAdsorcionM.au_sal_n1;
                    oAdsorcion.au_sal_n2 = oAdsorcionM.au_sal_n2;

                    oAdsorcion.ag_ing_n1 = oAdsorcionM.ag_ing_n1;
                    oAdsorcion.ag_ing_n2 = oAdsorcionM.ag_ing_n2;
                    oAdsorcion.ag_sal_n1 = oAdsorcionM.ag_sal_n1;
                    oAdsorcion.ag_sal_n2 = oAdsorcionM.ag_sal_n2;

                    oAdsorcion.flujo_ini_1 = oAdsorcionM.flujo_ini_1;
                    oAdsorcion.flujo_ini_2 = oAdsorcionM.flujo_ini_2;
                    oAdsorcion.flujo_fin_1 = oAdsorcionM.flujo_fin_1;
                    oAdsorcion.flujo_fin_2 = oAdsorcionM.flujo_fin_2;
                    oAdsorcion.activo = oAdsorcionM.activo;
                    oAdsorcion.usuario_crea = oAdsorcionM.usuario_crea;
                    oAdsorcion.fecha_crea = oAdsorcionM.fecha_crea;
                    oAdsorcion.usuario_mod = Session["USR_COD"].ToString();
                    oAdsorcion.fecha_mod = oAdsorcionM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oAdsorcionBL.actualizarAdsorcion(oAdsorcion);
                    oAdsorcionM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oAdsorcionM.resultado = 2;
            }

            return View(oAdsorcionM);
        }

        // GET: Adsorcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Adsorcion/Delete/5
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