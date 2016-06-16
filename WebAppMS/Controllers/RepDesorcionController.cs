using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using OfficeOpenXml;
using WebAppMS.Models;

namespace WebAppMS.Controllers
{
    public class RepDesorcionController : Controller
    {
        // GET: RepDesorcion
        public ActionResult Index()
        {
            DTORepDesorcionM oRepDesorcionM = new DTORepDesorcionM();
            cargarCombos(0);
            return View(oRepDesorcionM);
        }

        [HttpPost]
        public ActionResult Index(DTORepDesorcionM oRepDesorcionM)
        {
            GenerateExcel(oRepDesorcionM);
            cargarCombos(0);
            return View(oRepDesorcionM);
        }
        // GET: RepDesorcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepDesorcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepDesorcion/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepDesorcion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepDesorcion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RepDesorcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepDesorcion/Delete/5
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

        public void cargarCombos(int tipo_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Tipo = new List<DTOLista_valor>();
                Lista_valorBL oListaValorBL = new Lista_valorBL();


                DTOLista_valor oListaValorGenerico = new DTOLista_valor();
                oListaValorGenerico.lista_valor_id = 0;
                oListaValorGenerico.valor = "-----Todos-----";

                oLista_Tipo.Add(oListaValorGenerico);
                oLista_Tipo.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTipo"]) && u.activo == true).ToList());
                ViewBag.ListaTipo = new SelectList(oLista_Tipo, "lista_valor_id", "valor", tipo_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void GenerateExcel(DTORepDesorcionM oRepDesorcionM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/ReporteDesorcion.xlsx");
                copia = Server.MapPath("~/Templates/Copia/ReporteDesorcion.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                List<DTODesorcion> oListaDesorcion = new List<DTODesorcion>();
                DesorcionBL oDesorcionBL = new DesorcionBL();
                int index = 6;

                oListaDesorcion = oDesorcionBL.ObtenerReporteDesorcion(oRepDesorcionM.periodo_desde, oRepDesorcionM.periodo_hasta).DTOListaDesorcion;

                Logger.Write("Fin oListaDesorcion.count: " + oListaDesorcion.Count());

                foreach (var item in oListaDesorcion)
                {
                    ws.Cells["B" + index].Value = item.fecha_desc;
                    ws.Cells["C" + index].Value = item.num_desorcion_mes;
                    ws.Cells["D" + index].Value = item.num_fundicion;
                    ws.Cells["E" + index].Value = item.num_desorcion;
                    ws.Cells["F" + index].Value = item.num_col_desc;
                    ws.Cells["G" + index].Value = "";
                    ws.Cells["H" + index].Value = "";
                    ws.Cells["I" + index].Value = item.tiempo_desorcion;
                    ws.Cells["J" + index].Value = item.au_rico;
                    ws.Cells["K" + index].Value = item.au_pobre;
                    ws.Cells["N" + index].Value = item.ag_rico;
                    ws.Cells["O" + index].Value = item.ag_pobre;
                    ws.Cells["R" + index].Value = item.hg_rico;
                    ws.Cells["S" + index].Value = item.hg_pobre;
                    index = index + 1;
                }

                pck.Save();
                Download(copia);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

        public void Download(string ruta)
        {
            Response.ContentType = "application/vnd.ms-excel";
            string fileName = ruta;

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteDesorcion.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }
    }
}
