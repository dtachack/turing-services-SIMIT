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
    /// Infringement domain service.
    /// </summary>
    public class InfringementDomainService : DomainService, IInfringementDomainService
    {
        #region Fields

        /// <summary>
        /// The infringement repository.
        /// </summary>
        private readonly IRepository<Infringement> _infringementRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.InfringementDomainService"/> class.
        /// </summary>
        /// <param name="infringementRepository">Infringement repository.</param>
        public InfringementDomainService(IRepository<Infringement> infringementRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _infringementRepository = infringementRepository.NotNull(nameof(infringementRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public Infringement GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _infringementRepository.List(x => x.Id == Id).FirstOrDefault();
        }

        #endregion
    }
}
