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
    public class Lista_valorController : Controller
    {
        // GET: Lista_valor
        public ActionResult Index()
        {
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            DTOLista_valorRespuesta oLista_valorRpta = new DTOLista_valorRespuesta();
            oLista_valorRpta = oLista_valorBL.obtenerLista_valor();
            DTOLista_valorM oLista_valorM = new DTOLista_valorM();
            List<DTOLista_valorM> oLista_Lista_valorM = new List<DTOLista_valorM>();

            if (oLista_valorRpta.DTOListaLista_valor != null)
            {
                foreach (var item in oLista_valorRpta.DTOListaLista_valor)
                {
                    oLista_valorM = new DTOLista_valorM();
                    oLista_valorM.lista_valor_id = item.lista_valor_id;
                    oLista_valorM.lista_id = item.lista_id;
                    oLista_valorM.lista = item.lista;
                    oLista_valorM.valor = item.valor;
                    oLista_valorM.activo = item.activo;
                    oLista_valorM.usuario_crea = item.usuario_crea;
                    oLista_valorM.fecha_crea = item.fecha_crea;
                    oLista_valorM.usuario_mod = item.usuario_mod;
                    oLista_valorM.fecha_mod = item.fecha_mod;
                    oLista_Lista_valorM.Add(oLista_valorM);
                }
            }

            
            return View(oLista_Lista_valorM);
        }

        // GET: Lista_valor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lista_valor/Create
        public ActionResult Create()
        {
            DTOLista_valorM oLista_valor = new DTOLista_valorM();
            cargarCombos(0);
            return View(oLista_valor);
        }

        // POST: Lista_valor/Create
        [HttpPost]
        public ActionResult Create(DTOLista_valorM oLista_valorM)
        {
            try
            {
                // TODO: Add insert logic here
                Lista_valorBL Lista_valorBL = new Lista_valorBL();
                DTOLista_valor oLista_valor = new DTOLista_valor();
                oLista_valor.lista_valor_id = oLista_valorM.lista_valor_id;
                oLista_valor.lista_id = oLista_valorM.lista_id;
                oLista_valor.valor = oLista_valorM.valor;
                oLista_valor.activo = oLista_valorM.activo;
                oLista_valor.usuario_crea = oLista_valorM.usuario_crea;
                oLista_valor.fecha_crea = oLista_valorM.fecha_crea;
                oLista_valor.usuario_mod = oLista_valorM.usuario_mod;
                oLista_valor.fecha_mod = oLista_valorM.fecha_mod;
                Lista_valorBL.registrarLista_valor(oLista_valor);
                oLista_valorM.lista_valor_id = 0;
                oLista_valorM.lista_id = 0;
                oLista_valorM.valor = "";
                oLista_valorM.activo = true;
                oLista_valorM.usuario_crea = Session["USR_COD"].ToString();
                oLista_valorM.fecha_crea = null;
                oLista_valorM.usuario_mod = "";
                oLista_valorM.fecha_mod = null;
                oLista_valorM.resultado = 1;
            }
            catch(Exception ex)
            {
                Logger.Write(ex);
                oLista_valorM.resultado = 1;
            }
            cargarCombos(0);
            return View(oLista_valorM);
        }

        // GET: Lista_valor/Edit/5
        public ActionResult Edit(int id)
        {
            
            DTOLista_valorRespuesta oLista_valorRpta = new DTOLista_valorRespuesta();
            Lista_valorBL oLista_valorBL = new Lista_valorBL();
            DTOLista_valorM oLista_valorM = new DTOLista_valorM();
            try
            {
                oLista_valorRpta = oLista_valorBL.obtenerLista_valor_por_id(id);
                oLista_valorM.lista_valor_id = oLista_valorRpta.DTOLista_valor.lista_valor_id;
                oLista_valorM.lista_id = oLista_valorRpta.DTOLista_valor.lista_id;
                oLista_valorM.valor = oLista_valorRpta.DTOLista_valor.valor;
                oLista_valorM.activo = oLista_valorRpta.DTOLista_valor.activo;
                oLista_valorM.usuario_crea = oLista_valorRpta.DTOLista_valor.usuario_crea;
                oLista_valorM.fecha_crea = oLista_valorRpta.DTOLista_valor.fecha_crea;
                oLista_valorM.usuario_mod = oLista_valorRpta.DTOLista_valor.usuario_mod;
                oLista_valorM.fecha_mod = oLista_valorRpta.DTOLista_valor.fecha_mod;
                oLista_valorM.resultado = 1;
                cargarCombos(oLista_valorM.lista_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oLista_valorM.resultado = 2;
            }
            return View(oLista_valorM);
        }

        // POST: Lista_valor/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOLista_valorM oLista_valorM)
        {
            try
            {
                DTOLista_valor oLista_valor = new DTOLista_valor();
                Lista_valorBL oLista_valorBL = new Lista_valorBL();
                oLista_valor.lista_valor_id = oLista_valorM.lista_valor_id;
                oLista_valor.lista_id = oLista_valorM.lista_id;
                oLista_valor.valor = oLista_valorM.valor;
                oLista_valor.activo = oLista_valorM.activo;
                oLista_valor.usuario_crea = oLista_valorM.usuario_crea;
                oLista_valor.fecha_crea = oLista_valorM.fecha_crea;
                oLista_valor.usuario_mod = Session["USR_COD"].ToString();
                oLista_valor.fecha_mod = oLista_valorM.fecha_mod;
                //oLista.usuario_mod = "MS_USER";

                oLista_valorBL.actualizarLista_valor(oLista_valor);
                oLista_valorM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oLista_valorM.resultado = 2;
            }
            cargarCombos(oLista_valorM.lista_id);
            return View(oLista_valorM);
        }

        // GET: Lista_valor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lista_valor/Delete/5
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

        public void cargarCombos(int lista_id)
        {
            try
            {
                DTOListaRespuesta oListaRpta = new DTOListaRespuesta();
                List<DTOLista> oLista_Lista = new List<DTOLista>();
                ListaBL oListaBL = new ListaBL();
                oListaRpta = oListaBL.obtenerLista();
                oLista_Lista = oListaRpta.DTOListaLista.OrderBy(u => u.lista).ToList();
                ViewBag.Lista = new SelectList(oLista_Lista, "lista_id", "lista",lista_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

    }
}