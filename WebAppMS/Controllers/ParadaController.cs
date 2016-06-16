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
    public class ParadaController : Controller
    {
        // GET: Parada
        public ActionResult Index()
        {
            ParadaBL oParadaBL = new ParadaBL();
            DTOParadaRespuesta oParadaRpta = new DTOParadaRespuesta();
            oParadaRpta = oParadaBL.obtenerParada();
            DTOParadaM oParadaM = new DTOParadaM();
            List<DTOParadaM> oLista_ParadaM = new List<DTOParadaM>();

            if (oParadaRpta.DTOListaParada != null)
            {
                foreach (var item in oParadaRpta.DTOListaParada)
                {
                    oParadaM = new DTOParadaM(); oParadaM.parada_id = item.parada_id;
                    oParadaM.area_id = item.area_id;
                    oParadaM.fecha = item.fecha;
                    oParadaM.turno_id = item.turno_id;
                    oParadaM.hora_inicio = item.hora_inicio;
                    oParadaM.hora_fin = item.hora_fin;
                    oParadaM.duracion = item.duracion;
                    oParadaM.tipo_parada_id = item.tipo_parada_id;
                    oParadaM.estado_id = item.estado_id;
                    oParadaM.serie_id = item.serie_id;
                    oParadaM.comentario = item.comentario;
                    oParadaM.activo = item.activo;
                    oParadaM.usuario_crea = item.usuario_crea;
                    oParadaM.fecha_crea = item.fecha_crea;
                    oParadaM.usuario_mod = item.usuario_mod;
                    oParadaM.fecha_mod = item.fecha_mod;
                    oParadaM.area_desc = item.area_desc;
                    oParadaM.estado_desc = item.estado_desc;
                    oParadaM.serie_desc = item.serie_desc;
                    oParadaM.sub_tipo_parada_desc = item.sub_tipo_parada_desc;
                    oParadaM.tipo_parada_desc = item.tipo_parada_desc;
                    oParadaM.turno_desc = item.turno_desc;
                    

                    oLista_ParadaM.Add(oParadaM);
                }
            }


            return View(oLista_ParadaM);
        }

        // GET: Parada/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parada/Create
        public ActionResult Create()
        {
            DTOParadaM oParadaM = new DTOParadaM();
            cargarCombos(0, 0, 0, 0, 0, 0);
            oParadaM.activo = true;
            oParadaM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oParadaM);
        }

        // POST: Parada/Create
        [HttpPost]
        public ActionResult Create(DTOParadaM oParadaM)
        {
            try
            {
                    // TODO: Add insert logic here
                    ParadaBL ParadaBL = new ParadaBL();
                    DTOParada oParada = new DTOParada(); oParada.parada_id = oParadaM.parada_id;
                    oParada.area_id = oParadaM.area_id;
                    oParada.fecha = Convert.ToDateTime(oParadaM.fecha_desc);
                    oParada.turno_id = oParadaM.turno_id;
                    oParada.hora_inicio = oParadaM.hora_inicio;
                    oParada.hora_fin = oParadaM.hora_fin;
                    oParada.duracion = oParadaM.duracion;
                    oParada.tipo_parada_id = oParadaM.tipo_parada_id;
                    oParada.sub_tipo_parada_id = oParadaM.sub_tipo_parada_id;
                    oParada.estado_id = oParadaM.estado_id;
                    oParada.serie_id = oParadaM.serie_id;
                    oParada.comentario = oParadaM.comentario;
                    oParada.activo = oParadaM.activo;
                    oParada.usuario_crea = Session["USR_COD"].ToString();
                    oParada.fecha_crea = oParadaM.fecha_crea;
                    oParada.usuario_mod = oParadaM.usuario_mod;
                    oParada.fecha_mod = oParadaM.fecha_mod;
                    ParadaBL.registrarParada(oParada);
                   
                
                oParadaM.resultado = 1;
                cargarCombos(oParadaM.area_id, oParadaM.turno_id, oParadaM.tipo_parada_id, oParadaM.sub_tipo_parada_id, oParadaM.estado_id, oParadaM.serie_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oParadaM.resultado = 2;
            }

            return View(oParadaM);
        }

        // GET: Parada/Edit/5
        public ActionResult Edit(int id)
        {
            DTOParadaRespuesta oParadaRpta = new DTOParadaRespuesta();
            ParadaBL oParadaBL = new ParadaBL();
            DTOParadaM oParadaM = new DTOParadaM();
            try
            {
                oParadaRpta = oParadaBL.obtenerParada_por_id(id);
                oParadaM.parada_id = oParadaRpta.DTOParada.parada_id;
                oParadaM.area_id = oParadaRpta.DTOParada.area_id;
                oParadaM.fecha = Convert.ToDateTime(oParadaRpta.DTOParada.fecha);
                oParadaM.fecha_desc = Convert.ToDateTime(oParadaRpta.DTOParada.fecha).ToShortDateString();
                oParadaM.turno_id = oParadaRpta.DTOParada.turno_id;
                oParadaM.hora_inicio = oParadaRpta.DTOParada.hora_inicio;
                oParadaM.hora_fin = oParadaRpta.DTOParada.hora_fin;

                oParadaM.hora_hora_ini = oParadaM.hora_inicio.Substring(0,2);
                oParadaM.hora_min_ini = oParadaM.hora_inicio.Substring(3, 2);


                oParadaM.hora_hora_fin = oParadaM.hora_fin.Substring(0, 2);
                oParadaM.hora_min_fin = oParadaM.hora_fin.Substring(3, 2);


                oParadaM.duracion = oParadaRpta.DTOParada.duracion;
                oParadaM.tipo_parada_id = oParadaRpta.DTOParada.tipo_parada_id;
                oParadaM.sub_tipo_parada_id = oParadaRpta.DTOParada.sub_tipo_parada_id;
                oParadaM.estado_id = oParadaRpta.DTOParada.estado_id;
                oParadaM.serie_id = oParadaRpta.DTOParada.serie_id;
                oParadaM.comentario = oParadaRpta.DTOParada.comentario;
                oParadaM.activo = oParadaRpta.DTOParada.activo;
                oParadaM.usuario_crea = oParadaRpta.DTOParada.usuario_crea;
                oParadaM.fecha_crea = oParadaRpta.DTOParada.fecha_crea;
                oParadaM.usuario_mod = oParadaRpta.DTOParada.usuario_mod;
                oParadaM.fecha_mod = oParadaRpta.DTOParada.fecha_mod;
                cargarCombos(oParadaM.area_id, oParadaM.turno_id, oParadaM.tipo_parada_id, oParadaM.sub_tipo_parada_id, oParadaM.estado_id, oParadaM.serie_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oParadaM);
        }


        // POST: Parada/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOParadaM oParadaM)
        {
            try
            {
                    DTOParada oParada = new DTOParada();
                    ParadaBL oParadaBL = new ParadaBL();
                    oParada.parada_id = oParadaM.parada_id;
                    oParada.area_id = oParadaM.area_id;
                    oParada.fecha = Convert.ToDateTime(oParadaM.fecha_desc);
                    oParada.turno_id = oParadaM.turno_id;
                    oParada.hora_inicio = oParadaM.hora_inicio;
                    oParada.hora_fin = oParadaM.hora_fin;
                    oParada.duracion = oParadaM.duracion;
                    oParada.tipo_parada_id = oParadaM.tipo_parada_id;
                    oParada.sub_tipo_parada_id = oParadaM.sub_tipo_parada_id;
                    oParada.estado_id = oParadaM.estado_id;
                    oParada.serie_id = oParadaM.serie_id;
                    oParada.comentario = oParadaM.comentario;
                    oParada.activo = oParadaM.activo;
                    oParada.usuario_crea = oParadaM.usuario_crea;
                    oParada.fecha_crea = oParadaM.fecha_crea;
                    oParada.usuario_mod = Session["USR_COD"].ToString();
                    oParada.fecha_mod = oParadaM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oParadaBL.actualizarParada(oParada);
                    oParadaM.resultado = 1;
                
                cargarCombos(oParadaM.area_id, oParadaM.turno_id, oParadaM.tipo_parada_id, oParadaM.sub_tipo_parada_id, oParadaM.estado_id, oParadaM.serie_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oParadaM.resultado = 2;
            }

            return View(oParadaM);
        }

        // GET: Parada/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parada/Delete/5
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

                oLista_Area = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaArea"]) && u.activo==true).ToList();
                ViewBag.ListaArea = new SelectList(oLista_Area, "lista_valor_id", "valor", area_id);

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

                oLista_TipoParada = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTParada"]) && u.activo == true).ToList();
                ViewBag.ListaTParada = new SelectList(oLista_TipoParada, "lista_valor_id", "valor", tipo_parada_id);

                oLista_STipoParada = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaSTParada"]) && u.activo == true).ToList();
                ViewBag.ListaSTParada = new SelectList(oLista_STipoParada, "lista_valor_id", "valor", sub_tipo_parada_id);

                oLista_Estado = oEstadoBL.obtenerEstado().DTOListaEstado.Where(u=>u.activo==true).OrderBy(u => u.codigo).ToList();
                ViewBag.ListaEstado = new SelectList(oLista_Estado, "estado_id", "codigo", estado_id);

                oLista_Serie = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaSerie"]) && u.activo == true).ToList();
                ViewBag.ListaSerie = new SelectList(oLista_Serie, "lista_valor_id", "valor", serie_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}