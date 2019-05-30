using Microsoft.EntityFrameworkCore;
using ServicesSIMIT.Domain.Entities;
using UtilitiesLibrary;
using UtilitiesLibrary.Models;

namespace ServicesSIMIT.DataAccess
{
    /// <summary>
    /// SimitContext context.
    /// </summary>
    public partial class SimitContext : DbContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ServicesSIMIT.DataAccess.SimitContext"/> class.
        /// </summary>
        /// <param name="dbSettings">Db settings.</param>
        public SimitContext(DbSettings dbSettings) : base(dbSettings) { }

        /// <summary>
        /// Ons the model creating.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.DocumentNumber);
                entity.Property(e => e.DocumentType);
                entity.Property(e => e.Email);
                entity.Property(e => e.Name);
                entity.Property(e => e.PersonType);
            });


            modelBuilder.Entity<Subpoena>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Address);
                entity.Property(e => e.BarCode);
                entity.Property(e => e.DateImposition);
                entity.Property(e => e.DateInfringement);
                entity.Property(e => e.IdAgentDetector);
                entity.Property(e => e.IdAgentRegister);
                entity.Property(e => e.IdPerson);
                entity.Property(e => e.IdVehicle);
                entity.Property(e => e.Number);
                entity.Property(e => e.Observation);
                entity.Property(e => e.Photo1);
                entity.Property(e => e.Photo2);
                entity.Property(e => e.State);
                entity.Property(e => e.Value);
            });


            modelBuilder.Entity<Infringement>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Code);
                entity.Property(e => e.Description);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Brand);
                entity.Property(e => e.LicensePlate);
                entity.Property(e => e.Line);
                entity.Property(e => e.Model);
            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Badge);
                entity.Property(e => e.Name);
                entity.Property(e => e.DocumentNumber);
            });

            modelBuilder.Entity<PaymentSubpoena>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.IdBank);
                entity.Property(e => e.IdPerson);
                entity.Property(e => e.IdSubpoena);
                entity.Property(e => e.State);
                entity.Property(e => e.Value);
            });
        }
    }
}

