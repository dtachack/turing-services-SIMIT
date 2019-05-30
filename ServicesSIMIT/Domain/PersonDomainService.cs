using ServicesSIMIT.DataAccess;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Library.Const;
using Utilities.Library.DomainService;
using UtilitiesLibrary;
using UtilitiesLibrary.Helper;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.Domain
{
    /// <summary>
    /// Person domain service.
    /// </summary>
    public class PersonDomainService : DomainService, IPersonDomainService
    {
        #region Fields

        /// <summary>
        /// The person repository.
        /// </summary>
        private readonly IRepository<Person> _personRepository;

        #endregion

        #region Builders

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Domain.PersonDomainService"/> class.
        /// </summary>
        /// <param name="personRepository">Person repository.</param>
        public PersonDomainService(IRepository<Person> personRepository) : base()
        {
            DbSettings = (List<DbSettings>)Globals.ServiceProvider.GetService(typeof(List<DbSettings>)).NotNull();
            _personRepository = personRepository.NotNull(nameof(personRepository));
        }



        #endregion

        #region Methods

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <returns>The by identifier.</returns>
        /// <param name="Id">Identifier.</param>
        public Person GetById(Guid Id)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _personRepository.List(person => person.Id == Id).FirstOrDefault();
        }

        /// <summary>
        /// Gets the by document type by document number.
        /// </summary>
        /// <returns>The by document type by document number.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        public Person GetByDocumentTypeByDocumentNumber(int documentType, string documentNumber)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _personRepository.List(person => person.DocumentNumber == documentNumber && person.DocumentType == documentType).FirstOrDefault();
        }

        /// <summary>
        /// Exists the specified documentType and documentNumber.
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        public bool Exists(int documentType, string documentNumber)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));
            return _personRepository.List(person => person.DocumentNumber == documentNumber && person.DocumentType == documentType).Any();
        }

        /// <summary>
        /// Save the specified person.
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="person">Person.</param>
        public Person Save(Person person)
        {
            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Read));

            var _person = _personRepository.List(x => x.DocumentNumber == person.DocumentNumber).FirstOrDefault();

            if (_person != null)
                return _person;

            SetContext(SetContextDataBase.SetContext(DbSettings, SupportedAction.Write));

            person.Id = Guid.NewGuid();
            _personRepository.Insert(person);
            _personRepository.Context.SaveChanges();
            return person;
        }
        #endregion
    }
}
