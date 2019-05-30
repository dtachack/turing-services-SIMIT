using ServicesSIMIT.Domain.Entities;
using System;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Infringement domain service.
    /// </summary>
    public interface IInfringementDomainService:IDomainService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
       Infringement GetById(Guid Id);
    }
}
