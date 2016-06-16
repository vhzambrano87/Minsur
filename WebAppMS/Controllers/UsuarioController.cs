using BusinessEntities;
using BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMS.Models;

namespace WebAppMS.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioBL oUsuarioBL = new UsuarioBL();
            DTOUsuarioRespuesta oUsuarioRpta = new DTOUsuarioRespuesta();
            oUsuarioRpta = oUsuarioBL.obtenerUsuario();
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            List<DTOUsuarioM> oLista_UsuarioM = new List<DTOUsuarioM>();

            if (oUsuarioRpta.DTOListaUsuario != null)
            {
                foreach (var item in oUsuarioRpta.DTOListaUsuario)
                {
                    oUsuarioM = new DTOUsuarioM(); oUsuarioM.usuario_id = item.usuario_id;
                    oUsuarioM.usuario = item.usuario;
                    oUsuarioM.password = item.password;
                    oUsuarioM.nombres = item.nombres;
                    oUsuarioM.correo = item.correo;
                    oUsuarioM.activo = item.activo;
                    oUsuarioM.usuario_crea = item.usuario_crea;
                    oUsuarioM.fecha_crea = item.fecha_crea;
                    oUsuarioM.usuario_mod = item.usuario_mod;
                    oUsuarioM.fecha_mod = item.fecha_mod;
                    oLista_UsuarioM.Add(oUsuarioM);
                }
            }


            return View(oLista_UsuarioM);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            oUsuarioM.activo = true;
            return View(oUsuarioM);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(DTOUsuarioM oUsuarioM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    UsuarioBL UsuarioBL = new UsuarioBL();
                    DTOUsuario oUsuario = new DTOUsuario();
                    oUsuario.usuario_id = oUsuarioM.usuario_id;
                    oUsuario.usuario = oUsuarioM.usuario.ToUpper();
                    oUsuario.password = oUsuarioM.password;
                    oUsuario.nombres = oUsuarioM.nombres;
                    oUsuario.correo = oUsuarioM.correo;
                    oUsuario.activo = oUsuarioM.activo;
                    oUsuario.usuario_crea = Session["USR_COD"].ToString();
                    oUsuario.fecha_crea = oUsuarioM.fecha_crea;
                    oUsuario.usuario_mod = oUsuarioM.usuario_mod;
                    oUsuario.fecha_mod = oUsuarioM.fecha_mod;

                    if (UsuarioBL.obtenerUsuario().DTOListaUsuario.Where(u => u.usuario == oUsuarioM.usuario).ToList().Count == 0)
                    {
                        UsuarioBL.registrarUsuario(oUsuario);
                        oUsuarioM.resultado = 1;
                    }
                    else
                    {
                        oUsuarioM.resultado = 3;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oUsuarioM.resultado = 2;
            }

            return View(oUsuarioM);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            DTOUsuarioRespuesta oUsuarioRpta = new DTOUsuarioRespuesta();
            UsuarioBL oUsuarioBL = new UsuarioBL();
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            try
            {
                oUsuarioRpta = oUsuarioBL.obtenerUsuario_por_id(id);
                oUsuarioM.usuario_id = oUsuarioRpta.DTOUsuario.usuario_id;
                oUsuarioM.usuario = oUsuarioRpta.DTOUsuario.usuario;
                oUsuarioM.password = oUsuarioRpta.DTOUsuario.password;
                oUsuarioM.nombres = oUsuarioRpta.DTOUsuario.nombres;
                oUsuarioM.correo = oUsuarioRpta.DTOUsuario.correo;
                oUsuarioM.activo = oUsuarioRpta.DTOUsuario.activo;
                oUsuarioM.usuario_crea = oUsuarioRpta.DTOUsuario.usuario_crea;
                oUsuarioM.fecha_crea = oUsuarioRpta.DTOUsuario.fecha_crea;
                oUsuarioM.usuario_mod = oUsuarioRpta.DTOUsuario.usuario_mod;
                oUsuarioM.fecha_mod = oUsuarioRpta.DTOUsuario.fecha_mod;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return View(oUsuarioM);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(DTOUsuarioM oUsuarioM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DTOUsuario oUsuario = new DTOUsuario();
                    UsuarioBL oUsuarioBL = new UsuarioBL();
                    oUsuario.usuario_id = oUsuarioM.usuario_id;
                    oUsuario.usuario = oUsuarioM.usuario.ToUpper();
                    oUsuario.password = oUsuarioM.password;
                    oUsuario.nombres = oUsuarioM.nombres;
                    oUsuario.correo = oUsuarioM.correo;
                    oUsuario.activo = oUsuarioM.activo;
                    oUsuario.usuario_crea = oUsuarioM.usuario_crea;
                    oUsuario.fecha_crea = oUsuarioM.fecha_crea;
                    oUsuario.usuario_mod = Session["USR_COD"].ToString();
                    oUsuario.fecha_mod = oUsuarioM.fecha_mod;
                    //oLista.usuario_mod = "MS_USER";

                    if (oUsuarioBL.obtenerUsuario().DTOListaUsuario.Where(u => u.usuario == oUsuarioM.usuario && u.usuario_id != oUsuarioM.usuario_id).ToList().Count == 0)
                    {
                        oUsuarioBL.actualizarUsuario(oUsuario);
                        oUsuarioM.resultado = 1;
                    }
                    else
                    {
                        oUsuarioM.resultado = 3;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                oUsuarioM.resultado = 2;
            }

            return View(oUsuarioM);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
    }
}