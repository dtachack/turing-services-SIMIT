using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Bank domain service.
    /// </summary>
    public interface IBankDomainService : IDomainService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        IEnumerable<Bank> GetAll();

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        Bank GetById(Guid Id);

        /// <summary>
        /// Exists the specified Id.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="Id">Identifier.</param>
        bool Exists(Guid Id);

        /// <summary>
        /// Save the specified bank.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="bank">Bank.</param>
        Bank Save(Bank bank);


    }
}
