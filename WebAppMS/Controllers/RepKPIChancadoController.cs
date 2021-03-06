﻿using System;
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
    public class RepKPIChancadoController : Controller
    {
        // GET: KPIChancado
        public ActionResult Index()
        {
            DTORepKPIChancadoM oRepKPIChancadoM = new DTORepKPIChancadoM();
            cargarCombos(0);
            return View(oRepKPIChancadoM);
        }
        [HttpPost]
        public ActionResult Index(DTORepKPIChancadoM oRepKPIChancadoM)
        {
            GenerateExcel(oRepKPIChancadoM);
            cargarCombos(0);
            return View(oRepKPIChancadoM);
        }
        // GET: KPIChancado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KPIChancado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KPIChancado/Create
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

        // GET: KPIChancado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KPIChancado/Edit/5
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

        // GET: KPIChancado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KPIChancado/Delete/5
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

        public void cargarCombos(int area_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Area = new List<DTOLista_valor>();
                Lista_valorBL oListaValorBL = new Lista_valorBL();


                DTOLista_valor oListaValorGenerico = new DTOLista_valor();
                oListaValorGenerico.lista_valor_id = 0;
                oListaValorGenerico.valor = "-----Todos-----";

                oLista_Area = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaArea"]) && u.activo == true).ToList();
                ViewBag.ListaArea = new SelectList(oLista_Area, "lista_valor_id", "valor", area_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }

        public void GenerateExcel(DTORepKPIChancadoM oRepKPIChancadoM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/KPI.xlsx");
                copia = Server.MapPath("~/Templates/Copia/KPI.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                //KPI ORE
                var ws = pck.Workbook.Worksheets["KPI CHAN"];
                ws.View.ShowGridLines = true;

                //List<DTOParada> oListaParada = new List<DTOParada>();
                //ParadaBL oParadaBL = new ParadaBL();
                //int index = 5;


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
