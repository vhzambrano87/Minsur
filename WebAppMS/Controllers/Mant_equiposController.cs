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
    public class Mant_equiposController : Controller
    {
        // GET: Mant_equipos
        public ActionResult Index()
        {
            Mant_equiposBL oMant_equiposBL = new Mant_equiposBL();
            DTOMant_equiposRespuesta oMant_equiposRpta = new DTOMant_equiposRespuesta();
            oMant_equiposRpta = oMant_equiposBL.obtenerMant_equipos();
            DTOMant_equiposM oMant_equiposM = new DTOMant_equiposM();
            List<DTOMant_equiposM> oLista_Mant_equiposM = new List<DTOMant_equiposM>();

            if (oMant_equiposRpta.DTOListaMant_equipos != null)
            {
                foreach (var item in oMant_equiposRpta.DTOListaMant_equipos)
                {
                    oMant_equiposM = new DTOMant_equiposM();
                    oMant_equiposM.equipo_id = item.equipo_id;
                    oMant_equiposM.fecha = item.fecha;
                    oMant_equiposM.guardia_id = item.guardia_id;
                    oMant_equiposM.turno_id = item.turno_id;
                    oMant_equiposM.camiom_cargador = item.camiom_cargador;
                    oMant_equiposM.tipo_actividad_id = item.tipo_actividad_id;
                    oMant_equiposM.operador_id = item.operador_id;
                    oMant_equiposM.hora_inicial = item.hora_inicial;
                    oMant_equiposM.hora_fin = item.hora_fin;
                    oMant_equiposM.tancada = item.tancada;
                    oMant_equiposM.hora_ini_mant = item.hora_ini_mant;
                    oMant_equiposM.hora_fin_mant = item.hora_fin_mant;
                    oMant_equiposM.comentarios = item.comentarios;
                    oMant_equiposM.equipo_cargio_id = item.equipo_cargio_id;
                    oMant_equiposM.material_id = item.material_id;
                    oMant_equiposM.zona_carguio = item.zona_carguio;
                    oMant_equiposM.punto_descarga = item.punto_descarga;
                    oMant_equiposM.numero_viajes = item.numero_viajes;
                    oMant_equiposM.guardia_desc = item.guardia_desc;
                    oMant_equiposM.turno_desc = item.turno_desc;
                    oMant_equiposM.tipo_actividad_desc = item.tipo_actividad_desc;
                    oMant_equiposM.operador_desc = item.operador_desc;
                    oMant_equiposM.equipo_cargio_desc = item.equipo_cargio_desc;
                    oMant_equiposM.material_desc = item.material_desc;
                    oMant_equiposM.zona_carguio_desc = item.zona_carguio_desc;
                    oMant_equiposM.punto_descarga_desc = item.punto_descarga_desc;
                    oMant_equiposM.usuario_crea = item.usuario_crea;
                    oMant_equiposM.fecha_crea = item.fecha_crea;
                    oMant_equiposM.usuario_mod = item.usuario_mod;
                    oMant_equiposM.fecha_mod = item.fecha_mod;
                    oMant_equiposM.activo = item.activo;
                    oLista_Mant_equiposM.Add(oMant_equiposM);
                }
            }


            return View(oLista_Mant_equiposM);
        }

        // GET: Mant_equipos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mant_equipos/Create
        public ActionResult Create()
        {
            DTOMant_equiposM oMant_equiposM = new DTOMant_equiposM();
            cargarCombos(0, 0, 0, 0, 0, 0, 0, 0);
            oMant_equiposM.activo = true;
            oMant_equiposM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oMant_equiposM);
        }

        // POST: Mant_equipos/Create
        [HttpPost]
        public ActionResult Create(DTOMant_equiposM oMant_equiposM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Mant_equiposBL Mant_equiposBL = new Mant_equiposBL();
                    DTOMant_equipos oMant_equipos = new DTOMant_equipos(); oMant_equipos.equipo_id = oMant_equiposM.equipo_id;
                    oMant_equipos.fecha = Convert.ToDateTime(oMant_equiposM.fecha);
                    oMant_equipos.guardia_id = oMant_equiposM.guardia_id;
                    oMant_equipos.turno_id = oMant_equiposM.turno_id;
                    oMant_equipos.camiom_cargador = oMant_equiposM.camiom_cargador;
                    oMant_equipos.tipo_actividad_id = oMant_equiposM.tipo_actividad_id;
                    oMant_equipos.operador_id = oMant_equiposM.operador_id;
                    oMant_equipos.hora_inicial = oMant_equiposM.hora_inicial;
                    oMant_equipos.hora_fin = oMant_equiposM.hora_fin;
                    oMant_equipos.tancada = oMant_equiposM.tancada;
                    oMant_equipos.hora_ini_mant = oMant_equiposM.hora_ini_mant;
                    oMant_equipos.hora_fin_mant = oMant_equiposM.hora_fin_mant;
                    oMant_equipos.comentarios = oMant_equiposM.comentarios;
                    oMant_equipos.equipo_cargio_id = oMant_equiposM.equipo_cargio_id;
                    oMant_equipos.material_id = oMant_equiposM.material_id;
                    oMant_equipos.zona_carguio = oMant_equiposM.zona_carguio;
                    oMant_equipos.punto_descarga = oMant_equiposM.punto_descarga;
                    oMant_equipos.numero_viajes = oMant_equiposM.numero_viajes;
                    oMant_equipos.produccion_total = oMant_equiposM.produccion_total;
                    oMant_equipos.activo = oMant_equiposM.activo;
                    Mant_equiposBL.registrarMant_equipos(oMant_equipos);
                    oMant_equiposM.equipo_id = 0;
                    oMant_equiposM.fecha = null;
                    oMant_equiposM.guardia_id = 0;
                    oMant_equiposM.turno_id = 0;
                    oMant_equiposM.camiom_cargador = "";
                    oMant_equiposM.tipo_actividad_id = 0;
                    oMant_equiposM.operador_id = 0;
                    oMant_equiposM.hora_inicial = "";
                    oMant_equiposM.hora_fin = "";
                    oMant_equiposM.tancada = 0;
                    oMant_equiposM.hora_ini_mant = "";
                    oMant_equiposM.hora_fin_mant = "";
                    oMant_equiposM.comentarios = "";
                    oMant_equiposM.equipo_cargio_id = 0;
                    oMant_equiposM.material_id = 0;
                    oMant_equiposM.zona_carguio = 0;
                    oMant_equiposM.punto_descarga = 0;
                    oMant_equiposM.numero_viajes = 0;
                    oMant_equiposM.produccion_total = 0;
                    oMant_equipos.usuario_crea = Session["USR_COD"].ToString();
                    oMant_equiposM.resultado = 1;
                }
                cargarCombos(oMant_equiposM.guardia_id, oMant_equiposM.turno_id, oMant_equiposM.tipo_actividad_id, oMant_equiposM.operador_id, oMant_equiposM.equipo_cargio_id, oMant_equiposM.material_id, oMant_equiposM.zona_carguio, oMant_equiposM.punto_descarga);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oMant_equiposM.resultado = 2;
            }

            return View(oMant_equiposM);
        }

        // GET: Mant_equipos/Edit/5
        public ActionResult Edit(int id)
        {
            DTOMant_equiposRespuesta oMant_equiposRpta = new DTOMant_equiposRespuesta();
            Mant_equiposBL oMant_equiposBL = new Mant_equiposBL();
            DTOMant_equiposM oMant_equiposM = new DTOMant_equiposM();
            try
            {
                oMant_equiposRpta = oMant_equiposBL.obtenerMant_equipos_por_id(id);
                oMant_equiposM.equipo_id = oMant_equiposRpta.DTOMant_equipos.equipo_id;
                oMant_equiposM.fecha = oMant_equiposRpta.DTOMant_equipos.fecha;
                oMant_equiposM.guardia_id = oMant_equiposRpta.DTOMant_equipos.guardia_id;
                oMant_equiposM.turno_id = oMant_equiposRpta.DTOMant_equipos.turno_id;
                oMant_equiposM.camiom_cargador = oMant_equiposRpta.DTOMant_equipos.camiom_cargador;
                oMant_equiposM.tipo_actividad_id = oMant_equiposRpta.DTOMant_equipos.tipo_actividad_id;
                oMant_equiposM.operador_id = oMant_equiposRpta.DTOMant_equipos.operador_id;
                oMant_equiposM.hora_inicial = oMant_equiposRpta.DTOMant_equipos.hora_inicial;
                oMant_equiposM.hora_hora_ini = oMant_equiposRpta.DTOMant_equipos.hora_inicial.Substring(0,2);
                oMant_equiposM.hora_min_ini = oMant_equiposRpta.DTOMant_equipos.hora_inicial.Substring(3, 2);
                oMant_equiposM.hora_fin = oMant_equiposRpta.DTOMant_equipos.hora_fin;
                oMant_equiposM.hora_hora_fin = oMant_equiposRpta.DTOMant_equipos.hora_fin.Substring(0, 2); 
                oMant_equiposM.hora_min_fin = oMant_equiposRpta.DTOMant_equipos.hora_fin.Substring(3, 2);

                oMant_equiposM.tancada = oMant_equiposRpta.DTOMant_equipos.tancada;
                oMant_equiposM.hora_ini_mant = oMant_equiposRpta.DTOMant_equipos.hora_ini_mant;
                oMant_equiposM.hora_hora_ini_mant = oMant_equiposRpta.DTOMant_equipos.hora_ini_mant.Substring(0, 2);
                oMant_equiposM.hora_min_ini_mant = oMant_equiposRpta.DTOMant_equipos.hora_ini_mant.Substring(3, 2);

                oMant_equiposM.hora_fin_mant = oMant_equiposRpta.DTOMant_equipos.hora_fin_mant;
                oMant_equiposM.hora_hora_fin_mant = oMant_equiposRpta.DTOMant_equipos.hora_fin_mant.Substring(0, 2);
                oMant_equiposM.hora_min_fin_mant = oMant_equiposRpta.DTOMant_equipos.hora_fin_mant.Substring(3, 2);


                oMant_equiposM.comentarios = oMant_equiposRpta.DTOMant_equipos.comentarios;
                oMant_equiposM.equipo_cargio_id = oMant_equiposRpta.DTOMant_equipos.equipo_cargio_id;
                oMant_equiposM.material_id = oMant_equiposRpta.DTOMant_equipos.material_id;
                oMant_equiposM.zona_carguio = oMant_equiposRpta.DTOMant_equipos.zona_carguio;
                oMant_equiposM.punto_descarga = oMant_equiposRpta.DTOMant_equipos.punto_descarga;
                oMant_equiposM.numero_viajes = oMant_equiposRpta.DTOMant_equipos.numero_viajes;
                oMant_equiposM.produccion_total = oMant_equiposRpta.DTOMant_equipos.produccion_total;
                oMant_equiposM.usuario_crea = oMant_equiposRpta.DTOMant_equipos.usuario_crea;
                oMant_equiposM.fecha_crea = oMant_equiposRpta.DTOMant_equipos.fecha_crea;
                oMant_equiposM.activo = oMant_equiposRpta.DTOMant_equipos.activo;
                cargarCombos(oMant_equiposM.guardia_id, oMant_equiposM.turno_id, oMant_equiposM.tipo_actividad_id, oMant_equiposM.operador_id, oMant_equiposM.equipo_cargio_id, oMant_equiposM.material_id, oMant_equiposM.zona_carguio, oMant_equiposM.punto_descarga);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oMant_equiposM);
        }

        // POST: Mant_equipos/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOMant_equiposM oMant_equiposM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOMant_equipos oMant_equipos = new DTOMant_equipos();
                    Mant_equiposBL oMant_equiposBL = new Mant_equiposBL();
                    oMant_equipos.equipo_id = oMant_equiposM.equipo_id;
                    oMant_equipos.fecha = Convert.ToDateTime(oMant_equiposM.fecha);
                    oMant_equipos.guardia_id = oMant_equiposM.guardia_id;
                    oMant_equipos.turno_id = oMant_equiposM.turno_id;
                    oMant_equipos.camiom_cargador = oMant_equiposM.camiom_cargador;
                    oMant_equipos.tipo_actividad_id = oMant_equiposM.tipo_actividad_id;
                    oMant_equipos.operador_id = oMant_equiposM.operador_id;
                    oMant_equipos.hora_inicial = oMant_equiposM.hora_inicial;
                    oMant_equipos.hora_fin = oMant_equiposM.hora_fin;
                    oMant_equipos.tancada = oMant_equiposM.tancada;
                    oMant_equipos.hora_ini_mant = oMant_equiposM.hora_ini_mant;
                    oMant_equipos.hora_fin_mant = oMant_equiposM.hora_fin_mant;
                    oMant_equipos.comentarios = oMant_equiposM.comentarios;
                    oMant_equipos.equipo_cargio_id = oMant_equiposM.equipo_cargio_id;
                    oMant_equipos.material_id = oMant_equiposM.material_id;
                    oMant_equipos.zona_carguio = oMant_equiposM.zona_carguio;
                    oMant_equipos.punto_descarga = oMant_equiposM.punto_descarga;
                    oMant_equipos.numero_viajes = oMant_equiposM.numero_viajes;
                    oMant_equipos.produccion_total = oMant_equiposM.produccion_total;
                    oMant_equipos.usuario_crea = oMant_equiposM.usuario_crea;
                    oMant_equipos.fecha_crea = oMant_equiposM.fecha_crea;
                    oMant_equipos.usuario_mod = Session["USR_COD"].ToString();
                    oMant_equipos.activo = oMant_equiposM.activo;
                    //oLista.usuario_mod = "MS_USER";

                    oMant_equiposBL.actualizarMant_equipos(oMant_equipos);
                    oMant_equiposM.resultado = 1;
                }
                cargarCombos(oMant_equiposM.guardia_id, oMant_equiposM.turno_id, oMant_equiposM.tipo_actividad_id, oMant_equiposM.operador_id, oMant_equiposM.equipo_cargio_id, oMant_equiposM.material_id, oMant_equiposM.zona_carguio, oMant_equiposM.punto_descarga);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oMant_equiposM.resultado = 2;
            }

            return View(oMant_equiposM);
        }

        // GET: Mant_equipos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mant_equipos/Delete/5
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

        public void cargarCombos(int guardia_id, int turno_id, int tipo_actividad_id, int operador_id, int equipo_id, int material_id, int zona_cargio_id, int punto_descarga_id)
        {
            try
            {
                List<DTOLista_valor> oLista_equipo = new List<DTOLista_valor>();
                DTOLista_valorRespuesta oListaTurnoRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_guardia = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_tipo_actividad = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_operador = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_material = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_zona_cargio = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_punto_descarga = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();

                int lista_equipo_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaEquipo"]);
                int lista_gardia_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaGuardia"]);
                int lista_turno_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaTurno"]);
                int lista_tipo_actividad_id = Convert.ToInt16(ConfigurationManager.AppSettings["Listatipo_actividad"]);
                int lista_operador_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaOperario"]);
                int oLista_material_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaMaterial"]);
                int oLista_zona_cargio_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaZonaCargio"]);
                int oLista_punto_descarga_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaPuntoDesc"]);

                oLista_equipo = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_equipo_id).ToList();
                ViewBag.ListaEquipo = new SelectList(oLista_equipo, "lista_valor_id", "valor", equipo_id);

                oLista_guardia = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_gardia_id).ToList();
                ViewBag.ListaGuardia = new SelectList(oLista_guardia, "lista_valor_id", "valor", guardia_id);

                oLista_turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_turno_id).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_turno, "lista_valor_id", "valor", turno_id);

                oLista_tipo_actividad = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_tipo_actividad_id).ToList();
                ViewBag.Lista_tipo_actividad = new SelectList(oLista_tipo_actividad, "lista_valor_id", "valor", tipo_actividad_id);

                oLista_operador = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_operador_id).ToList();
                ViewBag.ListaOperador = new SelectList(oLista_operador, "lista_valor_id", "valor", operador_id);

                oLista_material = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == oLista_material_id).ToList();
                ViewBag.ListaMaterial = new SelectList(oLista_material, "lista_valor_id", "valor", material_id);

                oLista_zona_cargio = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == oLista_zona_cargio_id).ToList();
                ViewBag.ListaZonaCargio = new SelectList(oLista_zona_cargio, "lista_valor_id", "valor", zona_cargio_id);

                oLista_punto_descarga = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == oLista_punto_descarga_id).ToList();
                ViewBag.ListaPuntoDescarga = new SelectList(oLista_punto_descarga, "lista_valor_id", "valor", punto_descarga_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}