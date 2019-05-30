using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Domain.Entities;
using System;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Vehicle domain service.
    /// </summary>
    public interface IVehicleDomainService : IDomainService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        Vehicle GetById(Guid Id);

        /// <summary>
        /// Gets the by license plate.
        /// </summary>
        /// <returns>The by license plate.</returns>
        /// <param name="licensePlate">License plate.</param>
        Vehicle GetByLicensePlate(string licensePlate);

        /// <summary>
        /// Exists the specified licensePlate.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="licensePlate">License plate.</param>
        bool Exists(string licensePlate);

    }
}
