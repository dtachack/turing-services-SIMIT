using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Enums;
using ServicesSIMIT.Models;
using System;
using System.Collections.Generic;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Controllers
{
    /// <summary>
    /// Comparendo controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ComparendoController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// The subpoena serv.
        /// </summary>
        private readonly ISubpoenaAppService _subpoenaServ;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Controllers.ComparendoController"/> class.
        /// </summary>
        /// <param name="subpoenaServ">Subpoena serv.</param>
        public ComparendoController(ISubpoenaAppService subpoenaServ)
        {
            _subpoenaServ = subpoenaServ.NotNull(nameof(subpoenaServ));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the specified TipoDocumento, NoDocumento, NumeroPlaca and NumeroComparendo.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="TipoDocumento">Tipo documento.</param>
        /// <param name="NoDocumento">No documento.</param>
        /// <param name="NumeroPlaca">Numero placa.</param>
        /// <param name="NumeroComparendo">Numero comparendo.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RespuestaConsultaComparendo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Get(TipoDocumento? TipoDocumento, string NoDocumento, string NumeroPlaca, string NumeroComparendo)
        {

            try
            {
                return Ok(_subpoenaServ.Get(TipoDocumento, NoDocumento, NumeroPlaca, NumeroComparendo));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Update the specified comparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="comparendo">Comparendo.</param>
        [HttpPut]
        [ProducesResponseType(typeof(IEnumerable<RespuestaConsultaComparendo>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Update(RespuestaConsultaComparendo comparendo)
        {

            try
            {
                return Ok(_subpoenaServ.Update(comparendo));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
        #endregion

    }
}