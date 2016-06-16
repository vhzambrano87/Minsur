using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessLogic;
using WebAppMS.Models;

namespace WebAppMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: home/index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Session["USR_COD"] = "";
            Session["USR_NAME"] = "";
            Session["USR_OPCION"] = "[]";
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            return View(oUsuarioM);
        }

        [HttpPost]
        public ActionResult Login(DTOUsuarioM oUsuarioM)
        {
            UsuarioBL oUsuarioBL = new UsuarioBL();
            List<DTOUsuario> listaUsuario = new List<DTOUsuario>();
            SegOpcionBL oSegOpcionBL = new SegOpcionBL();
            List<DTOSegOpcion> olistaSegOpcion = new List<DTOSegOpcion>();
            string opciones = "";

            listaUsuario = oUsuarioBL.obtenerUsuario().DTOListaUsuario.Where(u => u.usuario.ToUpper() == oUsuarioM.usuario.ToUpper() && u.password.ToUpper() == oUsuarioM.password.ToUpper() && u.activo == true).ToList();
            if (listaUsuario.Count > 0)
            {
                Session["USR_COD"] = oUsuarioM.usuario.ToUpper();
                Session["USR_NAME"] = "Bienvenido(a) " + listaUsuario[0].nombres;
                olistaSegOpcion = oSegOpcionBL.ObtenerSegOpcion(oUsuarioM.usuario.ToUpper());
                foreach (var item in olistaSegOpcion)
                {
                    if (item.status)
                    {
                        opciones = opciones + "[" + item.opcion_cod + "]";
                    }
                }

                Session["USR_OPCION"] = opciones;

                return RedirectToAction("Index","Home");


            }
            else
            {
                oUsuarioM.resultado = 1;
            }
            return View(oUsuarioM);
        }

        public ActionResult Recover()
        {
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            return View(oUsuarioM);
        }

        [HttpPost]
        public ActionResult Recover(DTOUsuarioM oUsuarioM)
        {
            EmailBL oEmailBL = new EmailBL();
            UsuarioBL oUsuarioBL = new UsuarioBL();
            DTOUsuario oUsuario = new DTOUsuario();

            oUsuario = oUsuarioBL.obtenerUsuario().DTOListaUsuario.FirstOrDefault(u => u.usuario.ToUpper() == oUsuarioM.usuario.ToUpper());

            if (oUsuario != null)
            {
                oEmailBL.SendMail("Estimado usuario(a), su contraseña es: " + oUsuario.password, "Recuperación de contraseña", oUsuario.correo, "");
                oUsuarioM.resultado = 1;
            }
            else
            {
                oUsuarioM.resultado = 2;
            }
            return View(oUsuarioM);
        }


        public ActionResult UpdatePassword()
        {
            DTOUsuarioM oUsuarioM = new DTOUsuarioM();
            return View(oUsuarioM);
        }

        [HttpPost]
        public ActionResult UpdatePassword(DTOUsuarioM oUsuarioM)
        {
            if (oUsuarioM.usuario == "" || oUsuarioM.password == "" || oUsuarioM.newpassword == "" || oUsuarioM.usuario == null || oUsuarioM.password == null || oUsuarioM.newpassword == null)
            {
                oUsuarioM.resultado = 3;
            }
            else
            {
                EmailBL oEmailBL = new EmailBL();
                UsuarioBL oUsuarioBL = new UsuarioBL();
                UsuarioBL oUsuario2BL = new UsuarioBL();
                DTOUsuario oUsuario = new DTOUsuario();

                oUsuario = oUsuarioBL.obtenerUsuario().DTOListaUsuario.FirstOrDefault(u => u.usuario.ToUpper() == oUsuarioM.usuario.ToUpper() && u.password == oUsuarioM.password);

                if (oUsuario != null)
                {
                    oUsuario.password = oUsuarioM.newpassword;
                    oUsuario2BL.actualizarUsuario(oUsuario);
                    oUsuarioM.resultado = 1;
                }
                else
                {
                    oUsuarioM.resultado = 2;
                }
            }
            
            return View(oUsuarioM);
        }


        public ActionResult Social()
        {
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }
    }
}