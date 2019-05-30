using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Application.Contracts;
using ServicesSIMIT.Domain;
using ServicesSIMIT.Domain.Contracts;
using ServicesSIMIT.Domain.Entities;
using ServicesSIMIT.Enums;
using ServicesSIMIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Library.AppService;
using Utilities.Library.Exceptions;
using Utilities.Library.Extensions;
using UtilitiesLibrary.Helper;

namespace ServicesSIMIT.Application
{
    /// <summary>
    /// Subpoena app service.
    /// </summary>
    public class SubpoenaAppService : AppService, ISubpoenaAppService
    {

        #region Domain Services

        /// <summary>
        /// The person domain service.
        /// </summary>
        private readonly IPersonDomainService _personDomainService;

        /// <summary>
        /// The vehicle domain service.
        /// </summary>
        private readonly IVehicleDomainService _vehicleDomainService;

        /// <summary>
        /// The subpoena domain service.
        /// </summary>
        private readonly ISubpoenaDomainService _subpoenaDomainService;

        /// <summary>
        /// The infringement domain service.
        /// </summary>
        private readonly IInfringementDomainService _infringementDomainService;

        /// <summary>
        /// The agent domain service.
        /// </summary>
        private readonly IAgentDomainService _agentDomainService;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Builds

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.Application.SubpoenaAppService"/> class.
        /// </summary>
        /// <param name="context">Context.</param>
        /// <param name="mapper">Mapper.</param>
        public SubpoenaAppService(DbContext context, IMapper mapper) : base(context)
        {
            _personDomainService = context.GetDomainService<IPersonDomainService>().NotNull(nameof(_personDomainService));
            _vehicleDomainService = context.GetDomainService<IVehicleDomainService>().NotNull(nameof(_vehicleDomainService));
            _subpoenaDomainService = context.GetDomainService<ISubpoenaDomainService>().NotNull(nameof(_subpoenaDomainService));
            _infringementDomainService = context.GetDomainService<IInfringementDomainService>().NotNull(nameof(_infringementDomainService));
            _agentDomainService = context.GetDomainService<IAgentDomainService>().NotNull(nameof(_agentDomainService));

            _mapper = mapper;
        }


        #endregion

        #region Methods

        /// <summary>
        /// Get the specified documentType, documentNumber, licensePlate and subpoenaNumber.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="documentType">Document type.</param>
        /// <param name="documentNumber">Document number.</param>
        /// <param name="licensePlate">License plate.</param>
        /// <param name="subpoenaNumber">Subpoena number.</param>
        public IEnumerable<RespuestaConsultaComparendo> Get(TipoDocumento? documentType, string documentNumber, string licensePlate, string subpoenaNumber)
        {

            var result = new List<RespuestaConsultaComparendo>();

            if (string.IsNullOrEmpty(licensePlate) && string.IsNullOrEmpty(subpoenaNumber) && documentType == null && string.IsNullOrEmpty(documentNumber))
            {
                throw new ValidateNotNullExceptionMessage("Debe ingresar algun campo.");
            }

            if (documentType == null && !string.IsNullOrEmpty(documentNumber))
            {
                throw new ValidateNotNullExceptionMessage("El tipo de documento es requerido.");
            }

            if (documentType != null && string.IsNullOrEmpty(documentNumber))
            {
                throw new ValidateNotNullExceptionMessage("El numero de documento es requerido.");
            }

            if (!string.IsNullOrEmpty(documentNumber) && documentType != null)
            {

                var person = _personDomainService.GetByDocumentTypeByDocumentNumber(Convert.ToInt32(documentType), documentNumber);
                if (person == null)
                    return result;

                var _subpoenas = _subpoenaDomainService.GetByPersonId(person.Id);
                if (_subpoenas == null)
                    return result;

                if (!string.IsNullOrEmpty(licensePlate))
                {
                    var vehicle = _vehicleDomainService.GetByLicensePlate(licensePlate);
                    if (vehicle == null)
                        return result;
                    _subpoenas = _subpoenas.ToList().Where(x => x.IdVehicle == vehicle.Id).ToList();
                }

                if (!string.IsNullOrEmpty(subpoenaNumber))
                {
                    _subpoenas = _subpoenas.ToList().Where(x => x.Number == subpoenaNumber).ToList();
                }

                return GetSubpoenasToMapperResult(_subpoenas);
            }

            if (!string.IsNullOrEmpty(licensePlate) && !string.IsNullOrEmpty(subpoenaNumber))
            {

                var vehicle = _vehicleDomainService.GetByLicensePlate(licensePlate);
                if (vehicle == null)
                    return result;

                var _subpoenas = _subpoenaDomainService.GetByVehicleIdBySubpoenaNumber(vehicle.Id, subpoenaNumber);
                if (_subpoenas == null)
                    return result;

                return GetSubpoenasToMapperResult(_subpoenas);
            }


            if (!string.IsNullOrEmpty(licensePlate))
            {
                var vehicle = _vehicleDomainService.GetByLicensePlate(licensePlate);
                if (vehicle == null)
                    return result;

                var _subpoenas = _subpoenaDomainService.GetByVehicleId(vehicle.Id);
                if (_subpoenas == null)
                    return result;

                return GetSubpoenasToMapperResult(_subpoenas);
            }

            if (!string.IsNullOrEmpty(subpoenaNumber))
            {
                var _subpoenas = _subpoenaDomainService.GetByNumberSubpoena(subpoenaNumber);
                if (_subpoenas == null)
                    return result;

                return GetSubpoenasToMapperResult(_subpoenas);
            }

            return result;

        }


        /// <summary>
        /// Update the specified comparendo.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="comparendo">Comparendo.</param>
        public RespuestaConsultaComparendo Update(RespuestaConsultaComparendo comparendo)
        {
            var result = new RespuestaConsultaComparendo();
            comparendo.Comparendo.NotNull(nameof(comparendo.Comparendo));
            comparendo.AgenteDetectorInfraccion.NotNull(nameof(comparendo.AgenteDetectorInfraccion));
            comparendo.AgenteRegistroComparendo.NotNull(nameof(comparendo.AgenteRegistroComparendo));
            comparendo.Infraccion.NotNull(nameof(comparendo.Infraccion));
            comparendo.Persona.NotNull(nameof(comparendo.Persona));
            comparendo.Vehiculo.NotNull(nameof(comparendo.Vehiculo));

            var _subpoenaUpdate = _subpoenaDomainService.Update(_mapper.Map<Comparendo, Subpoena>(comparendo.Comparendo));
            return GetSubpoenaToMapperResult(_subpoenaUpdate);
        }

        /// <summary>
        /// Gets the subpoenas to mapper result.
        /// </summary>
        /// <returns>The subpoenas to mapper result.</returns>
        /// <param name="subpoenas">Subpoenas.</param>
        private List<RespuestaConsultaComparendo> GetSubpoenasToMapperResult(IEnumerable<Subpoena> subpoenas)
        {
            var result = new List<RespuestaConsultaComparendo>();
            foreach (var subpoena in subpoenas)
            {
                result.Add(GetSubpoenaToMapperResult(subpoena));
            }
            return result;
        }

        /// <summary>
        /// Gets the subpoena to mapper result.
        /// </summary>
        /// <returns>The subpoena to mapper result.</returns>
        /// <param name="subpoena">Subpoena.</param>
        private RespuestaConsultaComparendo GetSubpoenaToMapperResult(Subpoena subpoena)
        {
            var person = _personDomainService.GetById(subpoena.IdPerson);
            person.NotNull(nameof(person));

            var vehicle = _vehicleDomainService.GetById(subpoena.IdVehicle);
            vehicle.NotNull(nameof(vehicle));

            var infringement = _infringementDomainService.GetById(subpoena.IdInfringement);
            infringement.NotNull();

            var agentDetector = _agentDomainService.GetById(subpoena.IdAgentDetector);
            agentDetector.NotNull();

            var agentRegister = _agentDomainService.GetById(subpoena.IdAgentRegister);
            agentDetector.NotNull();

            var respuestaConsultaComparendo = new RespuestaConsultaComparendo();
            respuestaConsultaComparendo.Persona = _mapper.Map<Person, Persona>(person);
            respuestaConsultaComparendo.Comparendo = _mapper.Map<Subpoena, Comparendo>(subpoena);
            respuestaConsultaComparendo.Infraccion = _mapper.Map<Subpoena, Infraccion>(subpoena);
            respuestaConsultaComparendo.Vehiculo = _mapper.Map<Vehicle, Vehiculo>(vehicle);
            respuestaConsultaComparendo.AgenteDetectorInfraccion = _mapper.Map<Agent, AgenteDetector>(agentDetector);
            respuestaConsultaComparendo.AgenteRegistroComparendo = _mapper.Map<Agent, AgenteRegistro>(agentRegister);

            var _infringement = _mapper.Map<Infringement, Infraccion>(infringement);
            respuestaConsultaComparendo.Infraccion.CodigoInfraccion = _infringement.CodigoInfraccion;
            respuestaConsultaComparendo.Infraccion.DescipcionInfraccion = _infringement.DescipcionInfraccion;

            return respuestaConsultaComparendo;
        }
        #endregion


    }
}
