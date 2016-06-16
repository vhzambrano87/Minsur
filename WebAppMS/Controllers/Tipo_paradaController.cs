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
    public class Tipo_paradaController : Controller
    {
        // GET: Tipo_parada
        public ActionResult Index()
        {
            Tipo_paradaBL oTipo_paradaBL = new Tipo_paradaBL();
            DTOTipo_paradaRespuesta oTipo_paradaRpta = new DTOTipo_paradaRespuesta();
            oTipo_paradaRpta = oTipo_paradaBL.obtenerTipo_parada();
            DTOTipo_paradaM oTipo_paradaM = new DTOTipo_paradaM();
            List<DTOTipo_paradaM> oLista_Tipo_paradaM = new List<DTOTipo_paradaM>();

            if (oTipo_paradaRpta.DTOListaTipo_parada != null)
            {
                foreach (var item in oTipo_paradaRpta.DTOListaTipo_parada)
                {
                    oTipo_paradaM = new DTOTipo_paradaM(); oTipo_paradaM.tipo_parada_id = item.tipo_parada_id;
                    oTipo_paradaM.tipo_parada = item.tipo_parada;
                    oTipo_paradaM.sub_tipo_parada = item.sub_tipo_parada;
                    oTipo_paradaM.codigo_serie = item.codigo_serie;
                    oTipo_paradaM.descripcion_serie = item.descripcion_serie;
                    oTipo_paradaM.estado_serie = item.estado_serie;
                    oTipo_paradaM.observaciones = item.observaciones;
                    oTipo_paradaM.activo = item.activo;
                    oTipo_paradaM.usuario_crea = item.usuario_crea;
                    oTipo_paradaM.fecha_crea = item.fecha_crea;
                    oTipo_paradaM.usuario_mod = item.usuario_mod;
                    oTipo_paradaM.fecha_mod = item.fecha_mod;

                    oTipo_paradaM.tipo_parada_desc = item.tipo_parada_desc;
                    oTipo_paradaM.sub_tipo_parada_desc = item.sub_tipo_parada_desc;
                    oTipo_paradaM.estado_desc = item.estado_desc;

                    oLista_Tipo_paradaM.Add(oTipo_paradaM);
                }
            }


            return View(oLista_Tipo_paradaM);
        }

        // GET: Tipo_parada/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tipo_parada/Create
        public ActionResult Create()
        {
            DTOTipo_paradaM oTipo_paradaM = new DTOTipo_paradaM();
            oTipo_paradaM.activo = true;
            cargarCombos(0,0,0);
            return View(oTipo_paradaM);
        }

        // POST: Tipo_parada/Create
        [HttpPost]
        public ActionResult Create(DTOTipo_paradaM oTipo_paradaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Tipo_paradaBL Tipo_paradaBL = new Tipo_paradaBL();
                    DTOTipo_parada oTipo_parada = new DTOTipo_parada(); oTipo_parada.tipo_parada_id = oTipo_paradaM.tipo_parada_id;
                    oTipo_parada.tipo_parada = oTipo_paradaM.tipo_parada;
                    oTipo_parada.sub_tipo_parada = oTipo_paradaM.sub_tipo_parada;
                    oTipo_parada.codigo_serie = oTipo_paradaM.codigo_serie;
                    oTipo_parada.descripcion_serie = oTipo_paradaM.descripcion_serie;
                    oTipo_parada.estado_serie = oTipo_paradaM.estado_serie;
                    oTipo_parada.observaciones = oTipo_paradaM.observaciones;
                    oTipo_parada.activo = oTipo_paradaM.activo;
                    oTipo_parada.usuario_crea = Session["USR_COD"].ToString();
                    oTipo_parada.fecha_crea = oTipo_paradaM.fecha_crea;
                    oTipo_parada.usuario_mod = oTipo_paradaM.usuario_mod;
                    oTipo_parada.fecha_mod = oTipo_paradaM.fecha_mod;
                    Tipo_paradaBL.registrarTipo_parada(oTipo_parada);
                    
                    oTipo_paradaM.resultado = 1;
                    
                }
                cargarCombos(oTipo_paradaM.tipo_parada_id, oTipo_paradaM.sub_tipo_parada, oTipo_paradaM.estado_serie);

            }
            catch(Exception ex)
            {
                Logger.Write(ex);
                oTipo_paradaM.resultado = 2;
            }

            return View(oTipo_paradaM);
        }

        // GET: Tipo_parada/Edit/5
        public ActionResult Edit(int id)
        {
            DTOTipo_paradaRespuesta oTipo_paradaRpta = new DTOTipo_paradaRespuesta();
            Tipo_paradaBL oTipo_paradaBL = new Tipo_paradaBL();
            DTOTipo_paradaM oTipo_paradaM = new DTOTipo_paradaM();
            try
            {
                oTipo_paradaRpta = oTipo_paradaBL.obtenerTipo_parada_por_id(id);
                oTipo_paradaM.tipo_parada_id = oTipo_paradaRpta.DTOTipo_parada.tipo_parada_id;
                oTipo_paradaM.tipo_parada = oTipo_paradaRpta.DTOTipo_parada.tipo_parada;
                oTipo_paradaM.sub_tipo_parada = oTipo_paradaRpta.DTOTipo_parada.sub_tipo_parada;
                oTipo_paradaM.codigo_serie = oTipo_paradaRpta.DTOTipo_parada.codigo_serie;
                oTipo_paradaM.descripcion_serie = oTipo_paradaRpta.DTOTipo_parada.descripcion_serie;
                oTipo_paradaM.estado_serie = oTipo_paradaRpta.DTOTipo_parada.estado_serie;
                oTipo_paradaM.observaciones = oTipo_paradaRpta.DTOTipo_parada.observaciones;
                oTipo_paradaM.activo = oTipo_paradaRpta.DTOTipo_parada.activo;
                oTipo_paradaM.usuario_crea = oTipo_paradaRpta.DTOTipo_parada.usuario_crea;
                oTipo_paradaM.fecha_crea = oTipo_paradaRpta.DTOTipo_parada.fecha_crea;
                oTipo_paradaM.usuario_mod = oTipo_paradaRpta.DTOTipo_parada.usuario_mod;
                oTipo_paradaM.fecha_mod = oTipo_paradaRpta.DTOTipo_parada.fecha_mod;
                cargarCombos(oTipo_paradaM.tipo_parada, oTipo_paradaM.sub_tipo_parada, oTipo_paradaM.estado_serie);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oTipo_paradaM);
        }

        // POST: Tipo_parada/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOTipo_paradaM oTipo_paradaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOTipo_parada oTipo_parada = new DTOTipo_parada();
                    Tipo_paradaBL oTipo_paradaBL = new Tipo_paradaBL();
                    oTipo_parada.tipo_parada_id = oTipo_paradaM.tipo_parada_id;
                    oTipo_parada.tipo_parada = oTipo_paradaM.tipo_parada;
                    oTipo_parada.sub_tipo_parada = oTipo_paradaM.sub_tipo_parada;
                    oTipo_parada.codigo_serie = oTipo_paradaM.codigo_serie;
                    oTipo_parada.descripcion_serie = oTipo_paradaM.descripcion_serie;
                    oTipo_parada.estado_serie = oTipo_paradaM.estado_serie;
                    oTipo_parada.observaciones = oTipo_paradaM.observaciones;
                    oTipo_parada.activo = oTipo_paradaM.activo;
                    oTipo_parada.usuario_crea = oTipo_paradaM.usuario_crea;
                    oTipo_parada.fecha_crea = oTipo_paradaM.fecha_crea;
                    oTipo_parada.usuario_mod = Session["USR_COD"].ToString();
                    oTipo_parada.fecha_mod = oTipo_paradaM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oTipo_paradaBL.actualizarTipo_parada(oTipo_parada);
                    oTipo_paradaM.resultado = 1;
                }
                    
                cargarCombos(oTipo_paradaM.tipo_parada, oTipo_paradaM.sub_tipo_parada, oTipo_paradaM.estado_serie);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oTipo_paradaM.resultado = 2;
            }

            return View(oTipo_paradaM);
        }

        // GET: Tipo_parada/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tipo_parada/Delete/5
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

        public void cargarCombos(int tipo_parada_id, int sub_tipo_parada_id, int estado_id)
        {
            try
            {
                DTOLista_valorRespuesta oListaRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_TipoParada = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_SubTipoParada = new List<DTOLista_valor>();
                DTOEstadoRespuesta oLista_Estado = new DTOEstadoRespuesta();
                Lista_valorBL oLista_valorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();
                oListaRpta = oLista_valorBL.obtenerLista_valor();
                oLista_TipoParada = oListaRpta.DTOListaLista_valor.OrderBy(u => u.lista).Where(x=>x.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTParada"]) && x.activo == true).ToList();
                oLista_SubTipoParada = oListaRpta.DTOListaLista_valor.OrderBy(u => u.lista).Where(x => x.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaSTParada"]) && x.activo == true).ToList();
                oLista_Estado = oEstadoBL.obtenerEstado();
                    //oListaRpta.DTOListaLista_valor.OrderBy(u => u.lista).Where(x => x.lista_id == 3).ToList();

                ViewBag.ListaTParada = new SelectList(oLista_TipoParada, "lista_valor_id", "valor", tipo_parada_id);
                ViewBag.ListaSTParada = new SelectList(oLista_SubTipoParada, "lista_valor_id", "valor", sub_tipo_parada_id);
                ViewBag.ListaEstado = new SelectList(oLista_Estado.DTOListaEstado, "estado_id", "codigo", estado_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}