﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace BusinessLogic
{
    public class EmailBL
    {
        public Boolean SendMail(string mensaje, string asunto, string mailDestino, string url)
        {
            try
            {
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("minsur.adm@gmail.com", "Administrador", Encoding.UTF8);
                //Aquí ponemos el asunto del correo
                mail.Subject = asunto;
                //Aquí ponemos el mensaje que incluirá el correo
                mail.Body = mensaje;
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(mailDestino);
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                if (url != "")
                {
                    mail.Attachments.Add(new Attachment(url));
                }

                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("minsur.adm@gmail.com", "vhjjmeVH87");
                SmtpServer.EnableSsl = true;

                SmtpServer.Host = "smtp.gmail.com";

                Logger.Write("Envío de email");
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Write("Error Email: " + ex.Message);
                return false;
            }
        }
    }
}
