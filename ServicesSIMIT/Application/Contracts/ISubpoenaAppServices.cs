using ServicesSIMIT.Enums;
using ServicesSIMIT.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Library.AppService;

namespace ServicesSIMIT.Application.Contracts
{
    /// <summary>
    /// Subpoena app service.
    /// </summary>
    public interface ISubpoenaAppService : IAppService
    {
        /// <summary>
        /// Get the specified documentType, documentNumber, licensePlate and subpoenaNumber.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        /// <param name="licensePlate">License plate.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        IEnumerable<RespuestaConsultaComparendo> Get(TipoDocumento? documentType, string documentNumber, string licensePlate, string subpoenaNumber);

        /// <summary>
        /// Update the specified comparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="comparendo">Comparendo.</param>
        RespuestaConsultaComparendo Update(RespuestaConsultaComparendo comparendo);
    }
}
