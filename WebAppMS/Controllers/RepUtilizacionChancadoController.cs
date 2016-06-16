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
    public class RepUtilizacionChancadoController : Controller
    {
        // GET: UtilizacionChancado
        public ActionResult Index()
        {
            DTORepUtilizacionChancadoM oRepUtilizacionChancadoM = new DTORepUtilizacionChancadoM();
            cargarCombos(0, 0);
            return View(oRepUtilizacionChancadoM);
        }
        [HttpPost]
        public ActionResult Index(DTORepUtilizacionChancadoM oRepUtilizacionChancadoM)
        {
            GenerateExcel(oRepUtilizacionChancadoM);
            cargarCombos(0, 0);
            return View(oRepUtilizacionChancadoM);
        }
        // GET: UtilizacionChancado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtilizacionChancado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilizacionChancado/Create
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

        // GET: UtilizacionChancado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilizacionChancado/Edit/5
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

        // GET: UtilizacionChancado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilizacionChancado/Delete/5
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

        public void GenerateExcel(DTORepUtilizacionChancadoM oRepUtilizacionChancadoM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/Utilizacion_Chancadora.xlsx");
                copia = Server.MapPath("~/Templates/Copia/Utilizacion_Chancadora.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                List<DTOUtilizacion> oListaUtilizacion = new List<DTOUtilizacion>();
                UtilizacionBL oUtilizacionBL = new UtilizacionBL();
                int index = 6;


                oListaUtilizacion = oUtilizacionBL.obtenerUtilizacionRep(oRepUtilizacionChancadoM.area_id, oRepUtilizacionChancadoM.turno_id, oRepUtilizacionChancadoM.fecha_desde, oRepUtilizacionChancadoM.fecha_hasta).DTOListaUtilizacion;


                Logger.Write("Fin oListaUtilizacion.count: " + oListaUtilizacion.Count());

                foreach (var item in oListaUtilizacion)
                {
                    ws.Cells["A" + index].Value = item.mes;
                    ws.Cells["B" + index].Value = item.semana;
                    ws.Cells["C" + index].Value = item.fecha_op;
                    ws.Cells["D" + index].Value = item.dia;

                    ws.Cells["F" + index].Value = item.hop;
                    ws.Cells["G" + index].Value = item.dmtto;
                    ws.Cells["H" + index].Value = item.tmpd;
                    ws.Cells["Q" + index].Value = item.tmph;
                    ws.Cells["R" + index].Value = item.disp;
                    ws.Cells["S" + index].Value = item.util;
                    ws.Cells["T" + index].Value = item.oee;
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

        public void cargarCombos(int area_id, int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Area = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                DTOLista_valor oListaValorGenerico = new DTOLista_valor();
                oListaValorGenerico.lista_valor_id = 0;
                oListaValorGenerico.valor = "-----Todos-----";


                oLista_Area = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaArea"]) && u.activo == true).ToList();
                ViewBag.ListaArea = new SelectList(oLista_Area, "lista_valor_id", "valor", area_id);

                oLista_Turno.Add(oListaValorGenerico);
                oLista_Turno.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList());
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);
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

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteUtilizacion.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }

    }
}
