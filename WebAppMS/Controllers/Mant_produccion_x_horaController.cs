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
    public class Mant_produccion_x_horaController : Controller
    {
        // GET: Mant_produccion_x_hora
        public ActionResult Index()
        {
            Mant_produccion_x_horaBL oMant_produccion_x_horaBL = new Mant_produccion_x_horaBL();
            DTOMant_produccion_x_horaRespuesta oMant_produccion_x_horaRpta = new DTOMant_produccion_x_horaRespuesta();
            oMant_produccion_x_horaRpta = oMant_produccion_x_horaBL.obtenerMant_produccion_x_hora();
            DTOMant_produccion_x_horaM oMant_produccion_x_horaM = new DTOMant_produccion_x_horaM();
            List<DTOMant_produccion_x_horaM> oLista_Mant_produccion_x_horaM = new List<DTOMant_produccion_x_horaM>();

            if (oMant_produccion_x_horaRpta.DTOListaMant_produccion_x_hora != null)
            {
                foreach (var item in oMant_produccion_x_horaRpta.DTOListaMant_produccion_x_hora)
                {
                    oMant_produccion_x_horaM = new DTOMant_produccion_x_horaM(); oMant_produccion_x_horaM.produccion_hora_id = item.produccion_hora_id;
                    oMant_produccion_x_horaM.fecha = item.fecha;
                    oMant_produccion_x_horaM.guardia_id = item.guardia_id;
                    oMant_produccion_x_horaM.turno_id = item.turno_id;
                    oMant_produccion_x_horaM.hora = item.hora;
                    oMant_produccion_x_horaM.camion = item.camion;
                    oMant_produccion_x_horaM.toneladas = item.toneladas;
                    oMant_produccion_x_horaM.viajes = item.viajes;
                    oMant_produccion_x_horaM.material_id = item.material_id;
                    oMant_produccion_x_horaM.ruta_id = item.ruta_id;
                    oMant_produccion_x_horaM.zona_cargio_id = item.zona_cargio_id;
                    oMant_produccion_x_horaM.equipo_cargio_id = item.equipo_cargio_id;
                    oMant_produccion_x_horaM.ton1 = item.ton1;
                    oMant_produccion_x_horaM.ton2 = item.ton2;
                    oMant_produccion_x_horaM.ton3 = item.ton3;
                    oMant_produccion_x_horaM.ton4 = item.ton4;
                    oMant_produccion_x_horaM.ton5 = item.ton5;
                    oMant_produccion_x_horaM.ton6 = item.ton6;
                    oMant_produccion_x_horaM.ton7 = item.ton7;
                    oMant_produccion_x_horaM.ton8 = item.ton8;
                    oMant_produccion_x_horaM.ton9 = item.ton9;
                    oMant_produccion_x_horaM.ton10 = item.ton10;
                    oMant_produccion_x_horaM.ton11 = item.ton11;
                    oMant_produccion_x_horaM.ton12 = item.ton12;
                    oMant_produccion_x_horaM.ton13 = item.ton13;
                    oMant_produccion_x_horaM.ton14 = item.ton14;
                    oMant_produccion_x_horaM.ton15 = item.ton15;
                    oMant_produccion_x_horaM.ton16 = item.ton16;
                    oMant_produccion_x_horaM.ton17 = item.ton17;
                    oMant_produccion_x_horaM.ton18 = item.ton18;
                    oMant_produccion_x_horaM.ton19 = item.ton19;
                    oMant_produccion_x_horaM.ton20 = item.ton20;
                    oMant_produccion_x_horaM.ton21 = item.ton21;
                    oMant_produccion_x_horaM.ton22 = item.ton22;
                    oMant_produccion_x_horaM.ton23 = item.ton23;
                    oMant_produccion_x_horaM.ton24 = item.ton24;
                    oMant_produccion_x_horaM.ton25 = item.ton25;
                    oMant_produccion_x_horaM.ton26 = item.ton26;
                    oMant_produccion_x_horaM.ton27 = item.ton27;
                    oMant_produccion_x_horaM.ton28 = item.ton28;
                    oMant_produccion_x_horaM.ton29 = item.ton29;
                    oMant_produccion_x_horaM.ton30 = item.ton30;
                    oMant_produccion_x_horaM.activo = item.activo;
                    oMant_produccion_x_horaM.usuario_crea = item.usuario_crea;
                    oMant_produccion_x_horaM.fecha_crea = item.fecha_crea;
                    oMant_produccion_x_horaM.usuario_mod = item.usuario_mod;
                    oMant_produccion_x_horaM.fecha_mod = item.fecha_mod;

                    oMant_produccion_x_horaM.guardia_desc = item.guardia_desc;
                    oMant_produccion_x_horaM.turno_desc = item.turno_desc;
                    oMant_produccion_x_horaM.material_desc = item.material_desc;
                    oMant_produccion_x_horaM.equipo_cargio_desc = item.equipo_cargio_desc;
                    oMant_produccion_x_horaM.zona_cargio_desc = item.equipo_cargio_desc;
                    oMant_produccion_x_horaM.equipo_cargio_desc = item.equipo_cargio_desc;
                    oMant_produccion_x_horaM.ruta_desc = item.ruta_desc;

                    oLista_Mant_produccion_x_horaM.Add(oMant_produccion_x_horaM);
                }
            }


            return View(oLista_Mant_produccion_x_horaM);
        }

        // GET: Mant_produccion_x_hora/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mant_produccion_x_hora/Create
        public ActionResult Create()
        {
            DTOMant_produccion_x_horaM oMant_produccion_x_horaM = new DTOMant_produccion_x_horaM();
            cargarCombos(0, 0, 0, 0, 0, 0);
            oMant_produccion_x_horaM.activo = true;
            oMant_produccion_x_horaM.fecha_desc = DateTime.Today.ToShortDateString();
            return View(oMant_produccion_x_horaM);
        }

        // POST: Mant_produccion_x_hora/Create
        [HttpPost]
        public ActionResult Create(DTOMant_produccion_x_horaM oMant_produccion_x_horaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    Mant_produccion_x_horaBL Mant_produccion_x_horaBL = new Mant_produccion_x_horaBL();
                    DTOMant_produccion_x_hora oMant_produccion_x_hora = new DTOMant_produccion_x_hora(); oMant_produccion_x_hora.produccion_hora_id = oMant_produccion_x_horaM.produccion_hora_id;
                    oMant_produccion_x_hora.fecha = oMant_produccion_x_horaM.fecha;
                    oMant_produccion_x_hora.guardia_id = oMant_produccion_x_horaM.guardia_id;
                    oMant_produccion_x_hora.turno_id = oMant_produccion_x_horaM.turno_id;
                    oMant_produccion_x_hora.hora = oMant_produccion_x_horaM.hora;
                    oMant_produccion_x_hora.camion = oMant_produccion_x_horaM.camion;
                    oMant_produccion_x_hora.toneladas = oMant_produccion_x_horaM.toneladas;
                    oMant_produccion_x_hora.viajes = oMant_produccion_x_horaM.viajes;
                    oMant_produccion_x_hora.material_id = oMant_produccion_x_horaM.material_id;
                    oMant_produccion_x_hora.ruta_id = oMant_produccion_x_horaM.ruta_id;

                    oMant_produccion_x_hora.zona_cargio_id = oMant_produccion_x_horaM.zona_cargio_id;
                    oMant_produccion_x_hora.equipo_cargio_id = oMant_produccion_x_horaM.equipo_cargio_id;
                    oMant_produccion_x_hora.ton1 = oMant_produccion_x_horaM.ton1;
                    oMant_produccion_x_hora.ton2 = oMant_produccion_x_horaM.ton2;
                    oMant_produccion_x_hora.ton3 = oMant_produccion_x_horaM.ton3;
                    oMant_produccion_x_hora.ton4 = oMant_produccion_x_horaM.ton4;
                    oMant_produccion_x_hora.ton5 = oMant_produccion_x_horaM.ton5;
                    oMant_produccion_x_hora.ton6 = oMant_produccion_x_horaM.ton6;
                    oMant_produccion_x_hora.ton7 = oMant_produccion_x_horaM.ton7;
                    oMant_produccion_x_hora.ton8 = oMant_produccion_x_horaM.ton8;
                    oMant_produccion_x_hora.ton9 = oMant_produccion_x_horaM.ton9;
                    oMant_produccion_x_hora.ton10 = oMant_produccion_x_horaM.ton10;
                    oMant_produccion_x_hora.ton11 = oMant_produccion_x_horaM.ton11;
                    oMant_produccion_x_hora.ton12 = oMant_produccion_x_horaM.ton12;
                    oMant_produccion_x_hora.ton13 = oMant_produccion_x_horaM.ton13;
                    oMant_produccion_x_hora.ton14 = oMant_produccion_x_horaM.ton14;
                    oMant_produccion_x_hora.ton15 = oMant_produccion_x_horaM.ton15;
                    oMant_produccion_x_hora.ton16 = oMant_produccion_x_horaM.ton16;
                    oMant_produccion_x_hora.ton17 = oMant_produccion_x_horaM.ton17;
                    oMant_produccion_x_hora.ton18 = oMant_produccion_x_horaM.ton18;
                    oMant_produccion_x_hora.ton19 = oMant_produccion_x_horaM.ton19;
                    oMant_produccion_x_hora.ton20 = oMant_produccion_x_horaM.ton20;
                    oMant_produccion_x_hora.ton21 = oMant_produccion_x_horaM.ton21;
                    oMant_produccion_x_hora.ton22 = oMant_produccion_x_horaM.ton22;
                    oMant_produccion_x_hora.ton23 = oMant_produccion_x_horaM.ton23;
                    oMant_produccion_x_hora.ton24 = oMant_produccion_x_horaM.ton24;
                    oMant_produccion_x_hora.ton25 = oMant_produccion_x_horaM.ton25;
                    oMant_produccion_x_hora.ton26 = oMant_produccion_x_horaM.ton26;
                    oMant_produccion_x_hora.ton27 = oMant_produccion_x_horaM.ton27;
                    oMant_produccion_x_hora.ton28 = oMant_produccion_x_horaM.ton28;
                    oMant_produccion_x_hora.ton29 = oMant_produccion_x_horaM.ton29;
                    oMant_produccion_x_hora.ton30 = oMant_produccion_x_horaM.ton30;
                    oMant_produccion_x_hora.activo = oMant_produccion_x_horaM.activo;
                    oMant_produccion_x_hora.usuario_crea = Session["USR_COD"].ToString();
                    oMant_produccion_x_hora.fecha_crea = oMant_produccion_x_horaM.fecha_crea;
                    oMant_produccion_x_hora.usuario_mod = oMant_produccion_x_horaM.usuario_mod;
                    oMant_produccion_x_hora.fecha_mod = oMant_produccion_x_horaM.fecha_mod;
                    Mant_produccion_x_horaBL.registrarMant_produccion_x_hora(oMant_produccion_x_hora);
                    
                    oMant_produccion_x_horaM.resultado = 1;
                }
                cargarCombos(oMant_produccion_x_horaM.guardia_id, oMant_produccion_x_horaM.turno_id, oMant_produccion_x_horaM.material_id, oMant_produccion_x_horaM.ruta_id, oMant_produccion_x_horaM.zona_cargio_id, oMant_produccion_x_horaM.equipo_cargio_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oMant_produccion_x_horaM.resultado = 2;
            }

            return View(oMant_produccion_x_horaM);
        }

        // GET: Mant_produccion_x_hora/Edit/5
        public ActionResult Edit(int id)
        {
            DTOMant_produccion_x_horaRespuesta oMant_produccion_x_horaRpta = new DTOMant_produccion_x_horaRespuesta();
            Mant_produccion_x_horaBL oMant_produccion_x_horaBL = new Mant_produccion_x_horaBL();
            DTOMant_produccion_x_horaM oMant_produccion_x_horaM = new DTOMant_produccion_x_horaM();
            try
            {
                oMant_produccion_x_horaRpta = oMant_produccion_x_horaBL.obtenerMant_produccion_x_hora_por_id(id);
                oMant_produccion_x_horaM.produccion_hora_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.produccion_hora_id;
                oMant_produccion_x_horaM.fecha = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.fecha;
                oMant_produccion_x_horaM.fecha_desc = Convert.ToDateTime(oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.fecha).ToShortDateString();
                oMant_produccion_x_horaM.guardia_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.guardia_id;
                oMant_produccion_x_horaM.turno_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.turno_id;
                oMant_produccion_x_horaM.hora = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.hora;

                oMant_produccion_x_horaM.hora_hora = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.hora.Substring(0,2);
                oMant_produccion_x_horaM.hora_min = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.hora.Substring(3, 2);

                oMant_produccion_x_horaM.camion = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.camion;
                oMant_produccion_x_horaM.toneladas = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.toneladas;
                oMant_produccion_x_horaM.viajes = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.viajes;
                oMant_produccion_x_horaM.material_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.material_id;
                oMant_produccion_x_horaM.ruta_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ruta_id;
                oMant_produccion_x_horaM.zona_cargio_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.zona_cargio_id;
                oMant_produccion_x_horaM.equipo_cargio_id = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.equipo_cargio_id;
                oMant_produccion_x_horaM.ton1 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton1;
                oMant_produccion_x_horaM.ton2 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton2;
                oMant_produccion_x_horaM.ton3 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton3;
                oMant_produccion_x_horaM.ton4 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton4;
                oMant_produccion_x_horaM.ton5 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton5;
                oMant_produccion_x_horaM.ton6 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton6;
                oMant_produccion_x_horaM.ton7 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton7;
                oMant_produccion_x_horaM.ton8 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton8;
                oMant_produccion_x_horaM.ton9 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton9;
                oMant_produccion_x_horaM.ton10 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton10;
                oMant_produccion_x_horaM.ton11 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton11;
                oMant_produccion_x_horaM.ton12 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton12;
                oMant_produccion_x_horaM.ton13 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton13;
                oMant_produccion_x_horaM.ton14 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton14;
                oMant_produccion_x_horaM.ton15 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton15;
                oMant_produccion_x_horaM.ton16 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton16;
                oMant_produccion_x_horaM.ton17 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton17;
                oMant_produccion_x_horaM.ton18 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton18;
                oMant_produccion_x_horaM.ton19 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton19;
                oMant_produccion_x_horaM.ton20 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton20;
                oMant_produccion_x_horaM.ton21 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton21;
                oMant_produccion_x_horaM.ton22 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton22;
                oMant_produccion_x_horaM.ton23 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton23;
                oMant_produccion_x_horaM.ton24 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton24;
                oMant_produccion_x_horaM.ton25 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton25;
                oMant_produccion_x_horaM.ton26 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton26;
                oMant_produccion_x_horaM.ton27 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton27;
                oMant_produccion_x_horaM.ton28 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton28;
                oMant_produccion_x_horaM.ton29 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton29;
                oMant_produccion_x_horaM.ton30 = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ton30;
                oMant_produccion_x_horaM.activo = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.activo;
                oMant_produccion_x_horaM.usuario_crea = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.usuario_crea;
                oMant_produccion_x_horaM.fecha_crea = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.fecha_crea;
                oMant_produccion_x_horaM.usuario_mod = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.usuario_mod;
                oMant_produccion_x_horaM.fecha_mod = oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.fecha_mod;
                cargarCombos(oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.guardia_id, oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.turno_id, oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.material_id, oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.ruta_id, oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.zona_cargio_id, oMant_produccion_x_horaRpta.DTOMant_produccion_x_hora.equipo_cargio_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oMant_produccion_x_horaM);
        }

        // POST: Mant_produccion_x_hora/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOMant_produccion_x_horaM oMant_produccion_x_horaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOMant_produccion_x_hora oMant_produccion_x_hora = new DTOMant_produccion_x_hora();
                    Mant_produccion_x_horaBL oMant_produccion_x_horaBL = new Mant_produccion_x_horaBL();
                    oMant_produccion_x_hora.produccion_hora_id = oMant_produccion_x_horaM.produccion_hora_id;
                    oMant_produccion_x_hora.fecha = Convert.ToDateTime( oMant_produccion_x_horaM.fecha_desc);
                    oMant_produccion_x_hora.guardia_id = oMant_produccion_x_horaM.guardia_id;
                    oMant_produccion_x_hora.turno_id = oMant_produccion_x_horaM.turno_id;
                    oMant_produccion_x_hora.hora = oMant_produccion_x_horaM.hora;
                    oMant_produccion_x_hora.camion = oMant_produccion_x_horaM.camion;
                    oMant_produccion_x_hora.toneladas = oMant_produccion_x_horaM.toneladas;
                    oMant_produccion_x_hora.viajes = oMant_produccion_x_horaM.viajes;
                    oMant_produccion_x_hora.material_id = oMant_produccion_x_horaM.material_id;
                    oMant_produccion_x_hora.ruta_id = oMant_produccion_x_horaM.ruta_id;
                    oMant_produccion_x_hora.zona_cargio_id = oMant_produccion_x_horaM.zona_cargio_id;
                    oMant_produccion_x_hora.equipo_cargio_id = oMant_produccion_x_horaM.equipo_cargio_id;
                    oMant_produccion_x_hora.ton1 = oMant_produccion_x_horaM.ton1;
                    oMant_produccion_x_hora.ton2 = oMant_produccion_x_horaM.ton2;
                    oMant_produccion_x_hora.ton3 = oMant_produccion_x_horaM.ton3;
                    oMant_produccion_x_hora.ton4 = oMant_produccion_x_horaM.ton4;
                    oMant_produccion_x_hora.ton5 = oMant_produccion_x_horaM.ton5;
                    oMant_produccion_x_hora.ton6 = oMant_produccion_x_horaM.ton6;
                    oMant_produccion_x_hora.ton7 = oMant_produccion_x_horaM.ton7;
                    oMant_produccion_x_hora.ton8 = oMant_produccion_x_horaM.ton8;
                    oMant_produccion_x_hora.ton9 = oMant_produccion_x_horaM.ton9;
                    oMant_produccion_x_hora.ton10 = oMant_produccion_x_horaM.ton10;
                    oMant_produccion_x_hora.ton11 = oMant_produccion_x_horaM.ton11;
                    oMant_produccion_x_hora.ton12 = oMant_produccion_x_horaM.ton12;
                    oMant_produccion_x_hora.ton13 = oMant_produccion_x_horaM.ton13;
                    oMant_produccion_x_hora.ton14 = oMant_produccion_x_horaM.ton14;
                    oMant_produccion_x_hora.ton15 = oMant_produccion_x_horaM.ton15;
                    oMant_produccion_x_hora.ton16 = oMant_produccion_x_horaM.ton16;
                    oMant_produccion_x_hora.ton17 = oMant_produccion_x_horaM.ton17;
                    oMant_produccion_x_hora.ton18 = oMant_produccion_x_horaM.ton18;
                    oMant_produccion_x_hora.ton19 = oMant_produccion_x_horaM.ton19;
                    oMant_produccion_x_hora.ton20 = oMant_produccion_x_horaM.ton20;
                    oMant_produccion_x_hora.ton21 = oMant_produccion_x_horaM.ton21;
                    oMant_produccion_x_hora.ton22 = oMant_produccion_x_horaM.ton22;
                    oMant_produccion_x_hora.ton23 = oMant_produccion_x_horaM.ton23;
                    oMant_produccion_x_hora.ton24 = oMant_produccion_x_horaM.ton24;
                    oMant_produccion_x_hora.ton25 = oMant_produccion_x_horaM.ton25;
                    oMant_produccion_x_hora.ton26 = oMant_produccion_x_horaM.ton26;
                    oMant_produccion_x_hora.ton27 = oMant_produccion_x_horaM.ton27;
                    oMant_produccion_x_hora.ton28 = oMant_produccion_x_horaM.ton28;
                    oMant_produccion_x_hora.ton29 = oMant_produccion_x_horaM.ton29;
                    oMant_produccion_x_hora.ton30 = oMant_produccion_x_horaM.ton30;
                    oMant_produccion_x_hora.activo = oMant_produccion_x_horaM.activo;
                    oMant_produccion_x_hora.usuario_crea = oMant_produccion_x_horaM.usuario_crea;
                    oMant_produccion_x_hora.fecha_crea = oMant_produccion_x_horaM.fecha_crea;
                    oMant_produccion_x_hora.usuario_mod = Session["USR_COD"].ToString();
                    oMant_produccion_x_hora.fecha_mod = oMant_produccion_x_horaM.fecha_mod;
                    oMant_produccion_x_hora.activo = oMant_produccion_x_horaM.activo;
                    //oLista.usuario_mod = "MS_USER";

                    oMant_produccion_x_horaBL.actualizarMant_produccion_x_hora(oMant_produccion_x_hora);
                    oMant_produccion_x_horaM.resultado = 1;
                }
                cargarCombos(oMant_produccion_x_horaM.guardia_id, oMant_produccion_x_horaM.turno_id, oMant_produccion_x_horaM.material_id, oMant_produccion_x_horaM.ruta_id, oMant_produccion_x_horaM.zona_cargio_id, oMant_produccion_x_horaM.equipo_cargio_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oMant_produccion_x_horaM.resultado = 2;
            }

            return View(oMant_produccion_x_horaM);
        }

        // GET: Mant_produccion_x_hora/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mant_produccion_x_hora/Delete/5
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

        public void cargarCombos(int guardia_id, int turno_id, int material_id, int ruta_id, int zona_id, int equipo_cargio_id)
        {
            try
            {
                //DTOLista_valorRespuesta oListaTurnoRpta = new DTOLista_valorRespuesta();
                List<DTOLista_valor> oLista_guardia = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_turno = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_material = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_ruta = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_zona_cargio = new List<DTOLista_valor>();
                List<DTOLista_valor> oLista_equipo_cargio = new List<DTOLista_valor>();

                Lista_valorBL oListaValorBL = new Lista_valorBL();

                int lista_gardia_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaGuardia"]);
                int lista_turno_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaTurno"]);
                int lista_material_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaMaterial"]);
                int lista_ruta_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaRuta"]);
                int lista_zona_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaZonaCargio"]);
                int lista_equipo_cargio_id = Convert.ToInt16(ConfigurationManager.AppSettings["ListaEquipoCargio"]);


                oLista_guardia = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_gardia_id).ToList();
                ViewBag.ListaGuardia = new SelectList(oLista_guardia, "lista_valor_id", "valor", guardia_id);

                oLista_turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_turno_id).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_turno, "lista_valor_id", "valor", turno_id);

                oLista_material = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_material_id).ToList();
                ViewBag.ListaMaterial = new SelectList(oLista_material, "lista_valor_id", "valor", material_id);


                oLista_ruta = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_ruta_id).ToList();
                ViewBag.ListaRuta = new SelectList(oLista_ruta, "lista_valor_id", "valor", ruta_id);

                oLista_zona_cargio = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_zona_id).ToList();
                ViewBag.ListaZonaCargio = new SelectList(oLista_zona_cargio, "lista_valor_id", "valor", zona_id);

                oLista_equipo_cargio = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == lista_equipo_cargio_id).ToList();
                ViewBag.ListaEquipoCargio = new SelectList(oLista_equipo_cargio, "lista_valor_id", "valor", equipo_cargio_id);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}