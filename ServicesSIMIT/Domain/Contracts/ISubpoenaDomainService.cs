using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain
{
    /// <summary>
    /// Subpoena domain service.
    /// </summary>
    public interface ISubpoenaDomainService : IDomainService
    {
        /// <summary>
        /// Gets the by person identifier.
        /// </summary>
        /// <returns>The by person identifier.</returns>
        /// <param name="personId">Person identifier.</param>
        IEnumerable<Subpoena> GetByPersonId(Guid personId);

        Subpoena GetById(Guid subpoenaId);

        IEnumerable<Subpoena> GetByNumberSubpoena(string number);

        /// <summary>
        /// Gets the by vehicle identifier.
        /// </summary>
        /// <returns>The by vehicle identifier.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        IEnumerable<Subpoena> GetByVehicleId(Guid vehicleId);

        /// <summary>
        /// Gets the by vehicle identifier by person identifier.
        /// </summary>
        /// <returns>The by vehicle identifier by person identifier.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        IEnumerable<Subpoena> GetByVehicleIdByPersonId(Guid vehicleId, Guid personId);

        /// <summary>
        /// Gets the by person identifier by subpoena number.
        /// </summary>
        /// <returns>The by person identifier by subpoena number.</returns>
        /// <param name="personId">Person identifier.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        IEnumerable<Subpoena> GetByPersonIdBySubpoenaNumber(Guid personId, string subpoenaNumber);

        /// <summary>
        /// Gets the by vehicle identifier by person identifier by subpoena number.
        /// </summary>
        /// <returns>The by vehicle identifier by person identifier by subpoena number.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        IEnumerable<Subpoena> GetByVehicleIdByPersonIdBySubpoenaNumber(Guid vehicleId, Guid personId, string subpoenaNumber);

        IEnumerable<Subpoena> GetByVehicleIdBySubpoenaNumber(Guid vehicleId, string subpoenaNumber);

        /// <summary>
        /// Gets the by number.
        /// </summary>
        /// <returns>The by number.</returns>
        /// <param name="number">Number.</param>
        Subpoena GetByNumber(string number);

        /// <summary>
        /// Update the specified subpoena.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="subpoena">Subpoena.</param>
        Subpoena Update(Subpoena subpoena);

        /// <summary>
        /// Exists the specified number.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="number">Number.</param>
        bool Exists(string number);
    }
}
