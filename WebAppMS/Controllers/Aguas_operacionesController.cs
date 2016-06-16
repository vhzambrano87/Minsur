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
    public class Aguas_operacionesController : Controller
    {
        // GET: Aguas_operaciones
        public ActionResult Index()
        {
            Aguas_operacionesBL oAguas_operacionesBL = new Aguas_operacionesBL();
            DTOAguas_operacionesRespuesta oAguas_operacionesRpta = new DTOAguas_operacionesRespuesta();
            oAguas_operacionesRpta = oAguas_operacionesBL.obtenerAguas_operaciones();
            DTOAguas_operacionesM oAguas_operacionesM = new DTOAguas_operacionesM();
            List<DTOAguas_operacionesM> oLista_Aguas_operacionesM = new List<DTOAguas_operacionesM>();

            if (oAguas_operacionesRpta.DTOListaAguas_operaciones != null)
            {
                foreach (var item in oAguas_operacionesRpta.DTOListaAguas_operaciones)
                {
                    oAguas_operacionesM = new DTOAguas_operacionesM(); oAguas_operacionesM.agua_op_id = item.agua_op_id;
                    oAguas_operacionesM.fecha = item.fecha;
                    oAguas_operacionesM.turno_id = item.turno_id;
                    oAguas_operacionesM.turno = item.turno;
                    oAguas_operacionesM.tecnico_id = item.tecnico_id;
                    oAguas_operacionesM.nivel_tk_1 = item.nivel_tk_1;
                    oAguas_operacionesM.nivel_tk_2 = item.nivel_tk_2;
                    oAguas_operacionesM.nivel_tk_contraincendio = item.nivel_tk_contraincendio;
                    oAguas_operacionesM.nivel_tk_chancado = item.nivel_tk_chancado;
                    oAguas_operacionesM.nivel_pm_pad = item.nivel_pm_pad;
                    oAguas_operacionesM.nivel_pm_pls = item.nivel_pm_pls;
                    oAguas_operacionesM.nivel_tk_botadero = item.nivel_tk_botadero;
                    oAguas_operacionesM.consumo_mina_cat_777 = item.consumo_mina_cat_777;
                    oAguas_operacionesM.consumo_mina_riego_vias = item.consumo_mina_riego_vias;
                    oAguas_operacionesM.consumo_mina_riego_caliza = item.consumo_mina_riego_caliza;
                    oAguas_operacionesM.consumo_geologia = item.consumo_geologia;
                    oAguas_operacionesM.consumo_exploracion = item.consumo_exploracion;
                    oAguas_operacionesM.consumo_proy_campamento = item.consumo_proy_campamento;
                    oAguas_operacionesM.consumo_proy_obras = item.consumo_proy_obras;
                    oAguas_operacionesM.consumo_rrhh_timpure = item.consumo_rrhh_timpure;
                    oAguas_operacionesM.consumo_rrhh_pucamara = item.consumo_rrhh_pucamara;
                    oAguas_operacionesM.pluviometro_lixiviacion = item.pluviometro_lixiviacion;
                    oAguas_operacionesM.pluviometro_planta_adr = item.pluviometro_planta_adr;
                    oAguas_operacionesM.pluviomento_pozos_agua = item.pluviomento_pozos_agua;
                    oAguas_operacionesM.bombeo_chancado_niv_inicial = item.bombeo_chancado_niv_inicial;
                    oAguas_operacionesM.bombeo_chancado_niv_final = item.bombeo_chancado_niv_final;
                    oAguas_operacionesM.totalizador_pozo_1 = item.totalizador_pozo_1;
                    oAguas_operacionesM.totalizador_pozo_2 = item.totalizador_pozo_2;
                    oAguas_operacionesM.totalizador_pozo_3 = item.totalizador_pozo_3;
                    oAguas_operacionesM.totalizador_pozo_4 = item.totalizador_pozo_4;
                    oAguas_operacionesM.totalizador_pozo_5 = item.totalizador_pozo_5;
                    oAguas_operacionesM.totalizador_pozo_6 = item.totalizador_pozo_6;
                    oAguas_operacionesM.totalizador_ingreso_tk_2 = item.totalizador_ingreso_tk_2;
                    oAguas_operacionesM.totalizador_make_up_planta = item.totalizador_make_up_planta;
                    oAguas_operacionesM.nivel_freatico_pozo_1 = item.nivel_freatico_pozo_1;
                    oAguas_operacionesM.nivel_freatico_pozo_2 = item.nivel_freatico_pozo_2;
                    oAguas_operacionesM.nivel_freatico_pozo_3 = item.nivel_freatico_pozo_3;
                    oAguas_operacionesM.nivel_freatico_pozo_4 = item.nivel_freatico_pozo_4;
                    oAguas_operacionesM.nivel_freatico_pozo_5 = item.nivel_freatico_pozo_5;
                    oAguas_operacionesM.nivel_freatico_pozo_6 = item.nivel_freatico_pozo_6;
                    oAguas_operacionesM.variador_velocidad_pozo_1 = item.variador_velocidad_pozo_1;
                    oAguas_operacionesM.variador_velocidad_pozo_2 = item.variador_velocidad_pozo_2;
                    oAguas_operacionesM.variador_velocidad_pozo_3 = item.variador_velocidad_pozo_3;
                    oAguas_operacionesM.variador_velocidad_pozo_4 = item.variador_velocidad_pozo_4;
                    oAguas_operacionesM.variador_velocidad_pozo_5 = item.variador_velocidad_pozo_5;
                    oAguas_operacionesM.variador_velocidad_pozo_6 = item.variador_velocidad_pozo_6;
                    oAguas_operacionesM.activo = item.activo;
                    oAguas_operacionesM.usuario_crea = item.usuario_crea;
                    oAguas_operacionesM.fecha_crea = item.fecha_crea;
                    oAguas_operacionesM.usuario_mod = item.usuario_mod;
                    oAguas_operacionesM.fecha_mod = item.fecha_mod;
                    oLista_Aguas_operacionesM.Add(oAguas_operacionesM);
                }
            }


            return View(oLista_Aguas_operacionesM);
        }

        // GET: Aguas_operaciones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aguas_operaciones/Create
        public ActionResult Create()
        {
            DTOAguas_operacionesM oAguasOperacionesM = new DTOAguas_operacionesM();
            cargarCombos(0);
            oAguasOperacionesM.fecha_desc = DateTime.Today.ToShortDateString();
            oAguasOperacionesM.activo = true;
            return View(oAguasOperacionesM);
        }

        // POST: Aguas_operaciones/Create
        [HttpPost]
        public ActionResult Create(DTOAguas_operacionesM oAguas_operacionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Aguas_operacionesBL Aguas_operacionesBL = new Aguas_operacionesBL();
                    DTOAguas_operaciones oAguas_operaciones = new DTOAguas_operaciones(); oAguas_operaciones.agua_op_id = oAguas_operacionesM.agua_op_id;
                    oAguas_operaciones.fecha = Convert.ToDateTime(oAguas_operacionesM.fecha_desc);
                    oAguas_operaciones.turno_id = oAguas_operacionesM.turno_id;
                    oAguas_operaciones.tecnico_id = oAguas_operacionesM.tecnico_id;
                    oAguas_operaciones.nivel_tk_1 = oAguas_operacionesM.nivel_tk_1;
                    oAguas_operaciones.nivel_tk_2 = oAguas_operacionesM.nivel_tk_2;
                    oAguas_operaciones.nivel_tk_contraincendio = oAguas_operacionesM.nivel_tk_contraincendio;
                    oAguas_operaciones.nivel_tk_chancado = oAguas_operacionesM.nivel_tk_chancado;
                    oAguas_operaciones.nivel_pm_pad = oAguas_operacionesM.nivel_pm_pad;
                    oAguas_operaciones.nivel_pm_pls = oAguas_operacionesM.nivel_pm_pls;
                    oAguas_operaciones.nivel_tk_botadero = oAguas_operacionesM.nivel_tk_botadero;
                    oAguas_operaciones.consumo_mina_cat_777 = oAguas_operacionesM.consumo_mina_cat_777;
                    oAguas_operaciones.consumo_mina_riego_vias = oAguas_operacionesM.consumo_mina_riego_vias;
                    oAguas_operaciones.consumo_mina_riego_caliza = oAguas_operacionesM.consumo_mina_riego_caliza;
                    oAguas_operaciones.consumo_geologia = oAguas_operacionesM.consumo_geologia;
                    oAguas_operaciones.consumo_exploracion = oAguas_operacionesM.consumo_exploracion;
                    oAguas_operaciones.consumo_proy_campamento = oAguas_operacionesM.consumo_proy_campamento;
                    oAguas_operaciones.consumo_proy_obras = oAguas_operacionesM.consumo_proy_obras;
                    oAguas_operaciones.consumo_rrhh_timpure = oAguas_operacionesM.consumo_rrhh_timpure;
                    oAguas_operaciones.consumo_rrhh_pucamara = oAguas_operacionesM.consumo_rrhh_pucamara;
                    oAguas_operaciones.pluviometro_lixiviacion = oAguas_operacionesM.pluviometro_lixiviacion;
                    oAguas_operaciones.pluviometro_planta_adr = oAguas_operacionesM.pluviometro_planta_adr;
                    oAguas_operaciones.pluviomento_pozos_agua = oAguas_operacionesM.pluviomento_pozos_agua;
                    oAguas_operaciones.bombeo_chancado_niv_inicial = oAguas_operacionesM.bombeo_chancado_niv_inicial;
                    oAguas_operaciones.bombeo_chancado_niv_final = oAguas_operacionesM.bombeo_chancado_niv_final;
                    oAguas_operaciones.totalizador_pozo_1 = oAguas_operacionesM.totalizador_pozo_1;
                    oAguas_operaciones.totalizador_pozo_2 = oAguas_operacionesM.totalizador_pozo_2;
                    oAguas_operaciones.totalizador_pozo_3 = oAguas_operacionesM.totalizador_pozo_3;
                    oAguas_operaciones.totalizador_pozo_4 = oAguas_operacionesM.totalizador_pozo_4;
                    oAguas_operaciones.totalizador_pozo_5 = oAguas_operacionesM.totalizador_pozo_5;
                    oAguas_operaciones.totalizador_pozo_6 = oAguas_operacionesM.totalizador_pozo_6;
                    oAguas_operaciones.totalizador_ingreso_tk_2 = oAguas_operacionesM.totalizador_ingreso_tk_2;
                    oAguas_operaciones.totalizador_make_up_planta = oAguas_operacionesM.totalizador_make_up_planta;
                    oAguas_operaciones.nivel_freatico_pozo_1 = oAguas_operacionesM.nivel_freatico_pozo_1;
                    oAguas_operaciones.nivel_freatico_pozo_2 = oAguas_operacionesM.nivel_freatico_pozo_2;
                    oAguas_operaciones.nivel_freatico_pozo_3 = oAguas_operacionesM.nivel_freatico_pozo_3;
                    oAguas_operaciones.nivel_freatico_pozo_4 = oAguas_operacionesM.nivel_freatico_pozo_4;
                    oAguas_operaciones.nivel_freatico_pozo_5 = oAguas_operacionesM.nivel_freatico_pozo_5;
                    oAguas_operaciones.nivel_freatico_pozo_6 = oAguas_operacionesM.nivel_freatico_pozo_6;
                    oAguas_operaciones.variador_velocidad_pozo_1 = oAguas_operacionesM.variador_velocidad_pozo_1;
                    oAguas_operaciones.variador_velocidad_pozo_2 = oAguas_operacionesM.variador_velocidad_pozo_2;
                    oAguas_operaciones.variador_velocidad_pozo_3 = oAguas_operacionesM.variador_velocidad_pozo_3;
                    oAguas_operaciones.variador_velocidad_pozo_4 = oAguas_operacionesM.variador_velocidad_pozo_4;
                    oAguas_operaciones.variador_velocidad_pozo_5 = oAguas_operacionesM.variador_velocidad_pozo_5;
                    oAguas_operaciones.variador_velocidad_pozo_6 = oAguas_operacionesM.variador_velocidad_pozo_6;
                    oAguas_operaciones.activo = oAguas_operacionesM.activo;
                    oAguas_operaciones.usuario_crea = Session["USR_COD"].ToString();
                    oAguas_operaciones.fecha_crea = oAguas_operacionesM.fecha_crea;
                    oAguas_operaciones.usuario_mod = oAguas_operacionesM.usuario_mod;
                    oAguas_operaciones.fecha_mod = oAguas_operacionesM.fecha_mod;
                    Aguas_operacionesBL.registrarAguas_operaciones(oAguas_operaciones);
                    oAguas_operacionesM.resultado = 1;
                }
                cargarCombos(oAguas_operacionesM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oAguas_operacionesM.resultado = 2;
            }

            return View(oAguas_operacionesM);
        }

        // GET: Aguas_operaciones/Edit/5
        public ActionResult Edit(int id)
        {
            DTOAguas_operacionesRespuesta oAguas_operacionesRpta = new DTOAguas_operacionesRespuesta();
            Aguas_operacionesBL oAguas_operacionesBL = new Aguas_operacionesBL();
            DTOAguas_operacionesM oAguas_operacionesM = new DTOAguas_operacionesM();
            try
            {
                oAguas_operacionesRpta = oAguas_operacionesBL.obtenerAguas_operaciones_por_id(id);
                oAguas_operacionesM.agua_op_id = oAguas_operacionesRpta.DTOAguas_operaciones.agua_op_id;
                oAguas_operacionesM.fecha = oAguas_operacionesRpta.DTOAguas_operaciones.fecha;
                oAguas_operacionesM.fecha_desc = oAguas_operacionesRpta.DTOAguas_operaciones.fecha.ToShortDateString();
                oAguas_operacionesM.turno_id = oAguas_operacionesRpta.DTOAguas_operaciones.turno_id;
                oAguas_operacionesM.tecnico_id = oAguas_operacionesRpta.DTOAguas_operaciones.tecnico_id;
                oAguas_operacionesM.nivel_tk_1 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_tk_1;
                oAguas_operacionesM.nivel_tk_2 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_tk_2;
                oAguas_operacionesM.nivel_tk_contraincendio = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_tk_contraincendio;
                oAguas_operacionesM.nivel_tk_chancado = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_tk_chancado;
                oAguas_operacionesM.nivel_pm_pad = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_pm_pad;
                oAguas_operacionesM.nivel_pm_pls = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_pm_pls;
                oAguas_operacionesM.nivel_tk_botadero = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_tk_botadero;
                oAguas_operacionesM.consumo_mina_cat_777 = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_mina_cat_777;
                oAguas_operacionesM.consumo_mina_riego_vias = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_mina_riego_vias;
                oAguas_operacionesM.consumo_mina_riego_caliza = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_mina_riego_caliza;
                oAguas_operacionesM.consumo_geologia = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_geologia;
                oAguas_operacionesM.consumo_exploracion = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_exploracion;
                oAguas_operacionesM.consumo_proy_campamento = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_proy_campamento;
                oAguas_operacionesM.consumo_proy_obras = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_proy_obras;
                oAguas_operacionesM.consumo_rrhh_timpure = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_rrhh_timpure;
                oAguas_operacionesM.consumo_rrhh_pucamara = oAguas_operacionesRpta.DTOAguas_operaciones.consumo_rrhh_pucamara;
                oAguas_operacionesM.pluviometro_lixiviacion = oAguas_operacionesRpta.DTOAguas_operaciones.pluviometro_lixiviacion;
                oAguas_operacionesM.pluviometro_planta_adr = oAguas_operacionesRpta.DTOAguas_operaciones.pluviometro_planta_adr;
                oAguas_operacionesM.pluviomento_pozos_agua = oAguas_operacionesRpta.DTOAguas_operaciones.pluviomento_pozos_agua;
                oAguas_operacionesM.bombeo_chancado_niv_inicial = oAguas_operacionesRpta.DTOAguas_operaciones.bombeo_chancado_niv_inicial;
                oAguas_operacionesM.bombeo_chancado_niv_final = oAguas_operacionesRpta.DTOAguas_operaciones.bombeo_chancado_niv_final;
                oAguas_operacionesM.totalizador_pozo_1 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_1;
                oAguas_operacionesM.totalizador_pozo_2 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_2;
                oAguas_operacionesM.totalizador_pozo_3 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_3;
                oAguas_operacionesM.totalizador_pozo_4 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_4;
                oAguas_operacionesM.totalizador_pozo_5 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_5;
                oAguas_operacionesM.totalizador_pozo_6 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_pozo_6;
                oAguas_operacionesM.totalizador_ingreso_tk_2 = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_ingreso_tk_2;
                oAguas_operacionesM.totalizador_make_up_planta = oAguas_operacionesRpta.DTOAguas_operaciones.totalizador_make_up_planta;
                oAguas_operacionesM.nivel_freatico_pozo_1 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_1;
                oAguas_operacionesM.nivel_freatico_pozo_2 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_2;
                oAguas_operacionesM.nivel_freatico_pozo_3 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_3;
                oAguas_operacionesM.nivel_freatico_pozo_4 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_4;
                oAguas_operacionesM.nivel_freatico_pozo_5 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_5;
                oAguas_operacionesM.nivel_freatico_pozo_6 = oAguas_operacionesRpta.DTOAguas_operaciones.nivel_freatico_pozo_6;
                oAguas_operacionesM.variador_velocidad_pozo_1 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_1;
                oAguas_operacionesM.variador_velocidad_pozo_2 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_2;
                oAguas_operacionesM.variador_velocidad_pozo_3 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_3;
                oAguas_operacionesM.variador_velocidad_pozo_4 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_4;
                oAguas_operacionesM.variador_velocidad_pozo_5 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_5;
                oAguas_operacionesM.variador_velocidad_pozo_6 = oAguas_operacionesRpta.DTOAguas_operaciones.variador_velocidad_pozo_6;
                oAguas_operacionesM.activo = oAguas_operacionesRpta.DTOAguas_operaciones.activo;
                oAguas_operacionesM.usuario_crea = oAguas_operacionesRpta.DTOAguas_operaciones.usuario_crea;
                oAguas_operacionesM.fecha_crea = oAguas_operacionesRpta.DTOAguas_operaciones.fecha_crea;
                oAguas_operacionesM.usuario_mod = oAguas_operacionesRpta.DTOAguas_operaciones.usuario_mod;
                oAguas_operacionesM.fecha_mod = oAguas_operacionesRpta.DTOAguas_operaciones.fecha_mod;
                cargarCombos(oAguas_operacionesM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oAguas_operacionesM);
        }

        // POST: Aguas_operaciones/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOAguas_operacionesM oAguas_operacionesM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOAguas_operaciones oAguas_operaciones = new DTOAguas_operaciones();
                    Aguas_operacionesBL oAguas_operacionesBL = new Aguas_operacionesBL();
                    oAguas_operaciones.agua_op_id = oAguas_operacionesM.agua_op_id;
                    oAguas_operaciones.fecha = Convert.ToDateTime(oAguas_operacionesM.fecha_desc);
                    oAguas_operaciones.turno_id = oAguas_operacionesM.turno_id;
                    oAguas_operaciones.tecnico_id = oAguas_operacionesM.tecnico_id;
                    oAguas_operaciones.nivel_tk_1 = oAguas_operacionesM.nivel_tk_1;
                    oAguas_operaciones.nivel_tk_2 = oAguas_operacionesM.nivel_tk_2;
                    oAguas_operaciones.nivel_tk_contraincendio = oAguas_operacionesM.nivel_tk_contraincendio;
                    oAguas_operaciones.nivel_tk_chancado = oAguas_operacionesM.nivel_tk_chancado;
                    oAguas_operaciones.nivel_pm_pad = oAguas_operacionesM.nivel_pm_pad;
                    oAguas_operaciones.nivel_pm_pls = oAguas_operacionesM.nivel_pm_pls;
                    oAguas_operaciones.nivel_tk_botadero = oAguas_operacionesM.nivel_tk_botadero;
                    oAguas_operaciones.consumo_mina_cat_777 = oAguas_operacionesM.consumo_mina_cat_777;
                    oAguas_operaciones.consumo_mina_riego_vias = oAguas_operacionesM.consumo_mina_riego_vias;
                    oAguas_operaciones.consumo_mina_riego_caliza = oAguas_operacionesM.consumo_mina_riego_caliza;
                    oAguas_operaciones.consumo_geologia = oAguas_operacionesM.consumo_geologia;
                    oAguas_operaciones.consumo_exploracion = oAguas_operacionesM.consumo_exploracion;
                    oAguas_operaciones.consumo_proy_campamento = oAguas_operacionesM.consumo_proy_campamento;
                    oAguas_operaciones.consumo_proy_obras = oAguas_operacionesM.consumo_proy_obras;
                    oAguas_operaciones.consumo_rrhh_timpure = oAguas_operacionesM.consumo_rrhh_timpure;
                    oAguas_operaciones.consumo_rrhh_pucamara = oAguas_operacionesM.consumo_rrhh_pucamara;
                    oAguas_operaciones.pluviometro_lixiviacion = oAguas_operacionesM.pluviometro_lixiviacion;
                    oAguas_operaciones.pluviometro_planta_adr = oAguas_operacionesM.pluviometro_planta_adr;
                    oAguas_operaciones.pluviomento_pozos_agua = oAguas_operacionesM.pluviomento_pozos_agua;
                    oAguas_operaciones.bombeo_chancado_niv_inicial = oAguas_operacionesM.bombeo_chancado_niv_inicial;
                    oAguas_operaciones.bombeo_chancado_niv_final = oAguas_operacionesM.bombeo_chancado_niv_final;
                    oAguas_operaciones.totalizador_pozo_1 = oAguas_operacionesM.totalizador_pozo_1;
                    oAguas_operaciones.totalizador_pozo_2 = oAguas_operacionesM.totalizador_pozo_2;
                    oAguas_operaciones.totalizador_pozo_3 = oAguas_operacionesM.totalizador_pozo_3;
                    oAguas_operaciones.totalizador_pozo_4 = oAguas_operacionesM.totalizador_pozo_4;
                    oAguas_operaciones.totalizador_pozo_5 = oAguas_operacionesM.totalizador_pozo_5;
                    oAguas_operaciones.totalizador_pozo_6 = oAguas_operacionesM.totalizador_pozo_6;
                    oAguas_operaciones.totalizador_ingreso_tk_2 = oAguas_operacionesM.totalizador_ingreso_tk_2;
                    oAguas_operaciones.totalizador_make_up_planta = oAguas_operacionesM.totalizador_make_up_planta;
                    oAguas_operaciones.nivel_freatico_pozo_1 = oAguas_operacionesM.nivel_freatico_pozo_1;
                    oAguas_operaciones.nivel_freatico_pozo_2 = oAguas_operacionesM.nivel_freatico_pozo_2;
                    oAguas_operaciones.nivel_freatico_pozo_3 = oAguas_operacionesM.nivel_freatico_pozo_3;
                    oAguas_operaciones.nivel_freatico_pozo_4 = oAguas_operacionesM.nivel_freatico_pozo_4;
                    oAguas_operaciones.nivel_freatico_pozo_5 = oAguas_operacionesM.nivel_freatico_pozo_5;
                    oAguas_operaciones.nivel_freatico_pozo_6 = oAguas_operacionesM.nivel_freatico_pozo_6;
                    oAguas_operaciones.variador_velocidad_pozo_1 = oAguas_operacionesM.variador_velocidad_pozo_1;
                    oAguas_operaciones.variador_velocidad_pozo_2 = oAguas_operacionesM.variador_velocidad_pozo_2;
                    oAguas_operaciones.variador_velocidad_pozo_3 = oAguas_operacionesM.variador_velocidad_pozo_3;
                    oAguas_operaciones.variador_velocidad_pozo_4 = oAguas_operacionesM.variador_velocidad_pozo_4;
                    oAguas_operaciones.variador_velocidad_pozo_5 = oAguas_operacionesM.variador_velocidad_pozo_5;
                    oAguas_operaciones.variador_velocidad_pozo_6 = oAguas_operacionesM.variador_velocidad_pozo_6;
                    oAguas_operaciones.activo = oAguas_operacionesM.activo;
                    oAguas_operaciones.usuario_crea = oAguas_operacionesM.usuario_crea;
                    oAguas_operaciones.fecha_crea = oAguas_operacionesM.fecha_crea;
                    oAguas_operaciones.usuario_mod = Session["USR_COD"].ToString();
                    oAguas_operaciones.fecha_mod = oAguas_operacionesM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    oAguas_operacionesBL.actualizarAguas_operaciones(oAguas_operaciones);
                    oAguas_operacionesM.resultado = 1;
                }
                cargarCombos(oAguas_operacionesM.turno_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oAguas_operacionesM.resultado = 2;
            }

            return View(oAguas_operacionesM);
        }

        // GET: Aguas_operaciones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aguas_operaciones/Delete/5
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

        public void cargarCombos(int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();
                EstadoBL oEstadoBL = new EstadoBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurnoLix"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);


            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}