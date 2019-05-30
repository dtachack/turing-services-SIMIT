using AutoMapper;
using ServicesSIMIT.Domain.Entities;
using ServicesSIMIT.Models;

namespace ServicesSIMIT.Automapper
{
    /// <summary>
    /// Realiza la carga del perfil usado para los adaptadore
    /// de entidades a DTOs
    /// </summary>
    public sealed class GlobalMapperProfile : Profile
    {
        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public GlobalMapperProfile() : base()
        {
            //Realizamos el mapeo de las entidades
            CreateMap<Bank, Banco>()
            .ForMember(b => b.Id, dto => dto.MapFrom(src => src.Id))
            .ForMember(b => b.Nombre, dto => dto.MapFrom(src => src.Name));

            CreateMap<RegistroBanco, Bank>()
           .ForMember(b => b.Name, dto => dto.MapFrom(src => src.Nombre));


            CreateMap<Infringement, Infraccion>()
            .ForMember(b => b.CodigoInfraccion, dto => dto.MapFrom(src => src.Code))
            .ForMember(b => b.DescipcionInfraccion, dto => dto.MapFrom(src => src.Description));

            CreateMap<Person, Persona>()
            .ForMember(b => b.Email, dto => dto.MapFrom(src => src.Email))
            .ForMember(b => b.NombreyApellidos, dto => dto.MapFrom(src => src.Name))
            .ForMember(b => b.NumeroDocumento, dto => dto.MapFrom(src => src.DocumentNumber))
            .ForMember(b => b.TipoDocumento, dto => dto.MapFrom(src => src.DocumentType))
            .ForMember(b => b.TipoPersona, dto => dto.MapFrom(src => src.PersonType));

            CreateMap<Persona, Person>()
           .ForMember(b => b.Email, dto => dto.MapFrom(src => src.Email))
           .ForMember(b => b.Name, dto => dto.MapFrom(src => src.NombreyApellidos))
           .ForMember(b => b.DocumentNumber, dto => dto.MapFrom(src => src.NumeroDocumento))
           .ForMember(b => b.DocumentType, dto => dto.MapFrom(src => src.TipoDocumento))
           .ForMember(b => b.PersonType, dto => dto.MapFrom(src => src.TipoPersona));

            CreateMap<Subpoena, Comparendo>()
            .ForMember(b => b.CodigoBarras, dto => dto.MapFrom(src => src.BarCode))
            .ForMember(b => b.Estado, dto => dto.MapFrom(src => src.State))
            .ForMember(b => b.FechaImposicion, dto => dto.MapFrom(src => src.DateImposition))
            .ForMember(b => b.Foto, dto => dto.MapFrom(src => src.Photo1))
            .ForMember(b => b.NumeroComparendo, dto => dto.MapFrom(src => src.Number))
            .ForMember(b => b.Valor, dto => dto.MapFrom(src => src.Value));


            CreateMap<Comparendo, Subpoena>()
           .ForMember(b => b.BarCode, dto => dto.MapFrom(src => src.CodigoBarras))
           .ForMember(b => b.State, dto => dto.MapFrom(src => src.Estado))
           .ForMember(b => b.DateImposition, dto => dto.MapFrom(src => src.FechaImposicion))
           .ForMember(b => b.Photo1, dto => dto.MapFrom(src => src.Foto))
           .ForMember(b => b.Number, dto => dto.MapFrom(src => src.NumeroComparendo))
           .ForMember(b => b.Value, dto => dto.MapFrom(src => src.Valor));


            CreateMap<PagoComparendo, Subpoena>()
           .ForMember(b => b.State, dto => dto.MapFrom(src => src.Estado))
           .ForMember(b => b.Number, dto => dto.MapFrom(src => src.Numerocomparendo))
           .ForMember(b => b.Value, dto => dto.MapFrom(src => src.Valor));

            CreateMap<PagoComparendo, PaymentSubpoena>()
             .ForMember(b => b.State, dto => dto.MapFrom(src => src.Estado))
              .ForMember(b => b.Description, dto => dto.MapFrom(src => src.Descripcion))
              .ForMember(b => b.DatePayment, dto => dto.MapFrom(src => src.FechaPago))
              .ForMember(b => b.Cus, dto => dto.MapFrom(src => src.Cus))
             .ForMember(b => b.Value, dto => dto.MapFrom(src => src.Valor));

            CreateMap<PaymentSubpoena, PagoComparendo>()
           .ForMember(b => b.Estado, dto => dto.MapFrom(src => src.State))
              .ForMember(b => b.Descripcion, dto => dto.MapFrom(src => src.Description))
              .ForMember(b => b.FechaPago, dto => dto.MapFrom(src => src.DatePayment))
              .ForMember(b => b.Cus, dto => dto.MapFrom(src => src.Cus))
           .ForMember(b => b.Valor, dto => dto.MapFrom(src => src.Value));


            CreateMap<Subpoena, PagoComparendo>()
           .ForMember(b => b.Estado, dto => dto.MapFrom(src => src.State))
           .ForMember(b => b.Numerocomparendo, dto => dto.MapFrom(src => src.Number))
           .ForMember(b => b.Valor, dto => dto.MapFrom(src => src.Value));

            CreateMap<Subpoena, Infraccion>()
            .ForMember(b => b.DireccionInfraccion, dto => dto.MapFrom(src => src.Address))
            .ForMember(b => b.FechayhoraInfraccion, dto => dto.MapFrom(src => src.DateImposition))
            .ForMember(b => b.Observaciones, dto => dto.MapFrom(src => src.Observation));

            CreateMap<Vehicle, Vehiculo>()
            .ForMember(b => b.Placa, dto => dto.MapFrom(src => src.LicensePlate));

            CreateMap<Agent, AgenteDetector>()
            .ForMember(b => b.NombreAgenteDetector, dto => dto.MapFrom(src => src.Name))
            .ForMember(b => b.PlacaAgenteDetector, dto => dto.MapFrom(src => src.Badge));

            CreateMap<Agent, AgenteRegistro>()
            .ForMember(b => b.NombreAgenteDetector, dto => dto.MapFrom(src => src.Name))
            .ForMember(b => b.PlacaAgenteDetector, dto => dto.MapFrom(src => src.Badge));
        }

        #endregion
    }
}
