using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Library.Const;
using Utilities.Library.DomainService;
using Utilities.Library.Exceptions;
using UtilitiesLibrary;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.Domain
{
    /// <summary>
    /// Payment domain service.
    /// </summary>
    public class PaymentDomainService : DomainService, IPaymentDomainService
    {
        #region Fields

        /// <summary>
        /// The payment repository.
        /// </summary>
        private readonly IRepository<PaymentSubpoena> _paymentRepository;

        /// <summary>
        /// The subpoena repository.
        /// </summary>
        private readonly IRepository<Subpoena> _subpoenaRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.PaymentDomainService"/> class.
        /// </summary>
        /// <param name="paymentRepository">Payment repository.</param>
        /// <param name="subpoenaRepository">Subpoena repository.</param>
        public PaymentDomainService(IRepository<PaymentSubpoena> paymentRepository, IRepository<Subpoena> subpoenaRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _paymentRepository = paymentRepository.NotNull(nameof(paymentRepository));
            _subpoenaRepository = subpoenaRepository.NotNull(nameof(subpoenaRepository));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exists the specified Id.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="Id">Identifier.</param>
        public bool Exists(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _paymentRepository.List(x => x.Id == Id).Any();
        }

        /// <summary>
        /// Existses the by subpoena identifier.
        /// </summary>
        /// <returns><c>true</c>, if by subpoena identifier was existsed, <c>false</c> otherwise.</returns>
        /// <param name="subpoenaId">Subpoena identifier.</param>
        public bool ExistsBySubpoenaId(Guid subpoenaId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _paymentRepository.List(x => x.IdSubpoena == subpoenaId).Any();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public PaymentSubpoena GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _paymentRepository.List(x => x.Id == Id).FirstOrDefault();
        }

        public PaymentSubpoena GetBySubpoenaId(Guid SubpoenaId)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _paymentRepository.List(x => x.IdSubpoena == SubpoenaId).FirstOrDefault();
        }

        /// <summary>
        /// Save the specified paymentSubpoena.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="paymentSubpoena">Payment subpoena.</param>
        public PaymentSubpoena Save(PaymentSubpoena paymentSubpoena)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Write));
            _paymentRepository.Insert(paymentSubpoena);
            _paymentRepository.Context.SaveChanges();
            return paymentSubpoena;
        }

        /// <summary>
        /// Update the specified paymentSubpoena.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="paymentSubpoena">Payment subpoena.</param>
        public PaymentSubpoena Update(PaymentSubpoena paymentSubpoena)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));

            var _payment = _paymentRepository.List(x => x.Id == paymentSubpoena.Id).FirstOrDefault();

            if (_payment == null)
                throw new ValidateNotNullExceptionMessage("La entidad consulta no existe.");

            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Write));

            _payment.Cus = paymentSubpoena.Cus;
            _payment.DatePayment = paymentSubpoena.DatePayment;
            _payment.Description = paymentSubpoena.Description;
            _payment.State = paymentSubpoena.State;
            _payment.Value = paymentSubpoena.Value;
            _payment.IdBank = paymentSubpoena.IdBank;
            _payment.IdPerson = paymentSubpoena.IdPerson;
            _paymentRepository.Update(_payment);

            _paymentRepository.Context.SaveChanges();

            return _payment;
        }

        #endregion
    }
}
