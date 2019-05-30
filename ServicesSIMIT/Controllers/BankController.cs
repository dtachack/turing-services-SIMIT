using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Models;
using System;
using System.Collections.Generic;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Controllers
{
    /// <summary>
    /// Bank controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        #region Fields

        /// <summary>
        /// The bank app service.
        /// </summary>
        private readonly IBankAppService _bankAppService;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Controllers.BankController"/> class.
        /// </summary>
        /// <param name="bankAppService">Bank app service.</param>
        public BankController(IBankAppService bankAppService)
        {
            _bankAppService = bankAppService.NotNull(nameof(bankAppService));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Banco>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_bankAppService.GetAll());
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Save the specified banco.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="banco">Banco.</param>
        [HttpPost]
        [ProducesResponseType(typeof(Banco), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Save(RegistroBanco banco)
        {

            try
            {
                return Ok(_bankAppService.Save(banco));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        #endregion
    }
}