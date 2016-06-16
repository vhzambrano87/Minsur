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
    public class IngresonivelespozaController : Controller
    {
        // GET: Ingresonivelespoza
        public ActionResult Index()
        {
            IngresonivelespozaBL oIngresonivelespozaBL = new IngresonivelespozaBL();
            Lista_valorBL oListaValorBL = new Lista_valorBL();
            DTOIngresonivelespozaRespuesta oIngresonivelespozaRpta = new DTOIngresonivelespozaRespuesta();
            oIngresonivelespozaRpta = oIngresonivelespozaBL.obtenerIngresonivelespoza();
            DTOIngresonivelespozaM oIngresonivelespozaM = new DTOIngresonivelespozaM();
            List<DTOIngresonivelespozaM> oLista_IngresonivelespozaM = new List<DTOIngresonivelespozaM>();

            if (oIngresonivelespozaRpta.DTOListaIngresonivelespoza != null)
            {
                foreach (var item in oIngresonivelespozaRpta.DTOListaIngresonivelespoza)
                {
                    oIngresonivelespozaM = new DTOIngresonivelespozaM();
                    oIngresonivelespozaM.ingresonivelespoza_id = item.ingresonivelespoza_id;
                    oIngresonivelespozaM.fecha = item.fecha;
                    oIngresonivelespozaM.turno =  oListaValorBL.obtenerLista_valor_por_id(Convert.ToInt32(item.turno)).DTOLista_valor.valor;
                    oIngresonivelespozaM.cotapls = item.cotapls;
                    oIngresonivelespozaM.volumepls = item.volumepls;
                    oIngresonivelespozaM.cotapge = item.cotapge;
                    oIngresonivelespozaM.volumepge = item.volumepge;
                    oIngresonivelespozaM.usuario_crea = item.usuario_crea;
                    oIngresonivelespozaM.fecha_crea = item.fecha_crea;
                    oIngresonivelespozaM.usuario_mod = item.usuario_mod;
                    oIngresonivelespozaM.fecha_mod = item.fecha_mod;
                    oIngresonivelespozaM.activo = item.activo;
                    oLista_IngresonivelespozaM.Add(oIngresonivelespozaM);
                }
            }


            return View(oLista_IngresonivelespozaM);
        }

        // GET: Ingresonivelespoza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ingresonivelespoza/Create
        public ActionResult Create()
        {
            DTOIngresonivelespozaM oIngresonivelespozaM = new DTOIngresonivelespozaM();
            cargarCombos(0);
            oIngresonivelespozaM.fecha_desc = DateTime.Today.ToShortDateString();
            oIngresonivelespozaM.activo = true;
            return View(oIngresonivelespozaM);
        }

        // POST: Ingresonivelespoza/Create
        [HttpPost]
        public ActionResult Create(DTOIngresonivelespozaM oIngresonivelespozaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    IngresonivelespozaBL IngresonivelespozaBL = new IngresonivelespozaBL();
                    DTOIngresonivelespoza oIngresonivelespoza = new DTOIngresonivelespoza();
                    oIngresonivelespoza.ingresonivelespoza_id = oIngresonivelespozaM.ingresonivelespoza_id;
                    oIngresonivelespoza.fecha = Convert.ToDateTime(oIngresonivelespozaM.fecha_desc);
                    oIngresonivelespoza.turno = oIngresonivelespozaM.turno;
                    oIngresonivelespoza.cotapls = oIngresonivelespozaM.cotapls;
                    oIngresonivelespoza.volumepls = oIngresonivelespozaM.volumepls;
                    oIngresonivelespoza.cotapge = oIngresonivelespozaM.cotapge;
                    oIngresonivelespoza.volumepge = oIngresonivelespozaM.volumepge;
                    oIngresonivelespoza.activo = oIngresonivelespozaM.activo;
                    oIngresonivelespoza.usuario_crea = Session["USR_COD"].ToString();
                    oIngresonivelespoza.fecha_crea = oIngresonivelespozaM.fecha_crea;
                    oIngresonivelespoza.usuario_mod = oIngresonivelespozaM.usuario_mod;
                    oIngresonivelespoza.fecha_mod = oIngresonivelespozaM.fecha_mod;

                    IngresonivelespozaBL.registrarIngresonivelespoza(oIngresonivelespoza);

                    oIngresonivelespozaM.resultado = 1;
                }
                cargarCombos(Convert.ToInt32(oIngresonivelespozaM.turno));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oIngresonivelespozaM.resultado = 2;
            }

            return View(oIngresonivelespozaM);
        }

        // GET: Ingresonivelespoza/Edit/5
        public ActionResult Edit(int id)
        {
            DTOIngresonivelespozaRespuesta oIngresonivelespozaRpta = new DTOIngresonivelespozaRespuesta();
            IngresonivelespozaBL oIngresonivelespozaBL = new IngresonivelespozaBL();
            DTOIngresonivelespozaM oIngresonivelespozaM = new DTOIngresonivelespozaM();
            try
            {
                oIngresonivelespozaRpta = oIngresonivelespozaBL.obtenerIngresonivelespoza_por_id(id);
                oIngresonivelespozaM.ingresonivelespoza_id = oIngresonivelespozaRpta.DTOIngresonivelespoza.ingresonivelespoza_id;
                oIngresonivelespozaM.fecha = oIngresonivelespozaRpta.DTOIngresonivelespoza.fecha;
                oIngresonivelespozaM.fecha_desc = Convert.ToDateTime(oIngresonivelespozaRpta.DTOIngresonivelespoza.fecha).ToShortDateString();
                oIngresonivelespozaM.turno = oIngresonivelespozaRpta.DTOIngresonivelespoza.turno;
                oIngresonivelespozaM.cotapls = oIngresonivelespozaRpta.DTOIngresonivelespoza.cotapls;
                oIngresonivelespozaM.volumepls = oIngresonivelespozaRpta.DTOIngresonivelespoza.volumepls;
                oIngresonivelespozaM.cotapge = oIngresonivelespozaRpta.DTOIngresonivelespoza.cotapge;
                oIngresonivelespozaM.volumepge = oIngresonivelespozaRpta.DTOIngresonivelespoza.volumepge;

                oIngresonivelespozaM.activo = oIngresonivelespozaRpta.DTOIngresonivelespoza.activo;
                oIngresonivelespozaM.usuario_crea = oIngresonivelespozaRpta.DTOIngresonivelespoza.usuario_crea;
                oIngresonivelespozaM.fecha_crea = oIngresonivelespozaRpta.DTOIngresonivelespoza.fecha_crea;
                oIngresonivelespozaM.usuario_mod = oIngresonivelespozaRpta.DTOIngresonivelespoza.usuario_mod;
                oIngresonivelespozaM.fecha_mod = oIngresonivelespozaRpta.DTOIngresonivelespoza.fecha_mod;
                cargarCombos(Convert.ToInt32(oIngresonivelespozaM.turno));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oIngresonivelespozaM);
        }

        // POST: Ingresonivelespoza/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOIngresonivelespozaM oIngresonivelespozaM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOIngresonivelespoza oIngresonivelespoza = new DTOIngresonivelespoza();
                    IngresonivelespozaBL oIngresonivelespozaBL = new IngresonivelespozaBL();
                    oIngresonivelespoza.ingresonivelespoza_id = oIngresonivelespozaM.ingresonivelespoza_id;
                    oIngresonivelespoza.fecha = Convert.ToDateTime(oIngresonivelespozaM.fecha_desc);
                    oIngresonivelespoza.turno = oIngresonivelespozaM.turno;
                    oIngresonivelespoza.cotapls = oIngresonivelespozaM.cotapls;
                    oIngresonivelespoza.volumepls = oIngresonivelespozaM.volumepls;
                    oIngresonivelespoza.cotapge = oIngresonivelespozaM.cotapge;
                    oIngresonivelespoza.volumepge = oIngresonivelespozaM.volumepge;
                    //oLista.usuario_mod = "MS_USER";
                    cargarCombos(Convert.ToInt32(oIngresonivelespoza.turno));

                    oIngresonivelespoza.activo = oIngresonivelespozaM.activo;
                    oIngresonivelespoza.usuario_crea = oIngresonivelespozaM.usuario_crea;
                    oIngresonivelespoza.fecha_crea = oIngresonivelespozaM.fecha_crea;
                    oIngresonivelespoza.usuario_mod = Session["USR_COD"].ToString();
                    oIngresonivelespoza.fecha_mod = oIngresonivelespozaM.fecha_mod;

                    oIngresonivelespozaBL.actualizarIngresonivelespoza(oIngresonivelespoza);
                }
                oIngresonivelespozaM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oIngresonivelespozaM.resultado = 2;
            }

            return View(oIngresonivelespozaM);
        }

        public void cargarCombos(int turno_id)
        {
            try
            {
                List<DTOLista_valor> oLista_Turno = new List<DTOLista_valor>();                
                Lista_valorBL oListaValorBL = new Lista_valorBL();

                oLista_Turno = oListaValorBL.obtenerLista_valor().DTOListaLista_valor.Where(u => u.lista_id == Convert.ToInt32(ConfigurationManager.AppSettings["ListaTurno"]) && u.activo == true).ToList();
                ViewBag.ListaTurno = new SelectList(oLista_Turno, "lista_valor_id", "valor", turno_id);

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

        }
    }
}