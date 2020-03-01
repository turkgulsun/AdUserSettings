using AdUserSettings.DataAccess.Concrete.EntityFramework;
using AdUserSettings.DataAccess.Infrastructure;
using AdUserSettings.EntityFrameworkCore;
using AdUserSettings.EntityFrameworkCore.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdUserSettings.WebUI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static void AddAdUserSettingsServices(this IServiceCollection services)
        {
            //var connectionStringBlog = "Server = sqlserver-2.database.windows.net; Initial Catalog = BlogContext; Persist Security Info = False; User ID = SqlServerUser; Password = P@ssword1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";

            var connectionStringBlog = "Server = localhost; Initial Catalog = AdUserSettignsContext;  MultipleActiveResultSets = False; Encrypt = True; Trusted_Connection=True; TrustServerCertificate = True; Connection Timeout = 30";


            //AutoMapper
            //services.AddAutoMapper(typeof(Startup));

            //services.AddScoped<IClassRepository, ClassRepository>();

            services.AddDbContext<AdUserSettingsContext>(options => options.UseSqlServer(connectionStringBlog));

            #region EFCore

            services.AddTransient<IEntityFrameworkCoreUnitOfWork, EntityFrameworkCoreUnitOfWork>();
            services.AddTransient(typeof(IEntityFrameworkCoreRepository<>), typeof(EntityFrameworkCoreRepository<>));
            services.AddTransient<IEntityFrameworkCoreContextFactory, DbContextFactory>();

            #endregion
        }
    }
}
