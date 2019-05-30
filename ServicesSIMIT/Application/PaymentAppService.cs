using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Domain;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using ServicesSIMIT.Models;
using System;
using Utilities.Library.AppService;
using Utilities.Library.Exceptions;
using Utilities.Library.Extensions;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Application
{
    /// <summary>
    /// Payment app service.
    /// </summary>
    public class PaymentAppService : AppService, IPaymentAppService
    {
        #region Domain Services

        /// <summary>
        /// The payment domain service.
        /// </summary>
        private readonly IPaymentDomainService _paymentDomainService;

        /// <summary>
        /// The bank domain service.
        /// </summary>
        private readonly IBankDomainService _bankDomainService;

        /// <summary>
        /// The subpoena domain service.
        /// </summary>
        private readonly ISubpoenaDomainService _subpoenaDomainService;

        private readonly IPersonDomainService _personDomainService;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Builds

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Application.PaymentAppService"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="mapper">Mapper.</param>
        public PaymentAppService(DbContext context, IMapper mapper) : base(context)
        {
            _paymentDomainService = context.GetDomainService<IPaymentDomainService>().NotNull(nameof(_paymentDomainService));
            _bankDomainService = context.GetDomainService<IBankDomainService>().NotNull(nameof(_bankDomainService));
            _subpoenaDomainService = context.GetDomainService<ISubpoenaDomainService>().NotNull(nameof(_subpoenaDomainService));
            _personDomainService = context.GetDomainService<IPersonDomainService>().NotNull(nameof(_personDomainService));
            _mapper = mapper;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public PagoComparendo GetById(Guid Id)
        {
            var payment = _paymentDomainService.GetById(Id);
            if (payment==null)
                throw new ValidateNotNullExceptionMessage("El pago no se encuentra registrado.");

            var subpoena = _subpoenaDomainService.GetById(payment.IdSubpoena);
            if (subpoena == null)
                throw new ValidateNotNullExceptionMessage("Ocurrio un error al momento de consultar el comparendo.");

            var bank = _bankDomainService.GetById(payment.IdBank);
            if (bank == null)
                throw new ValidateNotNullExceptionMessage("Ocurrio un error al momento de consultar el banco.");

            var person = _personDomainService.GetById(payment.IdPerson);
            if (person == null)
                throw new ValidateNotNullExceptionMessage("Ocurrió un error al momento de consultar la persona");

            var result = new PagoComparendo();
            result = _mapper.Map<PaymentSubpoena, PagoComparendo>(payment);
            result.Banco = _mapper.Map<Bank, Banco>(bank);
            result.Numerocomparendo = subpoena.Number;
            result.Persona = _mapper.Map<Person, Persona>(person);
            result.IdPago = payment.Id.ToString();
            return result;


        }


        /// <summary>
        /// Save the specified pagoComparendo.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        //public RespuestaPagoComparendo Save(PagoComparendo pagoComparendo)
        //{
        //    pagoComparendo.Banco.NotNull(nameof(pagoComparendo.Banco));
        //    pagoComparendo.Banco.Id = pagoComparendo.Banco.Id.NotNullOrEmpty(nameof(pagoComparendo.Banco.Id)).Trim();
        //    Guid IdBank;
        //    if (!Guid.TryParse(pagoComparendo.Banco.Id, out IdBank))
        //        throw new ValidateNotNullExceptionMessage("El Id del banco no tiene el formateo correcto.");

        //    if (!_bankDomainService.Exists(IdBank))
        //        throw new ValidateNotNullExceptionMessage("El banco ingresado no se encuentra registrado.");

        //    if (!_subpoenaDomainService.Exists(pagoComparendo.Numerocomparendo.NotNullOrEmpty(nameof(pagoComparendo.Numerocomparendo))))
        //        throw new ValidateNotNullExceptionMessage("El comparendo no se encuentra registrado.");

        //    var _savePayment = _paymentDomainService.Save(_mapper.Map<PagoComparendo, PaymentSubpoena>(pagoComparendo));

        //    var respuestaPagoComparendo = new RespuestaPagoComparendo();

        //    respuestaPagoComparendo.Payment = _mapper.Map<PaymentSubpoena, PagoEntidad>(_savePayment);
        //    return respuestaPagoComparendo;
        //}

        public PagoComparendo Save(PagoComparendo pagoComparendo)
        {
            pagoComparendo.Banco.NotNull(nameof(pagoComparendo.Banco));
            pagoComparendo.Persona.NotNull(nameof(pagoComparendo.Persona));

            pagoComparendo.Banco.Id = pagoComparendo.Banco.Id.NotNullOrEmpty(nameof(pagoComparendo.Banco.Id)).Trim();

            Guid IdBank;
            if (!Guid.TryParse(pagoComparendo.Banco.Id, out IdBank))
                throw new ValidateNotNullExceptionMessage("El Id del banco no tiene el formato correcto.");

            var bank = _bankDomainService.GetById(IdBank);
            if (bank == null)
                throw new ValidateNotNullExceptionMessage("El banco ingresado no se encuentra registrado.");

            var subpoena = _subpoenaDomainService.GetByNumber(pagoComparendo.Numerocomparendo.NotNullOrEmpty(nameof(pagoComparendo.Numerocomparendo)));
            if (subpoena == null)
                throw new ValidateNotNullExceptionMessage("El comparendo no se encuentra registrado.");

            var payment = _paymentDomainService.GetBySubpoenaId(subpoena.Id);
            if (payment != null)
                throw new ValidateNotNullExceptionMessage("El comparendo ya tiene un pago registrado");

            var person = _personDomainService.Save(_mapper.Map<Persona, Person>(pagoComparendo.Persona));
            if (person == null)
                throw new ValidateNotNullExceptionMessage("Ocurrió un error al momento de guardar la persona");

            var paymentEntity = _mapper.Map<PagoComparendo, PaymentSubpoena>(pagoComparendo);
            paymentEntity.IdBank = IdBank;
            paymentEntity.IdPerson = person.Id;
            paymentEntity.IdSubpoena = subpoena.Id;

            var savePayment = _paymentDomainService.Save(paymentEntity);

            var result = new PagoComparendo();
            result = _mapper.Map<PaymentSubpoena, PagoComparendo>(savePayment);
            result.Banco = _mapper.Map<Bank, Banco>(bank);
            result.Numerocomparendo = subpoena.Number;
            result.Persona = _mapper.Map<Person, Persona>(person);
            result.IdPago = paymentEntity.Id.ToString();
            return result;
        }

        /// <summary>
        /// Update the specified pagoComparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="pagoComparendo">Pago comparendo.</param>
        public PagoComparendo Update(PagoComparendo pagoComparendo)
        {
            pagoComparendo.IdPago.NotNullOrEmpty(nameof(pagoComparendo.IdPago));
            pagoComparendo.Banco.NotNull(nameof(pagoComparendo.Banco));
            pagoComparendo.Persona.NotNull(nameof(pagoComparendo.Persona));

            pagoComparendo.Banco.Id = pagoComparendo.Banco.Id.NotNullOrEmpty(nameof(pagoComparendo.Banco.Id)).Trim();

            Guid IdPayment;
            if (!Guid.TryParse(pagoComparendo.IdPago, out IdPayment))
                throw new ValidateNotNullExceptionMessage("El Id del pago no tiene el formato correcto.");

            Guid IdBank;

            if (!Guid.TryParse(pagoComparendo.Banco.Id, out IdBank))
                throw new ValidateNotNullExceptionMessage("El Id del banco no tiene el formato correcto.");

            var bank = _bankDomainService.GetById(IdBank);
            if (bank == null)
                throw new ValidateNotNullExceptionMessage("El banco ingresado no se encuentra registrado.");

            if (!_bankDomainService.Exists(IdBank))
                throw new ValidateNotNullExceptionMessage("El banco ingresado no se encuentra registrado.");

            var subpoena = _subpoenaDomainService.GetByNumber(pagoComparendo.Numerocomparendo.NotNullOrEmpty(nameof(pagoComparendo.Numerocomparendo)));
            if (subpoena == null)
                throw new ValidateNotNullExceptionMessage("El comparendo no se encuentra registrado.");

            if (subpoena.Id != IdPayment)
                throw new ValidateNotNullExceptionMessage("El Id del pago y el numero del comparendo no conciden.");

            var person = _personDomainService.Save(_mapper.Map<Persona, Person>(pagoComparendo.Persona));
            if (person == null)
                throw new ValidateNotNullExceptionMessage("Ocurrió un error al momento de guardar la persona");


            var paymentEntity = _mapper.Map<PagoComparendo, PaymentSubpoena>(pagoComparendo);
            paymentEntity.IdBank = IdBank;
            paymentEntity.IdPerson = person.Id;
            paymentEntity.IdSubpoena = subpoena.Id;

            var savePayment = _paymentDomainService.Update(paymentEntity);

            var result = new PagoComparendo();
            result = _mapper.Map<PaymentSubpoena, PagoComparendo>(savePayment);
            result.Banco = _mapper.Map<Bank, Banco>(bank);
            result.Numerocomparendo = subpoena.Number;
            result.Persona = _mapper.Map<Person, Persona>(person);
            result.IdPago = paymentEntity.Id.ToString();
            return result;
        }

        #endregion
    }
}
