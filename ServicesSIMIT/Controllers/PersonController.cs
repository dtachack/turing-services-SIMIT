using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Models;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Controllers
{
    /// <summary>
    /// Person controller.
    /// </summary>
    public class PersonController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The person app service.
        /// </summary>
        private readonly IPersonAppService _personAppService;

        #endregion

        #region Builders

      //
        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService.NotNull(nameof(personAppService));
        }

        #endregion

        #region Methods

       
        #endregion
    }
}
