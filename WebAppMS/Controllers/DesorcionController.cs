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
    public class DesorcionController : Controller
    {
        // GET: Desorcion
        public ActionResult Index()
        {
            DesorcionBL oDesorcionBL = new DesorcionBL();
            DTODesorcionRespuesta oDesorcionRpta = new DTODesorcionRespuesta();
            oDesorcionRpta = oDesorcionBL.obtenerDesorcion();
            DTODesorcionM oDesorcionM = new DTODesorcionM();
            List<DTODesorcionM> oLista_DesorcionM = new List<DTODesorcionM>();

            if (oDesorcionRpta.DTOListaDesorcion != null)
            {
                foreach (var item in oDesorcionRpta.DTOListaDesorcion)
                {
                    oDesorcionM = new DTODesorcionM(); oDesorcionM.desorcion_id = item.desorcion_id;
                    oDesorcionM.fecha = item.fecha;
                    oDesorcionM.num_fundicion = item.num_fundicion;
                    oDesorcionM.mes = item.mes;
                    oDesorcionM.num_desorcion = item.num_desorcion;
                    oDesorcionM.num_desorcion_mes = item.num_desorcion_mes;
                    oDesorcionM.num_col_desc = item.num_col_desc;
                    oDesorcionM.peso_col_desc = item.peso_col_desc;
                    oDesorcionM.hora_inicio = item.hora_inicio;
                    oDesorcionM.hora_fin = item.hora_fin;
                    oDesorcionM.au_rico = item.au_rico;
                    oDesorcionM.au_pobre = item.au_pobre;
                    oDesorcionM.ag_rico = item.ag_rico;
                    oDesorcionM.ag_pobre = item.ag_pobre;
                    oDesorcionM.hg_rico = item.hg_rico;
                    oDesorcionM.hg_pobre = item.hg_pobre;
                    oDesorcionM.activo = item.activo;
                    oDesorcionM.usuario_crea = item.usuario_crea;
                    oDesorcionM.fecha_crea = item.fecha_crea;
                    oDesorcionM.usuario_mod = item.usuario_mod;
                    oDesorcionM.fecha_mod = item.fecha_mod;
                    oLista_DesorcionM.Add(oDesorcionM);
                }
            }


            return View(oLista_DesorcionM);
        }

        // GET: Desorcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Desorcion/Create
        public ActionResult Create()
        {
            DTODesorcionM oDesorcionM = new DTODesorcionM();
            oDesorcionM.activo = true;
            oDesorcionM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oDesorcionM);
        }

        // POST: Desorcion/Create
        [HttpPost]
        public ActionResult Create(DTODesorcionM oDesorcionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    DesorcionBL DesorcionBL = new DesorcionBL();
                    DTODesorcion oDesorcion = new DTODesorcion(); oDesorcion.desorcion_id = oDesorcionM.desorcion_id;
                    oDesorcion.fecha = Convert.ToDateTime(oDesorcionM.fecha_desc);
                    oDesorcion.num_fundicion = oDesorcionM.num_fundicion;
                    oDesorcion.mes = oDesorcionM.mes;
                    oDesorcion.num_desorcion = oDesorcionM.num_desorcion;
                    oDesorcion.num_desorcion_mes = oDesorcionM.num_desorcion_mes;
                    oDesorcion.num_col_desc = oDesorcionM.num_col_desc;
                    oDesorcion.peso_col_desc = oDesorcionM.peso_col_desc;
                    oDesorcion.hora_inicio = oDesorcionM.hora_inicio;
                    oDesorcion.hora_fin = oDesorcionM.hora_fin;
                    oDesorcion.au_rico = oDesorcionM.au_rico;
                    oDesorcion.au_pobre = oDesorcionM.au_pobre;
                    oDesorcion.ag_rico = oDesorcionM.ag_rico;
                    oDesorcion.ag_pobre = oDesorcionM.ag_pobre;
                    oDesorcion.hg_rico = oDesorcionM.hg_rico;
                    oDesorcion.hg_pobre = oDesorcionM.hg_pobre;
                    oDesorcion.activo = oDesorcionM.activo;
                    oDesorcion.usuario_crea = Session["USR_COD"].ToString();
                    oDesorcion.fecha_crea = oDesorcionM.fecha_crea;
                    oDesorcion.usuario_mod = oDesorcionM.usuario_mod;
                    oDesorcion.fecha_mod = oDesorcionM.fecha_mod;
                    DesorcionBL.registrarDesorcion(oDesorcion);


                    //oDesorcionM.desorcion_id = 0;
                    //oDesorcionM.fecha = null;
                    //oDesorcionM.num_fundicion = "";
                    //oDesorcionM.mes = "";
                    //oDesorcionM.num_desorcion = 0;
                    //oDesorcionM.num_desorcion_mes = 0;
                    //oDesorcionM.num_col_desc = 0;
                    //oDesorcionM.peso_col_desc = 0;
                    //oDesorcionM.hora_inicio = "";
                    //oDesorcionM.hora_fin = "";
                    //oDesorcionM.au_rico = 0;
                    //oDesorcionM.au_pobre = 0;
                    //oDesorcionM.ag_rico = 0;
                    //oDesorcionM.ag_pobre = 0;
                    //oDesorcionM.hg_rico = 0;
                    //oDesorcionM.hg_pobre = 0;
                    //oDesorcionM.activo = true;
                    //oDesorcionM.usuario_crea = "";
                    //oDesorcionM.fecha_crea = null;
                    //oDesorcionM.usuario_mod = "";
                    //oDesorcionM.fecha_mod = null;
                    oDesorcionM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oDesorcionM.resultado = 2;
            }

            return View(oDesorcionM);
        }

        // GET: Desorcion/Edit/5
        public ActionResult Edit(int id)
        {
            DTODesorcionRespuesta oDesorcionRpta = new DTODesorcionRespuesta();
            DesorcionBL oDesorcionBL = new DesorcionBL();
            DTODesorcionM oDesorcionM = new DTODesorcionM();
            try
            {
                oDesorcionRpta = oDesorcionBL.obtenerDesorcion_por_id(id);
                oDesorcionM.desorcion_id = oDesorcionRpta.DTODesorcion.desorcion_id;
                oDesorcionM.fecha = oDesorcionRpta.DTODesorcion.fecha;
                oDesorcionM.num_fundicion = oDesorcionRpta.DTODesorcion.num_fundicion;
                oDesorcionM.mes = oDesorcionRpta.DTODesorcion.mes;
                oDesorcionM.num_desorcion = oDesorcionRpta.DTODesorcion.num_desorcion;
                oDesorcionM.num_desorcion_mes = oDesorcionRpta.DTODesorcion.num_desorcion_mes;
                oDesorcionM.num_col_desc = oDesorcionRpta.DTODesorcion.num_col_desc;
                oDesorcionM.peso_col_desc = oDesorcionRpta.DTODesorcion.peso_col_desc;
                oDesorcionM.hora_inicio = oDesorcionRpta.DTODesorcion.hora_inicio;
                oDesorcionM.hora_fin = oDesorcionRpta.DTODesorcion.hora_fin;
                oDesorcionM.au_rico = oDesorcionRpta.DTODesorcion.au_rico;
                oDesorcionM.au_pobre = oDesorcionRpta.DTODesorcion.au_pobre;
                oDesorcionM.ag_rico = oDesorcionRpta.DTODesorcion.ag_rico;
                oDesorcionM.ag_pobre = oDesorcionRpta.DTODesorcion.ag_pobre;
                oDesorcionM.hg_rico = oDesorcionRpta.DTODesorcion.hg_rico;
                oDesorcionM.hg_pobre = oDesorcionRpta.DTODesorcion.hg_pobre;
                oDesorcionM.activo = oDesorcionRpta.DTODesorcion.activo;
                oDesorcionM.usuario_crea = oDesorcionRpta.DTODesorcion.usuario_crea;
                oDesorcionM.fecha_crea = oDesorcionRpta.DTODesorcion.fecha_crea;
                oDesorcionM.usuario_mod = oDesorcionRpta.DTODesorcion.usuario_mod;
                oDesorcionM.fecha_mod = oDesorcionRpta.DTODesorcion.fecha_mod;

                oDesorcionM.fecha_desc = oDesorcionRpta.DTODesorcion.fecha.ToShortDateString();
                oDesorcionM.hora_hora_ini = oDesorcionRpta.DTODesorcion.hora_inicio.Substring(0, 2);
                oDesorcionM.hora_min_ini = oDesorcionRpta.DTODesorcion.hora_inicio.Substring(3, 2);

                oDesorcionM.hora_hora_fin = oDesorcionRpta.DTODesorcion.hora_fin.Substring(0, 2);
                oDesorcionM.hora_min_fin = oDesorcionRpta.DTODesorcion.hora_fin.Substring(0, 2);

                oDesorcionM.fecha_desc = oDesorcionRpta.DTODesorcion.fecha.ToShortDateString();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oDesorcionM);
        }

        // POST: Desorcion/Edit/5
        [HttpPost]
        public ActionResult Edit(DTODesorcionM oDesorcionM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTODesorcion oDesorcion = new DTODesorcion();
                    DesorcionBL oDesorcionBL = new DesorcionBL();
                    oDesorcion.desorcion_id = oDesorcionM.desorcion_id;
                    oDesorcion.fecha = Convert.ToDateTime(oDesorcionM.fecha_desc);
                    oDesorcion.num_fundicion = oDesorcionM.num_fundicion;
                    oDesorcion.mes = oDesorcionM.mes;
                    oDesorcion.num_desorcion = oDesorcionM.num_desorcion;
                    oDesorcion.num_desorcion_mes = oDesorcionM.num_desorcion_mes;
                    oDesorcion.num_col_desc = oDesorcionM.num_col_desc;
                    oDesorcion.peso_col_desc = oDesorcionM.peso_col_desc;
                    oDesorcion.hora_inicio = oDesorcionM.hora_inicio;
                    oDesorcion.hora_fin = oDesorcionM.hora_fin;
                    oDesorcion.au_rico = oDesorcionM.au_rico;
                    oDesorcion.au_pobre = oDesorcionM.au_pobre;
                    oDesorcion.ag_rico = oDesorcionM.ag_rico;
                    oDesorcion.ag_pobre = oDesorcionM.ag_pobre;
                    oDesorcion.hg_rico = oDesorcionM.hg_rico;
                    oDesorcion.hg_pobre = oDesorcionM.hg_pobre;
                    oDesorcion.activo = oDesorcionM.activo;
                    oDesorcion.usuario_crea = oDesorcionM.usuario_crea;
                    oDesorcion.fecha_crea = oDesorcionM.fecha_crea;
                    oDesorcion.usuario_mod = Session["USR_COD"].ToString();
                    oDesorcion.fecha_mod = oDesorcionM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oDesorcionBL.actualizarDesorcion(oDesorcion);
                    oDesorcionM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oDesorcionM.resultado = 2;
            }

            return View(oDesorcionM);
        }

        // GET: Desorcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Desorcion/Delete/5
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