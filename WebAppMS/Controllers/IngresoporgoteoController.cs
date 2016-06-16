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
    public class IngresoporgoteoController : Controller
    {
        // GET: Ingresoporgoteo
        public ActionResult Index()
        {
            IngresoporgoteoBL oIngresoporgoteoBL = new IngresoporgoteoBL();
            DTOIngresoporgoteoRespuesta oIngresoporgoteoRpta = new DTOIngresoporgoteoRespuesta();
            oIngresoporgoteoRpta = oIngresoporgoteoBL.obtenerIngresoporgoteo();
            DTOIngresoporgoteoM oIngresoporgoteoM = new DTOIngresoporgoteoM();
            List<DTOIngresoporgoteoM> oLista_IngresoporgoteoM = new List<DTOIngresoporgoteoM>();
            Lista_valorBL olistaValorBL = new Lista_valorBL();
            if (oIngresoporgoteoRpta.DTOListaIngresoporgoteo != null)
            {
                foreach (var item in oIngresoporgoteoRpta.DTOListaIngresoporgoteo)
                {
                    oIngresoporgoteoM = new DTOIngresoporgoteoM(); oIngresoporgoteoM.ingresoporgoteo_id = item.ingresoporgoteo_id;
                    oIngresoporgoteoM.codarea = item.codarea;
                    oIngresoporgoteoM.area_desc = item.codarea;
                    oIngresoporgoteoM.flujo = item.flujo;
                    oIngresoporgoteoM.tonelajechancado = item.tonelajechancado;
                    oIngresoporgoteoM.leyauchancado = item.leyauchancado;
                    oIngresoporgoteoM.leyagchancado = item.leyagchancado;
                    oIngresoporgoteoM.tonelaje_overliner_ = item.tonelaje_overliner_;
                    oIngresoporgoteoM.leyauoverliner = item.leyauoverliner;
                    oIngresoporgoteoM.leyagoverliner = item.leyagoverliner;
                    oIngresoporgoteoM.fechainicioapilamiento = item.fechainicioapilamiento;
                    oIngresoporgoteoM.fechafinapilamiento = item.fechafinapilamiento;
                    oIngresoporgoteoM.fechainicioriego = item.fechainicioriego;
                    oIngresoporgoteoM.fechafinriego = item.fechafinriego;
                    oIngresoporgoteoM.fechafinrealriego = item.fechafinrealriego;
                    oIngresoporgoteoM.diariegoalafecha = item.diariegoalafecha;
                    oIngresoporgoteoM.diaprograriego = item.diaprograriego;
                    oIngresoporgoteoM.onzasau = item.onzasau;
                    oIngresoporgoteoM.onzasag = item.onzasag;
                    oIngresoporgoteoM.tms = item.tms;
                    oIngresoporgoteoM.celdaId = item.celdaId;
                    oIngresoporgoteoM.strCelda = olistaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.celdaId)).DTOLista_valor.valor;
                    oIngresoporgoteoM.usuario_crea = item.usuario_crea;
                    oIngresoporgoteoM.fecha_crea = item.fecha_crea;
                    oIngresoporgoteoM.usuario_mod = item.usuario_mod;
                    oIngresoporgoteoM.fecha_mod = item.fecha_mod;
                    oIngresoporgoteoM.activo = item.activo;
                    oLista_IngresoporgoteoM.Add(oIngresoporgoteoM);
                }
            }


            return View(oLista_IngresoporgoteoM);
        }

        // GET: Ingresoporgoteo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingresoporgoteo/Create
        public ActionResult Create()
        {
            DTOIngresoporgoteoM oIngresoporgoteoM = new DTOIngresoporgoteoM();
            oIngresoporgoteoM.activo = true;
            oIngresoporgoteoM.fecha_desc = DateTime.Today.ToShortDateString();
            cargarCombos(0);

            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(1, "Lift"));
            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(2, "Fase"));
            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(3, "Celda/Talud"));

            return View(oIngresoporgoteoM);
        }

        // POST: Ingresoporgoteo/Create
        [HttpPost]
        public ActionResult Create(DTOIngresoporgoteoM oIngresoporgoteoM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    IngresoporgoteoBL IngresoporgoteoBL = new IngresoporgoteoBL();
                    DTOIngresoporgoteo oIngresoporgoteo = new DTOIngresoporgoteo();
                    oIngresoporgoteo.ingresoporgoteo_id = oIngresoporgoteoM.ingresoporgoteo_id;
                    oIngresoporgoteo.codarea = oIngresoporgoteoM.codarea;
                    oIngresoporgoteo.flujo = oIngresoporgoteoM.flujo;
                    oIngresoporgoteo.tonelajechancado = oIngresoporgoteoM.tonelajechancado;

                    oIngresoporgoteo.celdaId = oIngresoporgoteoM.celdaId;

                    oIngresoporgoteo.leyauchancado = oIngresoporgoteoM.leyauchancado;
                    oIngresoporgoteo.leyagchancado = oIngresoporgoteoM.leyagchancado;
                    oIngresoporgoteo.tonelaje_overliner_ = oIngresoporgoteoM.tonelaje_overliner_;
                    oIngresoporgoteo.leyauoverliner = oIngresoporgoteoM.leyauoverliner;
                    oIngresoporgoteo.leyagoverliner = oIngresoporgoteoM.leyagoverliner;
                    oIngresoporgoteo.fechainicioapilamiento = oIngresoporgoteoM.fechainicioapilamiento;
                    oIngresoporgoteo.fechafinapilamiento = oIngresoporgoteoM.fechafinapilamiento;
                    oIngresoporgoteo.fechainicioriego = oIngresoporgoteoM.fechainicioriego;
                    oIngresoporgoteo.fechafinriego = oIngresoporgoteoM.fechafinriego;
                    oIngresoporgoteo.fechafinrealriego = oIngresoporgoteoM.fechafinrealriego;
                    oIngresoporgoteo.diariegoalafecha = oIngresoporgoteoM.diariegoalafecha;
                    oIngresoporgoteo.diaprograriego = oIngresoporgoteoM.diaprograriego;
                    oIngresoporgoteo.onzasau = oIngresoporgoteoM.onzasau;
                    oIngresoporgoteo.onzasag = oIngresoporgoteoM.onzasag;
                    oIngresoporgoteo.tms = oIngresoporgoteoM.tms;

                    oIngresoporgoteo.activo = oIngresoporgoteoM.activo;
                    oIngresoporgoteo.usuario_crea = Session["USR_COD"].ToString();
                    oIngresoporgoteo.fecha_crea = oIngresoporgoteoM.fecha_crea;
                    oIngresoporgoteo.usuario_mod = oIngresoporgoteoM.usuario_mod;
                    oIngresoporgoteo.fecha_mod = oIngresoporgoteoM.fecha_mod;

                    IngresoporgoteoBL.registrarIngresoporgoteo(oIngresoporgoteo);
                    oIngresoporgoteoM.resultado = 1;
                }
                cargarCombos(Convert.ToInt32(oIngresoporgoteoM.celdaId));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oIngresoporgoteoM.resultado = 2;
            }

            return View(oIngresoporgoteoM);
        }

        // GET: Ingresoporgoteo/Edit/5
        public ActionResult Edit(int id)
        {
            DTOIngresoporgoteoRespuesta oIngresoporgoteoRpta = new DTOIngresoporgoteoRespuesta();
            IngresoporgoteoBL oIngresoporgoteoBL = new IngresoporgoteoBL();
            DTOIngresoporgoteoM oIngresoporgoteoM = new DTOIngresoporgoteoM();
            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(1, "Lift"));
            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(2, "Fase"));
            //oIngresoporgoteoM.listaCelda.Add(new DTOCeldaM(3, "Celda/Talud"));
            try
            {
                oIngresoporgoteoRpta = oIngresoporgoteoBL.obtenerIngresoporgoteo_por_id(id);
                oIngresoporgoteoM.ingresoporgoteo_id = oIngresoporgoteoRpta.DTOIngresoporgoteo.ingresoporgoteo_id;
                oIngresoporgoteoM.codarea = oIngresoporgoteoRpta.DTOIngresoporgoteo.codarea;
                oIngresoporgoteoM.celdaId = oIngresoporgoteoRpta.DTOIngresoporgoteo.celdaId;

                oIngresoporgoteoM.flujo = oIngresoporgoteoRpta.DTOIngresoporgoteo.flujo;
                oIngresoporgoteoM.tonelajechancado = oIngresoporgoteoRpta.DTOIngresoporgoteo.tonelajechancado;
                oIngresoporgoteoM.leyauchancado = oIngresoporgoteoRpta.DTOIngresoporgoteo.leyauchancado;
                oIngresoporgoteoM.leyagchancado = oIngresoporgoteoRpta.DTOIngresoporgoteo.leyagchancado;
                oIngresoporgoteoM.tonelaje_overliner_ = oIngresoporgoteoRpta.DTOIngresoporgoteo.tonelaje_overliner_;
                oIngresoporgoteoM.leyauoverliner = oIngresoporgoteoRpta.DTOIngresoporgoteo.leyauoverliner;
                oIngresoporgoteoM.leyagoverliner = oIngresoporgoteoRpta.DTOIngresoporgoteo.leyagoverliner;
                oIngresoporgoteoM.fechainicioapilamiento = oIngresoporgoteoRpta.DTOIngresoporgoteo.fechainicioapilamiento;
                oIngresoporgoteoM.fechafinapilamiento = oIngresoporgoteoRpta.DTOIngresoporgoteo.fechafinapilamiento;
                oIngresoporgoteoM.fechainicioriego = oIngresoporgoteoRpta.DTOIngresoporgoteo.fechainicioriego;
                oIngresoporgoteoM.fechafinriego = oIngresoporgoteoRpta.DTOIngresoporgoteo.fechafinriego;
                oIngresoporgoteoM.fechafinrealriego = oIngresoporgoteoRpta.DTOIngresoporgoteo.fechafinrealriego;
                oIngresoporgoteoM.diariegoalafecha = oIngresoporgoteoRpta.DTOIngresoporgoteo.diariegoalafecha;
                oIngresoporgoteoM.diaprograriego = oIngresoporgoteoRpta.DTOIngresoporgoteo.diaprograriego;
                oIngresoporgoteoM.onzasau = oIngresoporgoteoRpta.DTOIngresoporgoteo.onzasau;
                oIngresoporgoteoM.onzasag = oIngresoporgoteoRpta.DTOIngresoporgoteo.onzasag;
                oIngresoporgoteoM.tms = oIngresoporgoteoRpta.DTOIngresoporgoteo.tms;
                oIngresoporgoteoM.activo = oIngresoporgoteoRpta.DTOIngresoporgoteo.activo;
                oIngresoporgoteoM.usuario_crea = oIngresoporgoteoRpta.DTOIngresoporgoteo.usuario_crea;
                oIngresoporgoteoM.fecha_crea = oIngresoporgoteoRpta.DTOIngresoporgoteo.fecha_crea;
                oIngresoporgoteoM.usuario_mod = oIngresoporgoteoRpta.DTOIngresoporgoteo.usuario_mod;
                oIngresoporgoteoM.fecha_mod = oIngresoporgoteoRpta.DTOIngresoporgoteo.fecha_mod;

                cargarCombos(Convert.ToInt32(oIngresoporgoteoM.celdaId));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oIngresoporgoteoM);
        }

        // POST: Ingresoporgoteo/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOIngresoporgoteoM oIngresoporgoteoM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    DTOIngresoporgoteo oIngresoporgoteo = new DTOIngresoporgoteo();
                    IngresoporgoteoBL oIngresoporgoteoBL = new IngresoporgoteoBL();
                    oIngresoporgoteo.ingresoporgoteo_id = oIngresoporgoteoM.ingresoporgoteo_id;
                    oIngresoporgoteo.codarea = oIngresoporgoteoM.codarea;
                    oIngresoporgoteo.flujo = oIngresoporgoteoM.flujo;
                    oIngresoporgoteo.celdaId = oIngresoporgoteoM.celdaId;
                    oIngresoporgoteo.tonelajechancado = oIngresoporgoteoM.tonelajechancado;
                    oIngresoporgoteo.leyauchancado = oIngresoporgoteoM.leyauchancado;
                    oIngresoporgoteo.leyagchancado = oIngresoporgoteoM.leyagchancado;
                    oIngresoporgoteo.tonelaje_overliner_ = oIngresoporgoteoM.tonelaje_overliner_;
                    oIngresoporgoteo.leyauoverliner = oIngresoporgoteoM.leyauoverliner;
                    oIngresoporgoteo.leyagoverliner = oIngresoporgoteoM.leyagoverliner;
                    oIngresoporgoteo.fechainicioapilamiento = oIngresoporgoteoM.fechainicioapilamiento;
                    oIngresoporgoteo.fechafinapilamiento = oIngresoporgoteoM.fechafinapilamiento;
                    oIngresoporgoteo.fechainicioriego = oIngresoporgoteoM.fechainicioriego;
                    oIngresoporgoteo.fechafinriego = oIngresoporgoteoM.fechafinriego;
                    oIngresoporgoteo.fechafinrealriego = oIngresoporgoteoM.fechafinrealriego;
                    oIngresoporgoteo.diariegoalafecha = oIngresoporgoteoM.diariegoalafecha;
                    oIngresoporgoteo.diaprograriego = oIngresoporgoteoM.diaprograriego;
                    oIngresoporgoteo.onzasau = oIngresoporgoteoM.onzasau;
                    oIngresoporgoteo.onzasag = oIngresoporgoteoM.onzasag;
                    oIngresoporgoteo.tms = oIngresoporgoteoM.tms;
                    oIngresoporgoteo.activo = oIngresoporgoteoM.activo;
                    oIngresoporgoteo.usuario_crea = oIngresoporgoteoM.usuario_crea;
                    oIngresoporgoteo.fecha_crea = oIngresoporgoteoM.fecha_crea;
                    oIngresoporgoteo.usuario_mod = Session["USR_COD"].ToString();
                    oIngresoporgoteo.fecha_mod = oIngresoporgoteoM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oIngresoporgoteoBL.actualizarIngresoporgoteo(oIngresoporgoteo);
                    oIngresoporgoteoM.resultado = 1;
                }
                cargarCombos(Convert.ToInt32(oIngresoporgoteoM.celdaId));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oIngresoporgoteoM.resultado = 2;
            }

            return View(oIngresoporgoteoM);
        }

        // GET: Ingresoporgoteo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ingresoporgoteo/Delete/5
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

        public void cargarCombos(int celda_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Celda = new List<DTOLista_valor>();
         
                Lista_valorBL oListaValorBL = new Lista_valorBL();

                oLista_Celda = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaCelda"]) && u.activo == true).ToList();
                ViewBag.ListaCelda = new SelectList(oLista_Celda, "lista_valor_id", "valor", celda_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}