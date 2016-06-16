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
using System.IO;
using OfficeOpenXml;

namespace WebAppMS.Controllers
{
    public class ParametroController : Controller
    {
        // GET: Parametro
        public ActionResult Index()
        {
            ParametroBL oParametroBL = new ParametroBL();
            DTOParametroRespuesta oParametroRpta = new DTOParametroRespuesta();
            oParametroRpta = oParametroBL.obtenerParametro();
            DTOParametroM oParametroM = new DTOParametroM();
            List<DTOParametroM> oLista_ParametroM = new List<DTOParametroM>();

            if (oParametroRpta.DTOListaParametro != null)
            {
                foreach (var item in oParametroRpta.DTOListaParametro)
                {
                    oParametroM = new DTOParametroM(); oParametroM.parametro_id = item.parametro_id;
                    oParametroM.horas = item.horas;
                    oParametroM.total_ini = item.total_ini;
                    oParametroM.total_fin = item.total_fin;
                    oParametroM.flujo_dia = item.flujo_dia;
                    oParametroM.nivel_poza_pls = item.nivel_poza_pls;
                    oParametroM.nivel_poza_may = item.nivel_poza_may;
                    oParametroM.vol_poza_pls = item.vol_poza_pls;
                    oParametroM.vol_poza_may = item.vol_poza_may;
                    oParametroM.activo = item.activo;
                    oParametroM.usuario_crea = item.usuario_crea;
                    oParametroM.fecha_crea = item.fecha_crea;
                    oParametroM.usuario_mod = item.usuario_mod;
                    oParametroM.fecha_mod = item.fecha_mod;
                    oLista_ParametroM.Add(oParametroM);
                }
            }


            return View(oLista_ParametroM);
        }

        // GET: Parametro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parametro/Create
        public ActionResult Create()
        {
            DTOParametroM oParametroM = new DTOParametroM();
            oParametroM.activo = true;        
            return View(oParametroM);
        }

        // POST: Parametro/Create
        [HttpPost]
        public ActionResult Create(DTOParametroM oParametroM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    ParametroBL ParametroBL = new ParametroBL();
                    DTOParametro oParametro = new DTOParametro(); oParametro.parametro_id = oParametroM.parametro_id;
                    oParametro.horas = oParametroM.horas;
                    oParametro.total_ini = oParametroM.total_ini;
                    oParametro.total_fin = oParametroM.total_fin;
                    oParametro.flujo_dia = oParametroM.flujo_dia;
                    oParametro.nivel_poza_pls = oParametroM.nivel_poza_pls;
                    oParametro.nivel_poza_may = oParametroM.nivel_poza_may;
                    oParametro.vol_poza_pls = oParametroM.vol_poza_pls;
                    oParametro.vol_poza_may = oParametroM.vol_poza_may;
                    oParametro.activo = oParametroM.activo;
                    oParametro.usuario_crea = Session["USR_COD"].ToString();
                    oParametro.fecha_crea = oParametroM.fecha_crea;
                    oParametro.usuario_mod = oParametroM.usuario_mod;
                    oParametro.fecha_mod = oParametroM.fecha_mod;
                    ParametroBL.registrarParametro(oParametro);
                    
                    oParametroM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oParametroM.resultado = 2;
            }

            return View(oParametroM);
        }

        // GET: Parametro/Edit/5
        public ActionResult Edit(int id)
        {
            DTOParametroRespuesta oParametroRpta = new DTOParametroRespuesta();
            ParametroBL oParametroBL = new ParametroBL();
            DTOParametroM oParametroM = new DTOParametroM();
            try
            {
                oParametroRpta = oParametroBL.obtenerParametro_por_id(id);
                oParametroM.parametro_id = oParametroRpta.DTOParametro.parametro_id;
                oParametroM.horas = oParametroRpta.DTOParametro.horas;
                oParametroM.total_ini = oParametroRpta.DTOParametro.total_ini;
                oParametroM.total_fin = oParametroRpta.DTOParametro.total_fin;
                oParametroM.flujo_dia = oParametroRpta.DTOParametro.flujo_dia;
                oParametroM.nivel_poza_pls = oParametroRpta.DTOParametro.nivel_poza_pls;
                oParametroM.nivel_poza_may = oParametroRpta.DTOParametro.nivel_poza_may;
                oParametroM.vol_poza_pls = oParametroRpta.DTOParametro.vol_poza_pls;
                oParametroM.vol_poza_may = oParametroRpta.DTOParametro.vol_poza_may;
                oParametroM.activo = oParametroRpta.DTOParametro.activo;
                oParametroM.usuario_crea = oParametroRpta.DTOParametro.usuario_crea;
                oParametroM.fecha_crea = oParametroRpta.DTOParametro.fecha_crea;
                oParametroM.usuario_mod = oParametroRpta.DTOParametro.usuario_mod;
                oParametroM.fecha_mod = oParametroRpta.DTOParametro.fecha_mod;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oParametroM);
        }

        // POST: Parametro/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOParametroM oParametroM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOParametro oParametro = new DTOParametro();
                    ParametroBL oParametroBL = new ParametroBL();
                    oParametro.parametro_id = oParametroM.parametro_id;
                    oParametro.horas = oParametroM.horas;
                    oParametro.total_ini = oParametroM.total_ini;
                    oParametro.total_fin = oParametroM.total_fin;
                    oParametro.flujo_dia = oParametroM.flujo_dia;
                    oParametro.nivel_poza_pls = oParametroM.nivel_poza_pls;
                    oParametro.nivel_poza_may = oParametroM.nivel_poza_may;
                    oParametro.vol_poza_pls = oParametroM.vol_poza_pls;
                    oParametro.vol_poza_may = oParametroM.vol_poza_may;
                    oParametro.activo = oParametroM.activo;
                    oParametro.usuario_crea = oParametroM.usuario_crea;
                    oParametro.fecha_crea = oParametroM.fecha_crea;
                    oParametro.usuario_mod = Session["USR_COD"].ToString();
                    oParametro.fecha_mod = oParametroM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oParametroBL.actualizarParametro(oParametro);
                    oParametroM.resultado = 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oParametroM.resultado = 2;
            }

            return View(oParametroM);
        }

        // GET: Parametro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parametro/Delete/5
            
        

    }
}