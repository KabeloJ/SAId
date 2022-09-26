using Access.Access;
using Core.AccountDetails.Access;
using Core.Document.Access;
using Core.IdApplication.Access;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Access
{
    public static class Startup
    {
        public static string? ConnectionString { get; internal set; }
        public static void AddDAL(this IServiceCollection services, IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
            services.AddSingleton<IAccountDetailAccess, AccountDetailAccess>();
            services.AddSingleton<IDocumentAccess, DocumentAccess>();
            services.AddSingleton<IIdApplicationAccess, IdApplicationAccess>();
            services.AddAutoMapper(typeof(MapProfile));
        }
    }
}