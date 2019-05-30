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
    /// Bank domain service.
    /// </summary>
    public class BankDomainService : DomainService, IBankDomainService
    {
        #region Fields

        /// <summary>
        /// The bank repository.
        /// </summary>
        private readonly IRepository<Bank> _bankRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.BankDomainService"/> class.
        /// </summary>
        /// <param name="bankRepository">Bank repository.</param>
        public BankDomainService(IRepository<Bank> bankRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _bankRepository = bankRepository.NotNull(nameof(bankRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exists the specified Id.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="Id">Identifier.</param>
        public bool Exists(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _bankRepository.List(x => x.Id == Id).Any();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public IEnumerable<Bank> GetAll()
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _bankRepository.List();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public Bank GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _bankRepository.List(x=>x.Id==Id).FirstOrDefault();
        }

        /// <summary>
        /// Save the specified bank.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="bank">Bank.</param>
        public Bank Save(Bank bank)
        {
            SetContext((SetContextDataBase.SetContext(DbSettings, SupportedAction.Write)));
            bank.Id = Guid.NewGuid();
            _bankRepository.Insert(bank);
            _bankRepository.Context.SaveChanges();
            return bank;
        }

        #endregion
    }
}
