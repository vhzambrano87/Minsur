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
    public class RepProduccionChancadoController : Controller
    {
        // GET: ProduccionChancado
        public ActionResult Index()
        {
            DTORepProduccionChancadoM oRepProduccionChancado = new DTORepProduccionChancadoM();
            cargarCombos(0,0,0);
            return View(oRepProduccionChancado);
        }
        [HttpPost]
        public ActionResult Index(DTORepProduccionChancadoM oRepProduccionChancado)
        {
            GenerateExcel(oRepProduccionChancado);
            cargarCombos(0,0,0);
            return View(oRepProduccionChancado);
        }
        // GET: ProduccionChancado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProduccionChancado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduccionChancado/Create
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

        // GET: ProduccionChancado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProduccionChancado/Edit/5
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

        // GET: ProduccionChancado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProduccionChancado/Delete/5
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

        public void cargarCombos(int turno_id, int jefe_id, int operario_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Operario = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_Jefe = new List<DTOLista_valor>();



                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();


                DTOLista_valor oListaValorGenerico = new DTOLista_valor();
                oListaValorGenerico.lista_valor_id = 0;
                oListaValorGenerico.valor = "-----Todos-----";

                oLista_Operario.Add(oListaValorGenerico);
                oLista_Operario.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaOperario"]) && u.activo == true).ToList());
                ViewBag.ListaOperario = new SelectList(oLista_Operario, "lista_valor_id", "valor", operario_id);

                oLista_Turno.Add(oListaValorGenerico);
                oLista_Turno.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList());
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_Jefe.Add(oListaValorGenerico);
                oLista_Jefe.AddRange(oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaJefe"]) && u.activo == true).ToList());
                ViewBag.ListaJefe = new SelectList(oLista_Jefe, "lista_valor_id", "valor", jefe_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }


        public void GenerateExcel(DTORepProduccionChancadoM oRepProduccionChancado)
        {
            try
            {
                DTOProduccion oProduccion = new DTOProduccion();
                oProduccion.turno_id = oRepProduccionChancado.turno_id;
                oProduccion.jefe_guardia_id = oRepProduccionChancado.jefe_id;
                oProduccion.operario_id = oRepProduccionChancado.operario_id;
                oProduccion.fecha_desde = oRepProduccionChancado.fecha_desde;
                oProduccion.fecha_hasta = oRepProduccionChancado.fecha_hasta;


                string templateDocument = "";
                Lista_valorBL olistaValorBL = new Lista_valorBL();
                string copia = "";

                templateDocument = Server.MapPath("~/Templates/ChancadoADR/ReporteProduccion.xlsx");
                copia = Server.MapPath("~/Templates/Copia/ReporteProduccion.xlsx");

                System.IO.File.Copy(templateDocument, copia, true);

                FileInfo newFile = new FileInfo(copia);

                ExcelPackage pck = new ExcelPackage(newFile);
                //Add the Content sheet
                var ws = pck.Workbook.Worksheets["Reporte"];
                ws.View.ShowGridLines = true;

                List<DTOProduccion> oListaProduccion = new List<DTOProduccion>();
                ProduccionBL oProduccionBL = new ProduccionBL();
                int index = 8;


                oListaProduccion = oProduccionBL.ObtenerReporteProduccion(oProduccion).DTOListaProduccion;


                foreach (var item in oListaProduccion)
                {
                    ws.Cells["A" + index].Value = item.mes_desc;
                    ws.Cells["B" + index].Value = item.dia_desc;
                    ws.Cells["C" + index].Value = item.fecha_op.ToShortDateString();
                    ws.Cells["D" + index].Value = item.turno_desc;
                    ws.Cells["E" + index].Value = item.jefe_guardia;
                    ws.Cells["F" + index].Value = item.operador_planta_chancado;
                    ws.Cells["G" + index].Value = "0";
                    ws.Cells["H" + index].Value = item.viajes_ch;
                    ws.Cells["I" + index].Value = item.ton_ch_cam;
                    ws.Cells["J" + index].Value = item.ton_ch_ox;
                    //ws.Cells["K" + index].Value = "";
                    //ws.Cells["L" + index].Value = "";
                    ws.Cells["M" + index].Value = item.tm_acum_ini_ch;
                    ws.Cells["N" + index].Value = item.tm_acum_fin_ch;
                    //ws.Cells["O" + index].Value = "";
                    //ws.Cells["P" + index].Value = "";
                    ws.Cells["Q" + index].Value = item.horas_ch;
                    ws.Cells["R" + index].Value = item.minutos_ch;
                    //ws.Cells["S" + index].Value = "";
                    ws.Cells["T" + index].Value = item.horas_mantto_ch;
                    ws.Cells["U" + index].Value = item.minutos_mantto_ch;
                    //ws.Cells["V" + index].Value = "";
                    ws.Cells["W" + index].Value = item.horas_operacion_ch;
                    ws.Cells["X" + index].Value = item.minutos_operacion_ch;

                    ws.Cells["AC" + index].Value = item.viajes_ob;
                    ws.Cells["AD" + index].Value = item.ton_ob_cam;
                    ws.Cells["AE" + index].Value = item.ton_ob_ox;

                    ws.Cells["AG" + index].Value = item.tm_acum_ini_ob;
                    ws.Cells["AH" + index].Value = item.tm_acum_fin_ob;

                    ws.Cells["AK" + index].Value = item.horas_op_ob;
                    ws.Cells["AL" + index].Value = item.minutos_op_ob;

                    ws.Cells["AN" + index].Value = item.horas_mantto_ob;
                    ws.Cells["AO" + index].Value = item.minutos_mantto_ob;

                    ws.Cells["AQ" + index].Value = item.horas_operacion_ob;
                    ws.Cells["AR" + index].Value = item.minutos_operacion_ob;

                    ws.Cells["AW" + index].Value = item.mps_porc;
                    ws.Cells["AX" + index].Value = item.presion_ntg;
                    ws.Cells["AY" + index].Value = item.rpm_main_shaft;
                    ws.Cells["AZ" + index].Value = item.amp_chancadora;
                    ws.Cells["BA" + index].Value = item.f_aceite_sup;
                    ws.Cells["BB" + index].Value = item.f_aceite_inf;
                    ws.Cells["BC" + index].Value = item.rpm_apron_feeder;
                    ws.Cells["BD" + index].Value = item.a_apron_feeder;
                    ws.Cells["BE" + index].Value = item.a_faja_uno;
                    ws.Cells["BF" + index].Value = item.a_faja_dos;
                    ws.Cells["BG" + index].Value = item.a_faja_tres;
                    ws.Cells["BH" + index].Value = item.frec_av_a;
                    ws.Cells["BI" + index].Value = item.frec_av_b;
                    ws.Cells["BJ" + index].Value = item.frec_av_c;
                    ws.Cells["BK" + index].Value = item.pr_hidra_uno;
                    ws.Cells["BL" + index].Value = item.pr_hidra_dos;
                    ws.Cells["BM" + index].Value = item.tk_verde;
                    ws.Cells["BN" + index].Value = item.tk_rojo;
                    ws.Cells["BO" + index].Value = item.stock_pile;
                    ws.Cells["BP" + index].Value = item.ratio_cal;
                    ws.Cells["BQ" + index].Value = item.silo_a;
                    ws.Cells["BR" + index].Value = item.silo_b;
                    ws.Cells["BS" + index].Value = item.tpm;
                    ws.Cells["BT" + index].Value = item.poligonos;
                    ws.Cells["BU" + index].Value = item.celda;
                    ws.Cells["BV" + index].Value = item.observacion;
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

            Response.AppendHeader("Content-Disposition", "attachment; filename=ReporteProduccion.xls");

            Response.TransmitFile(fileName);

            Response.End();
        }

    }
}
