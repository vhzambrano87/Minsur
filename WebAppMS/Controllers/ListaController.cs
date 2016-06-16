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
    public class ListaController : Controller
    {
        // GET: Lista
        public ActionResult Index()
        {
            ListaBL oListaBL = new ListaBL();
            DTOListaRespuesta oListaRpta = new DTOListaRespuesta();
            oListaRpta = oListaBL.obtenerLista();
            DTOListaM oListaM = new DTOListaM();
            List<DTOListaM> oLista_ListaM = new List<DTOListaM>();

            if (oListaRpta.DTOListaLista != null)
            {
                foreach (var item in oListaRpta.DTOListaLista)
                {
                    oListaM = new DTOListaM(); oListaM.lista_id = item.lista_id;
                    oListaM.lista = item.lista;
                    oListaM.activo = item.activo;
                    oListaM.usuario_crea = item.usuario_crea;
                    oListaM.fecha_crea = item.fecha_crea;
                    oListaM.usuario_mod = item.usuario_mod;
                    oListaM.fecha_mod = item.fecha_mod;
                    oLista_ListaM.Add(oListaM);
                }
            }


            return View(oLista_ListaM);
        }

        // GET: Lista/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lista/Create
        [HttpPost]
        public ActionResult Create(DTOListaM oListaM)
        {
            try
            {
                // TODO: Add insert logic here
                ListaBL ListaBL = new ListaBL();
                DTOLista oLista = new DTOLista(); oLista.lista_id = oListaM.lista_id;
                oLista.lista = oListaM.lista;
                oLista.activo = oListaM.activo;
                oLista.usuario_crea = oListaM.usuario_crea;
                oLista.fecha_crea = oListaM.fecha_crea;
                oLista.usuario_mod = oListaM.usuario_mod;
                oLista.fecha_mod = oListaM.fecha_mod;
                ListaBL.registrarLista(oLista);
                oListaM.lista_id = 0;
                oListaM.lista = "";
                oListaM.activo = true;
                oListaM.usuario_crea = "";
                oListaM.fecha_crea = null;
                oListaM.usuario_mod = "";
                oListaM.fecha_mod = null;
                oListaM.resultado = 1;
            }
            catch
            {
                return View();
            }

            return View(oListaM);
        }

        // GET: Lista/Edit/5
        public ActionResult Edit(int id)
        {
            DTOListaRespuesta oListaRpta = new DTOListaRespuesta();
            ListaBL oListaBL = new ListaBL();
            DTOListaM oListaM = new DTOListaM();
            try
            {
                oListaRpta = oListaBL.obtenerLista_por_id(id);

                oListaM.lista_id = oListaRpta.DTOLista.lista_id;
                oListaM.lista = oListaRpta.DTOLista.lista;
                oListaM.activo = oListaRpta.DTOLista.activo;
                oListaM.usuario_crea = oListaRpta.DTOLista.usuario_crea;
                oListaM.fecha_crea = oListaRpta.DTOLista.fecha_crea;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oListaM);
        }

        // POST: Lista/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOListaM oListaM)
        {
            try
            {
                DTOLista oLista = new DTOLista();
                ListaBL oListaBL = new ListaBL();
                oLista.lista_id = oListaM.lista_id;
                oLista.lista = oListaM.lista;
                oLista.activo = oListaM.activo;
                oLista.usuario_crea = oListaM.usuario_crea;
                oLista.fecha_crea = oListaM.fecha_crea;
                oLista.usuario_mod = Session["USR_COD"].ToString();

                oListaBL.actualizarLista(oLista);
                oListaM.resultado = 1;
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
                oListaM.resultado = 2;
            }

            return View(oListaM);
        }

        // GET: Lista/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lista/Delete/5
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