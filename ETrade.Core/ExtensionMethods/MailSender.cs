using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Core.ExtensionMethods
{
    public class MailSender
    {
    
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string smtpUsername;
        private readonly string smtpPassword;
        private readonly string smtpDisplayName;
        private readonly bool smtpEnableSsl;

        public MailSender()
        {
            this.smtpServer = "";
            this.smtpPort = 587;
            this.smtpUsername = "ETrade";
            this.smtpPassword = "";
            this.smtpDisplayName = "";
            this.smtpEnableSsl = true;
        }

        public bool SendEmail( string to, string subject, string body, bool isHtml = false)
        {
            try
            {
                
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@ETrade.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml,
                };

                mailMessage.To.Add(to);

                SmtpClient smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpDisplayName, smtpPassword),
                    EnableSsl = smtpEnableSsl,
                };

                
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderirken bir hata oluştu: " + ex.Message);
                return false;
            }
        }
    }

}

