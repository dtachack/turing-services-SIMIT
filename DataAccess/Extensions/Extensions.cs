using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Utilities.Library.Const;
using Utilities.Library.DomainService;
using UtilitiesLibrary;
namespace Utilities.Library.Extensions
{
    /// <summary>
    /// Métodos extendidos
    /// </summary>
    public static class Extensions
    {
        #region DbContext

        /// <summary>
        /// Obtiene un repositorio
        /// </summary>
        /// <typeparam name="TRepository">Tipo del repositorio a obtener</typeparam>
        /// <param name="context">Contexto quien extiende el método</param>
        /// <returns>Repositorio</returns>
        public static TRepository GetRepository<TRepository>(this DbContext context) where TRepository : IRepository
        {
            if (Globals.ServiceProvider == null)
                return default(TRepository);

            TRepository rep = Globals.ServiceProvider.GetService<TRepository>();

            if (rep != null)
                rep.Initialize(context);

            return rep;
        }

        /// <summary>
        /// Obtiene un servicio de dominio
        /// </summary>
        /// <typeparam name="TDomainService">Tipo del servicio a obtener</typeparam>
        /// <param name="context">Contexto quien extiende el método</param>
        /// <returns>Servicio</returns>
        public static TDomainService GetDomainService<TDomainService>(this DbContext context) where TDomainService : IDomainService
        {
            if (Globals.ServiceProvider == null)
                return default(TDomainService);

            TDomainService rep = Globals.ServiceProvider.GetService<TDomainService>();

            rep.SetContext(context);

            return rep;
        }

        #endregion
    }
}
