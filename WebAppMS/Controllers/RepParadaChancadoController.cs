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
    public class RepParadaChancadoController : Controller
    {
        // GET: ParadaChancado
        public ActionResult Index()
        {
            DTOParadaM oParadaM = new DTOParadaM();
            cargarCombos(0,0,0,0,0,0);
            return View(oParadaM);
        }
        [HttpPost]
        public ActionResult Index(DTOParadaM oParadaM)
        {
            GenerateExcel(oParadaM);
            cargarCombos(0, 0, 0, 0, 0, 0);
            return View(oParadaM);
        }

        // GET: ParadaChancado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParadaChancado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParadaChancado/Create
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

        // GET: ParadaChancado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParadaChancado/Edit/5
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

        // GET: ParadaChancado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParadaChancado/Delete/5
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


        public void cargarCombos(int area_id, int turno_id, int tipo_parada_id, int sub_tipo_parada_id, int estado_id, int serie_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Area = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_TipoParada = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_STipoParada = new List<DTOLista_valor>();
                List<DTOEstado> oLista_Estado = new List<DTOEstado>();
                List<DTOLista_valor> oLista_Serie = new List<DTOLista_valor>();
                

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();


                DTOLista_valor oListaValorGenerico = new DTOLista_valor();
                oListaValorGenerico.lista_valor_id = 0;
                oListaValorGenerico.valor = "-----Todos-----";

                DTOEstado oEstadoGenerico = new DTOEstado();
                oEstadoGenerico.estado_id = 0;
                oEstadoGenerico.codigo = "-----Todos-----";

                //oLista_Area.Add(oListaValorGenerico);
                oLista_Area = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaArea"]) && u.activo == true).ToList();
                ViewBag.ListaArea = new SelectList(oLista_Area, "lista_valor_id", "valor", area_id);

                oLista_Turno.Add(oListaValorGenerico);
                oLista_Turno.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList());
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_TipoParada.Add(oListaValorGenerico);
                oLista_TipoParada.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTParada"]) && u.activo == true).ToList());
                ViewBag.ListaTParada = new SelectList(oLista_TipoParada, "lista_valor_id", "valor", tipo_parada_id);

                oLista_STipoParada.Add(oListaValorGenerico);
                oLista_STipoParada.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaSTParada"]) && u.activo == true).ToList());
                ViewBag.ListaSTParada = new SelectList(oLista_STipoParada, "lista_valor_id", "valor", sub_tipo_parada_id);

                oLista_Estado.Add(oEstadoGenerico);
                oLista_Estado.AddRange(oEstadoBL.obtenerEstado().DTOListaEstado.Where(u=>u.activo==true).OrderBy(u => u.codigo).ToList());
                ViewBag.ListaEstado = new SelectList(oLista_Estado, "estado_id", "codigo", estado_id);

                oLista_Serie.Add(oListaValorGenerico);
                oLista_Serie.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaSerie"]) && u.activo == true).ToList());
                ViewBag.ListaSerie = new SelectList(oLista_Serie, "lista_valor_id", "valor", serie_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void GenerateExcel(DTOParadaM oParadaM)
        {
            try
            {
                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string area = olistaValorBL.obtenerLista_valor().DTOListaLista_valor.FirstOrDefault(u=>u.lista_valor_id == oParadaM.area_id).valor;
                Logger.Write("area: " + area);
                string copia = "";

                if (area.ToUpper().Trim().Contains("ORE BIN"))
                {
                    templateDocument = Server.MapPath("~/Templates/ChancadoADR/Parada_Chancado_OreBin.xlsx");
                    copia = Server.MapPath("~/Templates/Copia/Parada_Chancado_OreBin.xlsx");
                }
                else
                {
                    templateDocument = Server.MapPath("~/Templates/ChancadoADR/Parada_Chancado.xlsx");
                    copia = Server.MapPath("~/Templates/Copia/Parada_Chancado.xlsx");
                }
                

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                List<DTOParada> oListaParada = new List<DTOParada>();
                ParadaBL oParadaBL = new ParadaBL();
                int index = 5;


                oListaParada = oParadaBL.ObtenerReporteParadaChancado(oParadaM.area_id, oParadaM.tipo_parada_id, oParadaM.sub_tipo_parada_id, oParadaM.estado_id, oParadaM.serie_id, oParadaM.turno_id, oParadaM.fecha_desde, oParadaM.fecha_hasta).DTOListaParada;


                Logger.Write("Fin oListaParada.count: " + oListaParada.Count());

                foreach (var item in oListaParada)
                {
                    ws.Cells["A" + index].Value = "Operario";
                    ws.Cells["B" + index].Value = item.mes;
                    ws.Cells["C" + index].Value = item.area_desc;
                    ws.Cells["D" + index].Value = item.tipo_parada_desc;
                    ws.Cells["E" + index].Value = item.estado_desc;
                    ws.Cells["F" + index].Value = item.serie_desc;
                    ws.Cells["G" + index].Value = "";
                    ws.Cells["H" + index].Value = item.comentario;
                    ws.Cells["I" + index].Value = item.fecha;
                    ws.Cells["J" + index].Value = item.turno_desc;
                    ws.Cells["K" + index].Value = item.hora_inicio;
                    ws.Cells["L" + index].Value = item.hora_fin;
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

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteChancado.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }

    }
}
