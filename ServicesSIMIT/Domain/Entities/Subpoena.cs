using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesSIMIT.Domain.Entities
{
    /// <summary>
    /// Subpoena.
    /// </summary>
    public class Subpoena
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the date imposition.
        /// </summary>
        /// <value>The date imposition.</value>
        public DateTime DateImposition { get; set; }

        /// <summary>
        /// Gets or sets the bar code.
        /// </summary>
        /// <value>The bar code.</value>
        public string BarCode { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public int State { get; set; }

        /// <summary>
        /// Gets or sets the photo1.
        /// </summary>
        /// <value>The photo1.</value>
        public string Photo1 { get; set; }

        /// <summary>
        /// Gets or sets the photo2.
        /// </summary>
        /// <value>The photo2.</value>
        public string Photo2 { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the date infringement.
        /// </summary>
        /// <value>The date infringement.</value>
        public DateTime DateInfringement { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the observation.
        /// </summary>
        /// <value>The observation.</value>
        public string Observation { get; set; }

        /// <summary>
        /// Gets or sets the identifier vehicle.
        /// </summary>
        /// <value>The identifier vehicle.</value>
        public Guid IdVehicle { get; set; }

        /// <summary>
        /// Gets or sets the identifier person.
        /// </summary>
        /// <value>The identifier person.</value>
        public Guid IdPerson { get; set; }

        /// <summary>
        /// Gets or sets the identifier agent detector.
        /// </summary>
        /// <value>The identifier agent detector.</value>
        public Guid IdAgentDetector { get; set; }

        /// <summary>
        /// Gets or sets the identifier agent register.
        /// </summary>
        /// <value>The identifier agent register.</value>
        public Guid IdAgentRegister { get; set; }

        /// <summary>
        /// Gets or sets the identifier infringement.
        /// </summary>
        /// <value>The identifier infringement.</value>
        public Guid IdInfringement { get; set; }
    }
}
