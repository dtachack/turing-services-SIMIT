using Microsoft.Extensions.DependencyInjection;
using ServicesSIMIT.Application;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using System.Collections.Generic;
using UtilitiesLibrary;
using UtilitiesLibrary.Models;
using UtilitiesLibrary.Repository;

namespace ServicesSIMIT.DI
{
    /// <summary>
    /// Provee la carga de los perfiles de inyección de dependencias
    /// de toda la solución
    /// </summary>
    public static class DependencyInjectionProfile
    {
        #region Profiles

        /// <summary>
        /// Registra el perfil de producción
        /// </summary>
        /// <param name="services">Colección de servicios</param>
        public static void RegisterProfile(IServiceCollection services)
        {
            #region Context

            services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, SimitContext>(s =>
            {
                List<DbSettings> settings = s.GetService<List<DbSettings>>();
                return new SimitContext(settings[1]);
            });

            services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, SimitContext>(s =>
            {
                List<DbSettings> settings = s.GetService<List<DbSettings>>();
                return new SimitContext(settings[0]);
            });


            #endregion

            #region Repositories

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IRepository<Agent>), typeof(Repository<Agent>));
            services.AddTransient(typeof(IRepository<Bank>), typeof(Repository<Bank>));
            services.AddTransient(typeof(IRepository<Infringement>), typeof(Repository<Infringement>));
            services.AddTransient(typeof(IRepository<PaymentSubpoena>), typeof(Repository<PaymentSubpoena>));
            services.AddTransient(typeof(IRepository<Person>), typeof(Repository<Person>));
            services.AddTransient(typeof(IRepository<Subpoena>), typeof(Repository<Subpoena>));
            services.AddTransient(typeof(IRepository<Vehicle>), typeof(Repository<Vehicle>));

            #endregion

            #region Application

            services.AddTransient<IBankAppService, BankAppService>();
            services.AddTransient<ISubpoenaAppService, SubpoenaAppService>();
            services.AddTransient<IPaymentAppService, PaymentAppService>();

            #endregion

            #region Domain

            services.AddTransient<IAgentDomainService, AgentDomainService>();
            services.AddTransient<IBankDomainService,BankDomainService>();
            services.AddTransient<IInfringementDomainService, InfringementDomainService>();
            services.AddTransient<IPaymentDomainService, PaymentDomainService>();
            services.AddTransient<IPersonDomainService, PersonDomainService>();
            services.AddTransient<ISubpoenaDomainService, SubpoenaDomainService>();
            services.AddTransient<IVehicleDomainService, VehicleDomainService>();

            #endregion
        }

        #endregion
    }
}
