using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMS.Models;
using DataAccess;

namespace WebAppMS.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            RolBL oRolBL = new RolBL();
            DTORolRespuesta oRolRpta = new DTORolRespuesta();
            oRolRpta = oRolBL.obtenerRol();
            DTORolM oRolM = new DTORolM();
            List<DTORolM> oLista_RolM = new List<DTORolM>();

            if (oRolRpta.DTOListaRol != null)
            {
                foreach (var item in oRolRpta.DTOListaRol)
                {
                    oRolM = new DTORolM(); oRolM.rol_id = item.rol_id;
                    oRolM.nombre = item.nombre;
                    oRolM.activo = item.activo;
                    oRolM.usuario_crea = item.usuario_crea;
                    oRolM.fecha_crea = item.fecha_crea;
                    oRolM.usuario_mod = item.usuario_mod;
                    oRolM.fecha_mod = item.fecha_mod;
                    oLista_RolM.Add(oRolM);
                }
            }


            return View(oLista_RolM);
        }

        // GET: Rol/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            DTORolM oRolM = new DTORolM();
            oRolM.activo = true;

            return View(oRolM);
        }

        // POST: Rol/Create
        [HttpPost]
        public ActionResult Create(DTORolM oRolM)
        {
            try
            {
                // TODO: Add insert logic here
                RolBL RolBL = new RolBL();
                DTORol oRol = new DTORol(); oRol.rol_id = oRolM.rol_id;
                oRol.nombre = oRolM.nombre;
                oRol.activo = oRolM.activo;
                oRol.usuario_crea = Session["USR_COD"].ToString();
                oRol.fecha_crea = oRolM.fecha_crea;
                oRol.usuario_mod = oRolM.usuario_mod;
                oRol.fecha_mod = oRolM.fecha_mod;
                RolBL.registrarRol(oRol);
                oRolM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oRolM.resultado = 2;
            }

            return View(oRolM);
        }

        // GET: Rol/Edit/5
        public ActionResult Edit(int id)
        {
            DTORolRespuesta oRolRpta = new DTORolRespuesta();
            RolBL oRolBL = new RolBL();
            DTORolM oRolM = new DTORolM();
            try
            {
                oRolRpta = oRolBL.obtenerRol_por_id(id);
                oRolM.rol_id = oRolRpta.DTORol.rol_id;
                oRolM.nombre = oRolRpta.DTORol.nombre;
                oRolM.activo = oRolRpta.DTORol.activo;
                oRolM.usuario_crea = oRolRpta.DTORol.usuario_crea;
                oRolM.fecha_crea = oRolRpta.DTORol.fecha_crea;
                oRolM.usuario_mod = oRolRpta.DTORol.usuario_mod;
                oRolM.fecha_mod = oRolRpta.DTORol.fecha_mod;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oRolM);
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public ActionResult Edit(DTORolM oRolM)
        {
            try
            {
                DTORol oRol = new DTORol();
                RolBL oRolBL = new RolBL();
                oRol.rol_id = oRolM.rol_id;
                oRol.nombre = oRolM.nombre;
                oRol.activo = oRolM.activo;
                oRol.usuario_crea = oRolM.usuario_crea;
                oRol.fecha_crea = oRolM.fecha_crea;
                oRol.usuario_mod = Session["USR_COD"].ToString();
                oRol.fecha_mod = oRolM.fecha_mod;
                //oLista.usuario_mod = "MS_USER";

                oRolBL.actualizarRol(oRol);
                oRolM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oRolM.resultado = 2;
            }

            return View(oRolM);
        }

        public ActionResult Asociar(int id)
        {
            DTORolM oRolM = new DTORolM();
            oRolM.activo = true;
            oRolM.rol_id = id;
            UsuarioBL oUsuarioBL = new UsuarioBL();
            oRolM.listaUsuario = oUsuarioBL.obtenerUsuarioSelected(id).DTOListaUsuario;
            oRolM.asociados = "";
            foreach (var item in oRolM.listaUsuario)
            {
                oRolM.asociados = oRolM.asociados + item.asociados;
            }

            return View(oRolM);
        }


        public ActionResult AsociarOpcion(int id)
        {
            DTORolM oRolM = new DTORolM();
            oRolM.activo = true;
            oRolM.rol_id = id;
            OpcionBL oOpcionBL = new OpcionBL();
            oRolM.listaOpcion = oOpcionBL.obtenerOpcionSelected(id).DTOListaOpcion;
            oRolM.asociadosOpc = "";
            foreach (var item in oRolM.listaOpcion)
            {
                oRolM.asociadosOpc = oRolM.asociadosOpc + item.asociados;
            }

            return View(oRolM);
        }


        // POST: Rol/Asociar
        [HttpPost]
        public ActionResult Asociar(DTORolM oRolM)
        {
            try
            {
                // TODO: Add insert logic here
                RolBL RolBL = new RolBL();
                Usuario_rolBL usuarioRolBL = new Usuario_rolBL();

                DTORol oRol = new DTORol();
                oRol.rol_id = oRolM.rol_id;
                oRol.nombre = oRolM.nombre;
                oRol.activo = oRolM.activo;
                oRol.usuario_crea = oRolM.usuario_crea;
                oRol.fecha_crea = oRolM.fecha_crea;
                oRol.usuario_mod = oRolM.usuario_mod;
                oRol.fecha_mod = oRolM.fecha_mod;

                bool flag = true;
                int index = 0;
                int index_2 = 0;
                int usuario_id = 0;
                string usr = "";

                usuarioRolBL.EliminaUsuarioRol();

                while (flag)
                {
                    DTOUsuario_rol oUsuarioRol = new DTOUsuario_rol();                
                    index = oRolM.asociados.IndexOf("]");
                    index_2 = index + 1;
                    usr = oRolM.asociados.Substring(0, index);
                    usr = usr.Replace("[","");
                    usuario_id = Convert.ToInt32(usr);

                    oUsuarioRol.usuario_id = usuario_id;
                    oUsuarioRol.rol_id = oRol.rol_id;

                    usuarioRolBL.registrarUsuario_rol(oUsuarioRol);

                    oRolM.asociados = oRolM.asociados.Substring(index_2 , oRolM.asociados.Length-index_2);

                    if (oRolM.asociados == "")
                    {
                        flag = false;
                    }
                }
                UsuarioBL oUsuarioBL = new UsuarioBL();
                oRolM.listaUsuario = oUsuarioBL.obtenerUsuarioSelected(oRolM.rol_id).DTOListaUsuario;


                //RolBL.registrarRol(oRol);
                oRolM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oRolM.resultado = 2;
            }

            return View(oRolM);
        }


        [HttpPost]
        public ActionResult AsociarOpcion(DTORolM oRolM)
        {
            try
            {
                // TODO: Add insert logic here
                RolBL RolBL = new RolBL();
                Rol_opcionBL orolOpcionBL = new Rol_opcionBL();

                Usuario_rolBL usuarioRolBL = new Usuario_rolBL();

                DTORol oRol = new DTORol();
                oRol.rol_id = oRolM.rol_id;
                oRol.nombre = oRolM.nombre;
                oRol.activo = oRolM.activo;
                oRol.usuario_crea = oRolM.usuario_crea;
                oRol.fecha_crea = oRolM.fecha_crea;
                oRol.usuario_mod = oRolM.usuario_mod;
                oRol.fecha_mod = oRolM.fecha_mod;

                bool flag = true;
                int index = 0;
                int index_2 = 0;
                int opcion_id = 0;
                string opc = "";

                usuarioRolBL.EliminaRolOpcion();

                while (flag)
                {
                    DTORol_opcion oRolOpcion = new DTORol_opcion();
                    index = oRolM.asociadosOpc.IndexOf("]");
                    index_2 = index + 1;
                    opc = oRolM.asociadosOpc.Substring(0, index);
                    opc = opc.Replace("[", "");
                    opcion_id = Convert.ToInt32(opc);

                    oRolOpcion.opcion_id = opcion_id;
                    oRolOpcion.rol_id = oRol.rol_id;

                    orolOpcionBL.registrarRol_opcion(oRolOpcion);

                    oRolM.asociadosOpc = oRolM.asociadosOpc.Substring(index_2, oRolM.asociadosOpc.Length - index_2);

                    if (oRolM.asociadosOpc == "")
                    {
                        flag = false;
                    }
                }
                OpcionBL oOpcionBL = new OpcionBL();
                oRolM.listaOpcion = oOpcionBL.obtenerOpcionSelected(oRolM.rol_id).DTOListaOpcion;


                //RolBL.registrarRol(oRol);
                oRolM.resultado = 1;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oRolM.resultado = 2;
            }

            return View(oRolM);
        }


    }
}