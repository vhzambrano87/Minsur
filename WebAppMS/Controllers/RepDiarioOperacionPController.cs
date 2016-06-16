using System;
using System.Collections.Generic;
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
    public class RepDiarioOperacionPController : Controller
    {
        // GET: RepDiarioOperacionP
        public ActionResult Index()
        {
            DTORepDiarioOperacionPM oRepDiarioOperacionM = new DTORepDiarioOperacionPM();
            return View(oRepDiarioOperacionM);
        }
        [HttpPost]
        public ActionResult Index(DTORepDiarioOperacionPM oRepDiarioOperacionM)
        {
            GenerateExcel(oRepDiarioOperacionM);
            return View(oRepDiarioOperacionM);
        }
        // GET: RepDiarioOperacionP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepDiarioOperacionP/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepDiarioOperacionP/Create
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

        // GET: RepDiarioOperacionP/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepDiarioOperacionP/Edit/5
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

        // GET: RepDiarioOperacionP/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepDiarioOperacionP/Delete/5
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
        public void GenerateExcel(DTORepDiarioOperacionPM oRepDiarioOperacionM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/ReporteDiarioPlanta.xlsx");
                copia = Server.MapPath("~/Templates/Copia/ReporteDiarioPlanta.xlsx");
                
                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                List<DTOParada> oListaParada = new List<DTOParada>();
                ParadaBL oParadaBL = new ParadaBL();
                int index = 5;


                //oListaParada = oParadaBL.ObtenerReporteParadaChancado(oParadaM.area_id, oParadaM.tipo_parada_id, oParadaM.sub_tipo_parada_id, oParadaM.estado_id, oParadaM.serie_id, oParadaM.turno_id, oParadaM.fecha_desde, oParadaM.fecha_hasta).DTOListaParada;


                //Logger.Write("Fin oListaParada.count: " + oListaParada.Count());

                //foreach (var item in oListaParada)
                //{
                //    ws.Cells["A" + index].Value = "Operario";
                //    ws.Cells["B" + index].Value = item.mes;
                //    ws.Cells["C" + index].Value = item.area_desc;
                //    ws.Cells["D" + index].Value = item.tipo_parada_desc;
                //    ws.Cells["E" + index].Value = item.estado_desc;
                //    ws.Cells["F" + index].Value = item.serie_desc;
                //    ws.Cells["G" + index].Value = "";
                //    ws.Cells["H" + index].Value = item.comentario;
                //    ws.Cells["I" + index].Value = item.fecha;
                //    ws.Cells["J" + index].Value = item.turno_desc;
                //    ws.Cells["K" + index].Value = item.hora_inicio;
                //    ws.Cells["L" + index].Value = item.hora_fin;
                //    index = index + 1;
                //}

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

            Response.AppendHeader("Content-Disposition", "attachment; filename=Test.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }
    }
}
