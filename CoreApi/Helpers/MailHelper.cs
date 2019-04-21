using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;
using CoreApi.Models;

namespace CoreApi.Helpers
{
    public class MailHelper
    {
        public void SendMail(string toAddress, string Subject,string Message)
        {
            //UPDATE YOUR EMAIL ADDRESS HERE
            var from = "myemail@office365.com"; //From address   
            MailMessage message = new MailMessage(from,toAddress);
            message.Subject = Subject;
            message.Body = Message;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            var client = new SmtpClient("smtp.office365.com", 587);    
            
            //UPDATE EMAIL CREDENTIALS HERE
            var basicCredential1 = new NetworkCredential("myemail@office365.com", "EMAILPASSWORD");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }
}
