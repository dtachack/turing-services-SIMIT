using ServicesSIMIT.Models;
using System.Collections.Generic;
using Utilities.Library.AppService;

namespace ServicesSIMIT.Application.Contracts
{
    /// <summary>
    /// Bank app service.
    /// </summary>
    public interface IBankAppService : IAppService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        IEnumerable<Banco> GetAll();

        /// <summary>
        /// Save the specified banco.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="banco">Banco.</param>
        Banco Save(RegistroBanco banco);
    }
}
