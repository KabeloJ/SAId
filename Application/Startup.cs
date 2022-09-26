using Application.AccountDetails;
using Application.Document;
using Application.IdApplication;
using Core.AccountDetails.Application;
using Core.Document.Application;
using Core.IdApplication.Application;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Startup
    {
        public static void AddApp(this IServiceCollection services)
        {
            services.AddSingleton<IAccountDetailsServices, AccountDetailsServices>();
            services.AddSingleton<IDocumentServices, DocumentServices>();
            services.AddSingleton<IIdApplicationServices, IdApplicationServices>();
        }
    }
}