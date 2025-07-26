using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;
        public void AgregarAdjunto(Attachment adjunto)
        {
            email.Attachments.Add(adjunto);
        }

        private readonly string myEmail = "devops.codetesting@gmail.com";
        private readonly string myPassword = "fngv fkzp wwyq canu";
        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential(myEmail, myPassword);
            server.EnableSsl = true;
            server.Port = 25;
            server.Host = "smtp.gmail.com";
        }
        public void ArmarEmail(string correoDestino, string asutno, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noreponder@tuentrada.com");
            email.To.Add(correoDestino);
            email.Subject = asutno;
            email.Body = cuerpo;
        }
        public void MensajeContacto(string nombre, string emailRemitente, string mensaje)
        { 
            email = new MailMessage();
            email.From = new MailAddress("noreponder@tuentrada.com");
            email.To.Add("devops.codetesting@gmail.com");
            email.Subject = "Nuevo mensaje de contacto";
            email.Body = $"Nombre: {nombre}\nEmail: {emailRemitente}\nMensaje:\n{mensaje}";
        }
        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
