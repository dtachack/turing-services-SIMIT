using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Models;
using Utilities.Library.AppService;
using Utilities.Library.Extensions;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Application
{
    public class PersonAppService:AppService,IPersonAppService
    {

        #region Repository´s

        /// <summary>
        /// The person domain service.
        /// </summary>
        private readonly IPersonDomainService _personDomainService;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;
        #endregion

        #region Builds

        public PersonAppService(DbContext context, IMapper mapper) : base(context)
        {
            _personDomainService = context.GetDomainService<IPersonDomainService>().NotNull(nameof(_personDomainService));
            _mapper = mapper;
        }

        public Persona GetById(Guid Id)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Methods
        #endregion


    }
}
