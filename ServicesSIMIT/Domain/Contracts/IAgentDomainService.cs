using ServicesSIMIT.Domain.Entities;
using System;
using System.Threading.Tasks;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Agent domain service.
    /// </summary>
    public interface IAgentDomainService : IDomainService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        Agent GetById(Guid Id);
    }
}
