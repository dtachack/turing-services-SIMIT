using ServicesSIMIT.DataAccess;
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
    /// Subpoena domain service.
    /// </summary>
    public class SubpoenaDomainService : DomainService, ISubpoenaDomainService
    {
        #region Fields

        /// <summary>
        /// The subpoena repository.
        /// </summary>
        private readonly IRepository<Subpoena> _subpoenaRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.SubpoenaDomainService"/> class.
        /// </summary>
        /// <param name="subpoenaRepository">Subpoena repository.</param>
        public SubpoenaDomainService(IRepository<Subpoena> subpoenaRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _subpoenaRepository = subpoenaRepository.NotNull(nameof(subpoenaRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the by person identifier.
        /// </summary>
        /// <returns>The by person identifier.</returns>
        /// <param name="personId">Person identifier.</param>
        public IEnumerable<Subpoena> GetByPersonId(Guid personId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.IdPerson == personId).ToList();
        }

        /// <summary>
        /// Gets the by vehicle identifier.
        /// </summary>
        /// <returns>The by vehicle identifier.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        public IEnumerable<Subpoena> GetByVehicleId(Guid vehicleId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.IdVehicle == vehicleId).ToList();
        }

        /// <summary>
        /// Gets the by number.
        /// </summary>
        /// <returns>The by number.</returns>
        /// <param name="number">Number.</param>
        public Subpoena GetByNumber(string number)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.Number == number).FirstOrDefault();
        }

        /// <summary>
        /// Gets the by vehicle identifier by person identifier.
        /// </summary>
        /// <returns>The by vehicle identifier by person identifier.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        public IEnumerable<Subpoena> GetByVehicleIdByPersonId(Guid vehicleId, Guid personId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.IdVehicle == vehicleId && x.IdPerson == personId).ToList();
        }

        /// <summary>
        /// Gets the by vehicle identifier by person identifier by subpoena number.
        /// </summary>
        /// <returns>The by vehicle identifier by person identifier by subpoena number.</returns>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        public IEnumerable<Subpoena> GetByVehicleIdByPersonIdBySubpoenaNumber(Guid vehicleId, Guid personId, string subpoenaNumber)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.IdVehicle == vehicleId && x.IdPerson == personId && x.Number == subpoenaNumber).ToList();
        }

        /// <summary>
        /// Gets the by person identifier by subpoena number.
        /// </summary>
        /// <returns>The by person identifier by subpoena number.</returns>
        /// <param name="personId">Person identifier.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        public IEnumerable<Subpoena> GetByPersonIdBySubpoenaNumber(Guid personId, string subpoenaNumber)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.IdPerson == personId && x.Number == subpoenaNumber).ToList();
        }

        /// <summary>
        /// Update the specified subpoena.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="subpoena">Subpoena.</param>
        public Subpoena Update(Subpoena subpoena)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Write));

            var _subpoena = _subpoenaRepository.List(x => x.Number == subpoena.Number).FirstOrDefault();

            _subpoena.State = subpoena.State;

            _subpoenaRepository.Update(_subpoena);
            _subpoenaRepository.Context.SaveChanges();
            return _subpoena;
        }

        /// <summary>
        /// Exists the specified number.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="number">Number.</param>
        public bool Exists(string number)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.Number == number).Any();
        }

        public IEnumerable<Subpoena> GetByNumberSubpoena(string number)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.Number == number).ToList();
        }

        public IEnumerable<Subpoena> GetByVehicleIdBySubpoenaNumber(Guid vehicleId, string subpoenaNumber)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.Number == subpoenaNumber && x.IdVehicle == vehicleId).ToList();
        }

        public Subpoena GetById(Guid subpoenaId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _subpoenaRepository.List(x => x.Id == subpoenaId).FirstOrDefault();
        }


        #endregion
    }
}
