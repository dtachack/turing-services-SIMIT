using System;
using System.Collections.Generic;
using System.Linq;
using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using Utilities.Library.Const;
using Utilities.Library.DomainService;
using UtilitiesLibrary;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.Domain
{
    /// <summary>
    /// Agent domain service.
    /// </summary>
    public class AgentDomainService : DomainService, IAgentDomainService
    {
        #region Fields

        /// <summary>
        /// The agent repository.
        /// </summary>
        private readonly IRepository<Agent> _agentRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.AgentDomainService"/> class.
        /// </summary>
        /// <param name="agentRepository">Agent repository.</param>
        public AgentDomainService(IRepository<Agent> agentRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _agentRepository = agentRepository.NotNull(nameof(agentRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public Agent GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _agentRepository.List(x => x.Id == Id).ToList().FirstOrDefault();
        }

        #endregion
    }
}
