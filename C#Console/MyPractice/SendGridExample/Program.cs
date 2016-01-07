using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendGridExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SendAsync();
        }
        public static async Task SendAsync()
        {
            try
            {

                #region formatter
                string text = string.Format("Please click on this link to {0}: {1}", "test", "testBody");
                string html = "Please confirm your account by clicking this link: <a href=\"" + "testBody" + "\">link</a><br/>";

                #endregion


                string emailFrom = "admin@contactbookweb.azurewebsite.com";
                //string userName = "contactbook";
                //string password = "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";
                string userName = "arif.bannehasan";
                string password = "@ndheri788";

                var mailFrom = new MailAddress(emailFrom);
                //var mailTo = new MailAddress();

                var sendGridMessage = new SendGridMessage();
                sendGridMessage.Subject = "testSubject";
                sendGridMessage.AddTo("arif788@gmail.com");
                sendGridMessage.From = mailFrom;
                sendGridMessage.Text = text;
                sendGridMessage.Html = html;

                SmtpClient smtpClient = new SmtpClient();

                NetworkCredential networkCredential = new NetworkCredential(userName, password);
                var webTransport = new SendGrid.Web(networkCredential);
                Task t = webTransport.DeliverAsync(sendGridMessage);
                t.Wait();
            }
            catch (AggregateException ex)
            {

                ex.Handle(hex =>
                {
                    Console.WriteLine("SendAynsc (AggregateException): " + hex.Message);
                    return true;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static void SendSmtp()
        {
            //var smtpClient = new SmtpClient("smtp.sendgrid.net", 587);
            //smtpClient.Timeout = 60000;
            //smtpClient.UseDefaultCredentials = false;
            //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtpClient.Credentials = new NetworkCredential(userName, password);

            //MailMessage mail = new MailMessage();
            //mail.To.Add(new MailAddress("arif788@gmail.com"));
            //mail.From = new MailAddress("arif.bannehasan@gmail.com");
            //mail.Subject = "this is a test email.";
            //mail.Body = "this is my test email body";
            //smtpClient.Send(mail);

        }

    }
}
