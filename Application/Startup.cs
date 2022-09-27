using Application.AccountDetails;
using Application.Document;
using Application.Email;
using Application.IdApplication;
using Core.AccountDetails.Application;
using Core.Document.Application;
using Core.Email.Application;
using Core.IdApplication.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static void AddApp(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IAccountDetailsServices, AccountDetailsServices>();
            services.AddSingleton<IDocumentServices, DocumentServices>();
            services.AddSingleton<IIdApplicationServices, IdApplicationServices>();
            services.AddSingleton<IEmailServices, EmailServices>();

            var email = config.GetSection("Email");
            SmtpSettings.Address = email.GetSection("Address").Value;
            SmtpSettings.Password = email.GetSection("Password").Value;
            SmtpSettings.Host = email.GetSection("Host").Value;
            SmtpSettings.Port = Convert.ToInt32(email.GetSection("Port").Value);
            SmtpSettings.SSL = Convert.ToBoolean(email.GetSection("SSL").Value);
        }
    }
}