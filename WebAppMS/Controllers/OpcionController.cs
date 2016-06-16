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
    public class OpcionController : Controller
    {
        // GET: Opcion
        public ActionResult Index()
        {
            OpcionBL oOpcionBL = new OpcionBL();
            DTOOpcionRespuesta oOpcionRpta = new DTOOpcionRespuesta();
            oOpcionRpta = oOpcionBL.obtenerOpcion();
            DTOOpcionM oOpcionM = new DTOOpcionM();
            List<DTOOpcionM> oLista_OpcionM = new List<DTOOpcionM>();

            if (oOpcionRpta.DTOListaOpcion != null)
            {
                foreach (var item in oOpcionRpta.DTOListaOpcion)
                {
                    oOpcionM = new DTOOpcionM(); oOpcionM.opcion_id = item.opcion_id;
                    oOpcionM.opcion_cod = item.opcion_cod;
                    oOpcionM.nombre = item.nombre;
                    oOpcionM.activo = item.activo;
                    oOpcionM.usuario_crea = item.usuario_crea;
                    oOpcionM.fecha_crea = item.fecha_crea;
                    oOpcionM.usuario_mod = item.usuario_mod;
                    oOpcionM.fecha_mod = item.fecha_mod;
                    oLista_OpcionM.Add(oOpcionM);
                }
            }


            return View(oLista_OpcionM);
        }

        // GET: Opcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Opcion/Create
        public ActionResult Create()
        {
            DTOOpcionM oOpcionM = new DTOOpcionM();
            oOpcionM.activo = true;
            return View(oOpcionM);
        }

        // POST: Opcion/Create
        [HttpPost]
        public ActionResult Create(DTOOpcionM oOpcionM)
        {
            try
            {
                // TODO: Add insert logic here
                OpcionBL OpcionBL = new OpcionBL();
                DTOOpcion oOpcion = new DTOOpcion(); oOpcion.opcion_id = oOpcionM.opcion_id;
                oOpcion.opcion_cod = oOpcionM.opcion_cod;
                oOpcion.nombre = oOpcionM.nombre;
                oOpcion.activo = oOpcionM.activo;
                oOpcion.usuario_crea = Session["USR_COD"].ToString();
                oOpcion.fecha_crea = oOpcionM.fecha_crea;
                oOpcion.usuario_mod = oOpcionM.usuario_mod;
                oOpcion.fecha_mod = oOpcionM.fecha_mod;
                OpcionBL.registrarOpcion(oOpcion);

                oOpcionM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oOpcionM.resultado = 2;
            }

            return View(oOpcionM);
        }

        // GET: Opcion/Edit/5
        public ActionResult Edit(int id)
        {
            DTOOpcionRespuesta oOpcionRpta = new DTOOpcionRespuesta();
            OpcionBL oOpcionBL = new OpcionBL();
            DTOOpcionM oOpcionM = new DTOOpcionM();
            try
            {
                oOpcionRpta = oOpcionBL.obtenerOpcion_por_id(id);
                oOpcionM.opcion_id = oOpcionRpta.DTOOpcion.opcion_id;
                oOpcionM.opcion_cod = oOpcionRpta.DTOOpcion.opcion_cod;
                oOpcionM.nombre = oOpcionRpta.DTOOpcion.nombre;
                oOpcionM.activo = oOpcionRpta.DTOOpcion.activo;
                oOpcionM.usuario_crea = oOpcionRpta.DTOOpcion.usuario_crea;
                oOpcionM.fecha_crea = oOpcionRpta.DTOOpcion.fecha_crea;
                oOpcionM.usuario_mod = oOpcionRpta.DTOOpcion.usuario_mod;
                oOpcionM.fecha_mod = oOpcionRpta.DTOOpcion.fecha_mod;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oOpcionM);
        }

        // POST: Opcion/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOOpcionM oOpcionM)
        {
            try
            {
                DTOOpcion oOpcion = new DTOOpcion();
                OpcionBL oOpcionBL = new OpcionBL();
                oOpcion.opcion_id = oOpcionM.opcion_id;
                oOpcion.opcion_cod = oOpcionM.opcion_cod;
                oOpcion.nombre = oOpcionM.nombre;
                oOpcion.activo = oOpcionM.activo;
                oOpcion.usuario_crea = oOpcionM.usuario_crea;
                oOpcion.fecha_crea = oOpcionM.fecha_crea;
                oOpcion.usuario_mod = Session["USR_COD"].ToString();
                oOpcion.fecha_mod = oOpcionM.fecha_mod;
                //oLista.usuario_mod = "MS_USER";

                oOpcionBL.actualizarOpcion(oOpcion);
                oOpcionM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oOpcionM.resultado = 2;
            }

            return View(oOpcionM);
        }

        // GET: Opcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Opcion/Delete/5
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