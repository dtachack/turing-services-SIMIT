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
    /// Payment controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        #region Fields

        private readonly IPaymentAppService _paymentAppService;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Controllers.PaymentController"/> class.
        /// </summary>
        /// <param name="paymentAppService">Payment app service.</param>
        public PaymentController(IPaymentAppService paymentAppService)
        {
            _paymentAppService = paymentAppService.NotNull(nameof(paymentAppService));
        }

        #endregion

        #region Methods

       
        [HttpGet]
        [ProducesResponseType(typeof(PagoComparendo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Route("GetById")]
        public IActionResult GetById(Guid Id)
        {

            try
            {
                return Ok(_paymentAppService.GetById(Id));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        /// <summary>
        /// Save the specified pagoComparendo.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        [HttpPost]
        [ProducesResponseType(typeof(PagoComparendo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Route("Save")]
        public IActionResult Save(PagoComparendo pagoComparendo)
        {

            try
            {
                return Ok(_paymentAppService.Save(pagoComparendo));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }


        /// <summary>
        /// Update the specified pagoComparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        [HttpPut]
        [ProducesResponseType(typeof(PagoComparendo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Route("Update")]
        public IActionResult Update(PagoComparendo pagoComparendo)
        {

            try
            {
                return Ok(_paymentAppService.Update(pagoComparendo));
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }


        #endregion
    }
}