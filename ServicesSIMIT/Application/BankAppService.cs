using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using ServicesSIMIT.Models;
using System;
using System.Collections.Generic;
using Utilities.Library.AppService;
using Utilities.Library.Const;
using Utilities.Library.Extensions;
using UtilitiesLibrary;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.Application
{
    /// <summary>
    /// Banck app service.
    /// </summary>
    public class BankAppService : AppService, IBankAppService
    {
        #region Repository´s
        /// <summary>
        /// The bank repository.
        /// </summary>
        private readonly IBankDomainService _bankDomainService;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region Builds

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Application.BanckAppService"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="mapper">Mapper.</param>
        public BankAppService(DbContext context, IMapper mapper) : base(context)
        {
            _bankDomainService = context.GetDomainService<IBankDomainService>().NotNull(nameof(_bankDomainService));
            _mapper = mapper;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public IEnumerable<Banco> GetAll()
        {
            var banks = _bankDomainService.GetAll();
            return _mapper.Map<IEnumerable<Bank>, IEnumerable<Banco>>(banks);
        }

        /// <summary>
        /// Save the specified banco.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="banco">Banco.</param>
        public Banco Save(RegistroBanco banco)
        {
            banco.Nombre = banco.Nombre.NotNullOrEmpty(nameof(banco.Nombre)).Trim();
            var bank = _bankDomainService.Save(_mapper.Map<RegistroBanco, Bank>(banco));
            return _mapper.Map<Bank, Banco>(bank);
        }

        #endregion
    }
}
