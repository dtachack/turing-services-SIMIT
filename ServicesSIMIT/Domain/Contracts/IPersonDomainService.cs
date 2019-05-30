using ServicesSIMIT.Domain.Entities;
using System;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Person domain service.
    /// </summary>
    public interface IPersonDomainService : IDomainService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        Person GetById(Guid Id);

        /// <summary>
        /// Gets the by document type by document number.
        /// </summary>
        /// <returns>The by document type by document number.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        Person GetByDocumentTypeByDocumentNumber(int documentType, string documentNumber);

        /// <summary>
        /// Exists the specified documentType and documentNumber.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        bool Exists(int documentType, string documentNumber);

        /// <summary>
        /// Save the specified person.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="person">Person.</param>
        Person Save(Person person);
    }
}
