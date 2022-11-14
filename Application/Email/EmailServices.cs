using Core.Email.Application;
using Core.AccountDetails.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Core.AccountDetails.Models;
using System.Diagnostics.SymbolStore;

namespace Application.Email
{
    public class EmailServices: IEmailServices
    {
        private readonly IAccountDetailsServices _accountDetailsServices;
        public EmailServices(IAccountDetailsServices accountDetailsServices)
        {
            _accountDetailsServices = accountDetailsServices;
        }
        public async Task ForgotPassword(string to, string subject, string body)
        {
            string message = System.IO.File.ReadAllText("wwwroot\\EmailTemplate.txt");

            message = message.Replace("{message}", body);
            message = message.Replace("{targetUser}", to);
            await SendAsync(to, subject, message);

        }
        public async Task SendEmail(AccountDetailsModel model)
        {
            if (model != null)
            {
                string EmailAddress= "";
                string body = "";
                string subject = "";
                string message = "";
                var user = _accountDetailsServices.Get(model.AppliedBy);
                if (user != null)
                {
                    EmailAddress = user.EmailAddress;
                }
                body = System.IO.File.ReadAllText("wwwroot\\EmailTemplate.txt");

                if (model.ApplicationStatus == "Declined")
                {
                    subject = "Smart Id got declined";
                    message = $"You application for a smart Id with " +
                             $"<strong>Id Number :</strong> {user?.IdNumber} was declined on {DateTime.Now}" +
                             $"<br><br>" +
                             $"<strong>Reason For Declining:</strong><br>" +
                             $"{model?.DeclineMessage}"+
                            "<br><br> Thank you so much for using our online System." +
                            "<br><br>";
                }
                if (model.ApplicationStatus == "Approved")
                {
                    subject = "Smart Id Application Approved";
                    string tbody = "";
                    if (user?.IsPostalAddressSameAsPhysical == false)
                    {
                        tbody =
                        $"<tr>" +
                        $"<th align='left'>Street Name:</th>" +
                        $"<td align='right'>{user?.PostalStreetNumber}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>Suburb:</th>" +
                        $"<td align='right'>{user?.PostalSuburb}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>City:</th>" +
                        $"<td align='right'>{user?.PostalCity}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>Postal Code:</th>" +
                        $"<td align='right'>{user?.PostalPostalCode}</td>" +
                        $"</tr>";
                    }
                    else
                    {
                        tbody =
                        $"<tr>" +
                        $"<th align='left'>Street Name:</th>" +
                        $"<td align='right'>{user?.PhysicalStreetNumber} {user?.PhysicalStreetName}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>Suburb:</th>" +
                        $"<td align='right'>{user?.PhysicalSuburb}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>City:</th>" +
                        $"<td align='right'>{user?.PhysicalCity}</td>" +
                        $"</tr><tr>" +
                        $"<th align='left'>Postal Code:</th>" +
                        $"<td align='right'>{user?.PhysicalPostalCode}</td>" +
                        $"</tr><tr>" +
                        $"</tr>";

                    }
                    message = $"You application for a smart Id with with " +
                        $"<strong>Id Number :</strong> {user?.IdNumber} was approved on {DateTime.Now}" +
                        $"<br><br>" +
                        $"The Smart Id Card will be shipped to the address below within the next 5 days."+
                        $"<table>" +tbody+"</table>" +
                        "<br><br> Thank you so much for using our online System." +
                        "<br><br>";
                    
                }
                if (body != null)
                {
                    string targetUser = $"{user?.FirstNames}";
                    body = body.Replace("{message}", message);
                    body = body.Replace("{targetUser}", targetUser);
                }

                await SendAsync(EmailAddress, subject, body);
            }
        }

        async Task SendAsync(string to, string subject, string body)
        {
            using (SmtpClient client = LoadSmtp())
            {
                using (MailMessage message = new MailMessage())
                {
                    message.To.Add(to);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(SmtpSettings.Address);
                    await client.SendMailAsync(message);
                }
            }
        }

        SmtpClient LoadSmtp()
        {
            SmtpClient client = new SmtpClient()
            {
                Credentials = new NetworkCredential() { UserName = SmtpSettings.Address, Password = SmtpSettings.Password },
                Host = SmtpSettings.Host,
                Port = SmtpSettings.Port,
                EnableSsl = SmtpSettings.SSL
            };
            return client;
        }
    }
}
