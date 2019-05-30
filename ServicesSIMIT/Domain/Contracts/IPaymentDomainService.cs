using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Library.DomainService;

namespace ServicesSIMIT.Domain.Contracts
{
    /// <summary>
    /// Payment domain service.
    /// </summary>
    public interface IPaymentDomainService : IDomainService
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        PaymentSubpoena GetById(Guid Id);

        PaymentSubpoena GetBySubpoenaId(Guid SubpoenaId);

        /// <summary>
        /// Save the specified paymentSubpoena.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="paymentSubpoena">Payment subpoena.</param>
        PaymentSubpoena Save(PaymentSubpoena paymentSubpoena);

        /// <summary>
        /// Update the specified paymentSubpoena.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="paymentSubpoena">Payment subpoena.</param>
        PaymentSubpoena Update(PaymentSubpoena paymentSubpoena);

        /// <summary>
        /// Existses the by subpoena identifier.
        /// </summary>
        /// <returns><c>true</c>, if by subpoena identifier was existsed, <c>false</c> otherwise.</returns>
        /// <param name="subpoenaId">Subpoena identifier.</param>
        bool ExistsBySubpoenaId(Guid subpoenaId);
    }
}
