using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Library.Const;
using Utilities.Library.DomainService;
using UtilitiesLibrary;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.Domain
{
    /// <summary>
    /// Vehicle domain service.
    /// </summary>
    public class VehicleDomainService : DomainService, IVehicleDomainService
    {
        #region Fields

        /// <summary>
        /// The vehicle repository.
        /// </summary>
        private readonly IRepository<Vehicle> _vehicleRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.VehicleDomainService"/> class.
        /// </summary>
        /// <param name="vehicleRepository">Vehicle repository.</param>
        public VehicleDomainService(IRepository<Vehicle> vehicleRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _vehicleRepository = vehicleRepository.NotNull(nameof(vehicleRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public Vehicle GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _vehicleRepository.List(x => x.Id == Id).ToList().FirstOrDefault();

        }

        /// <summary>
        /// Gets the by license plate.
        /// </summary>
        /// <returns>The by license plate.</returns>
        /// <param name="licensePlate">License plate.</param>
        public Vehicle GetByLicensePlate(string licensePlate)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _vehicleRepository.List(x => x.LicensePlate == licensePlate).ToList().FirstOrDefault();
        }

        /// <summary>
        /// Exists the specified licensePlate.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="licensePlate">License plate.</param>
        public bool Exists(string licensePlate)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _vehicleRepository.List(x => x.LicensePlate == licensePlate).Any();
        }

        #endregion
    }
}
