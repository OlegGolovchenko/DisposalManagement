using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace DisposalManagement.MailSender
{
    public class Sender
    {
        private string host = "smtp.gmail.com";
        private int port = 465;
        private bool enableSsl = true;
        private SmtpClient client;
        private string login;

        public Sender()
        {
            this.login = "eliasje3@gmail.com";
            client = new SmtpClient();
            client.Host = this.host;
            client.Port = this.port;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(this.login, "papaniki");
            client.Timeout = 100000;
            client.EnableSsl = this.enableSsl;
        }

        public void send(string address, string subject, string body)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(login);
            msg.To.Add(new MailAddress(address));
            msg.Subject = subject;
            msg.Body = body;
            this.client.Send(msg);
        }

        ~Sender()
        {
            this.client.Dispose();
        }
    }
}