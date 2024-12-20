﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server= new SmtpClient();
            server.Credentials = new System.Net.NetworkCredential("723a44bfb526a6", "7caa512a27f3a8");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email= new MailMessage();
            email.From = new MailAddress("noresponder@ecommerceceramicas.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml= true;            
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
