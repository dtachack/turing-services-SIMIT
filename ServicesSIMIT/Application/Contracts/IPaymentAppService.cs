using System;
using ServicesSIMIT.Models;
using Utilities.Library.AppService;

namespace ServicesSIMIT.Application.Contracts
{
    /// <summary>
    /// Payment app service.
    /// </summary>
    public interface IPaymentAppService : IAppService
    {
        /// <summary>
        /// Save the specified pagoComparendo.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        //RespuestaPagoComparendo Save(PagoComparendo pagoComparendo);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        PagoComparendo GetById(Guid Id);

        /// <summary>
        /// Save the specified pagoComparendo.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        PagoComparendo Save(PagoComparendo pagoComparendo);

        /// <summary>
        /// Update the specified pagoComparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        PagoComparendo Update(PagoComparendo pagoComparendo);


    }
}
