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
    public class RepAdsorcionController : Controller
    {
        // GET: RepAdsorcion
        public ActionResult Index()
        {
            DTORepAdsorcionM oRepAdsorcionM = new DTORepAdsorcionM();
            cargarCombos(0);
            return View(oRepAdsorcionM);
        }
        [HttpPost]
        public ActionResult Index(DTORepAdsorcionM oRepAdsorcionM)
        {
            GenerateExcel(oRepAdsorcionM);
            cargarCombos(0);
            return View(oRepAdsorcionM);
        }

        // GET: RepAdsorcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepAdsorcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepAdsorcion/Create
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

        // GET: RepAdsorcion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RepAdsorcion/Edit/5
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

        // GET: RepAdsorcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RepAdsorcion/Delete/5
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


        public void GenerateExcel(DTORepAdsorcionM oRepAdsorcionM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/ReporteAdsorcion.xlsx");
                copia = Server.MapPath("~/Templates/Copia/ReporteAdsorcion.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var wsAu = pck.Workbook.Worksheets["ReporteAu"];
                var wsAg = pck.Workbook.Worksheets["ReporteAg"];

                wsAu.View.ShowGridLines = true;
                wsAg.View.ShowGridLines = true;


                AdsorcionBL oAdsorcionBL = new AdsorcionBL();

                List<DTOAdsorcion> oListaAdsorcion = new List<DTOAdsorcion>();
                oListaAdsorcion = oAdsorcionBL.ObtenerReporteAdsorcion(oRepAdsorcionM.tipo_id, oRepAdsorcionM.fecha_desde, oRepAdsorcionM.fecha_hasta).DTOListaAdsorcion;

                int index = 6;

                Logger.Write("Fin oListaAdsorcion.count: " + oListaAdsorcion.Count());


                if (oRepAdsorcionM.tipo_id == 0)
                {
                    foreach (var item in oListaAdsorcion)
                    {
                        wsAu.Cells["A" + index].Value = item.fecha_desc;
                        wsAu.Cells["B" + index].Value = item.mes;
                        wsAu.Cells["C" + index].Value = item.horas.ToString();
                        wsAu.Cells["D" + index].Value = item.flujo_ini_1;
                        wsAu.Cells["E" + index].Value = item.au_ing_n1;
                        wsAu.Cells["F" + index].Value = item.au_sal_n1;
                        wsAu.Cells["G" + index].Value = "";
                        wsAu.Cells["H" + index].Value = item.flujo_ini_2;
                        wsAu.Cells["I" + index].Value = item.au_ing_n2;
                        wsAu.Cells["J" + index].Value = item.au_sal_n2;
                        index = index + 1;
                    }
                    index = 6;

                    foreach (var item in oListaAdsorcion)
                    {
                        wsAg.Cells["A" + index].Value = item.fecha_desc;
                        wsAg.Cells["B" + index].Value = item.mes;
                        wsAg.Cells["C" + index].Value = item.horas.ToString();
                        wsAg.Cells["D" + index].Value = item.flujo_ini_1;
                        wsAg.Cells["E" + index].Value = item.au_ing_n1;
                        wsAg.Cells["F" + index].Value = item.au_sal_n1;
                        wsAg.Cells["G" + index].Value = "";
                        wsAg.Cells["H" + index].Value = item.flujo_ini_2;
                        wsAg.Cells["I" + index].Value = item.au_ing_n2;
                        wsAg.Cells["J" + index].Value = item.au_sal_n2;
                        index = index + 1;
                    }
                }
                else
                {
                        if (oRepAdsorcionM.tipo_id == Convert.ToInt32(ConfigurationManager.AppSettings["TipoAu"]))
                        {

                            foreach (var item in oListaAdsorcion)
                            {
                                wsAu.Cells["A" + index].Value = item.fecha_desc;
                                wsAu.Cells["B" + index].Value = item.mes;
                                wsAu.Cells["C" + index].Value = item.horas.ToString();
                                wsAu.Cells["D" + index].Value = item.flujo_ini_1;
                                wsAu.Cells["E" + index].Value = item.au_ing_n1;
                                wsAu.Cells["F" + index].Value = item.au_sal_n1;
                                wsAu.Cells["G" + index].Value = "";
                                wsAu.Cells["H" + index].Value = item.flujo_ini_2;
                                wsAu.Cells["I" + index].Value = item.au_ing_n2;
                                wsAu.Cells["J" + index].Value = item.au_sal_n2;
                                index = index + 1;
                            }
                        }

                        if (oRepAdsorcionM.tipo_id == Convert.ToInt32(ConfigurationManager.AppSettings["TipoAg"]))
                        {

                            foreach (var item in oListaAdsorcion)
                            {
                                wsAg.Cells["A" + index].Value = item.fecha_desc;
                                wsAg.Cells["B" + index].Value = item.mes;
                                wsAg.Cells["C" + index].Value = item.horas.ToString();
                                wsAg.Cells["D" + index].Value = item.flujo_ini_1;
                                wsAg.Cells["E" + index].Value = item.au_ing_n1;
                                wsAg.Cells["F" + index].Value = item.au_sal_n1;
                                wsAg.Cells["G" + index].Value = "";
                                wsAg.Cells["H" + index].Value = item.flujo_ini_2;
                                wsAg.Cells["I" + index].Value = item.au_ing_n2;
                                wsAg.Cells["J" + index].Value = item.au_sal_n2;
                                index = index + 1;
                            }
                        }

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

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteAdsorcion.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }

    }
}
