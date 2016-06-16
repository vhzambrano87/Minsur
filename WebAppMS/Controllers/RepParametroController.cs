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
    public class RepParametroController : Controller
    {
        // GET: RepParametro
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DTOParametroM oParametro)
        {
            try
            {
                GenerateExcel();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        public void GenerateExcel()
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/ReporteParametroPlantaDia.xlsx");
                copia = Server.MapPath("~/Templates/Copia/ReporteParametroPlantaDia.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                ParametroBL oParametroBL = new ParametroBL();
                List<DTOParametro> oListaParametro = new List<DTOParametro>();
                oListaParametro = oParametroBL.obtenerParametro().DTOListaParametro.Where(u => u.activo == true).ToList();

                int index = 5;

                foreach (var item in oListaParametro)
                {
                    ws.Cells["B" + index].Value = Convert.ToDateTime(item.fecha_crea).ToShortDateString();
                    ws.Cells["C" + index].Value = Convert.ToDateTime(item.fecha_crea).Month;
                    ws.Cells["D" + index].Value = item.horas.ToString();
                    ws.Cells["E" + index].Value = item.total_ini;
                    ws.Cells["F" + index].Value = item.total_fin;
                    ws.Cells["G" + index].Value = item.flujo_dia;
                    ws.Cells["H" + index].Value = item.nivel_poza_pls;
                    ws.Cells["I" + index].Value = item.nivel_poza_may;
                    ws.Cells["J" + index].Value = item.vol_poza_pls;
                    ws.Cells["K" + index].Value = item.vol_poza_may;

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

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteParametro.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }
    }
}
