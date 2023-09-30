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
            this.smtpServer = "smtp-relay.brevo.com";
            this.smtpPort = 587;
            this.smtpUsername = "ETrade";
            this.smtpPassword = "xsmtpsib-9397117a52181487065e900e5e083dfdc1291cd2e2438728bd0cb898ec14532d-xhISbR2ZN6P45nrD";
            this.smtpDisplayName = "halilcinar1260@outlook.com";
            this.smtpEnableSsl = true;
        }

        public bool SendEmail( string to, string subject, string body, bool isHtml = false)
        {
            try
            {
                
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("mustafac798@outlook.com"),
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

