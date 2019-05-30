using System;
using ServicesSIMIT.Models;
using Utilities.Library.AppService;

namespace ServicesSIMIT.Application.Contracts
{
    /// <summary>
    /// Person app service.
    /// </summary>
    public interface IPersonAppService:IAppService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        Persona GetById(Guid Id);
    }
}
