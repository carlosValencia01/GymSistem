using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GymSis.Services
{
    public class EmailService
    {
        public static Boolean SendEmailPasswordRecovery1(string dest, string pass)
        {
            MailMessage e_mail = new MailMessage();
            e_mail = new MailMessage();
            e_mail.From = new MailAddress("notificaciones.gymsys@gmail.com");
            e_mail.To.Add(dest);
            e_mail.Subject = "Recuperacion de Contraseña";
            e_mail.IsBodyHtml = false;
            e_mail.Body = "Su nueva contraseña es " + pass + ". Favor de cambiarla";

            SmtpClient Smtp_Server = new SmtpClient();
            Smtp_Server.Host = "smtp.gmail.com";
            Smtp_Server.EnableSsl = true;
            Smtp_Server.UseDefaultCredentials = false;
            Smtp_Server.Credentials = new NetworkCredential("notificaciones.gymsys@gmail.com", "GYMsys23");
            ServicePointManager.ServerCertificateValidationCallback =
                (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;
            //podemos meter esto en un try
            try
            {
                Smtp_Server.Send(e_mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static Boolean SendEmailPasswordRecovery2(string dest, string pass)
        {
            string to = dest; //To address    
            string from = "notificaciones.gymsys@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Su nueva contraseña es " + pass + ". Favor de cambiarla";
            message.Subject = "Recuperacion de Contraseña";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            //System.Net.NetworkCredential basicCredential1 = new
            //System.Net.NetworkCredential("notificaciones.gymsys@gmail.com", "GYMsys23");
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.Credentials = basicCredential1;

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("notificaciones.gymsys@gmail.com", "GYMsys23");
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    throw ex;
                    return false;
                }
                return true;
            }
        }

        public static Boolean SendEmailPasswordRecovery(string dest, string pass)
        {
            MailAddress to = new MailAddress(dest);
            MailAddress from = new MailAddress("notificaciones.gymsys@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Good morning, Charles";
            message.Body = "Charles, Long time no talk. Would you be up for lunch in Soho on Monday? I'm paying.;";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("notificaciones.gymsys@gmail.com", "GYMsys23"),
                EnableSsl = true
                // specify whether your host accepts SSL connections
            };
            // code in brackets above needed if authentication required
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
