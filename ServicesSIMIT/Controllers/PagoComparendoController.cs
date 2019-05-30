using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Models;
using System;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Controllers
{
    ///// <summary>
    ///// Pago comparendo controller.
    ///// </summary>
    //[Route("api/[controller]")]
    //[ApiController]
    //public class PagoComparendoController : ControllerBase
    //{
    //    #region Fields

    //    /// <summary>
    //    /// The payment serv.
    //    /// </summary>
    //    private readonly IPaymentAppService _paymentServ;

    //    #endregion

    //    #region Builders

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Controllers.PagoComparendoController"/> class.
    //    /// </summary>
    //    /// <param name="paymentServ">Payment serv.</param>
    //    public PagoComparendoController(IPaymentAppService paymentServ)
    //    {
    //        _paymentServ = paymentServ.NotNull(nameof(paymentServ));
    //    }

    //    #endregion


    //    #region Methods

    //    /// <summary>
    //    /// Adds the pago comparendo.
    //    /// </summary>
    //    /// <returns>The pago comparendo.</returns>
    //    /// <param name="pagoComparendo">Pago comparendo.</param>
    //    [HttpPut]
    //    [ProducesResponseType(typeof(RespuestaPagoComparendo), StatusCodes.Status200OK)]
    //    [ProducesResponseType(StatusCodes.Status409Conflict)]
    //    public IActionResult AddPagoComparendo(PagoComparendo pagoComparendo)
    //    {

    //        try
    //        {
    //            //return Ok(_paymentServ.Save(pagoComparendo));
    //            return Ok();
    //        }
    //        catch (Exception e)
    //        {
    //            return Conflict(e.Message);
    //        }
    //    }

    //    #endregion
    //}
}