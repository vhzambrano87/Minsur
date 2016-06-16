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
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            EstadoBL oEstadoBL = new EstadoBL();
            DTOEstadoRespuesta oEstadoRpta = new DTOEstadoRespuesta();
            oEstadoRpta = oEstadoBL.obtenerEstado();
            DTOEstadoM oEstadoM = new DTOEstadoM();
            List<DTOEstadoM> oLista_EstadoM = new List<DTOEstadoM>();

            if (oEstadoRpta.DTOListaEstado != null)
            {
                foreach (var item in oEstadoRpta.DTOListaEstado)
                {
                    oEstadoM = new DTOEstadoM(); oEstadoM.estado_id = item.estado_id;
                    oEstadoM.codigo = item.codigo;
                    oEstadoM.descripcion = item.descripcion;
                    oEstadoM.tipo_mantenimiento = item.tipo_mantenimiento;
                    oEstadoM.activo = item.activo;
                    oEstadoM.usuario_crea = item.usuario_crea;
                    oEstadoM.fecha_crea = item.fecha_crea;
                    oEstadoM.usuario_mod = item.usuario_mod;
                    oEstadoM.fecha_mod = item.fecha_mod;
                    oLista_EstadoM.Add(oEstadoM);
                }
            }


            return View(oLista_EstadoM);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            DTOEstadoM oEstadoM = new DTOEstadoM();
            oEstadoM.activo = true;
            return View(oEstadoM);
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(DTOEstadoM oEstadoM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    EstadoBL EstadoBL = new EstadoBL();
                    DTOEstado oEstado = new DTOEstado(); oEstado.estado_id = oEstadoM.estado_id;
                    oEstado.codigo = oEstadoM.codigo;
                    oEstado.descripcion = oEstadoM.descripcion;
                    oEstado.tipo_mantenimiento = oEstadoM.tipo_mantenimiento;
                    oEstado.activo = oEstadoM.activo;
                    oEstado.usuario_crea = oEstadoM.usuario_crea;
                    oEstado.fecha_crea = oEstadoM.fecha_crea;
                    oEstado.usuario_mod = oEstadoM.usuario_mod;
                    oEstado.fecha_mod = oEstadoM.fecha_mod;
                    EstadoBL.registrarEstado(oEstado);
                    oEstadoM.estado_id = 0;
                    oEstadoM.codigo = "";
                    oEstadoM.descripcion = "";
                    oEstadoM.tipo_mantenimiento = true;
                    oEstadoM.activo = true;
                    oEstadoM.usuario_crea = Session["USR_COD"].ToString();
                    oEstadoM.fecha_crea = null;
                    oEstadoM.usuario_mod = "";
                    oEstadoM.fecha_mod = null;
                    oEstadoM.resultado = 1;

                }

                    
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
                oEstadoM.resultado = 2;
            }
            return View(oEstadoM);
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            DTOEstadoRespuesta oEstadoRpta = new DTOEstadoRespuesta();
            EstadoBL oEstadoBL = new EstadoBL();
            DTOEstadoM oEstadoM = new DTOEstadoM();
            try
            {
                oEstadoRpta = oEstadoBL.obtenerEstado_por_id(id);
                oEstadoM.estado_id = oEstadoRpta.DTOEstado.estado_id;
                oEstadoM.codigo = oEstadoRpta.DTOEstado.codigo;
                oEstadoM.descripcion = oEstadoRpta.DTOEstado.descripcion;
                oEstadoM.tipo_mantenimiento = oEstadoRpta.DTOEstado.tipo_mantenimiento;
                oEstadoM.activo = oEstadoRpta.DTOEstado.activo;
                oEstadoM.usuario_crea = oEstadoRpta.DTOEstado.usuario_crea;
                oEstadoM.fecha_crea = oEstadoRpta.DTOEstado.fecha_crea;
                oEstadoM.usuario_mod = oEstadoRpta.DTOEstado.usuario_mod;
                oEstadoM.fecha_mod = oEstadoRpta.DTOEstado.fecha_mod;

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oEstadoM);
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOEstadoM oEstadoM)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    DTOEstado oEstado = new DTOEstado();
                    EstadoBL oEstadoBL = new EstadoBL();
                    oEstado.estado_id = oEstadoM.estado_id;
                    oEstado.codigo = oEstadoM.codigo;
                    oEstado.descripcion = oEstadoM.descripcion;
                    oEstado.tipo_mantenimiento = oEstadoM.tipo_mantenimiento;
                    oEstado.activo = oEstadoM.activo;
                    oEstado.usuario_crea = oEstadoM.usuario_crea;
                    oEstado.fecha_crea = oEstadoM.fecha_crea;
                    oEstado.usuario_mod = Session["USR_COD"].ToString();
                    oEstado.fecha_mod = oEstadoM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oEstadoBL.actualizarEstado(oEstado);
                    oEstadoM.resultado = 1;

                }

                    
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oEstadoM.resultado = 2;
            }

            return View(oEstadoM);
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estado/Delete/5
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